using System.Windows;
using LevelUpEsapi.DoseMetrics.esapi;
using VMS.TPS.Common.Model.API;
using Application = System.Windows.Application;

namespace LevelUpEsapi.FakeEclipse
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var scriptContext = LoadScriptContext();
            var script = new Script();
            script.Execute(scriptContext);

            // Needed because there's no main window, which would normally
            // shutdown the app when the window is closed.
            Shutdown();
        }

        private ScriptContext LoadScriptContext()
        {
            return new ScriptContext() { Patient = new Patient() { Id = "Test" } };
        }
    }
}
