using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LevelUpEsapi.DoseMetrics.esapi.Models;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class StructureViewModel : ViewModelBase
    {
        private readonly ITpsService _tps;

        public StructureViewModel(ITpsService tps, Structure structure)
        {
            _tps = tps;
            Structure = structure;
        }

        public Structure Structure { get; }

        public bool IsChecked
        {
            get => _isChecked;
            set => Set(nameof(IsChecked), ref _isChecked, value, broadcast: true);
        }
        private bool _isChecked;

        public ObservableCollection<MetricResultViewModel> Metrics { get; } =
            new ObservableCollection<MetricResultViewModel>();

        public ICommand AddMetricCommand => new RelayCommand(() =>
        {
            var newMetricVm = new NewMetricViewModel();
            var newMetricDialog = new NewMetricDialog {DataContext = newMetricVm};
            if (newMetricDialog.ShowDialog() == true)
            {
                var metricText = newMetricVm.Metric;
                if (DvhMetric.TryParse(metricText, out DvhMetric dvhMetric))
                {
                    DvhData dvhData = _tps.CreateDvh(Structure.Id);
                    double result = dvhMetric.Calculate(dvhData);
                    Metrics.Add(new MetricResultViewModel
                    {
                        Metric = dvhMetric,
                        Result = result
                    });
                }
            }
        });
    }
}