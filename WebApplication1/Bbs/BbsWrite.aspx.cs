using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class BbsWrite : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();
        SecurityUtility su = new SecurityUtility();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["s_m_id"] != null)
            {
                loginStatus.Value = "Y";
                p_wname.Text = Session["s_m_id"].ToString();                
            }
            else
                loginStatus.Value = "N";

            if (Request["p_member"] != null)
                memStatus.Value = Request["p_member"].ToString();
            else
                memStatus.Value = "";

            if (!IsPostBack)
            {
                if (Request["mode"] == "new")
                {//새 글쓰기일 때
                    lblTitle.Text = "게시글 작성";
                    btnWrite.Visible = true;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = false;
                    btnRead.Visible = false;
                    //modeStatus.Value = "new";

                    string bbs_cat = Request["bbs_cat"];
                    string r_c_no = Request["c_no"];
                    if (bbs_cat != null)
                        c_no.SelectedValue = r_c_no;
                }
                else if (Request["mode"] == "mod")
                {//글 수정일 때
                    lblTitle.Text = "게시글 수정";
                    btnWrite.Visible = false;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = true;
                    btnRead.Visible = true;
                    //modeStatus.Value = "mod";

                    string selectString = "SELECT * FROM bbs_POST ";
                    selectString += "WHERE p_no=" + Request["p_no"];

                    DataTable dt = dbConn.GetData(selectString);
                    if (dt == null)
                    {
                        MessageBox.Show("잘못된 접근입니다");
                        Response.Redirect("/Main.aspx");
                    }

                    DataRow row = dt.Rows[0];

                    btnRead.PostBackUrl = "/Bbs/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + Request["p_no"];

                    p_wname.Text = row["p_wname"].ToString();
                    p_subject.Text = row["p_subject"].ToString();
                    p_content.Text = row["p_content"].ToString();

                    if (row["p_thumb"].ToString() != "noimg.png")
                    {
                        old_o_thumb.Visible = true;
                        old_o_thumb.Text = "기존 첨부 파일 : " + row["p_thumb"].ToString();
                    }

                    if (row["p_open"].ToString() == "Y")
                    {
                        p_open_y.Checked = true;
                    }
                    else if (row["p_open"].ToString() == "N")
                    {
                        p_open_n.Checked = true;
                    }

                    c_no.Items.FindByValue(row["c_no"].ToString()).Selected = true;



                }

            }
        }//Page_Load() end


        protected void BtnWrite_Click(object sender, EventArgs e)
        {
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string insertString = "INSERT INTO bbs_post(c_no, p_subject, p_content, p_wname, p_wip, p_pw, p_thumb, p_regdt, p_open, p_member)";
                insertString += "VALUES(@c_no, @p_subject, @p_content, @p_wname, @p_wip, @p_pw, @p_thumb, GETDATE(), @p_open, @p_member)";

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                if (!(c_no.Text.Equals("")))
                    cmd.Parameters.AddWithValue("@c_no", c_no.Text);
                else
                    cmd.Parameters.AddWithValue("@c_no", DBNull.Value);
                
                cmd.Parameters.AddWithValue("@p_subject", p_subject.Text);
                cmd.Parameters.AddWithValue("@p_content", p_content.Text);
                cmd.Parameters.AddWithValue("@p_wname", p_wname.Text);
                cmd.Parameters.AddWithValue("@p_wip", dbConn.GetIP());

                if (loginStatus.Value == "Y")
                    cmd.Parameters.AddWithValue("@p_pw", Session["s_m_pw"]);
                else
                {
                    string sha_p_pw = su.SHA256Result(p_pw.Text);   //비밀번호 암호화
                    cmd.Parameters.AddWithValue("@p_pw", sha_p_pw);
                }

                cmd.Parameters.AddWithValue("@p_member", loginStatus.Value);

                if (p_thumb.HasFile)
                {
                    string savePath = Server.MapPath("~/Uploads") + @"\";
                    string fileName = p_thumb.FileName;

                    FileUpload fu = new FileUpload();

                    if (fu.ImageFileCheck(fileName))
                    {
                        fileName = fu.FileNameCheck(fileName, savePath);
                        p_thumb.SaveAs(savePath + fileName);
                        cmd.Parameters.AddWithValue("@p_thumb", fileName);
                    }
                    else
                    {
                        Response.Redirect("/Bbs/BbsList.aspx?mode=fileTypeError");
                    }

                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_thumb", "noimg.png");
                }

                string p_open = "";
                if (p_open_y.Checked == true)
                    p_open = "Y";
                else if (p_open_n.Checked == true)
                    p_open = "N";

                cmd.Parameters.AddWithValue("@p_open", p_open);

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

                Response.Redirect("/Bbs/BbsList.aspx?c_no" + c_no.Text);

            }
        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string selectString = "SELECT * FROM bbs_POST ";
                selectString += "WHERE p_no=" + Request["p_no"];

                DataTable dt = dbConn.GetData(selectString);
                DataRow row = dt.Rows[0];

                string old_thumb = row["p_thumb"].ToString();


                string sql = "UPDATE bbs_post ";
                sql += "SET c_no=@c_no, p_subject=@p_subject, p_content=@p_content, p_wname=@p_wname, p_wip=@p_wip, p_pw=@p_pw, p_thumb=@p_thumb, p_open=@p_open ";
                sql += "WHERE p_no=" + Request["p_no"];

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                if (!(c_no.Text.Equals("")))
                    cmd.Parameters.AddWithValue("@c_no", c_no.Text);
                else
                    cmd.Parameters.AddWithValue("@c_no", DBNull.Value);

                cmd.Parameters.AddWithValue("@p_subject", p_subject.Text);
                cmd.Parameters.AddWithValue("@p_content", p_content.Text);
                cmd.Parameters.AddWithValue("@p_wname", p_wname.Text);
                cmd.Parameters.AddWithValue("@p_wip", dbConn.GetIP());
                if (loginStatus.Value == "Y")
                    cmd.Parameters.AddWithValue("@p_pw", Session["s_m_pw"]);
                else
                {
                    string sha_p_pw = su.SHA256Result(p_pw.Text);   //비밀번호 암호화
                    cmd.Parameters.AddWithValue("@p_pw", sha_p_pw);
                }

                if (p_thumb.HasFile)
                {
                    string savePath = Server.MapPath("~/Uploads") + @"\";
                    string fileName = p_thumb.FileName;

                    FileUpload fu = new FileUpload();

                    if (fu.ImageFileCheck(fileName))
                    {
                        fileName = fu.FileNameCheck(fileName, savePath);
                        p_thumb.SaveAs(savePath + fileName);
                        cmd.Parameters.AddWithValue("@p_thumb", fileName);
                        if (old_thumb != "noimg.png") { File.Delete(savePath + old_thumb); }
                    }
                    else
                    {
                        Response.Redirect("/Bbs/BbsMsg.aspx?mode=fileTypeError");
                    }

                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_thumb", old_thumb);
                }

                string p_open = "";
                if (p_open_y.Checked == true)
                    p_open = "Y";
                else if (p_open_n.Checked == true)
                    p_open = "N";

                cmd.Parameters.AddWithValue("@p_open", p_open);

                cmd.Connection = conn;

                try
                {
                    cmd.CommandText = sql;
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

                Response.Redirect("/Bbs/BbsRead.aspx?c_no=" + c_no.Text + "&p_no=" + row["p_no"].ToString());

            }
        }



        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            c_no.SelectedIndex = 0;
            //c_no.Items.FindByValue("1").Selected = true;
            p_wname.Text = "";
            p_pw.Text = "";
            p_subject.Text = "";
            p_content.Text = "";

        }

    }

}