using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class AddProduct 
    {
        public int id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string product_group { get; set; }
        public string product_color { get; set; }
        public Nullable<int> base_unit { get; set; }
        public Nullable<int> tax_type { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> rack_id { get; set; }
        public string description { get; set; }
        public int hsn_code { get; set; }
        public string minimum { get; set; }
        public string reorder { get; set; }
        public string maximum { get; set; }
        public Nullable<int> purchase_rate { get; set; }
        public Nullable<int> sales_rate { get; set; }
        public Nullable<int> sales_percent { get; set; }
        public Nullable<int> mrp { get; set; }
        public Nullable<int> min_salesrate { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}