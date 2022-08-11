using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using Dapper;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1
{
    //class BbsPost
    //{
    //    public int p_no { get; set; }
    //    public int c_no { get; set; }
    //    public string p_subject { get; set; }
    //    public string p_content { get; set; }
    //    public string p_wname { get; set; }
    //    public string p_wip { get; set; }
    //    public string p_pw { get; set; }
    //    public string p_thumb { get; set; }
    //    public string p_regdt { get; set; }
    //    public int p_readcnt { get; set; }
    //    public string p_open { get; set; }
    //}

    public partial class MoreContents : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nowPage.Value = "1";
            }
        }

        [WebMethod]
        public static string MorePosts()
        {
            return "ajax메시지";
        }


    }
}