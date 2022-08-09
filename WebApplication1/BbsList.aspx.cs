using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class BbsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["keyword"] == null)
            {
                dsrcProduct.SelectCommand = "SELECT * FROM bbs_post WHERE c_no=" + Request["c_no"] + " ORDER BY p_no DESC";
            }
            else
            {
                string keyword = Request["keyword"];
                dsrcProduct.SelectCommand = "SELECT * FROM bbs_post WHERE p_subject LIKE '%" + keyword + "%' OR p_wname LIKE '%" + keyword + "%' OR p_content LIKE '%" + keyword + "%' ORDER BY p_no DESC";
            }


            rptProduct.DataSource = dsrcProduct;
            rptProduct.DataBind();
        }

    }
}