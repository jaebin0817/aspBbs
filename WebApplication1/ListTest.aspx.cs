using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;
using System.Windows.Forms;
using System.Web.UI;

namespace WebApplication1
{
    public partial class ListTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(PreviousPage != null)
            {
                //SiteMaster pp = PreviousPage as SiteMaster;



            }


            Paging pg = new Paging();




            string nowPage = Request["nowPage"];
            if (nowPage == null) { nowPage = "1"; }

            Int32.TryParse(nowPage, out int nPage);
            Double.TryParse(nowPage, out double nPageDo);

            string bbs_cat = hfCat.Value.ToString();
            string c_no = hfCno.Value.ToString();
            string keyword = Request["keyword"];

            if (bbs_cat != null || bbs_cat != "")
            {
                lblTitle.Text = bbs_cat + " 게시글 목록";
            }
            else if (keyword != null)
            {
                lblTitle.Text = "\"" + keyword + "\" 검색 결과";
            }
            else
            {
                lblTitle.Text = "전체 게시글 목록";
            }

            List<BbsPost> results = pg.PostList(nPage, c_no, keyword);
            rptProduct.DataSource = results;
            rptProduct.DataBind();

            int totalPost = pg.TotalCount(c_no, keyword);
            int pages = pg.TotalPage(totalPost);
            int pageGroup = (int)Math.Ceiling(nPageDo / 10.0);
            int lastPageGroup = (int)Math.Ceiling(pages / 10.0);

            lblCount.Text = totalPost.ToString();
            lblPage.Text = pages.ToString();
            lblNowPage.Text = nowPage;

            if (nPage == 1)
            {
                btnPrev.Visible = false;
                btnFirst.Visible = false;
            }
            else
            {
                btnPrev.Visible = true;
                btnFirst.Visible = true;
            }

            if (nPage == pages)
            {
                btnNext.Visible = false;
                btnLast.Visible = false;
            }
            else
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }

            if (pageGroup == 1)
            {
                btnPrev10.Visible = false;
            }
            else
            {
                btnPrev10.Visible = true;
            }

            if (pageGroup == lastPageGroup)
            {
                btnNext10.Visible = false;
            }
            else
            {
                btnNext10.Visible = true;
            }


            string url = "/BbsList.aspx?";

            if (c_no != null)
            {
                url += "bbs_cat=" + bbs_cat + "&c_no=" + c_no + "&";
            }
            else if (keyword != null)
            {
                url += "keyword=" + keyword + "&";
            }

            url += "nowPage=";

            btnPrev.PostBackUrl = url + (nPage - 1);
            btnNext.PostBackUrl = url + (nPage + 1);

            btnPrev10.PostBackUrl = url + (nPage - 10);
            btnNext10.PostBackUrl = url + (nPage + 10);

            btnFirst.PostBackUrl = url + 1;
            btnLast.PostBackUrl = url + pages;

            int startPage = (pageGroup - 1) * pg.PAGE_GRP_SIZE + 1;
            int endPage = pageGroup * pg.PAGE_GRP_SIZE;
            string strPaging = "";

            for (int i = startPage; i <= endPage; i++)
            {
                if (i == nPage) { strPaging += "<strong>"; }
                strPaging += "<a href='" + url + i + "'>" + i + "</a> ";
                if (i == nPage) { strPaging += "</strong>"; }

                if (i == pages) { break; }
            }

            lblPaging.Text = strPaging;

        }


        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BbsList.aspx?keyword=" + navSearch.Text);
        }

    }
}