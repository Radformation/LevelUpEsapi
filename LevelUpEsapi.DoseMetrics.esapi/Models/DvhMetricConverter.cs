using System;

namespace LevelUpEsapi.DoseMetrics.esapi.Models
{
    public static class DvhMetricConverter
    {
        public static string ToString(DvhMetric metric)
        {
            switch (metric.Kind)
            {
                case DvhMetricKind.Dose:     return DoseMetricToString(metric);
                case DvhMetricKind.Volume:   return VolumeMetricToString(metric);
                case DvhMetricKind.MeanDose: return MeanDoseMetricToString(metric);
                case DvhMetricKind.MinDose:  return MinDoseMetricToString(metric);
                case DvhMetricKind.MaxDose:  return MaxDoseMetricToString(metric);

                default: throw new Exception($"Unknown metric kind {metric.Kind}");
            }
        }

        private static string DoseMetricToString(DvhMetric metric)
        {
            string inputVolume = $"{metric.Value}";
            string inputVolumeUnit = VolumeUnitToString(metric.InputVolumeUnit.Value);
            string outputDoseUnit = DoseUnitToString(metric.OutputDoseUnit.Value);
            return $"D{inputVolume}{inputVolumeUnit}[{outputDoseUnit}]";
        }

        private static string VolumeMetricToString(DvhMetric metric)
        {
            string inputDose = $"{metric.Value}";
            string inputDoseUnitStr = DoseUnitToString(metric.InputDoseUnit.Value);
            string outputVolumeUnitStr = VolumeUnitToString(metric.OutputVolumeUnit.Value);
            return $"V{inputDose}{inputDoseUnitStr}[{outputVolumeUnitStr}]";
        }

        private static string MeanDoseMetricToString(DvhMetric metric)
        {
            return $"MeanDose[{DoseUnitToString(metric.OutputDoseUnit.Value)}]";
        }

        private static string MinDoseMetricToString(DvhMetric metric)
        {
            return $"MinDose[{DoseUnitToString(metric.OutputDoseUnit.Value)}]";
        }

        private static string MaxDoseMetricToString(DvhMetric metric)
        {
            return $"MaxDose[{DoseUnitToString(metric.OutputDoseUnit.Value)}]";
        }

        private static string DoseUnitToString(DoseUnit unit)
        {
            switch (unit)
            {
                case DoseUnit.CGy:     return "cGy";
                case DoseUnit.Gy:      return "Gy";
                case DoseUnit.Percent: return "%";

                default: throw new Exception($"Unknown dose unit {unit}");
            }
        }

        private static string VolumeUnitToString(VolumeUnit unit)
        {
            switch (unit)
            {
                case VolumeUnit.Cc:      return "cc";
                case VolumeUnit.Percent: return "%";

                default: throw new Exception($"Unknown volume unit {unit}");
            }
        }
    }
}