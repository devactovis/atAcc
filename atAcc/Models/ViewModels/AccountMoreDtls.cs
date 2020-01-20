using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atAcc.Models.DB;

namespace atAcc.Models.ViewModels
{
    public class AccountMoreDtls
    {
        public int id { get; set; }
        public Nullable<int> grp_id { get; set; }
        public string contact_person { get; set; }
        public string contact_personArabic { get; set; }
        public string addr1 { get; set; }
        public string addr1Arabic { get; set; }
        public string addr2 { get; set; }
        public string addr2Arabic { get; set; }
        public string city { get; set; }
        public string cityArabic { get; set; }
        public string postal_code { get; set; }
        public string tel_no { get; set; }
        public string acc_id { get; set; }
        public string mob_no { get; set; }
        public string email { get; set; }
        public string vat_no { get; set; }
        public string tax_no { get; set; }
        public string gst_no { get; set; }
        public string state { get; set; }
        public string state_code { get; set; }
        public string ledger_id { get; set; }

    }

}

