using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atAcc.Models.DB;
using atAcc.Models.ViewModels;
using System.Data.SqlClient;

namespace atAcc.Controllers
{
    public class CompanyController : Controller
    {
        crm_iktisadEntities objentity = new crm_iktisadEntities();
        string connectionString = "Data Source=crmasp.database.windows.net;Initial Catalog=crm_iktisad;Persist Security Info=True;User ID=crm_admin;Password=Actovis@123";
        // GET: Company
        public ActionResult CompanyView()
        {
            return View();
        }
        public ActionResult ViewCompany()
        {
            return View();
        }
        public ActionResult CompanyDetailView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCompany(CompanyDetails objCompany)
        {
            if (ModelState.IsValid)
            {
                tbl_companyDetails objuser = new Models.DB.tbl_companyDetails();
                string compname = objCompany.CompName;
                string yr = DateTime.Now.Year.ToString();
                string crmname = "crm";
                string compid = compname + "_" + yr + "_" + crmname;
                objuser.comp_name = objCompany.CompName;
                objuser.comp_url = objCompany.CompUrl;
                objuser.comp_addr = objCompany.CompAddr;
                objuser.city = objCompany.City;
                objuser.state = objCompany.State;
                objuser.postal_code = objCompany.PostalCode;
                objuser.tel_no = objCompany.TelphoneNo;
                objuser.comp_email = objCompany.CompEmail;
                objuser.mob_no = objCompany.MobNo;
                objuser.comp_fax = objCompany.CompFax;
                objuser.comp_site = objCompany.CompSite;
                objuser.acc_no = objCompany.AccNo;
                objuser.tax = objCompany.Tax;
                objuser.vat_no = objCompany.VatNo;
                objuser.vat_pswd = objCompany.VatPswd;
                objentity.tbl_companyDetails.Add(objuser);
                if (objentity.SaveChanges() > 0)
                {
                    return RedirectToAction("CompanyView", "Company");
                }
                else
                {
                    ViewBag.errormessage = "Failed";
                }
                return RedirectToAction("CompanyView", "Company");
            }
            return RedirectToAction("CompanyView", "Company");
        }
    }
}