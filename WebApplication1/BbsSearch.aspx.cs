using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class BbsSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string keyword = Request["keyword"];
            dsrcProduct.SelectCommand = "SELECT * FROM bbs_post WHERE p_subject LIKE '%" + keyword + "%' OR p_wname LIKE '%" + keyword + "%' OR p_content LIKE '%" + keyword + "%' ORDER BY p_no DESC";

            rptProduct.DataSource = dsrcProduct;
            rptProduct.DataBind();

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BbsSearch.aspx?keyword=" + navSearch.Text);
        }
    }
}