using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class RackModel
    { 
        public int id { get; set; }
        public string rack_name { get; set; }
        public int capacity { get; set; }
        public int quantity { get; set; }
    }
}