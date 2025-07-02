using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using VMS.TPS.Common.Model.API;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class MainViewModel
    {
        private readonly ScriptContext _context;

        public MainViewModel(ScriptContext context)
        {
            _context = context;

            CheckedStructuresView = new ListCollectionView(Structures);
            CheckedStructuresView.Filter = IsStructureChecked;

            Messenger.Default.Register<PropertyChangedMessage<bool>>(this, PropertyChanged);
        }

        public ObservableCollection<StructureViewModel> Structures { get; } =
            new ObservableCollection<StructureViewModel>();

        public ICollectionView CheckedStructuresView { get; }

        public void Initialize()
        {
            foreach (var structure in _context.StructureSet.Structures)
            {
                var vm = new StructureViewModel(structure, _context.PlanSetup);
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