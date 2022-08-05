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

            dsrcProduct.SelectCommand = "SELECT * FROM bbs_post WHERE c_no="+ Request["c_no"] +" ORDER BY p_no DESC";


            rptProduct.DataSource = dsrcProduct;
            rptProduct.DataBind();
        }

    }
}