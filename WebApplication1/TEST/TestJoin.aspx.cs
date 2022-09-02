using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.TEST
{
    public partial class TestJoin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnJoin_Click2(object sender, EventArgs e)
        {
            MemberDAO mb = new MemberDAO();

            string m_email = "";
            m_email += email1.Text.ToString() + "@" + email2.Text.ToString();

            string m_phone = "";

            if (hp2.Text != "" && hp3.Text != "")
                m_phone += hp1.Text.ToString() + "-" + hp2.Text.ToString() + "-" + hp3.Text.ToString();

            string m_gender = "";
            if (m_gender_m.Checked == true)
                m_gender = "M";
            else if (m_gender_f.Checked == true)
                m_gender = "F";

            string m_birth = "";
            if (mb_birth.Value != "")
                m_birth += mb_birth.Value.ToString();

            if (mb.EmailCheck(m_email) != null)
            {//이미 사용중인 이메일
                Response.Write("이미 사용중인 이메일입니다");
            }
            else if (mb.PhoneCheck(m_phone) != null)
            {//이미 사용중인 연락처
                Response.Write("이미 사용중인 번호입니다");
            }
            else
            {
                Response.Write(m_gender + m_birth + "회원가입 클릭" + !(m_birth.Equals("")));
            }
            

        }


        protected void BtnJoin_Click(object sender, EventArgs e)
        {
            MemberDAO mb = new MemberDAO();
            DBConn dbConn = new DBConn();

            string m_email = "";
            m_email += email1.Text.ToString() + "@" + email2.Text.ToString();

            string m_phone = "";
            if (hp2.Text != "" && hp3.Text != "")
                m_phone += hp1.Text.ToString() + "-" + hp2.Text.ToString() + "-" + hp3.Text.ToString();

            string m_gender = "";
            if (m_gender_m.Checked == true)
                m_gender = "M";
            else if (m_gender_f.Checked == true)
                m_gender = "F";

            string m_birth = "";
            if (mb_birth.Value != "")
                m_birth += mb_birth.Value.ToString();


            if (mb.EmailCheck(m_email) != null)
            {//이미 사용중인 이메일
                Response.Write("이미 사용중인 이메일입니다");
            }
            else if (mb.PhoneCheck(m_phone) != null)
            {//이미 사용중인 연락처
                Response.Write("이미 사용중인 번호입니다");
            }
            else
            {
                string strConn = dbConn.GetConnectionString();

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    SqlCommand cmd = new SqlCommand();

                    string insertString = "INSERT INTO member(m_id, m_pw, m_name, m_email, m_regdt, m_level";

                    if (!(m_phone.Equals("")))
                        insertString += ", m_phone";
                    if (!(m_birth.Equals("")))
                        insertString += ", m_birth";
                    if (!(m_gender.Equals("")))
                        insertString += ", m_gender";

                    insertString += ") VALUES(@m_id, @m_pw, @m_name, @m_email, GETDATE(), 'C'";

                    if (!(m_phone.Equals("")))
                    {
                        insertString += ", @m_phone";
                        cmd.Parameters.AddWithValue("@m_phone", m_phone);
                    }
                    if (!(m_birth.Equals("")))
                    {
                        insertString += ", @m_birth";
                        cmd.Parameters.AddWithValue("@m_birth", m_birth);
                    }
                    if (!(m_gender.Equals("")))
                    {
                        insertString += ", @m_gender";
                        cmd.Parameters.AddWithValue("@m_gender", m_gender);
                    }

                    insertString += ")";

                    conn.Open();

                    cmd.Parameters.AddWithValue("@m_id", mb_id.Text);
                    cmd.Parameters.AddWithValue("@m_pw", mb_pw.Text);
                    cmd.Parameters.AddWithValue("@m_name", mb_name.Text);
                    cmd.Parameters.AddWithValue("@m_email", m_email);

                    cmd.Connection = conn;

                    try
                    {
                        cmd.CommandText = insertString;
                        int cnt = cmd.ExecuteNonQuery();

                        if (cnt == 0)
                            Response.Write("DB등록 실패");
                        else
                            Response.Write("DB등록 성공");

                    }
                    catch (Exception error)
                    {
                        Response.Write(error.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }



                //Response.Redirect("/TEST/TestJoin.aspx");

            }//using end



        }


    }
}