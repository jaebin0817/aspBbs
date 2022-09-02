using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class BbsReplyMod : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string selectString = "SELECT r_wname, r_content FROM bbs_reply WHERE r_no=" + Request["r_no"];
                DataTable dt = dbConn.GetData(selectString);
                DataRow row = dt.Rows[0];

                r_wname.Text = row["r_wname"].ToString();
                r_content.Text = row["r_content"].ToString();
            }
        }


        protected void BtnReplyMod_Click(object sender, EventArgs e)
        {
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string selectString = "SELECT A.p_no, B.c_no FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE r_no=" + Request["r_no"];
                DataRow row = dbConn.GetRow(selectString);

                string updateString = "UPDATE bbs_reply SET r_wname=@r_wname, r_pw=@r_pw, r_content=@r_content, r_wip=@r_wip WHERE r_no=" + Request["r_no"];            

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@r_content", r_content.Text);
                cmd.Parameters.AddWithValue("@r_wname", r_wname.Text);
                cmd.Parameters.AddWithValue("@r_pw", r_pw.Text);
                cmd.Parameters.AddWithValue("@r_wip", dbConn.GetIP());

                cmd.Connection = conn;

                try
                {
                    cmd.CommandText = updateString;
                    cmd.ExecuteNonQuery();

                }
                catch (Exception error)
                {
                    Response.Write(error.ToString());
                }
                finally
                {
                    conn.Close();
                }

                Response.Redirect("~/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString());

            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            string selectString = "SELECT A.p_no, B.c_no FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE r_no=" + Request["r_no"];
            DataRow row = dbConn.GetRow(selectString);
            Response.Redirect("~/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString());

        }
    }
}