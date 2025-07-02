using System.Windows.Media;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public interface ITpsService
    {
        Structure[] GetStructures();

        DvhData CreateDvh(string structureId);
    }

    public class Structure
    {
        public string Id { get; set; }
        public double VolumeCc { get; set; }
        public bool IsEmpty { get; set; }
        public Color Color { get; set; }
    }

    public class DvhData
    {
        public DvhPoint[] Points { get; set; }
        public double MeanDoseGy { get; set; }
        public double MaxDoseGy { get; set; }
        public double MinDoseGy { get; set; }
        public double RxDoseGy { get; set; }
        public double VolumeCc { get; set; }
    }

    public struct DvhPoint
    {
        public DvhPoint(double doseGy, double volumeCc)
        {
            DoseGy = doseGy;
            VolumeCc = volumeCc;
        }

        public double DoseGy { get; }
        public double VolumeCc { get; }
    }
}