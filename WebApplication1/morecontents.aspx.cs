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

    public partial class MoreContents : System.Web.UI.Page
    {

        private int postPerPage = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nowPage.Value = "1";
            }

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BoardDB"].ConnectionString))
            {
                List<BbsPost> results = null;
                if (Request["keyword"] == null)
                {
                    results = db.Query<BbsPost>("SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY p_no DESC) AS rownum FROM bbs_post WHERE c_no=" + Request["c_no"] + ")A WHERE A.rownum BETWEEN @start AND @end", new { start = 1, end = postPerPage }).ToList();
                }
                else
                {
                    string keyword = Request["keyword"];
                    results = db.Query<BbsPost>("SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY p_no DESC) AS rownum FROM bbs_post WHERE p_subject LIKE '%" + keyword + "%' OR p_wname LIKE '%" + keyword + "%' OR p_content LIKE '%" + keyword + "%')A WHERE A.rownum BETWEEN @start AND @end", new { start = 1, end = postPerPage }).ToList();
                }

                rptProduct.DataSource = results;
                rptProduct.DataBind();

            }
        }


        protected void BtnMore_Click(object sender, EventArgs e)
        {
            DBConn dbConn = new DBConn();

            Int32.TryParse(nowPage.Value, out int page);
            int newNowPage = page + 1;

            nowPage.Value = newNowPage.ToString();



            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BoardDB"].ConnectionString))
            {
                string countString = "";
                List<BbsPost> results = null;
                if (Request["keyword"] == null)
                {
                    results = db.Query<BbsPost>("SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY p_no DESC) AS rownum FROM bbs_post WHERE c_no=" + Request["c_no"] + ")A WHERE A.rownum BETWEEN @start AND @end", new { start = 1, end = newNowPage * postPerPage }).ToList();
                    countString = "SELECT COUNT(*) AS cnt FROM bbs_post WHERE c_no=" + Request["c_no"];
                }
                else
                {
                    string keyword = Request["keyword"];
                    results = db.Query<BbsPost>("SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY p_no DESC) AS rownum FROM bbs_post WHERE p_subject LIKE '%" + keyword + "%' OR p_wname LIKE '%" + keyword + "%' OR p_content LIKE '%" + keyword + "%')A WHERE A.rownum BETWEEN @start AND @end", new { start = 1, end = newNowPage * postPerPage }).ToList();
                    countString = "SELECT COUNT(*) AS cnt FROM bbs_post WHERE p_subject LIKE '%" + keyword + "%' OR p_wname LIKE '%" + keyword + "%' OR p_content LIKE '%" + keyword + "%'";
                }

                rptProduct.DataSource = results;
                rptProduct.DataBind();

                DataRow row = dbConn.GetRow(countString);
                Int32.TryParse(row["cnt"].ToString(), out int cnt);
                if (cnt < page * postPerPage) { MessageBox.Show("더 이상 불러 올 게시글이 없습니다"); }

            }
        }


        [WebMethod]
        public static string MorePosts()
        {
            return "ajax메시지";
        }


    }
}