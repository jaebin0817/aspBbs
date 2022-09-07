using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class MemJoinForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["mode"] != "update")
                {
                    lblTitle.Text = "회원가입";
                    btnJoin.Visible = true;
                    btnUpdate.Visible = false;
                    modeStatus.Value = "join";
                }
                else
                {//회원정보수정일 때
                    lblTitle.Text = "회원정보수정";
                    btnJoin.Visible = false;
                    btnUpdate.Visible = true;
                    idCheck.Visible = false;
                    modeStatus.Value = "update";

                    DBConn dbConn = new DBConn();

                    string selectString = "SELECT m_id, m_name, m_email, m_phone, m_birth, m_gender FROM member ";
                    selectString += "WHERE m_id='" + Session["s_m_id"] +"'";

                    DataTable dt = dbConn.GetData(selectString);
                    if (dt == null)
                    {
                        MessageBox.Show("잘못된 접근입니다");
                        Response.Redirect("/Main.aspx");
                    }

                    DataRow row = dt.Rows[0];

                    mb_id.Text = row["m_id"].ToString();
                    mb_name.Text = row["m_name"].ToString();

                    string m_email = row["m_email"].ToString();
                    int idx = m_email.LastIndexOf('@');

                    email1.Text = m_email.Substring(0, idx);
                    email2.Text = m_email.Substring(idx + 1);

                    string m_phone = row["m_phone"].ToString();
                    string m_birth = row["m_birth"].ToString();
                    string m_gender = row["m_gender"].ToString();

                    old_email.Value = m_email;
                    old_hp.Value = m_phone;

                    if (row["m_phone"] != null && !m_phone.Equals(""))
                    {                        
                        string[] hps = m_phone.Split('-');

                        hp1.Text = hps[0];
                        hp2.Text = hps[1];
                        hp3.Text = hps[2];
                    }

                    if (row["m_birth"] != null && !m_birth.Equals(""))
                    {
                        
                        string[] births = m_birth.Split('-');
                        int bidx = m_birth.LastIndexOf('-');

                        oldBirth1.Value = births[0];
                        oldBirth2.Value = births[1];
                        oldBirth3.Value = m_birth.Substring(bidx + 1, 2);

                    }

                    if (row["m_gender"] != null && !m_gender.Equals(""))
                    {
                        
                        if (m_gender == "M") { m_gender_m.Checked = true; }
                        else if (m_gender == "F") { m_gender_f.Checked = true; }
                    }

                }

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

            string m_birth = "";
            if (mb_birth.Value != "")
                m_birth += mb_birth.Value.ToString();

            string m_gender = "";
            if (m_gender_m.Checked == true)
                m_gender = "M";
            else if (m_gender_f.Checked == true)
                m_gender = "F";

            if (mb.EmailCheck(m_email) != null)
            {//이미 사용중인 이메일
                msg_mb_email.Text = "이미 사용중인 이메일입니다";
            }
            else if (mb.PhoneCheck(m_phone) != null)
            {//이미 사용중인 연락처
                msg_mb_hp.Text = "이미 사용중인 번호입니다";
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

                    insertString += " )";

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

                        if (cnt != 0)
                        {
                            Response.Write("<script> alert('회원 가입 성공'); location.href='/Main.aspx'; </script>");
                        }
                        else
                        {
                            Response.Write("<script> alert('회원 가입 실패'); </script>");
                        }
                    }
                    catch (Exception error)
                    {
                        Response.Write(error.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }//using end
            }//if end
        }//BtnJoin_Click end


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            MemberDAO mb = new MemberDAO();
            DBConn dbConn = new DBConn();

            string m_email = "";
            m_email += email1.Text.ToString() + "@" + email2.Text.ToString();

            string m_phone = "";

            if (hp2.Text != "" && hp3.Text != "")
                m_phone += hp1.Text.ToString() + "-" + hp2.Text.ToString() + "-" + hp3.Text.ToString();

            string m_birth = "";
            if (mb_birth.Value != "")
                m_birth += mb_birth.Value.ToString();

            string m_gender = "";
            if (m_gender_m.Checked == true)
                m_gender = "M";
            else if (m_gender_f.Checked == true)
                m_gender = "F";

            if (mb.EmailCheck(m_email) != null && m_email != old_email.Value)
            {//이미 사용중인 이메일
                msg_mb_email.Text = "이미 사용중인 이메일입니다";
            }
            else if (mb.PhoneCheck(m_phone) != null && m_phone != old_hp.Value)
            {//이미 사용중인 연락처
                msg_mb_hp.Text = "이미 사용중인 번호입니다";
            }
            else
            {
                string strConn = dbConn.GetConnectionString();

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    SqlCommand cmd = new SqlCommand();
                    conn.Open();

                    string updateString = "UPDATE member";
                    updateString += " SET m_pw=@m_pw, m_name=@m_name, m_email=@m_email, m_phone=@m_phone, m_birth=@m_birth, m_gender=@m_gender";

                    if (!(m_phone.Equals("")))
                        cmd.Parameters.AddWithValue("@m_phone", m_phone);
                    else
                        cmd.Parameters.AddWithValue("@m_phone", DBNull.Value);
               
                    if (!(m_birth.Equals("")))
                        cmd.Parameters.AddWithValue("@m_birth", m_birth);
                    else
                        cmd.Parameters.AddWithValue("@m_birth", DBNull.Value);

                    if (!(m_gender.Equals("")))
                        cmd.Parameters.AddWithValue("@m_gender", m_gender);
                    else
                        cmd.Parameters.AddWithValue("@m_gender", DBNull.Value);

                    updateString += " WHERE m_id=@m_id";

                    cmd.Parameters.AddWithValue("@m_id", mb_id.Text);

                    SqlCommand pcmd = new SqlCommand();
                    SqlCommand rcmd = new SqlCommand();


                    if (mb_pw.Text != "")
                    {//신규 비밀번호를 입력했다면
                        cmd.Parameters.AddWithValue("@m_pw", mb_pw.Text);
                        
                        pcmd.CommandText = "UPDATE bbs_post SET p_pw=@p_pw WHERE p_member='Y' AND p_wname=@p_wname";
                        pcmd.Parameters.AddWithValue("@p_pw", mb_pw.Text);
                        pcmd.Parameters.AddWithValue("@p_wname", Session["s_m_id"]);
                        pcmd.Connection = conn;

                        rcmd.CommandText = "UPDATE bbs_reply SET r_pw=@r_pw WHERE r_member='Y' AND r_wname=@r_wname";
                        rcmd.Parameters.AddWithValue("@r_pw", mb_pw.Text);
                        rcmd.Parameters.AddWithValue("@r_wname", Session["s_m_id"]);
                        rcmd.Connection = conn;
                    }                        
                    else
                        cmd.Parameters.AddWithValue("@m_pw", Session["s_m_pw"]);

                    cmd.Parameters.AddWithValue("@m_name", mb_name.Text);
                    cmd.Parameters.AddWithValue("@m_email", m_email);

                    cmd.Connection = conn;

                    try
                    {
                        cmd.CommandText = updateString;
                        int cnt = cmd.ExecuteNonQuery();

                        if (cnt != 0)
                        {
                            if (mb_pw.Text != "")
                                Session["s_m_pw"] = mb_pw.Text; //비밀번호를 수정했다면 세션비밀번호도 변경

                            pcmd.ExecuteNonQuery();
                            rcmd.ExecuteNonQuery();

                            Response.Write("<script>alert('회원정보수정 성공'); location.href='/Member/MemMypage.aspx'; </script>");
                            //Response.Redirect("/Member/MemMypage.aspx");
                            //DialogResult dr = MessageBox.Show("회원정보수정 성공\n확인을 누르면 마이페이지로 이동합니다.", "", MessageBoxButtons.OK);
                            //if (dr == DialogResult.OK)
                            //{
                            //    Response.Redirect("/Member/MemMypage.aspx");
                            //}
                        }
                        else
                        {
                            Response.Write("<script>alert('회원정보수정 실패');</script>");

                        }
                    }
                    catch (Exception error)
                    {
                        Response.Write(error.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }//using end
            }//if end
        }



    }
}