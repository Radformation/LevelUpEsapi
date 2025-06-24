using System.Windows.Media;
using VMS.TPS.Common.Model.API;

namespace LevelUpEsapi.FakeEclipse
{
    public static class FakeScriptContext
    {
        /// <summary>
        /// Creates a fake ScriptContext (from LevelUpEsapi.FakeEsapi project) with hard-coded data.
        /// </summary>
        /// <returns>A ScriptContext object with hard-coded data.</returns>
        public static ScriptContext Create()
        {
            return new ScriptContext
            {
                Patient = new Patient
                {
                    Id = "Test"
                },
                StructureSet = new StructureSet()
                {
                    Structures = new []
                    {
                        new Structure
                        {
                            Id = "PTV",
                            Color = Colors.Red,
                            Volume = 11.87934
                        },
                        new Structure
                        {
                            Id = "Liver",
                            Color = Colors.Blue,
                            IsEmpty = true,
                            Volume = 132.26453
                        }
                    }
                }
            };
        }
    }
}