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
    public partial class BbsRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string updateString = "UPDATE bbs_post SET p_readcnt=p_readcnt+1 ";
            updateString += "WHERE p_no=" + Request["p_no"];

            string selectString = "SELECT * FROM bbs_POST ";
            selectString += "WHERE p_no=" + Request["p_no"];

            DataTable dt = GetData(selectString);
            DataRow row = dt.Rows[0];           

            lblP_subject.Text = row["p_subject"].ToString();
            lblP_content.Text = row["p_content"].ToString();
            lblP_wname.Text = row["p_wname"].ToString();
            lblP_regdt.Text = row["p_regdt"].ToString();
            lblP_readcnt.Text = row["p_readcnt"].ToString();

            string selectCatString = "SELECT c_name FROM bbs_cat WHERE c_no=";
            selectCatString += Request["c_no"];
            DataTable catDt = GetData(selectCatString);
            DataRow cat = catDt.Rows[0];
            lblP_cat.Text = cat["c_name"].ToString();



        }

        private DataTable GetData(string selectString)
        {
            string strConn = GetConnectionString();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(selectString, conn);
                adapter.Fill(dt);
            }
            return dt;
        }




        public string GetConnectionString(string name = "BoardDB")
        {
            if (ConfigurationManager.ConnectionStrings[name] == null) return string.Empty;
            else return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}