using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class AccountLedgerDtls
    {
        public int id { get; set; }
        public Nullable<int> grp_id { get; set; }
        public Nullable<int> ledger_code { get; set; }
        public string ledger_name { get; set; }
        public string under { get; set; }
        public Nullable<int> discount { get; set; }
    }
}