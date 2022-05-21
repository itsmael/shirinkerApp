using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirinkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //instacia a classe que gera a string de conexãop
            ConnectionStringGenerator newConnectionString = new ConnectionStringGenerator();
            //metodo que retorna a string de conexão
            newConnectionString.ConStringGenerator();
            //instancia connection passando a string de conexão
            Connection newConnection = new Connection(newConnectionString.ConStringGenerator());


            //teste de select 
            SqlCommand command = new SqlCommand("select l.name, d.name from sys.master_files l inner join sys.databases d on d.database_id = l.database_id where l.type = 1 ", newConnection.connect());
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                //Console.WriteLine(reader.GetString(0));
                //Console.WriteLine(reader.GetString(1));
                //Console.WriteLine(reader.GetValue(0));
                list.Add(reader.GetString(0));
            }
            Console.WriteLine(string.Join("\t", list));

            Console.ReadLine();
        }
    }
}
