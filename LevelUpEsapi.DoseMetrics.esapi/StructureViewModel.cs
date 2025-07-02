using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LevelUpEsapi.DoseMetrics.esapi.Models;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class StructureViewModel : ViewModelBase
    {
        private readonly PlanSetup _planSetup;

        public StructureViewModel(Structure structure, PlanSetup planningItem)
        {
            _planSetup = planningItem;
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
                    DVHData dvhData = _planSetup.GetDVHCumulativeData(
                        Structure, DoseValuePresentation.Absolute, VolumePresentation.AbsoluteCm3, 0.01);
                    double rxDoseGy = ConvertToGy(_planSetup.TotalPrescribedDose);
                    double result = dvhMetric.Calculate(dvhData, rxDoseGy);
                    Metrics.Add(new MetricResultViewModel
                    {
                        Metric = dvhMetric,
                        Result = result
                    });
                }
            }
        });

        private static double ConvertToGy(DoseValue dose)
        {
            switch (dose.Unit)
            {
                case DoseValue.DoseUnit.Gy: return dose.Dose;
                case DoseValue.DoseUnit.cGy: return dose.Dose / 100.0;

                // We know dose must be absolute because we asked for it in DVH method
                case DoseValue.DoseUnit.Percent:
                case DoseValue.DoseUnit.Unknown:
                default: throw new Exception($"Unexpected dose unit {dose.Unit}");
            }
        }
    }
}