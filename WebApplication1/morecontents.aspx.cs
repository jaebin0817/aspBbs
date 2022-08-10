using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class morecontents : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();

        protected DataTable Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string selectString = "SELECT * FROM bbs_post WHERE c_no=" + Request["c_no"] + " ORDER BY p_no DESC";

            dbConn.GetData(selectString);

            return dt;

        }
    }
}