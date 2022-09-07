using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Web.Security;
using System.Net;
using System.Net.Sockets;


public class DBConn
    {

        public string GetConnectionString(string name = "BoardDB")
        {
            if (ConfigurationManager.ConnectionStrings[name] == null) return string.Empty;
            else return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }


        public DataTable GetData(string selectString)
        {
            string strConn = GetConnectionString();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(selectString, conn);

                try { adapter.Fill(dt); }
                catch { dt = null; }
           
            }
            return dt;
        }

        public DataRow GetRow(string selectString)
        {
            DataRow row = null;
            DataTable dt = GetData(selectString);

            if(dt !=null)
                if (dt.Rows.Count > 0)
                    row = dt.Rows[0];

        return row;

        }


        public string GetIP()
        {
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;

        }


}
