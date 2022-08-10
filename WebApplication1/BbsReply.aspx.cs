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
    public partial class BbsReply : System.Web.UI.Page
    {

        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {
            dsrcProduct.SelectCommand = "SELECT A.*, B.c_no FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE r_no=" + Request["r_no"];

            rptProduct.DataSource = dsrcProduct;
            rptProduct.DataBind();
            

        }


        protected void BtnReply_Click(object sender, EventArgs e)
        {
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string selectString = "SELECT A.*, B.c_no FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE r_no=" + Request["r_no"];
                DataRow row = dbConn.GetRow(selectString);

                string updateString = "UPDATE bbs_reply SET r_grpord=r_grpord+1 WHERE r_grpord>@r_grpord AND r_grpno=@r_grpno";

                string insertString = "INSERT INTO bbs_reply(p_no, r_content, r_wname, r_pw, r_wip, r_regdt, r_grpno, r_grpord, r_indent) ";
                insertString += "VALUES(@p_no, @r_content, @r_wname, @r_pw, @r_wip, GETDATE(), @r_grpno, @r_grpord+1, @r_indent)";

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                string str_grpord = row["r_grpord"].ToString();
                int.TryParse(str_grpord, out int r_grpord);

                string str_indent = row["r_indent"].ToString();
                int.TryParse(str_indent, out int r_indent);
                    

                cmd.Parameters.AddWithValue("@p_no", row["p_no"].ToString());
                cmd.Parameters.AddWithValue("@r_content", r_content.Text);
                cmd.Parameters.AddWithValue("@r_wname", r_wname.Text);
                cmd.Parameters.AddWithValue("@r_pw", r_pw.Text);
                cmd.Parameters.AddWithValue("@r_wip", dbConn.GetIP());
                cmd.Parameters.AddWithValue("@r_grpno", row["r_grpno"].ToString());
                cmd.Parameters.AddWithValue("@r_grpord", r_grpord);
                cmd.Parameters.AddWithValue("@r_indent", r_indent+1);

                cmd.Connection = conn;

                try
                {
                    cmd.CommandText = updateString;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = insertString;
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

                Response.Redirect("~/BbsRead.aspx?c_no=" + row["p_no"].ToString() + "&p_no=" + row["p_no"].ToString());

            }
        }





    }
}