using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace Bbs
{
    public class DBConn
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["ASPNET"].ConnectionString;
        public SqlConnection dbConn;

        public DBConn()
        {
            dbConn = new SqlConnection(connectionString);
            dbConn.Open();
        }

        public void Close()
        {
            dbConn.Close();
        }

        public SqlConnection GetConnection()
        {
            return dbConn;
        }

        public void ExecuteNonQuery(string queryString)
        {
            SqlCommand cmd = new SqlCommand(queryString, dbConn);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string queryString)
        {
            SqlCommand cmd = new SqlCommand(queryString, dbConn);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string queryString)
        {
            SqlCommand cmd = new SqlCommand(queryString, dbConn);
            return cmd.ExecuteScalar();

        }

    }
}