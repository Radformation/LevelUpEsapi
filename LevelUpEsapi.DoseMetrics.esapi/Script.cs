using LevelUpEsapi.DoseMetrics.esapi;
using VMS.TPS.Common.Model.API;

// ReSharper disable once CheckNamespace
namespace VMS.TPS
{
    public class Script
    {
        public void Execute(ScriptContext context)
        {
            var tps = new EsapiService(context);
            var viewModel = new MainViewModel(tps);
            var window = new MainWindow(viewModel);
            window.ShowDialog();
        }
    }
}
