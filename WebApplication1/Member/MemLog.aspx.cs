using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1.Member
{
    public partial class MemLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SecurityUtility su = new SecurityUtility();
            MemberDAO mb = new MemberDAO();

            string t_m_id = m_id.Text.ToString();
            string sha_p_pw = su.SHA256Result(m_pw.Text);           

            string m_level = mb.LoginCheck(t_m_id, sha_p_pw);

            if (m_level != "")
            {//로그인 성공

                Session["s_m_id"] = t_m_id;
                Session["s_m_pw"] = sha_p_pw;
                Session["s_m_level"] = m_level;

                Response.Redirect("/Member/MemMypage.aspx");

            }                
            else
                msg_login.Text = "로그인 실패. 아이디와 비밀번호를 확인하세요.";

        }




    }
}