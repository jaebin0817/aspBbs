using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Member
{
    public partial class IdCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnIDChk.Visible = true;
            BtnIDUse.Visible = false;
            BtnRetry.Visible = false;
            lblNotice.Text = "";
        }

        protected void BtnIDChk_Click(object sender, EventArgs e)
        {
            MemberDAO mb = new MemberDAO();

            string typed_m_id = m_id.Text.ToString();

            if (mb.IdCheck(typed_m_id) != null)
            {
                m_id_chk_msg.Text = "<p>이미 사용중인 아이디입니다</p>";

            }
            else
            {
                m_id_chk_msg.Text = "<p><strong>" + typed_m_id+ "</strong><br/>사용가능한 아이디입니다</p>";

                checked_id.Value = typed_m_id;

                BtnIDChk.Visible = false;
                BtnIDUse.Visible = true;
                BtnRetry.Visible = true;
                m_id.Visible = false;
                lblNotice.Text = "";
            }           
        }

        protected void BtnIDUse_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();</script>");
        }

        protected void BtnRetry_Click(object sender, EventArgs e)
        {           
            BtnIDChk.Visible = true;
            BtnIDUse.Visible = false;
            m_id.Text = "";
            m_id.Visible = true;
            BtnRetry.Visible = false;
            m_id_chk_msg.Text = "";
            lblNotice.Text = "<p>사용할 아이디를 입력해 주세요.</p>";
        }

        protected void BtnConf_Click(object sender, EventArgs e)
        {

        }

        protected void BtnConf_Click1(object sender, EventArgs e)
        {

        }
    }
}