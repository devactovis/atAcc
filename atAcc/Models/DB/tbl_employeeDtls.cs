//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace atAcc.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_employeeDtls
    {
        public int id { get; set; }
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string department { get; set; }
        public string type { get; set; }
        public string emp_addr { get; set; }
        public string city { get; set; }
        public Nullable<int> postal_code { get; set; }
        public string state { get; set; }
        public string nationality { get; set; }
        public string remarks { get; set; }
        public Nullable<long> tel_no { get; set; }
        public string email_id { get; set; }
        public Nullable<long> passport_no { get; set; }
        public string visa_status { get; set; }
        public Nullable<System.DateTime> psprt_expdate { get; set; }
        public Nullable<System.DateTime> visa_date { get; set; }
        public Nullable<System.DateTime> join_date { get; set; }
        public Nullable<int> is_contract { get; set; }
        public Nullable<System.DateTime> contract_end { get; set; }
        public Nullable<int> is_employee { get; set; }
    }
}
