﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class BbsReply : System.Web.UI.Page
    {

        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["s_m_id"] != null)
            {
                r_wname.Visible = false;
                r_pw.Visible = false;
            }

            dsrcProduct.SelectCommand = "SELECT * FROM bbs_reply WHERE r_no=" + Request["r_no"];

            rptProduct.DataSource = dsrcProduct;
            rptProduct.DataBind();

            string selectString = "SELECT A.p_no, B.c_no  FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE A.r_no=" + Request["r_no"];
            DataRow row = dbConn.GetRow(selectString);
            string p_no = row["p_no"].ToString();
            string c_no = row["c_no"].ToString();

            hyperBack.NavigateUrl = "/Bbs/BbsRead.aspx?c_no=" + c_no + "&p_no=" + p_no;

        }


        protected void BtnReply_Click(object sender, EventArgs e)
        {
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string selectString = "SELECT A.*, B.c_no FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE r_no=" + Request["r_no"];
                DataRow row = dbConn.GetRow(selectString);

                string updateString = "UPDATE bbs_reply SET r_grpord=r_grpord+1 WHERE r_grpord>@r_grpord AND r_grpno=@r_grpno";

                string insertString = "INSERT INTO bbs_reply(p_no, r_content, r_wname, r_pw, r_wip, r_regdt, r_grpno, r_grpord, r_indent, r_member) ";
                insertString += "VALUES(@p_no, @r_content, @r_wname, @r_pw, @r_wip, GETDATE(), @r_grpno, @r_grpord+1, @r_indent, @r_member)";

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                string str_grpord = row["r_grpord"].ToString();
                int.TryParse(str_grpord, out int r_grpord);

                string str_indent = row["r_indent"].ToString();
                int.TryParse(str_indent, out int r_indent);    

                cmd.Parameters.AddWithValue("@p_no", row["p_no"].ToString());
                cmd.Parameters.AddWithValue("@r_content", r_content.Text);

                if (Session["s_m_id"] != null)
                {
                    cmd.Parameters.AddWithValue("@r_wname", Session["s_m_id"]);
                    cmd.Parameters.AddWithValue("@r_pw", Session["s_m_pw"]);
                    cmd.Parameters.AddWithValue("@r_member", "Y");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@r_wname", r_wname.Text);
                    cmd.Parameters.AddWithValue("@r_pw", r_pw.Text);
                    cmd.Parameters.AddWithValue("@r_member", "N");
                }

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

                Response.Redirect("/Bbs/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString());

            }
        }





    }
}