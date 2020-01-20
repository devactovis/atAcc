using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atAcc.Models.ViewModels
{
    public partial class UserProfile
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string name { get; set; }
        public string Password { get; set; }
        public long phone { get; set; }

        public Nullable<bool> IsActive { get; set; }
    }
}