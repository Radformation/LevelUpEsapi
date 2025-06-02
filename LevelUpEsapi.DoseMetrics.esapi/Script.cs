using LevelUpEsapi.DoseMetrics.esapi;
using VMS.TPS.Common.Model.API;

// ReSharper disable once CheckNamespace
namespace VMS.TPS
{
    public class Script
    {
        public void Execute(ScriptContext context)
        {
            var viewModel = new MainViewModel(context);
            var window = new MainWindow(viewModel);
            window.ShowDialog();
        }
    }
}
