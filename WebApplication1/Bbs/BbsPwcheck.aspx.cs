using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class BbsPwcheck : System.Web.UI.Page
    {
       
        DBConn dbConn = new DBConn();
        String backUrl = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            String mode = Request["mode"];
            string rbackurl = "";
            if (mode == "del" || mode == "mod")
                hyperBack.NavigateUrl = "/Bbs/BbsRead.aspx?c_no=" + Request["c_no"] + "&p_no=" + Request["p_no"];
            else if (mode == "r_mod" || mode == "r_del")
            {
                string selectString = "SELECT A.p_no, B.c_no  FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE A.r_no=" + Request["r_no"];
                DataRow row = dbConn.GetRow(selectString);

                string p_no = row["p_no"].ToString();
                string c_no = row["c_no"].ToString();

                rbackurl = "/Bbs/BbsRead.aspx?c_no=" + c_no + "&p_no=" + p_no;

                hyperBack.NavigateUrl = rbackurl;
            }
            else if (mode == "read")
            {
                string selectCatString = "SELECT c_name FROM bbs_cat A JOIN bbs_post B ON A.c_no=B.c_no WHERE p_no=";
                selectCatString += Request["p_no"];
                DataRow cat = dbConn.GetRow(selectCatString);
                if (Request["c_no"] != null)
                {
                    backUrl = "/Bbs/BbsList.aspx?bbs_cat=" + cat["c_name"].ToString() + "&c_no =" + Request["c_no"];
                    if (Request["nowPage"] != null)
                        backUrl += "&nowPage=" + Request["nowPage"];
                }
                else
                {
                    backUrl = "/Bbs/BbsList.aspx?";
                    if (Request["nowPage"] != null)
                        backUrl += "nowPage=" + Request["nowPage"];
                }

                


                hyperBack.NavigateUrl = backUrl;
            }

            //회원이 작성한 글이라면 세션정보랑 비교해서 일치하면 페이지 이동, 일치하지 않으면 alert
            string p_member = Request["p_member"];
            string r_member = Request["r_member"];

            string m_id = "";
            string m_pw = "";

            if (Session["s_m_id"] != null)
            {
                m_id = Session["s_m_id"].ToString();
                m_pw = Session["s_m_pw"].ToString();
            }

            string dmbackurl = "/Bbs/BbsRead.aspx?&p_no=" + Request["p_no"];

            if (mode == "del")
            {
                if (p_member == "N")
                {
                    lblModeInfo.Text = "삭제를 ";
                }
                else if (p_member == "Y")
                {
                    if (GetPost(Request["p_no"].ToString(), m_id, m_pw))//세션이 일치하면 비밀번호 보기로 이동
                    {
                        lblModeInfo.Text = "삭제를 ";
                        lblModeInfo2.Text = "위해 로그인 비밀번호를 입력해주세요";
                    }                    
                    else
                    {
                        if (Session["s_m_id"] == null)
                            Response.Write("<script>if(confirm('작성자 본인만 삭제할 수 있습니다.\\n로그인하시겠습니까?')){location.href='/Member/MemLog.aspx'}else{location.href='"+ dmbackurl + "'};</script>");
                        else
                            Response.Write("<script>if(confirm('작성자 본인만 삭제할 수 있습니다.')){location.href='" + dmbackurl + "'}else{location.href='" + dmbackurl + "'};</script>");
                    }
                }                
            }
            else if (mode == "mod")
            {
                if (p_member == "N")
                {
                    lblModeInfo.Text = "수정을 ";
                }
                else if (p_member == "Y")
                {
                    if (GetPost(Request["p_no"].ToString(), m_id, m_pw))//세션이 일치하면 비밀번호 보기로 이동
                    {
                        lblModeInfo.Text = "수정을 ";
                        lblModeInfo2.Text = "위해 로그인 비밀번호를 입력해주세요";
                    }
                    else
                    {
                        if (Session["s_m_id"] == null)
                            Response.Write("<script>if(confirm('작성자 본인만 수정할 수 있습니다.\\n로그인하시겠습니까?')){location.href='/Member/MemLog.aspx'}else{location.href='" + dmbackurl + "'};</script>");
                        else
                            Response.Write("<script>if(confirm('작성자 본인만 수정할 수 있습니다.')){location.href='" + dmbackurl + "'}else{location.href='" + dmbackurl + "'};</script>");
                    }
                }
                
            }
            else if (mode == "r_mod")
            {
                if (r_member == "N")
                {
                    lblModeInfo.Text = "댓글 수정을 ";
                }
                else if (r_member == "Y")
                {
                    if (GetReply(Request["r_no"].ToString(), m_id, m_pw))//세션이 일치하면 비밀번호 보기로 이동
                    {
                        lblModeInfo.Text = "댓글 수정을 ";
                        lblModeInfo2.Text = "위해 로그인 비밀번호를 입력해주세요";
                    }
                    else
                    {
                        if (Session["s_m_id"] == null)
                            Response.Write("<script>if(confirm('작성자 본인만 수정할 수 있습니다.\\n로그인하시겠습니까?')){location.href='/Member/MemLog.aspx'}else{location.href='" + rbackurl + "'};</script>");
                        else
                            Response.Write("<script>if(confirm('작성자 본인만 수정할 수 있습니다.')){location.href='" + rbackurl + "'}else{location.href='" + rbackurl + "'};</script>");
                    }
                }
            }
            else if (mode == "r_del")
            {
                if (r_member == "N")
                {
                    lblModeInfo.Text = "댓글 삭제를 ";
                }
                else if (r_member == "Y")
                {
                    if (GetReply(Request["r_no"].ToString(), m_id, m_pw))//세션이 일치하면 비밀번호 보기로 이동
                    {
                        lblModeInfo.Text = "댓글 삭제를 ";
                        lblModeInfo2.Text = "위해 로그인 비밀번호를 입력해주세요";
                    }
                    else
                    {
                        if (Session["s_m_id"] == null)
                            Response.Write("<script>if(confirm('작성자 본인만 삭제할 수 있습니다.\\n로그인하시겠습니까?')){location.href='/Member/MemLog.aspx'}else{location.href='" + rbackurl + "'};</script>");
                        else
                            Response.Write("<script>if(confirm('작성자 본인만 삭제할 수 있습니다.')){location.href='" + rbackurl + "'}else{location.href='" + rbackurl + "'};</script>");
                    }
                }
            }
            else if (mode == "read")
            {                
                if(p_member=="N")
                    lblModeInfo.Text = "게시글을 열람하기 ";
                else if (p_member == "Y")
                {
                    if (GetPost(Request["p_no"].ToString(), m_id, m_pw))
                        Response.Redirect("/Bbs/BbsRead.aspx?c_no=" + Request["c_no"] + "&p_no=" + Request["p_no"] + "&nowPage=" + Request["nowPage"]);
                    else
                    {
                        if(Session["s_m_id"] == null)
                            Response.Write("<script>if(confirm('작성자 본인만 열람할 수 있습니다.\\n로그인하시겠습니까?')){location.href='/Member/MemLog.aspx'}else{location.href='" + backUrl + "'};</script>");
                        else
                            Response.Write("<script>if(confirm('작성자 본인만 열람할 수 있습니다.')){location.href='" + backUrl + "'}else{location.href='" + backUrl + "'};</script>");
                    }
                }

            }
            else if (Request["mode"] == null)
            {
                MessageBox.Show("잘못된 접근입니다");
                Response.Redirect("/Bbs/BbsList.aspx");
            }

        }


        protected void BtnCheck_Click(object sender, EventArgs e)
        {
            string pw = GetPw();
            if (pw == typed_pw.Text)
            {
                string strConn = dbConn.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    string sql = "";

                    if (Request["mode"] == "del")
                    {
                        DialogResult dr = MessageBox.Show("삭제된 내용은 복구되지 않습니다.\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo);

                        if(dr == DialogResult.Yes)
                        {
                            sql = "DELETE FROM bbs_post";
                            sql += " WHERE p_no=" + Request["p_no"];
                            sql += " AND p_pw=@p_pw";

                            string selectString = "SELECT p_thumb FROM bbs_post WHERE p_no=" + Request["p_no"];
                            DBConn dbConn = new DBConn();
                            DataRow row = dbConn.GetRow(selectString);
                            string fileName = row["p_thumb"].ToString();

                            cmd.Parameters.AddWithValue("@p_pw", typed_pw.Text);
                            cmd.Connection = conn;

                            cmd.CommandText = sql;
                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt != 0)
                            {//삭제 성공
                                string savePath = Server.MapPath("~/Uploads") + @"\";
                                if(fileName!= "noimg.png") { File.Delete(savePath + fileName); }
                                
                                Response.Redirect("/Bbs/BbsMsg.aspx?mode=del");
                            }
                        }

                    }
                    else if (Request["mode"] == "mod")
                    {
                        Response.Redirect("/Bbs/BbsUpdate.aspx?p_no=" + Request["p_no"] + "&p_member=" + Request["p_member"]);
                    }
                    else if (Request["mode"] == "r_del")
                    {
                        DialogResult dr = MessageBox.Show("삭제된 내용은 복구되지 않습니다.\n삭제하시겠습니까?", "", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {
                            string selectString = "SELECT A.p_no, B.c_no  FROM bbs_reply A JOIN bbs_post B ON A.p_no=B.p_no WHERE A.r_no=" + Request["r_no"];
                            DataRow row = dbConn.GetRow(selectString);
                            string p_no = row["p_no"].ToString();
                            string c_no = row["c_no"].ToString();


                            sql += "UPDATE bbs_reply";
                            sql += " SET r_content='삭제된 댓글입니다', r_wname='', r_regdt='' ";
                            sql += " WHERE r_no=" + Request["r_no"];
                            //sql += " AND r_pw=@r_pw";

                            //cmd.Parameters.AddWithValue("@r_pw", typed_pw.Text);
                            cmd.Connection = conn;

                            cmd.CommandText = sql;
                            int cnt = cmd.ExecuteNonQuery();

                            if (cnt != 0)
                            {//삭제 성공
                                Response.Redirect("/Bbs/BbsRead.aspx?c_no=" + c_no + "&p_no=" + p_no);
                            }

                        }

                    }
                    else if (Request["mode"] == "r_mod")
                    {
                        //Response.Redirect("/Bbs/BbsReplyMod.aspx?r_no=" + Request["r_no"]);
                        string url = "/Bbs/BbsReply.aspx?mode=r_mod&r_no=" + Request["r_no"] + "&r_member=" + Request["r_member"];
                        Response.Write("<script> open('"+ url + "', 'reply', 'width = 450, height = 300'); location.href='" + hyperBack.NavigateUrl + "';  </script>");
                    }
                    else if (Request["mode"] == "read")
                    {
                        Response.Redirect("/Bbs/BbsRead.aspx?c_no=" + Request["c_no"] + "&p_no=" + Request["p_no"] + "&nowPage=" + Request["nowPage"]);
                    }
                }
            }
            else
            {//비밀번호 일치하지 않을 때
                lblAlert.Text = "비밀번호가 일치하지 않습니다";
            }


        }


        private string GetPw()
        {
            string strConn = dbConn.GetConnectionString();
            string pw = "";
            DataTable dt = new DataTable();            

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                string sql = "";

                if(Request["mode"] == "mod" || Request["mode"] == "del")
                {
                    sql = "SELECT p_pw AS pw FROM bbs_post WHERE p_no=" + Request["p_no"];
                }else if(Request["mode"] == "r_mod" || Request["mode"] == "r_del")
                {
                    sql = "SELECT r_pw AS pw FROM bbs_reply WHERE r_no=" + Request["r_no"];
                }
                else if (Request["mode"] == "read")
                {
                    sql = "SELECT p_pw AS pw FROM bbs_post WHERE p_no=" + Request["p_no"];
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
                DataRow row = dt.Rows[0];
                pw = row["pw"].ToString();
            }
            return pw;
        }


        public Boolean GetPost(string p_no, string m_id, string m_pw)
        {
            Boolean result = false;
            string strConn = dbConn.GetConnectionString();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM bbs_post WHERE p_no=@p_no AND p_wname=@p_wname AND p_pw=@p_pw";
            cmd.Parameters.AddWithValue("@p_no", p_no);
            cmd.Parameters.AddWithValue("@p_wname", m_id);
            cmd.Parameters.AddWithValue("@p_pw", m_pw);

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                cmd.Connection = conn;

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                    while (rdr.Read())
                        result = true;
            }
            return result;
        }


        public Boolean GetReply(string r_no, string m_id, string m_pw)
        {
            Boolean result = false;
            string strConn = dbConn.GetConnectionString();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM bbs_reply WHERE r_no=@r_no AND r_wname=@r_wname AND r_pw=@r_pw";
            cmd.Parameters.AddWithValue("@r_no", r_no);
            cmd.Parameters.AddWithValue("@r_wname", m_id);
            cmd.Parameters.AddWithValue("@r_pw", m_pw);

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                cmd.Connection = conn;

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                    while (rdr.Read())
                        result = true;
            }
            return result;
        }


        protected void Typed_pw_OnLoad(object sender, EventArgs e)
        {
            lblAlert.Text = "";
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}