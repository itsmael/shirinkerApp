using System;
using System.IO;

namespace ShirinkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //instancia connection passando a string de conexão
                var newConnection = Connection.Connect();

                //teste de select 
                var query = "select l.name as logName, d.name as dbName from sys.master_files l inner join sys.databases d on d.database_id = l.database_id where l.type = 1 and d.name not in ('master', 'msdb', 'model', 'tempdb')";

                var data = Services.GetDatabases(query, newConnection);
                
                //arquivo de log 
                var logFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\Log_{DateTime.Now:ddMMyyyy}.log";

                foreach (DbInfo item in data)
                {
                    try
                    {
                        var connection = Connection.Connect();
                        Log.AppendText(logFile, $"##### Process Start on: {item.DbName} #####");
                        Services.ExecuteShirink(item, connection);
                        Log.AppendText(logFile, $"##### Shirink executed on: {item.LogName} #####");
                    }
                    catch (Exception ex)
                    {
                        Log.AppendText(logFile, $"##### Process Error: {ex.Message} #####");
                        Log.AppendText(logFile, "");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
