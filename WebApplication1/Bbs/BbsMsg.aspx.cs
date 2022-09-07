using System;

namespace WebApplication1
{
    public partial class BbsMsg : System.Web.UI.Page
    {
        public static string msg { get; set; }
            

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["mode"] == "del") { lblMsg.Text = "삭제 성공"; }

        }

        

    }
}