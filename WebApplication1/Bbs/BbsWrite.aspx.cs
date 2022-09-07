using System;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class BbsWrite : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {
            string bbs_cat = Request["bbs_cat"];
            string r_c_no = Request["c_no"];

            if (bbs_cat != null)
                c_no.SelectedValue = r_c_no;

            if (Session["s_m_id"] != null)
            {
                loginStatus.Value = "Y";
                p_wname.Text = Session["s_m_id"].ToString();                
            }
            else
                loginStatus.Value = "N";
        }

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
                    cmd.Parameters.AddWithValue("@p_pw", p_pw.Text);


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