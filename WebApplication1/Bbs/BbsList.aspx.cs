using System;
using System.Collections.Generic;

namespace WebApplication1
{



    public partial class BbsList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Paging pg = new Paging();
            //SecurityUtility su = new SecurityUtility("bbssec12");

            string nowPage = Request["nowPage"];
            if (nowPage == null) { nowPage = "1"; }

            Int32.TryParse(nowPage, out int nPage);
            Double.TryParse(nowPage, out double nPageDo);

            //string selectCatString = "SELECT c_name FROM bbs_cat

            //string enc_c_no = Request["c_no"];
            //string c_no = null;
            //if (enc_c_no != null) c_no = su.DesResult(DesType.Decrypt, enc_c_no);

            string bbs_cat = Request["bbs_cat"];
            string c_no = Request["c_no"];
            string keyword = Request["keyword"];

            string writeLink = "BbsWrite.aspx?mode=new";        

            if (bbs_cat != null)
            {
                lblTitle.Text = bbs_cat + " 게시글 목록";
                writeLink += "&bbs_cat=" + bbs_cat + "&c_no=" + c_no;
            }
            else if (keyword != null)
            {
                lblTitle.Text = "\"" + keyword + "\" 검색 결과";
            }
            else
            {
                lblTitle.Text = "전체 게시글 목록";
            }

            HlWrite.NavigateUrl = writeLink;

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
            else {
                btnNext10.Visible = true;
            }


            string url = "/Bbs/BbsList.aspx?";

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

            for(int i=startPage; i<=endPage; i++)
            {
                if(i == nPage) { strPaging += "<strong>"; }
                strPaging += "<a href='"+ url + i +"'>" + i + "</a> ";
                if (i == nPage) { strPaging += "</strong>"; }

                if(i == pages) { break; }
            }

            lblPaging.Text = strPaging;

        }


        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Bbs/BbsList.aspx?keyword=" + navSearch.Text);
        }



    }
}