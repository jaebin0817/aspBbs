using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Member
{
    public partial class IdPwFind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            string m_name = f_m_name.Text.ToString();
            string m_email = f_m_email.Text.ToString();

            MemberDAO mb = new MemberDAO();

            string m_id = mb.FindId(m_name, m_email);

            if (m_id == null)
            {
                lblFindmsg.Text = "<p>일치하는 회원정보가 없습니다</p>";
            }
            else
            {
                Response.Redirect("/Member/IdPwFindResult.aspx?m_name=" + m_name + "&m_email=" + m_email);

            }

        }//BtnFind_Click()



    }
}