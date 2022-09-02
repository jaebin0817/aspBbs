using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Windows.Forms;


namespace WebApplication1
{
    public partial class TestPwcheck : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["mode"] = Request["mode"];
            String mode = Session["mode"].ToString();

            if (mode == "del" || mode == "mod")
                hyperBack.NavigateUrl = "TestRead.aspx?c_no=" + Session["r_c_no"] + "&p_no=" + Session["p_no"];
            else if (mode == "r_mod" || mode == "r_del")
            {
                string selectString = "SELECT A.p_no, B.c_no  FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE A.r_no=" + Request["r_no"];
                DataRow row = dbConn.GetRow(selectString);
                string p_no = row["p_no"].ToString();
                string c_no = row["c_no"].ToString();

                hyperBack.NavigateUrl = "BbsRead.aspx?c_no=" + c_no + "&p_no=" + p_no;
            }


            if (mode == "del")
            {
                lblModeInfo.Text = "삭제를 ";
            }
            else if (mode == "mod")
            {
                lblModeInfo.Text = "수정을 ";
            }
            else if (mode == "r_mod")
            {
                lblModeInfo.Text = "댓글 수정을 ";
            }
            else if (mode == "r_del")
            {
                lblModeInfo.Text = "댓글 삭제를 ";
            }
            else if (Request["mode"] == null)
            {
                MessageBox.Show("잘못된 접근입니다");
                Response.Redirect("BbsList.aspx");
            }

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

                        if (dr == DialogResult.Yes)
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
                                if (fileName != "noimg.png") { File.Delete(savePath + fileName); }

                                Response.Redirect("~/BbsMsg.aspx?mode=del");
                            }
                        }

                    }
                    else if (Request["mode"] == "mod")
                    {
                        Response.Redirect("~/BbsUpdate.aspx?p_no=" + Request["p_no"]);
                    }
                    else if (Request["mode"] == "r_del")
                    {
                        DialogResult dr = MessageBox.Show("삭제된 내용은 복구되지 않습니다.\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {
                            string selectString = "SELECT A.p_no, B.c_no  FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE A.r_no=" + Request["r_no"];
                            DataRow row = dbConn.GetRow(selectString);
                            string p_no = row["p_no"].ToString();
                            string c_no = row["c_no"].ToString();


                            sql += "UPDATE bbs_reply";
                            sql += " SET r_content='삭제된 댓글입니다', r_wname='', r_regdt='' ";
                            sql += " WHERE r_no=" + Request["r_no"];
                            //sql += " AND r_pw=@r_pw";

                            //cmd.Parameters.AddWithValue("@r_pw", typed_pw.Text);
                            cmd.Connection = conn;

                            cmd.CommandText = sql;
                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt != 0)
                            {//삭제 성공
                                Response.Redirect("~/BbsRead.aspx?c_no=" + c_no + "&p_no=" + p_no);
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

                if (Request["mode"] == "mod" || Request["mode"] == "del")
                {
                    sql = "SELECT p_pw AS pw FROM bbs_post WHERE p_no=" + Request["p_no"];
                }
                else if (Request["mode"] == "r_mod" || Request["mode"] == "r_del")
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

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}