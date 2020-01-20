using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atAcc.Models.DB;

namespace atAcc.Models.Join
{
    public class JoinPurchaseInvoice
    {
        public tbl_invoice tbl_invoice { get; set; }
        public tbl_purchaseInvoice tbl_purchaseInvoice { get; set; }
    }
}