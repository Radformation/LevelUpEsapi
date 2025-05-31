using System.Windows;
using VMS.TPS.Common.Model.API;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class Script
    {
        public void Execute(ScriptContext context)
        {
            MessageBox.Show(context.Patient.Id);
        }
    }
}
