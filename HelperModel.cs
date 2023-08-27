using SimpleWebSite.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebSite.Models
{
    public class AddProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HSNNumber { get; set; }
        public string BrandName { get; set; }
        public string UOM { get; set; }
        public string Weight { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> BuyingPrice { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }

    public class ProductDataListPagingVm
    {
        public List<Product> ProductData { get; set; }
        public Pager Pager { get; set; }

    }
}