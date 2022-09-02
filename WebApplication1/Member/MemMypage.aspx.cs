using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1.Member
{
    public partial class MemMypage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check = "";

            check += Session["s_m_id"].ToString() + " ";
            check += Session["s_m_pw"].ToString() + " ";
            check += Session["s_m_level"].ToString() + " ";
            check += Session.Timeout.ToString() + "분";

            LblSid.Text = "<strong>" + Session["s_m_id"].ToString() + "</strong>님 환영합니다";

        }

        //protected void BtnUpdate_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("/Member/MemJoinForm.aspx?mode=update");
        //}


        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["s_m_id"] = null;
            Session["s_m_pw"] = null;
            Session["s_m_level"] = null;

            DialogResult dr = MessageBox.Show("로그아웃 성공\n확인을 누르면 홈으로 이동합니다.", "", MessageBoxButtons.OK);
            if (dr == DialogResult.OK)
            {
                Response.Redirect("/Main.aspx");
            }
        }




    }
}