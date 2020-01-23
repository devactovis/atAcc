using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atAcc.Models.DB;

namespace atAcc.Models.ViewModels
{
    public class AccountsParent
    {
        public  tbl_accountLedgerDtls accountledger { get; set; }
        public tbl_accountMoreDtls accountmore { get; set; }
        public tbl_accountGroupDtls groupdetails { get; set; }
    }
}