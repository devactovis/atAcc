using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atAcc.Models.DB;

namespace atAcc.Models.ViewModels
{
    public class ProductDtlsModel
    {
        public tbl_productDtls products {get; set; }
        public string taxprcnt { get; set; }

    }
}