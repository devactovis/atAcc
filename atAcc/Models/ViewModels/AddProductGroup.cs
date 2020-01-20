using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class AddProductGroup
    {
        public int id { get; set; }
        public string hsn_code { get; set; }
        public string group_name { get; set; }
        public string group_head { get; set; }
        public int stock_status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}