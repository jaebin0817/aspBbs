using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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