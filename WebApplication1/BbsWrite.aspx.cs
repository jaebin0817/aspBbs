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
                    string fileName = Server.MapPath("~/Uploads") + @"\" + p_thumb.FileName;
                    p_thumb.SaveAs(fileName);

                    cmd.Parameters.AddWithValue("@p_thumb", p_thumb.FileName);

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