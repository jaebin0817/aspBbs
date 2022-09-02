using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Member
{
    public partial class IdPwFindResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string m_name = Request["m_name"];
            string m_email = Request["m_email"];

            MemberDAO mb = new MemberDAO();

            string m_id = mb.FindId(m_name, m_email);

            string[] ch = {
                        "A","B","C","D","E","F","G","H","I","J","K","L","M",
                        "N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                        "a","b","c","d","e","f","g","h","i","j","k","l","m",
                        "n","o","p","q","r","s","t","u","v","w","x","y","z",
                        "0","1","2","3","4","5","6","7","8","9"
                };

            Random rd = new Random();
            string tmpPw = "";

            for (int i = 1; i <= 10; i++)
            {
                int idx = rd.Next(0, ch.Length);
                tmpPw += ch[idx];
            }

            DBConn dbConn = new DBConn();
            string strConn = dbConn.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                conn.Open();

                string updateString = "UPDATE member";
                updateString += " SET m_pw=@m_pw";
                updateString += " WHERE m_id=@m_id";

                cmd.Parameters.AddWithValue("@m_id", m_id);
                cmd.Parameters.AddWithValue("@m_pw", tmpPw);


                cmd.Connection = conn;

                try
                {
                    cmd.CommandText = updateString;
                    int cnt = cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    Response.Write(error.ToString());
                }
                finally
                {
                    conn.Close();
                }

                lblId.Text = m_id;
                lblTmpPw.Text = tmpPw;
            }
        }


    }
}