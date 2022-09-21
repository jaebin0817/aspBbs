using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class BbsReply : System.Web.UI.Page
    {

        DBConn dbConn = new DBConn();
        SecurityUtility su = new SecurityUtility();

        protected string r_member = "";
        protected string p_member = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            r_member = Request["r_member"];
            p_member = Request["p_member"];

            if (Session["s_m_id"] != null)
                hdSID.Value = Session["s_m_id"].ToString();

            if (Request["mode"] == "r_re")
            {
                lblTitle.Text = "답글 작성";
                btnReply.Visible = true;
                btnReplyMod.Visible = false;
                if (Session["s_m_id"] != null)
                {
                    r_wname.Visible = false;
                    r_pw.Visible = false;
                    lblText.Visible = true;
                }
            }
            else if (Request["mode"] == "r_mod")
            {
                lblTitle.Text = "댓글 수정";
                btnReply.Visible = false;
                btnReplyMod.Visible = true;
                if (r_member == "Y")
                {
                    r_wname.Visible = false;
                    r_pw.Visible = false;
                }

                if (!IsPostBack)
                {
                    string selectString = "SELECT r_wname, r_content FROM bbs_reply WHERE r_no=" + Request["r_no"];
                    DataTable dt = dbConn.GetData(selectString);
                    DataRow row = dt.Rows[0];

                    r_wname.Text = row["r_wname"].ToString();
                    r_content.Text = row["r_content"].ToString();
                }

            }



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
                    cmd.Parameters.AddWithValue("@r_member", "N");

                    string sha_r_pw = su.SHA256Result(r_pw.Text);   //비밀번호 암호화
                    cmd.Parameters.AddWithValue("@r_pw", sha_r_pw);

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

                string openerUrl = "/Bbs/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString();

                Response.Write("<script> opener.location.href='"+ openerUrl + "'; window.close(); </script>");
                //Response.Redirect("/Bbs/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString());

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
                cmd.Parameters.AddWithValue("@r_wip", dbConn.GetIP());

                if(r_member=="Y")
                {
                    cmd.Parameters.AddWithValue("@r_wname", Session["s_m_id"]);
                    cmd.Parameters.AddWithValue("@r_pw", Session["s_m_pw"]);
                }
                else if(r_member=="N")
                {
                    cmd.Parameters.AddWithValue("@r_wname", r_wname.Text);
                    string sha_r_pw = su.SHA256Result(r_pw.Text);   //비밀번호 암호화
                    cmd.Parameters.AddWithValue("@r_pw", sha_r_pw);
                }

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

                string openerUrl = "/Bbs/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString();
                Response.Write("<script> opener.location.href='" + openerUrl + "'; window.close(); </script>");

                //Response.Redirect("/Bbs/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString());

            }
        }




    }
}