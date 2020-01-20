using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.AjaxModels
{
    public class Inventory_filter_values
    {
        public string fltertype {get; set;}
        public DateTime datefrom { get; set; }
        public DateTime dateto { get; set; }
        public string productname { get; set; }
        public string productgroup { get; set; }

    }
}