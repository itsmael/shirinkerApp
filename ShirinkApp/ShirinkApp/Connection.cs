using System;
using System.Data;
using System.Data.SqlClient;

namespace ShirinkApp
{
    public static class  Connection
    {
        static  SqlConnection con = new SqlConnection();

        //Method Connect
        public static SqlConnection Connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConnectionStringGenerator.ConStringGenerator();
                con.Open();
            }
            return con;
        }

        public static DataTable GetData<T>(string query, SqlConnection conexao)  where T : IDbDataAdapter, IDisposable, new()
        {
            try
            {
                var dataTable = new DataTable();
                using (conexao)
                {
                    using (var da = new T())
                    {
                        using (da.SelectCommand = conexao.CreateCommand())
                        {
                            da.SelectCommand.CommandText = query;
                            //da.SelectCommand.Connection 
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                                dataTable = ds.Tables[0];
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
