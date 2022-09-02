using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //세션의 아이디와 비번 정보
            if (Session["s_m_id"] == null && Session["s_m_pw"] == null)
            {//로그아웃된 상태
                hlMypage.Visible = false;
                hlLogout.Visible = false;
                hlSignon.Visible = true;
                hlLogin.Visible = true;
            }
            else
            {
                hlSignon.Visible = false;
                hlLogin.Visible = false;
                hlMypage.Visible = true;
                hlLogout.Visible = true;
            }

        }

        protected void HyperAll_Unload(object sender, EventArgs e)
        {

        }

        protected void LinkCat1_Click(object sender, EventArgs e)
        {
            Session["bbs_cat"] = "카테고리1";
            Session["c_no"] = "1";
            Session["keyword"] = null;
            Session["nowPage"] = null;

            Response.Redirect("TestList.aspx");

        }

        protected void LinkCat2_Click(object sender, EventArgs e)
        {
            Session["bbs_cat"] = "카테고리2";
            Session["c_no"] = "2";
            Session["keyword"] = null;
            Session["nowPage"] = null;

            Response.Redirect("TestList.aspx");

        }

        protected void LinkAll_Click(object sender, EventArgs e)
        {
            Session["bbs_cat"] = null;
            Session["c_no"] = null;
            Session["keyword"] = null;
            Session["nowPage"] = null;

            Response.Redirect("TestList.aspx");

        }

        protected void HlLogout_Click(object sender, EventArgs e)
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