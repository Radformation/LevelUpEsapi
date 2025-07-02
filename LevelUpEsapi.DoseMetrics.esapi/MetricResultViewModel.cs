using LevelUpEsapi.DoseMetrics.esapi.Models;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class MetricResultViewModel
    {
        public DvhMetric Metric { get; set; }
        public double Result { get; set; }
    }
}