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
    
    public partial class tbl_creditDebitCard
    {
        public int id { get; set; }
        public string code { get; set; }
        public Nullable<bool> is_active { get; set; }
        public string card_name { get; set; }
    }
}
