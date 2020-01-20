using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class AccountLedger
    {
        public int Id { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public string Under { get; set; }
        public int Discount { get; set; }
    }
}