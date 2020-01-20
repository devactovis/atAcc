using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public class CompanyAccountDtls
    {
        public int AccId { get; set; }
        public int CompId { get; set; }
        public int AccNo { get; set; }
        public int Currency { get; set; }
        public int Tax { get; set; }
        public int VatNo { get; set; }
        public string VatPswd { get; set; }
    }
}