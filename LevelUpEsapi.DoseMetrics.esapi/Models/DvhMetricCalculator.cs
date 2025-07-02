using System;
using System.Linq;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace LevelUpEsapi.DoseMetrics.esapi.Models
{
    internal static class DvhMetricCalculator
    {
        public static double Calculate(DvhMetric dvhMetric, DvhData dvhData)
        {
            switch (dvhMetric.Kind)
            {
                case DvhMetricKind.Dose:     return CalculateDoseMetric(dvhMetric, dvhData);
                case DvhMetricKind.Volume:   return CalculateVolumeMetric(dvhMetric, dvhData);
                case DvhMetricKind.MeanDose: return CalculateMeanDose(dvhMetric, dvhData);
                case DvhMetricKind.MinDose:  return CalculateMinDose(dvhMetric, dvhData);
                case DvhMetricKind.MaxDose:  return CalculateMaxDose(dvhMetric, dvhData);

                default: throw new ArgumentOutOfRangeException();
            }
        }

        private static double CalculateDoseMetric(DvhMetric metric, DvhData dvhData)
        {
            // Convert the metric input volume to cc, so that we can compare
            // against the DVH data (which we know its volume is in cc)
            double inputVolumeCc = ConvertInputVolumeCc(metric, dvhData);
            Log.Debug($"inputVolumeCc = {inputVolumeCc}");

            // Start from the right of the DVH so we find the highest dose
            foreach (DvhPoint dvhPoint in dvhData.Points.Reverse())
            {
                if (dvhPoint.VolumeCc >= inputVolumeCc)
                {
                    Log.Debug("Found point.");
                    double doseGy = dvhPoint.DoseGy;
                    Log.Debug($"dose = {doseGy}");
                    return ConvertDose(doseGy, DoseUnit.Gy, metric.OutputDoseUnit.Value, dvhData.RxDoseGy);
                }
            }

            Log.Debug("Not found, returning 0.0");
            return 0.0;
        }

        private static double CalculateVolumeMetric(DvhMetric metric, DvhData dvhData)
        {
            // Convert the metric input dose to Gy, so that we can compare
            // against the DVH data (which we know is in Gy)
            double inputDoseGy = ConvertInputDoseToGy(metric, dvhData);

            // Start from the right of the DVH so we find the highest volume
            foreach (DvhPoint dvhPoint in dvhData.Points.Reverse())
            {
                if (dvhPoint.DoseGy <= inputDoseGy)
                {
                    double volumeCc = dvhPoint.VolumeCc;
                    return ConvertVolume(volumeCc, VolumeUnit.Cc, metric.OutputVolumeUnit.Value, dvhData.VolumeCc);
                }
            }

            return 0.0;
        }

        private static double ConvertInputVolumeCc(DvhMetric metric, DvhData dvhData)
        {
            // Get the input volume and unit from the metric
            double inputVolume = metric.Value;
            VolumeUnit inputVolumeUnit = metric.InputVolumeUnit.Value;

            // Convert the volume to cc
            return ConvertVolume(inputVolume, inputVolumeUnit, VolumeUnit.Cc, dvhData.VolumeCc);
        }

        private static double ConvertInputDoseToGy(DvhMetric metric, DvhData dvhData)
        {
            // Get the input dose and unit from the metric
            double inputDose = metric.Value;
            DoseUnit inputDoseUnit = metric.InputDoseUnit.Value;

            // Get the TPS dose unit and convert the input dose
            return ConvertDose(inputDose, inputDoseUnit, DoseUnit.Gy, dvhData.RxDoseGy);
        }

        private static double CalculateMeanDose(DvhMetric metric, DvhData dvhData)
        {
            return ConvertDose(dvhData.MeanDoseGy, DoseUnit.Gy, metric.OutputDoseUnit.Value, dvhData.RxDoseGy);
        }

        private static double CalculateMinDose(DvhMetric metric, DvhData dvhData)
        {
            return ConvertDose(dvhData.MinDoseGy, DoseUnit.Gy, metric.OutputDoseUnit.Value, dvhData.RxDoseGy);
        }

        private static double CalculateMaxDose(DvhMetric metric, DvhData dvhData)
        {
            return ConvertDose(dvhData.MaxDoseGy, DoseUnit.Gy, metric.OutputDoseUnit.Value, dvhData.RxDoseGy);
        }

        private static double ConvertDose(double dose, DoseUnit fromUnit, DoseUnit toUnit, double normDoseGy)
        {
            double doseGy = ToGy(dose, fromUnit, normDoseGy);
            Log.Debug($"doseGy = {doseGy}");
            double result = FromGyTo(toUnit, doseGy, normDoseGy);
            Log.Debug($"dose [{toUnit}] = {result}");
            return result;
        }

        private static double ConvertVolume(double volume, VolumeUnit fromUnit, VolumeUnit toUnit, double normVolumeCc)
        {
            double volumeCc = ToCc(volume, fromUnit, normVolumeCc);
            return FromCcTo(toUnit, volumeCc, normVolumeCc);
        }

        private static double ToGy(double dose, DoseUnit unit, double normDoseGy)
        {
            switch (unit)
            {
                case DoseUnit.Gy:      return dose;
                case DoseUnit.CGy:     return dose / 100.0;
                case DoseUnit.Percent: return dose * normDoseGy / 100.0;

                default: throw new Exception($"Unknown dose unit {unit}");
            }
        }

        private static double FromGyTo(DoseUnit unit, double doseGy, double normDoseGy)
        {
            Log.Debug($"FromGyTo: unit = {unit}, doseGy = {doseGy}, normDoseGy = {normDoseGy}");
            switch (unit)
            {
                case DoseUnit.CGy:     return doseGy * 100.0;
                case DoseUnit.Gy:      return doseGy;
                case DoseUnit.Percent: return doseGy / normDoseGy * 100.0;

                default: throw new Exception($"Unknown dose unit {unit}");
            }
        }

        private static double ToCc(double volume, VolumeUnit unit, double normVolumeCc)
        {
            switch (unit)
            {
                case VolumeUnit.Cc:      return volume;
                case VolumeUnit.Percent: return volume * normVolumeCc / 100.0;

                default: throw new Exception($"Unknown volume unit {unit}");
            }
        }

        private static double FromCcTo(VolumeUnit unit, double volumeCc, double normVolumeCc)
        {
            switch (unit)
            {
                case VolumeUnit.Cc:      return volumeCc;
                case VolumeUnit.Percent: return volumeCc / normVolumeCc * 100.0;

                default: throw new Exception($"Unknown dose unit {unit}");
            }
        }

        private static DoseUnit GetTpsDoseUnit(DVHData dvhData)
        {
            DoseValue.DoseUnit tpsDoseUnit = dvhData.MeanDose.Unit;

            switch (tpsDoseUnit)
            {
                case DoseValue.DoseUnit.Gy:      return DoseUnit.Gy;
                case DoseValue.DoseUnit.cGy:     return DoseUnit.CGy;
                case DoseValue.DoseUnit.Percent: return DoseUnit.Percent;

                // Unknown unit should also throw an exception
                case DoseValue.DoseUnit.Unknown:
                default: throw new Exception($"Unknown TPS dose unit {tpsDoseUnit}");
            }
        }

        private static VolumeUnit GetTpsVolumeUnit(DVHData dvhData)
        {
            // Assumes there's at least one entry in CurveData
            string tpsVolumeUnit = dvhData.CurveData[0].VolumeUnit;

            switch (tpsVolumeUnit)
            {
                case "cm³": return VolumeUnit.Cc;
                case "%":   return VolumeUnit.Percent;

                default: throw new Exception($"Unknown TPS volume unit {tpsVolumeUnit}");
            }
        }
    }
}