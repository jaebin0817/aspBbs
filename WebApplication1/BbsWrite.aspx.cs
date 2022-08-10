using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net;
using System.Net.Sockets;

namespace WebApplication1
{
    public partial class BbsWrite : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnWrite_Click(object sender, EventArgs e)
        {
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string insertString = "INSERT INTO bbs_post(c_no, p_subject, p_content, p_wname, p_wip, p_pw, p_thumb, p_regdt, p_open)";
                insertString += "VALUES(@c_no, @p_subject, @p_content, @p_wname, @p_wip, @p_pw, @p_thumb, GETDATE(), @p_open)";

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@c_no", c_no.Text);
                cmd.Parameters.AddWithValue("@p_subject", p_subject.Text);
                cmd.Parameters.AddWithValue("@p_content", p_content.Text);
                cmd.Parameters.AddWithValue("@p_wname", p_wname.Text);
                cmd.Parameters.AddWithValue("@p_wip", dbConn.GetIP());
                cmd.Parameters.AddWithValue("@p_pw", p_pw.Text);

                if (p_thumb.HasFile)
                {
                    string savePath = Server.MapPath("~/Uploads") + @"\";
                    string fileName = p_thumb.FileName;

                    FileUpload fu = new FileUpload();
                    fileName = fu.FileNameCheck(fileName, savePath);

                    p_thumb.SaveAs(savePath+fileName);

                    cmd.Parameters.AddWithValue("@p_thumb", fileName);

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

                Response.Redirect("~/BbsMsg.aspx?mode=ins");


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