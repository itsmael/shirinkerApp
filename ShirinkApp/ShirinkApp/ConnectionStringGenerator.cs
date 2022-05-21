using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirinkApp
{
    public class ConnectionStringGenerator
    {
        public string ConStringGenerator()
        {
            string pathConection = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"connection.txt");
            string conString = System.IO.File.ReadAllText(path: pathConection);
            return conString;
        }
    }
}
