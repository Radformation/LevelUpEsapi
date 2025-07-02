using System.IO;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public static class Log
    {
        public static void Debug(string text)
        {
            File.AppendAllText(@"C:\Temp\LevelUpEsapi.log", text + "\n");
        }
    }
}