using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class BbsPost
    {
        public int p_no { get; set; }
        public int c_no { get; set; }
        public string p_subject { get; set; }
        public string p_content { get; set; }
        public string p_wname { get; set; }
        public string p_wip { get; set; }
        public string p_pw { get; set; }
        public string p_thumb { get; set; }
        public string p_regdt { get; set; }
        public int p_readcnt { get; set; }
        public string p_open { get; set; }
    }

    public class Paging
    {
        public int PAGE_SIZE = 5;
        public int PAGE_GRP_SIZE = 10;

        public List<BbsPost> PostList(int now_page, string c_no, string keyword)
        {
            List<BbsPost> results = null;

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BoardDB"].ConnectionString))
            {

                int start_id, end_id;
                start_id = (now_page - 1) * PAGE_SIZE + 1;
                end_id = now_page * PAGE_SIZE;
                System.Text.StringBuilder query = new System.Text.StringBuilder();

                query.Append("SELECT * FROM");
                query.Append(" (");
                query.Append("SELECT *, ROW_NUMBER() OVER(ORDER BY p_no DESC) AS rownum");
                query.Append(" FROM bbs_post ");

                if (c_no != null && !(c_no.Equals("")) )
                {
                    query.Append("WHERE c_no=" + c_no);
                }
                else if (keyword != null && !(keyword.Equals("")))
                {
                    SqlParameter parameter = new SqlParameter("@keyword", SqlDbType.VarChar);

                    keyword = keyword.Replace("'", "''");

                    parameter.Value = keyword;
                    query.Append("WHERE p_subject LIKE '%"+@keyword+ "%' OR p_wname LIKE '%" + @keyword + "%' OR p_content LIKE '%" + @keyword + "%'");

                }

                query.Append(")A WHERE A.rownum BETWEEN " + start_id + "AND " + end_id);

                results = db.Query<BbsPost>(query.ToString()).ToList();
            }

            return results;
        }


        public int TotalCount(string c_no, string keyword)
        {
            DBConn dbConn = new DBConn();

            System.Text.StringBuilder countString = new System.Text.StringBuilder();

            countString.Append("SELECT COUNT(*) AS cnt FROM bbs_post ");
            if (c_no != null && !(c_no.Equals("")))
            {
                countString.Append("WHERE c_no=" + c_no);
            }
            else if (keyword != null && !(keyword.Equals("")))
            {
                SqlParameter parameter = new SqlParameter("@keyword", SqlDbType.VarChar);
                keyword = keyword.Replace("'", "''");
                parameter.Value = keyword;
                countString.Append($"WHERE p_subject LIKE '%{@keyword}%' OR p_wname LIKE '%{@keyword}%' OR p_content LIKE '%{@keyword}%'");
            }

            DataRow row = dbConn.GetRow(countString.ToString());
            Int32.TryParse(row["cnt"].ToString(), out int cnt);

            return cnt;
        }

        public int TotalPage(int totalPost)
        {
            int pages = 1;
            if (totalPost != 0)
            {
                pages = totalPost / PAGE_SIZE;

                if(totalPost % PAGE_SIZE != 0)
                {
                    pages++;
                }

            }
            return pages;

        }
    }
}