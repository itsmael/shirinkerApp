using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirinkApp
{
    public class Connection
    {
        SqlConnection con = new SqlConnection();
        
        //Constructor
        public Connection (string conString)
        {
            con.ConnectionString = conString;
            Console.WriteLine(conString);
        }

        //Method Connect
        public SqlConnection connect()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        //Method Desconect
        public void disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
