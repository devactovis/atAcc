using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class InvoiceBasic
    {
        public int id { get; set; }
        public string invoice_id { get; set; }
        public string voucher { get; set; }
        public string cash_party_acc { get; set; }
        public string voucherArabic { get; set; }
        public string type { get; set; }
        public string acc_id { get; set; }
        public string remarks { get; set; }
        public string depot_loc { get; set; }
        public string purchase_acc { get; set; }
        public DateTime date { get; set; }
        public DateTime dateArabic { get; set; }
        public string party_vno { get; set; }
        public string spl_disc { get; set; }
        public string gst { get; set; }
        public string addl_per { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string tot_qty { get; set; }
        public string tot_gross { get; set; }
        public string tot_net { get; set; }
        public string party_name { get; set; }
        public string party_namearabic { get; set; }

        public string actionType { get; set; }
    }
}