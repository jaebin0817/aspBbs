using System;
using System.Web.UI;
using System.Text;
using System.Net;
using System.IO;

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
            StringBuilder sb = new StringBuilder();
            sb.Append("bbs_cat=카테고리1&c_no=1");

            Encoding encoding = Encoding.UTF8;
            byte[] result = encoding.GetBytes(sb.ToString());

            string url = "http://localhost:58253/TEST/TestList.aspx";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = result.Length;

            Stream postDataStream = req.GetRequestStream();
            postDataStream.Write(result, 0, result.Length);
            postDataStream.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream respPostStream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(respPostStream, Encoding.Default);

            string resultPost = sr.ReadToEnd();

            Response.Redirect(resultPost);

        }

        protected void LinkCat2_Click(object sender, EventArgs e)
        {


        }

        protected void LinkAll_Click(object sender, EventArgs e)
        {


        }

        protected void HlLogout_Click(object sender, EventArgs e)
        {
            Session["s_m_id"] = null;
            Session["s_m_pw"] = null;
            Session["s_m_level"] = null;

            Response.Redirect("/Main.aspx");
        }
    }
}