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
    public partial class Home : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDataHangHoa();
        }
        public void GetDataHangHoa()
        {
            string query = "Select TOP (4) * from HangHoa ";
            var data = Common.QueryString(query);
            if (data != null && data.Rows.Count > 0)
            {
                var products = new List<ProductModel>();
                foreach (DataRow item in data.Rows)
                {
                    var product = new ProductModel();
                    if (item["MaHang"] != null && !string.IsNullOrEmpty(Convert.ToString(item["MaHang"])))
                    {
                        product.MaHang = Convert.ToString(item["MaHang"]);
                    }
                    if (item["TenHang"] != null && !string.IsNullOrEmpty(Convert.ToString(item["TenHang"])))
                    {
                        product.TenHang = Convert.ToString(item["TenHang"]);
                    }
                    if (item["DonViTinh"] != null && !string.IsNullOrEmpty(Convert.ToString(item["DonViTinh"])))
                    {
                        product.DonViTinh = Convert.ToString(item["DonViTinh"]);
                    }
                    if (item["DonGia"] != null && !string.IsNullOrEmpty(Convert.ToString(item["DonGia"])))
                    {
                        product.DonGia = Convert.ToDecimal(item["DonGia"]);
                    }
                    if (item["HinhAnh"] != null && !string.IsNullOrEmpty(Convert.ToString(item["HinhAnh"])))
                    {
                        product.HinhAnh = Convert.ToString(item["HinhAnh"]);
                    }
                    if (item["Mota"] != null && !string.IsNullOrEmpty(Convert.ToString(item["Mota"])))
                    {
                        product.Mota = Convert.ToString(item["Mota"]);
                    }
                    if (item["MaDM"] != null && !string.IsNullOrEmpty(Convert.ToString(item["MaDM"])))
                    {
                        product.MaDM = Convert.ToString(item["MaDM"]);
                    }
                    products.Add(product);
                }
                if (products != null && products.Count > 0)
                {
                    RenderHtml(products);
                }
            }
        }
        public void RenderHtml(List<ProductModel> products)
        {
            if (products != null && products.Count > 0)
            {
                var html = "";
                foreach (var item in products)
                {
                    html += Html(item);
                }
                Products.InnerHtml = html;
            }
        }
        public string Html(ProductModel product)
        {
            if (product != null)
            {
                var html = "<div class='item'> " +
                    "<a href=Product.aspx?ProductId=" + product.MaHang + " title=" + product.TenHang + ">" +
                    "<img src='images/" + product.HinhAnh + "' /> " +
                    "<p class='txt-title font-bold'>" + product.TenHang + "</p> " +
                    "<p class='txt-content'>đơn giá: <span class='price font-bold'>" + (product.DonGia > 0 ? product.DonGia.ToString("#,###") : "") + "</span></p> </a> </div> ";
                return html;
            }
            return "";
        }
    }
}