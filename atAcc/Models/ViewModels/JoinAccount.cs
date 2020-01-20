using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atAcc.Models.DB;

namespace atAcc.Models.ViewModels
{
    public class JoinAccount
    {
        public tbl_accountLedgerDtls AccountLedgerDtls { get; set; }
        public tbl_accountMoreDtls AccountMoreDtls { get; set; }

        public tbl_accountGroupDtls AccountGroupDtls { get; set; }
    }
}