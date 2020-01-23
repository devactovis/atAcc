using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atAcc.Models.DB;
using atAcc.Models.ViewModels;
using System.Data.SqlClient;
using System.Data.Entity;

namespace atAcc.Controllers
{
    public class CompanyController : Controller
    {
        crm_iktisadEntities objentity = new crm_iktisadEntities();
        //string connectionString = "Data Source=crmasp.database.windows.net;Initial Catalog=crm_iktisad;Persist Security Info=True;User ID=crm_admin;Password=Actovis@123";
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


                string compname = objCompany.comp_name;
                string yr = DateTime.Now.Year.ToString();
                string crmname = "crm";
                string compid = compname + "_" + yr + "_" + crmname;
                objuser.comp_id = compid;
                objuser.holder_id = 24;
                objuser.comp_name = objCompany.comp_name;
                objuser.comp_url = objCompany.comp_url;
                objuser.comp_addr = objCompany.comp_addr;
                objuser.city = objCompany.city;
                objuser.state = objCompany.state;
                objuser.country = objCompany.country;
                objuser.postal_code = objCompany.postal_code;
                objuser.tel_no = objCompany.tel_no;
                objuser.comp_email = objCompany.comp_email;
                objuser.mob_no = objCompany.mob_no;
                objuser.comp_fax = objCompany.comp_fax;
                objuser.personal_site = objCompany.personal_site;
                objuser.acc_no = objCompany.acc_no;
                objuser.tax_no = objCompany.tax_no;
                objuser.vat_no = objCompany.vat_no;
                objuser.vat_pswd = objCompany.vat_pswd;
                objuser.currency = objCompany.currency;
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
        public JsonResult getCompDtls(int id)
        {
            return Json(objentity.tbl_companyDetails.Where(e => e.id == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult updateCompany(CompanyDetails objComp)
        {
            Int32 StudentId = 3;
            var StudentData = objentity.tbl_companyDetails.Where(x => x.id == StudentId).FirstOrDefault();
            if (StudentData != null)
            {
                StudentData.comp_name = objComp.comp_name;
                StudentData.comp_url = objComp.comp_url;
                StudentData.comp_addr = objComp.comp_addr;
                StudentData.city = objComp.city;
                StudentData.state = objComp.state;
                StudentData.country = objComp.country;
                StudentData.postal_code = objComp.postal_code;
                StudentData.tel_no = objComp.tel_no;
                StudentData.comp_email = objComp.comp_email;
                StudentData.mob_no = objComp.mob_no;
                StudentData.comp_fax = objComp.comp_fax;
                StudentData.personal_site = objComp.personal_site;
                StudentData.acc_no = objComp.acc_no;
                StudentData.tax_no = objComp.tax_no;
                StudentData.vat_no = objComp.vat_no;
                StudentData.vat_pswd = objComp.vat_pswd;
                StudentData.currency = objComp.currency;
                objentity.Entry(StudentData).State = EntityState.Modified;
                objentity.SaveChanges();
            }
            return RedirectToAction("ViewCompany");
        }
    }
}