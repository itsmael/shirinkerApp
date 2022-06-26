using System;
using System.IO;

namespace ShirinkApp
{
    public static class ConnectionStringGenerator
    {
        public static string ConStringGenerator()
        {
            string pathConection = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"connection.txt");
            string conString = File.ReadAllText(path: pathConection);
            return conString;
        }
    }
}
