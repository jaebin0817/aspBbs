using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.IO;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class BbsPwcheck : System.Web.UI.Page
    {

        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtnCheck_Click(object sender, EventArgs e)
        {
            string pw = GetPw();
            if (pw == typed_pw.Text)
            {
                string strConn = dbConn.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    string sql = "";

                    if (Request["mode"] == "del")
                    {
                        DialogResult dr = MessageBox.Show("삭제된 내용은 복구되지 않습니다.\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo);

                        if(dr == DialogResult.Yes)
                        {
                            sql = "DELETE FROM bbs_post";
                            sql += " WHERE p_no=" + Request["p_no"];
                            sql += " AND p_pw=@p_pw";

                            string selectString = "SELECT p_thumb FROM bbs_post WHERE p_no=" + Request["p_no"];
                            DBConn dbConn = new DBConn();
                            DataRow row = dbConn.GetRow(selectString);
                            string fileName = row["p_thumb"].ToString();

                            cmd.Parameters.AddWithValue("@p_pw", typed_pw.Text);
                            cmd.Connection = conn;

                            cmd.CommandText = sql;
                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt != 0)
                            {//삭제 성공
                                string savePath = Server.MapPath("~/Uploads") + @"\";

                                File.Delete(savePath + fileName);
                                Response.Redirect("~/BbsMsg.aspx?mode=del");
                            }
                        }

                    }
                    else if (Request["mode"] == "mod")
                    {
                        Response.Redirect("~/BbsUpdate.aspx?p_no="+Request["p_no"]);
                    }
                    else if (Request["mode"] == "r_del")
                    {
                        DialogResult dr = MessageBox.Show("삭제된 내용은 복구되지 않습니다.\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {
                            sql = "DELETE FROM bbs_reply";
                            sql += " WHERE r_no=" + Request["r_no"];
                            sql += " AND r_pw=@r_pw";

                            cmd.Parameters.AddWithValue("@r_pw", typed_pw.Text);
                            cmd.Connection = conn;

                            cmd.CommandText = sql;
                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt != 0)
                            {//삭제 성공
                                Response.Redirect("~/BbsMsg.aspx?mode=del");
                            }

                        }

                    }
                    else if (Request["mode"] == "r_mod")
                    {
                        Response.Redirect("~/BbsReplyMod.aspx?r_no=" + Request["r_no"]);
                    }
                }
            }
            else
            {//비밀번호 일치하지 않을 때
                lblAlert.Text = "비밀번호가 일치하지 않습니다";
            }


        }


        private string GetPw()
        {
            string strConn = dbConn.GetConnectionString();
            string pw = "";
            DataTable dt = new DataTable();            

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sql = "";

                if(Request["mode"] == "mod" || Request["mode"] == "del")
                {
                    sql = "SELECT p_pw AS pw FROM bbs_post WHERE p_no=" + Request["p_no"];
                }else if(Request["mode"] == "r_mod" || Request["mode"] == "r_del")
                {
                    sql = "SELECT r_pw AS pw FROM bbs_reply WHERE r_no=" + Request["r_no"];
                }
                
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
                DataRow row = dt.Rows[0];
                pw = row["pw"].ToString();
            }
            return pw;
        }




        protected void Typed_pw_OnLoad(object sender, EventArgs e)
        {
            lblAlert.Text = "";
        }
    }
}