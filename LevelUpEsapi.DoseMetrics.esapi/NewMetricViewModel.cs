using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LevelUpEsapi.DoseMetrics.esapi.Models;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    internal class NewMetricViewModel : ViewModelBase, IDataErrorInfo
    {
        public string Metric
        {
            get => _metric;
            set => Set(nameof(Metric), ref _metric, value);
        }
        private string _metric;

        public ICommand AddNewMetricCommand => new RelayCommand(() =>
        {
            // Do nothing because the action is handled by Click in the view,
            // but use the canExecute callback to enable/disable the button
        }, () => this[nameof(Metric)] == null);

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(Metric): return DvhMetric.TryParse(Metric, out _) ? null : "Invalid DVH metric";
                    default: return null;
                }
            }
        }

        public string Error => null;
    }
}