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
    public partial class BbsWriteTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnWrite_Click(object sender, EventArgs e)
        {
            string strConn = GetConnectionString();

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
                cmd.Parameters.AddWithValue("@p_wip", GetIP());
                cmd.Parameters.AddWithValue("@p_pw", p_pw.Text);

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
                        Response.Redirect("~/BbsMsg.aspx?mode=fileTypeError");
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

                Response.Redirect("~/BbsList.aspx");

            }
        }

        public string GetConnectionString(string name = "BoardDB")
        {
            if (ConfigurationManager.ConnectionStrings[name] == null) return string.Empty;
            else return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public string GetIP()
        {
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;

        }

        protected void FileTest_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/Uploads") + @"\";
            string fileName = uploadfile.PostedFile.FileName.ToString();

            uploadfile.PostedFile.SaveAs(savePath+fileName);
        }
    }
}