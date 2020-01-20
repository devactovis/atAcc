using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class InvoiceParent
    {
        public InvoiceBasic InvoiceBasic { get; set; }

        public PurchaseInvoice InvoicePurchase { get; set; }
    }
}