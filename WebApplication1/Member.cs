using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class MemberDTO
{
    public string m_id { get; set; }
    public string m_pw { get; set; }
    public string m_name { get; set; }
    public string m_email { get; set; }
    public string m_phone { get; set; }
    public string m_birth { get; set; }
    public string m_gender { get; set; }
    public string m_level { get; set; }
    public string m_regdt { get; set; }

}

public class MemberDAO
{
    DBConn dbConn = new DBConn();

    public string ReadMember(SqlCommand cmd)
    {
        string result = null;
        string strConn = dbConn.GetConnectionString();

        using (SqlConnection conn = new SqlConnection(strConn))
        {
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
                while (rdr.Read())
                    result = rdr[0].ToString();
        }
        return result;
    }


    public string IdCheck(string m_id)
    {
        string result = null;
        SqlCommand cmd = new SqlCommand();
            
        cmd.CommandText = "SELECT m_id FROM member WHERE m_id = @m_id";
        cmd.Parameters.AddWithValue("@m_id", m_id);

        result = ReadMember(cmd);

        return result;
    }//IdCheck() end


    public string EmailCheck(string m_email)
    {
        string result = null;
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT m_email FROM member WHERE m_email = @m_email";
        cmd.Parameters.AddWithValue("@m_email", m_email);

        result = ReadMember(cmd);

        return result;
    }//EmailCheck() end


    public string PhoneCheck(string m_phone)
    {
        string result = null;
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT m_phone FROM member WHERE m_phone = @m_phone";
        cmd.Parameters.AddWithValue("@m_phone", m_phone);

        result = ReadMember(cmd);

        return result;
    }//PhoneCheck() end


    public string LoginCheck(string m_id, string m_pw)
    {
        string m_level = "";
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT m_id, m_pw, m_level FROM member WHERE m_id = @m_id AND m_pw = @m_pw AND m_level != 'F'";
        cmd.Parameters.AddWithValue("@m_id", m_id);
        cmd.Parameters.AddWithValue("@m_pw", m_pw);

        string strConn = dbConn.GetConnectionString();

        using (SqlConnection conn = new SqlConnection(strConn))
        {
            cmd.Connection = conn;

            conn.Open();
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
                while (rdr.Read())
                    m_level = rdr[2].ToString();
        }

        return m_level;
    }//LoginCheck() end


    public string FindId(string m_name, string m_email)
    {
        string result = null;
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT m_id FROM member WHERE m_name=@m_name AND m_email=@m_email AND m_level!='F'";
        cmd.Parameters.AddWithValue("@m_name", m_name);
        cmd.Parameters.AddWithValue("@m_email", m_email);

        result = ReadMember(cmd);

        return result;
    }//PhoneCheck() end




}//Member end

