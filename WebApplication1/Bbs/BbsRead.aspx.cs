using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class BbsRead : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //카테고리명 조회
            string selectCatString = "SELECT c_name FROM bbs_cat WHERE c_no=";
            selectCatString += Request["c_no"];
            DataRow cat = dbConn.GetRow(selectCatString);
            if (cat == null)
            {
                MessageBox.Show("잘못된 접근입니다");
                Response.Redirect("/Bbs/BbsList.aspx");
            }
                
            lblP_cat.Text = cat["c_name"].ToString();

            String backUrl = "~/Bbs/BbsList.aspx?";

            if (Request["keyword"] == null)
            {
                backUrl += "bbs_cat=" + cat["c_name"].ToString() + "&c_no=" + Request["c_no"];               
            }
            else
            {
                btnList.PostBackUrl = "keyword=" + Request["keyword"];
            }

            if (Request["nowPage"] != null)
                backUrl += "&nowPage=" + Request["nowPage"];

            btnList.PostBackUrl = backUrl;


            string updateString = "UPDATE bbs_post SET p_readcnt=p_readcnt+1 ";
            updateString += "WHERE p_no=" + Request["p_no"];
            

            string selectString = "SELECT * FROM bbs_POST ";
            selectString += "WHERE p_no=" + Request["p_no"];           

            DataRow row = dbConn.GetRow(selectString);           

            lblP_subject.Text = row["p_subject"].ToString();
            lblP_content.Text = row["p_content"].ToString();
            lblP_wname.Text = row["p_wname"].ToString();
            lblP_regdt.Text = row["p_regdt"].ToString();
            if(row["p_thumb"].ToString()!="noimg.png")
                lblImage.Text = "<img src='/Uploads/" + row["p_thumb"].ToString() + "'/>";

            //글 상세보기 눌렀을 때 조회수 증가
            PlusReadcnt(updateString);
            Int32.TryParse(row["p_readcnt"].ToString(), out int cnt);
            int readcnt = cnt + 1;
            lblP_readcnt.Text = readcnt.ToString();

            lblDel.Text = "<a href='/Bbs/BbsPwcheck.aspx?mode=del&c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString() + "'>삭제</a>";
            lblMod.Text = "<a href='/Bbs/BbsPwcheck.aspx?mode=mod&c_no=" + row["c_no"].ToString() + "&p_no=" + row["p_no"].ToString() + "'>수정</a>";

            //댓글 로드
            dsrcProduct.SelectCommand = "SELECT * FROM bbs_reply WHERE p_no=" + Request["p_no"] + " ORDER BY r_grpno DESC, r_grpord ASC ";

            rptProduct.DataSource = dsrcProduct;
            rptProduct.DataBind();


            if (Session["s_m_id"] != null)
            {
                r_wname.Visible = false;
                r_pw.Visible = false;
            }
            


        }


        private void PlusReadcnt(string updateString)
        {
            string strConn = dbConn.GetConnectionString();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand cmd = new SqlCommand(updateString, conn);
            cmd.ExecuteNonQuery();
        }

        protected void BtnLeft_Click(object sender, EventArgs e)
        {
            string prePostSelect = "SELECT MAX(p_no) AS p_no FROM bbs_post WHERE p_no<" + Request["p_no"] + " AND c_no=" + Request["c_no"];
            DataTable preDt = dbConn.GetData(prePostSelect);
            DataRow row = preDt.Rows[0];

            if(row["p_no"].ToString() == "") { MessageBox.Show("이전페이지가 없습니다"); }
            else { Response.Redirect("~/Bbs/BbsRead.aspx?c_no=" + Request["c_no"] + "&p_no=" + row["p_no"].ToString()); }

            
        }


        protected void BtnRight_Click(object sender, EventArgs e)
        {
            string nextPostSelect = "SELECT MIN(p_no) AS p_no FROM bbs_post WHERE p_no>" + Request["p_no"] + " AND c_no=" + Request["c_no"];
            DataTable nextDt = dbConn.GetData(nextPostSelect);
            DataRow row = nextDt.Rows[0];

            if (row["p_no"].ToString() == "") { MessageBox.Show("다음 페이지가 없습니다"); }
            else { Response.Redirect("~/Bbs/BbsRead.aspx?c_no=" + Request["c_no"] + "&p_no=" + row["p_no"].ToString()); }

        }


        protected void BtnReply_Click(object sender, EventArgs e)
        {
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string insertString = "INSERT INTO bbs_reply(p_no, r_content, r_wname, r_pw, r_wip, r_regdt, r_grpno, r_member) ";
                insertString += "VALUES(@p_no, @r_content, @r_wname, @r_pw, @r_wip, GETDATE(), (SELECT ISNULL(MAX(r_no), 0)+1 FROM bbs_reply), @r_member)";

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@p_no", Request["p_no"]);
                cmd.Parameters.AddWithValue("@r_content", r_content.Text);
                cmd.Parameters.AddWithValue("@r_wip", dbConn.GetIP());

                if (Session["s_m_id"] != null)
                {
                    cmd.Parameters.AddWithValue("@r_wname", Session["s_m_id"]);
                    cmd.Parameters.AddWithValue("@r_pw", Session["s_m_pw"]);
                    cmd.Parameters.AddWithValue("@r_member", "Y");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@r_wname", r_wname.Text);
                    cmd.Parameters.AddWithValue("@r_pw", r_pw.Text);
                    cmd.Parameters.AddWithValue("@r_member", "N");
                }
 
                cmd.Connection = conn;

                try
                {
                    cmd.CommandText = insertString;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    Response.Write(error.ToString());
                }
                finally
                {
                    conn.Close();
                }

                Response.Redirect("~/Bbs/BbsRead.aspx?c_no=" + Request["c_no"] + "&p_no=" + Request["p_no"]);

            }

        }

        protected string ShowIndent(int indent)
        {
            string returnString = "";
            for (int i = 0; i < indent; i++)
            {
                returnString += "&nbsp;&nbsp;&nbsp;";
            }
            return returnString;
        }

        protected string ShowReplyIcon(int indent)
        {
            string returnString = "";
            if (indent != 0)
            {
                returnString += "<img src='/images/reply_icon.png' />";
            }
            return returnString;
        }

        protected string ShowReplySpace(int indent)
        {
            string returnString = "";
            if (indent != 0)
            {
                returnString += "<img src='/images/reply_space.png' />";
            }
            return returnString;
        }




    }
}