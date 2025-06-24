using System.Windows;
using VMS.TPS;
using VMS.TPS.Common.Model.API;
using Application = System.Windows.Application;

namespace LevelUpEsapi.FakeEclipse
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            // Create a fake ScriptContext with hard-coded data.
            ScriptContext scriptContext = FakeScriptContext.Create();

            // Create and execute the Script object that Eclipse would also execute,
            // but because we are using a fake ScriptContext, we can run it locally.
            var script = new Script();
            script.Execute(scriptContext);

            // Needed because there's no main window, which would normally
            // shutdown the app when the window is closed.
            Shutdown();
        }
    }
}
