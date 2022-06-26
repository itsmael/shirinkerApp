using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShirinkApp
{
    internal static class Services
    {
        public static List<DbInfo> GetDatabases(string query, SqlConnection connection)
        {
            var list = new List<DbInfo>();
            var data = Connection.GetData<SqlDataAdapter>(query, connection);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new DbInfo
                    {
                        DbName = row["dbName"].ToString(),
                        LogName = row["logName"].ToString(),
                    });
                }
            }
            return list;
        }

        public static bool DbExecuteCommand(string query, SqlConnection connection)
        {
            bool result = false;
            using (connection)
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        int resultQuery = cmd.ExecuteNonQuery();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return result;
        }
        public static bool ExecuteShirink(DbInfo dataInfo, SqlConnection connection)
        {
            try
            {
                var query = $"use {dataInfo.DbName}  DBCC SHRINKFILE({dataInfo.LogName},1)";
                DbExecuteCommand(query, connection);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
