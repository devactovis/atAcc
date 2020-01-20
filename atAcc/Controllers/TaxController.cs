using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atAcc.Models.DB;
using atAcc.Models.ViewModels;

namespace atAcc.Controllers
{
    public class TaxController : Controller
    {
        crm_iktisadEntities objEntity = new crm_iktisadEntities();
        // GET: Tax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult saveTax(TaxModel tax)
        {
            if (ModelState != null)
            {
                if (ModelState.IsValid)
                {
                    tbl_taxInfo objTax = new Models.DB.tbl_taxInfo();
                    objTax.tax_name = tax.tax_name;
                    objTax.taxprcnt = tax.taxprcnt;
                    objEntity.tbl_taxInfo.Add(objTax);
                    objEntity.SaveChanges();

                }


            }
            return RedirectToAction("Index", "Tax");
        }

        public ActionResult ViewTax()
        {
            //var taxes = objEntity.tbl_taxInfo.Select(m => new { m.tax_name, m.taxprcnt });
            var taxes = objEntity.tbl_taxInfo;
            ViewBag.data = taxes;
            return View();
        }
    }
}