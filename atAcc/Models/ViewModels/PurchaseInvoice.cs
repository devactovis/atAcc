using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class PurchaseInvoice
    {
        public string id { get; set; }
        public string invoice_id { get; set; }
        public string code { get; set; }
        public string product_name { get; set; }
        public string quantity { get; set; }
        public string rate { get; set; }
        public string amount { get; set; }
        public string spl_per { get; set; }
        public string spl_disc { get; set; }
        public string addl_disc { get; set; }
        public string total_tax { get; set; }
        public string net_amt { get; set; }
        public string gst_per { get; set; }
        public string discount { get; set; }
        public string gst { get; set; }
        public string mrp { get; set; }
        public string sticker_qty { get; set; }
        public string imeno { get; set; }
        public string tot_qty { get; set; }
        public string tot_gross { get; set; }
        public string tot_net { get; set; }
    }
}