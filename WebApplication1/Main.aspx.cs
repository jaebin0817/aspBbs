using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public override void DataBind()
        {
            DataTable dt = GetHotPost();
            DataRow row0 = dt.Rows[0];
            DataRow row1 = dt.Rows[1];


            
        }

        private DataTable GetHotPost()
        {
            string strConn = GetConnectionString();// "Data Source=(local);Initial Catalog=bbs;Persist Security Info=True;User ID=sa;Password=1234567890";
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sql = "SELECT p_subject, p_thumb FROM bbs_post ORDER BY p_readcnt DESC";
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


    }//main end
}//namespace end