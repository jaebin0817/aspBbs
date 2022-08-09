﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace WebApplication1
{
    public partial class BbsUpdate : System.Web.UI.Page
    {
        DBConn dbConn = new DBConn();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string selectString = "SELECT * FROM bbs_POST ";
                selectString += "WHERE p_no=" + Request["p_no"];

                DataTable dt = dbConn.GetData(selectString);
                DataRow row = dt.Rows[0];

                btnRead.PostBackUrl = "~/BbsRead.aspx?c_no=" + row["c_no"].ToString() + "&p_no=" + Request["p_no"];

                p_wname.Text = row["p_wname"].ToString();
                p_subject.Text = row["p_subject"].ToString();
                p_content.Text = row["p_content"].ToString();

                if (row["p_thumb"].ToString() != "noimg.png")
                {
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

                    p_thumb.SaveAs(savePath + fileName);

                    cmd.Parameters.AddWithValue("@p_thumb", fileName);

                    File.Delete(savePath + old_thumb);

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

                Response.Redirect("~/Main.aspx");

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