using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ShirinkApp
{
    public static class Log
    {
        public static void AppendText(string logFile, string message)
        {
            File.AppendAllText(logFile, $"{message}{Environment.NewLine}");
        }
    }
}
