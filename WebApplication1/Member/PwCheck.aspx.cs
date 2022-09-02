using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1.Member
{
    public partial class PwCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["mode"] == "withdraw")
            {
                lblPwtitle.Text = "<p>탈퇴를 위해 사용자 비밀번호를 다시 한번 확인합니다</p>";
                BtnConf.Visible = true;
                BtnMUpdate.Visible = false;
            }                
            else if (Request["mode"] == "update")
            {
                lblPwtitle.Text = "<p>회원정보수정을 위해 사용자 비밀번호를 다시 한번 확인합니다</p>";
                BtnConf.Visible = false;
                BtnMUpdate.Visible = true;
            }
                
        }

        protected void BtnMUpdate_Click(object sender, EventArgs e)
        {
            string m_pw = w_m_pw.Text.ToString();
            string m_id = Session["s_m_id"].ToString();

            MemberDAO mb = new MemberDAO();

            string result = mb.LoginCheck(m_id, m_pw);

            if (result == "")
            {
                m_pw_chk_msg.Text = "비밀번호가 일치하지 않습니다";
            }
            else
            {
                Response.Write("<script>opener.location.replace('/Member/MemJoinForm.aspx?mode=update');</script>");
                Response.Write("<script>window.close();</script>");
            }
        }

        protected void BtnConf_Click(object sender, EventArgs e)
        {
            string m_pw = w_m_pw.Text.ToString();
            string m_id = Session["s_m_id"].ToString();

            MemberDAO mb = new MemberDAO();

            string result = mb.LoginCheck(m_id, m_pw);

            if (result == "")
            {
                m_pw_chk_msg.Text = "비밀번호가 일치하지 않습니다";
            }
            else
            {
                DialogResult dr = MessageBox.Show("삭제된 회원정보는 복구되지 않습니다.\n정말 탈퇴하시겠습니까?", "", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    DBConn dbConn = new DBConn();
                    string strConn = dbConn.GetConnectionString();
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        string sql = "";

                        sql = "UPDATE member SET m_level='F'";
                        sql += " WHERE m_id=@m_id AND m_pw=@m_pw";

                        cmd.Parameters.AddWithValue("@m_id", m_id);
                        cmd.Parameters.AddWithValue("@m_pw", m_pw);

                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        int cnt = cmd.ExecuteNonQuery();

                        if (cnt != 0)
                        {//탈퇴 성공

                            DialogResult drc = MessageBox.Show("탈퇴 성공\n확인을 누르면 홈으로 이동합니다.", "", MessageBoxButtons.OK);
                            if (drc == DialogResult.OK)
                            {
                                Response.Write("<script>opener.location.replace('/Main.aspx');</script>");
                                Response.Write("<script>window.close();</script>");

                                Session["s_m_id"] = null;
                                Session["s_m_pw"] = null;
                                Session["s_m_level"] = null;
                            }
                        }
                    }
                }
            }

        }


    }
}