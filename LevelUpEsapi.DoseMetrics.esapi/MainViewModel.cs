using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class MainViewModel
    {
        private readonly ITpsService _tps;

        public MainViewModel(ITpsService tps)
        {
            _tps = tps;

            CheckedStructuresView = new ListCollectionView(Structures);
            CheckedStructuresView.Filter = IsStructureChecked;

            Messenger.Default.Register<PropertyChangedMessage<bool>>(this, PropertyChanged);
        }

        public ObservableCollection<StructureViewModel> Structures { get; } =
            new ObservableCollection<StructureViewModel>();

        public ICollectionView CheckedStructuresView { get; }

        public void Initialize()
        {
            foreach (Structure structure in _tps.GetStructures())
            {
                var vm = new StructureViewModel(_tps, structure);
                Structures.Add(vm);
            }
        }

        private static bool IsStructureChecked(object obj)
        {
            if (obj is StructureViewModel structureVm)
                return structureVm.IsChecked;
            return false;
        }

        private void PropertyChanged(PropertyChangedMessage<bool> msg)
        {
            if (msg.Sender is StructureViewModel)
            {
                if (msg.PropertyName == nameof(StructureViewModel.IsChecked))
                    CheckedStructuresView.Refresh();
            }
        }
    }
}