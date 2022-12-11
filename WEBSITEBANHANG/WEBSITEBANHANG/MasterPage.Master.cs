using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBSITEBANHANG.Model;

namespace WEBSITEBANHANG
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataDanhMuc();
            }
        }
        public void GetDataDanhMuc()
        {
            string query = "Select * from DanhMuc";
            var data = Common.QueryString(query);
            if (data != null && data.Rows.Count > 0)
            {
                var html = "";
                foreach (DataRow item in data.Rows)
                {
                    html += "<li> <a href=Product.aspx?CategoryId="+ item["MaDM"] + " title="+ item["TenDM"] + ">" + item["TenDM"] + "</a></li>";
                }
                menu.InnerHtml = html;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDN = username.Value;
            string MatKhau = matkhau.Value;
            if (!string.IsNullOrEmpty(tenDN) && !string.IsNullOrEmpty(MatKhau))
            {
                string query = "Select * from KhachHang where TenDN ='" + tenDN + "' And Makhau='"+ MatKhau + "'";
                var data = Common.QueryString(query);
                if (data != null && data.Rows.Count > 0)
                {
                    var customer = new CustomerModel();
                    var khachHang = data.Rows[0];
                    if (khachHang["TenDN"] != null && !string.IsNullOrEmpty(Convert.ToString(khachHang["TenDN"])))
                    {
                        customer.TenDN = Convert.ToString(khachHang["TenDN"]);
                        Session["TenDN"] = customer.TenDN;                       
                    }
                    if (khachHang["MaKhau"] != null && !string.IsNullOrEmpty(Convert.ToString(khachHang["MaKhau"])))
                    {
                        customer.MatKhau = Convert.ToString(khachHang["MaKhau"]);
                        Session["MatKhau"] = customer.MatKhau;
                    }
                    username.Value = "";
                    matkhau.Value = "";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "ThongBao(2)", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "ThongBao(0)", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "ThongBao(1)", true);
            }
            

        }
    }
}