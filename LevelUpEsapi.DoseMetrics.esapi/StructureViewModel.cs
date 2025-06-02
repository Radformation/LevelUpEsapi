using GalaSoft.MvvmLight;
using VMS.TPS.Common.Model.API;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class StructureViewModel : ViewModelBase
    {
        public StructureViewModel(Structure structure)
        {
            Structure = structure;
        }

        public Structure Structure { get; }

        public bool IsChecked
        {
            get => _isChecked;
            set => Set(nameof(IsChecked), ref _isChecked, value, broadcast: true);
        }
        private bool _isChecked;
    }
}