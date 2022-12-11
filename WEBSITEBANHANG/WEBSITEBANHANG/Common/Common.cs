using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WEBSITEBANHANG
{
    public static class Common
    {
        static string sqlConnectString = ConfigurationManager.ConnectionStrings["databaseConnectionStrings"].ConnectionString;
        public static SqlConnection GetConnect()
        {
            var con = new SqlConnection(sqlConnectString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public static DataTable QueryString(string query)
        {
            var con = GetConnect();
            if (!string.IsNullOrEmpty(query))
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            return null;
        }
        public static bool ExecuteNoQuery(string query)
        {
            var con = GetConnect();
            if (!string.IsNullOrEmpty(query))
            {
                SqlCommand sc = new SqlCommand(query, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return false;
        }
        public static string CheckLogin()
        {
            var tenDN = HttpContext.Current.Session["TenDN"];
            var matKhau = HttpContext.Current.Session["Matkhau"];
            if (tenDN != null && !string.IsNullOrEmpty(Convert.ToString(tenDN)) &&
                matKhau != null && !string.IsNullOrEmpty(Convert.ToString(matKhau)))
            {
                return tenDN.ToString();
            }
            return "";
        }

    }

}