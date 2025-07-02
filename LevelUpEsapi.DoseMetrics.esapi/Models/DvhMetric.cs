using System;
using VMS.TPS.Common.Model.API;

namespace LevelUpEsapi.DoseMetrics.esapi.Models
{
    public struct DvhMetric
    {
        public DvhMetricKind Kind { get; set; }
        public double Value { get; set; }
        public VolumeUnit? InputVolumeUnit { get; set; }
        public DoseUnit? InputDoseUnit { get; set; }
        public DoseUnit? OutputDoseUnit { get; set; }
        public VolumeUnit? OutputVolumeUnit { get; set; }

        public double Calculate(DVHData dvhData, double normDoseGy)
        {
            return DvhMetricCalculator.Calculate(this, dvhData, normDoseGy);
        }

        public static bool TryParse(string str, out DvhMetric metric)
        {
            try
            {
                metric = Parse(str);
                return true;
            }
            catch (Exception)
            {
                metric = default(DvhMetric);
                return false;
            }
        }

        public override string ToString()
        {
            return DvhMetricConverter.ToString(this);
        }

        private static DvhMetric Parse(string str)
        {
            DvhMetricKind kind = ParseKind(str);

            switch (kind)
            {
                case DvhMetricKind.Dose:     return ParseDoseMetric(str);
                case DvhMetricKind.Volume:   return ParseVolumeMetric(str);
                case DvhMetricKind.MeanDose: return ParseMeanDoseMetric(str);
                case DvhMetricKind.MinDose:  return ParseMinDoseMetric(str);
                case DvhMetricKind.MaxDose:  return ParseMaxDoseMetric(str);

                default: throw new Exception($"Unknown kind {kind}");
            }
        }

        private static DvhMetricKind ParseKind(string str)
        {
            if (str.StartsWith("MeanDose")) return DvhMetricKind.MeanDose;
            if (str.StartsWith("MinDose"))  return DvhMetricKind.MinDose;
            if (str.StartsWith("MaxDose"))  return DvhMetricKind.MaxDose;
            if (str.StartsWith("D"))        return DvhMetricKind.Dose;
            if (str.StartsWith("V"))        return DvhMetricKind.Volume;

            throw new Exception($"Unknown DVH metric in {str}");
        }

        private static DvhMetric ParseDoseMetric(string str)
        {
            return new DvhMetric
            {
                Kind = DvhMetricKind.Dose,
                Value = ParseValue(str),
                InputVolumeUnit = ParseInputVolumeUnit(str),
                OutputDoseUnit = ParseOutputDoseUnit(str)
            };
        }

        private static DvhMetric ParseVolumeMetric(string str)
        {
            return new DvhMetric
            {
                Kind = DvhMetricKind.Volume,
                Value = ParseValue(str),
                InputDoseUnit = ParseInputDoseUnit(str),
                OutputVolumeUnit = ParseOutputVolumeUnit(str)
            };
        }

        private static DvhMetric ParseMeanDoseMetric(string str)
        {
            return new DvhMetric
            {
                Kind = DvhMetricKind.MeanDose,
                OutputDoseUnit = ParseOutputDoseUnit(str),
            };
        }

        private static DvhMetric ParseMinDoseMetric(string str)
        {
            return new DvhMetric
            {
                Kind = DvhMetricKind.MinDose,
                OutputDoseUnit = ParseOutputDoseUnit(str),
            };
        }

        private static DvhMetric ParseMaxDoseMetric(string str)
        {
            return new DvhMetric
            {
                Kind = DvhMetricKind.MaxDose,
                OutputDoseUnit = ParseOutputDoseUnit(str),
            };
        }

        private static double ParseValue(string str)
        {
            int endIndex = 1;  // must start after "D" or "V"

            // Start searching after the first digit
            for (int index = 2; index < str.Length; index++)
            {
                // Only digits and period allowed (no negative or E)
                if (char.IsDigit(str[index]) || str[index] == '.')
                    endIndex++;
                else
                    break;
            }

            // 012345789
            // ---------
            // D0.01cc[Gy]
            //  ^  ^
            //  |  end index = 4
            //  start index = 1
            //
            // Substring length is always equal to end index
            string numberStr = str.Substring(1, endIndex);
            return double.Parse(numberStr);
        }

        private static DoseUnit ParseInputDoseUnit(string str)
        {
            // To make parsing easier, remove unit in [ ]
            str = RemoveOutputUnit(str);

            // Test for cGy must appear first so matching works properly
            // (since testing for Gy would be true if unit is cGy)
            if (str.ToLower().Contains("cgy")) return DoseUnit.CGy;
            if (str.ToLower().Contains("gy"))  return DoseUnit.Gy;
            if (str.ToLower().Contains("%"))   return DoseUnit.Percent;

            throw new Exception($"Unknown input dose unit in {str}");
        }

        private static VolumeUnit ParseInputVolumeUnit(string str)
        {
            // To make parsing easier, remove unit in [ ]
            str = RemoveOutputUnit(str);

            if (str.ToLower().Contains("cc")) return VolumeUnit.Cc;
            if (str.ToLower().Contains("%"))  return VolumeUnit.Percent;

            throw new Exception($"Unknown input dose unit in {str}");
        }

        private static DoseUnit ParseOutputDoseUnit(string str)
        {
            string unitStr = ExtractOutputUnit(str);
            return ParseDoseUnit(unitStr);
        }

        private static VolumeUnit ParseOutputVolumeUnit(string str)
        {
            string unitStr = ExtractOutputUnit(str);
            return ParseVolumeUnit(unitStr);
        }

        private static string ExtractOutputUnit(string str)
        {
            // Output unit is inside [ ]
            int bracketStart = str.IndexOf('[');
            int bracketEnd = str.IndexOf(']');

            return str.Substring(bracketStart + 1, bracketEnd - bracketStart - 1).Trim();
        }

        private static DoseUnit ParseDoseUnit(string str)
        {
            switch (str.ToLower())
            {
                case "gy":  return DoseUnit.Gy;
                case "cgy": return DoseUnit.CGy;
                case "%":   return DoseUnit.Percent;
            }

            throw new Exception($"Unknown dose unit {str}");
        }

        private static VolumeUnit ParseVolumeUnit(string str)
        {
            switch (str.ToLower())
            {
                case "cc": return VolumeUnit.Cc;
                case "%":  return VolumeUnit.Percent;
            }

            throw new Exception($"Unknown volume unit {str}");
        }

        private static string RemoveOutputUnit(string str)
        {
            // Output unit is inside [ ]
            int bracketStart = str.IndexOf('[');
            int bracketEnd = str.IndexOf(']');

            // 01234578
            // --------
            // D95%[Gy]
            //     ^  ^
            //     |  end index = 8
            //     start index = 4
            //
            // Count is always equal to end index - start index
            return str.Remove(bracketStart, bracketEnd - bracketStart);
        }
    }
}