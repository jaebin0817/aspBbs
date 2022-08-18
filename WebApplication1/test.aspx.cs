using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace WebApplication1
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public override void DataBind()
        {
            //DataSet ds = GetData();
            DataTable dt = GetData2();
            DataRow row = dt.Rows[0];

            Response.Write(row["p_subject"].ToString());

        }

        

        protected void GetIP_Click(object sender, EventArgs e)
        {

            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            Response.Write(localIP);
            hf.Value = "히든필드";

        }



            protected void CatInsert_Click(object sender, EventArgs e)
        {
            string strConn = GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string insertString = "INSERT INTO bbs_cat(c_name)";
                insertString += "VALUES('카테고리')";

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = insertString;
                cmd.ExecuteNonQuery();
            }
        }


        private DataSet GetData()
        {
            string strConn = "Data Source=(local);Initial Catalog=bbs;Persist Security Info=True;User ID=sa;Password=1234567890";
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            string sql = "SELECT * FROM bbs_post ORDER BY p_no";

            // SqlDataAdapter 초기화
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            // Fill 메서드 실행하여 결과 DataSet을 리턴받음
            adapter.Fill(ds);

            conn.Close();
            return ds;

            //using (SqlConnection conn = new SqlConnection(strConn))
            //{
            //    conn.Open();

            //    string sql = "SELECT * FROM bbs_post ORDER BY p_no";

            //    // SqlDataAdapter 초기화
            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            //    // Fill 메서드 실행하여 결과 DataSet을 리턴받음
            //    adapter.Fill(dt);
            //}    

            //return dt;
        }
        private DataTable GetData2()
        {
            string strConn = GetConnectionString();// "Data Source=(local);Initial Catalog=bbs;Persist Security Info=True;User ID=sa;Password=1234567890";
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sql = "SELECT * FROM bbs_post ORDER BY p_no";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }

            return dt;
        }

        public string GetConnectionString(string name = "BoardDB")
        {
            if (ConfigurationManager.ConnectionStrings[name] == null) return string.Empty;
            else return ConfigurationManager.ConnectionStrings[name].ConnectionString;

            
        }

        protected void Move_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("testAction.aspx");
        }
    }
}