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
        public string BbsCat
        {
            get { return hfCat.Value; }
        }

        public string Cno
        {
            get { return hfCno.Value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public override void DataBind()
        {
            DataTable hDt = GetHotPost();
            DataRow hPost1 = hDt.Rows[0];
            DataRow hPost2 = hDt.Rows[1];

            lblP_hot_title1.Text = hPost1["p_subject"].ToString();
            lblP_hot_title2.Text = hPost2["p_subject"].ToString();

            string hThumnfile1 = hPost1["p_thumb"].ToString();
            string hThumnfile2 = hPost2["p_thumb"].ToString();

            string hP_no1 = hPost1["p_no"].ToString();
            string hC_no1 = hPost1["c_no"].ToString();
            string hP_no2 = hPost2["p_no"].ToString();
            string hC_no2 = hPost2["c_no"].ToString();

            lblP_hot_thumb1.Text = "<a href='BbsRead.aspx?c_no="+ hC_no1 + "&p_no=" + hP_no1 + "'><img src='/uploads/" + hThumnfile1 + "' class='rec-thumb'/></a>";
            lblP_hot_thumb2.Text = "<a href='BbsRead.aspx?c_no=" + hC_no2 + "&p_no=" + hP_no2 + "'><img src='/uploads/" + hThumnfile2 + "' class='rec-thumb'/></a>";


            DataTable nDt = GetNewPost();
            DataRow nPost1 = nDt.Rows[0];
            DataRow nPost2 = nDt.Rows[1];

            lblP_new_title1.Text = nPost1["p_subject"].ToString();
            lblP_new_title2.Text = nPost2["p_subject"].ToString();

            string nThumnfile1 = nPost1["p_thumb"].ToString();
            string nThumnfile2 = nPost2["p_thumb"].ToString();

            string nP_no1 = nPost1["p_no"].ToString();
            string nC_no1 = nPost1["c_no"].ToString();
            string nP_no2 = nPost2["p_no"].ToString();
            string nC_no2 = nPost2["c_no"].ToString();

            lblP_new_thumb1.Text = "<a href='BbsRead.aspx?c_no=" + nC_no1 + "&p_no=" + nP_no1 + "'><img src='/uploads/" + nThumnfile1 + "' class='rec-thumb'/></a>";
            lblP_new_thumb2.Text = "<a href='BbsRead.aspx?c_no=" + nC_no2 + "&p_no=" + nP_no2 + "'><img src='/uploads/" + nThumnfile2 + "' class='rec-thumb'/></a>";

        }

        private DataTable GetHotPost()
        {
            string strConn = GetConnectionString();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sql = "SELECT p_subject, p_thumb, p_no, c_no FROM bbs_post ORDER BY p_readcnt DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }
            return dt;
        }


        private DataTable GetNewPost()
        {
            string strConn = GetConnectionString();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sql = "SELECT p_subject, p_thumb, p_no, c_no FROM bbs_post ORDER BY p_regdt DESC";
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BbsList.aspx?keyword=" + navSearch.Text);
        }


    }//main end
}//namespace end