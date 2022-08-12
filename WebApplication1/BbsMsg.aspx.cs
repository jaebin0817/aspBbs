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
            if (Request["mode"] == "ins") { lblMsg.Text = "글 작성 성공"; }
            if (Request["mode"] == "fileTypeError") {
                string msg = "글 작성 실패<br/>";
                msg += "이미지 파일만 업로드 가능합니다<br/>";
                msg += "(.jpg, .jpeg, .png, .gif )<br/><br/>";
                msg += "<a href='javascript:history.back();'>뒤로 가기</a>";
                lblMsg.Text = msg;
            }

        }

        

    }
}