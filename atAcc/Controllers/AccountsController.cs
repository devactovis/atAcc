using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atAcc.Models.DB;
using System.Data.SqlClient;
using atAcc.Models.ViewModels;
using System.Diagnostics;

namespace atAcc.Controllers
{
    public class AccountsController : Controller
    {
        crm_iktisadEntities entityOBJ = new crm_iktisadEntities();
        // GET: Accounts
        public ActionResult AccountView()
        {
            tbl_accountGroupDtls tbl_accountGroupDtlsOBJ = new tbl_accountGroupDtls();
            var tableData = entityOBJ.tbl_accountGroupDtls.ToList();
            ViewBag.data = tableData;
            return View();
        }
        [HttpPost]
        public ActionResult AccountGroup(string groupname, string under)
        {
            //object status = null;
            tbl_accountGroupDtls tableAccountGroupDtls = new tbl_accountGroupDtls();
            tableAccountGroupDtls.grp_name = groupname;
            tableAccountGroupDtls.under = under;
            entityOBJ.tbl_accountGroupDtls.Add(tableAccountGroupDtls);
            if (entityOBJ.SaveChanges() > 0)
            {
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]

        public ActionResult SaveLedger(AccountLedgerDtls AccountLedgerDtls)
        {
            var id = "";
            tbl_accountLedgerDtls tbl_accountLegerOBJ = new tbl_accountLedgerDtls();
            tbl_accountLegerOBJ.grp_id = AccountLedgerDtls.grp_id;
            tbl_accountLegerOBJ.ledger_code = AccountLedgerDtls.ledger_code;
            tbl_accountLegerOBJ.ledger_name = AccountLedgerDtls.ledger_name;
            tbl_accountLegerOBJ.under = AccountLedgerDtls.under;
            tbl_accountLegerOBJ.discount = AccountLedgerDtls.grp_id;
            entityOBJ.tbl_accountLedgerDtls.Add(tbl_accountLegerOBJ);
            if (entityOBJ.SaveChanges() > 0)
            {
                id = Convert.ToString(entityOBJ.tbl_accountLedgerDtls.Max(item => item.id));
                return Json(id, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]

        public ActionResult ledgerMoreDetails(AccountMoreDtls AccountMoreDtls)
        {
            tbl_accountMoreDtls tbl_accountMoreDtlsOBJ = new tbl_accountMoreDtls();
            tbl_accountMoreDtlsOBJ.grp_id = AccountMoreDtls.grp_id;
            tbl_accountMoreDtlsOBJ.contact_person = AccountMoreDtls.contact_person;
            tbl_accountMoreDtlsOBJ.contact_personArabic = AccountMoreDtls.contact_personArabic;
            tbl_accountMoreDtlsOBJ.addr1 = AccountMoreDtls.addr1;
            tbl_accountMoreDtlsOBJ.addr1Arabic = AccountMoreDtls.addr1Arabic;
            tbl_accountMoreDtlsOBJ.addr2 = AccountMoreDtls.addr2;
            tbl_accountMoreDtlsOBJ.addr2Arabic = AccountMoreDtls.addr2Arabic;
            tbl_accountMoreDtlsOBJ.city = AccountMoreDtls.city;
            tbl_accountMoreDtlsOBJ.cityArabic = AccountMoreDtls.cityArabic;
            tbl_accountMoreDtlsOBJ.postal_code = AccountMoreDtls.postal_code;
            tbl_accountMoreDtlsOBJ.tel_no = AccountMoreDtls.tel_no;
            tbl_accountMoreDtlsOBJ.acc_id = AccountMoreDtls.acc_id;
            tbl_accountMoreDtlsOBJ.mob_no = AccountMoreDtls.mob_no;
            tbl_accountMoreDtlsOBJ.email = AccountMoreDtls.email;
            tbl_accountMoreDtlsOBJ.vat_no = AccountMoreDtls.vat_no;
            tbl_accountMoreDtlsOBJ.tax_no = AccountMoreDtls.tax_no;
            tbl_accountMoreDtlsOBJ.gst_no = AccountMoreDtls.gst_no;
            tbl_accountMoreDtlsOBJ.state = AccountMoreDtls.state;
            tbl_accountMoreDtlsOBJ.ledger_id = AccountMoreDtls.ledger_id;
            tbl_accountMoreDtlsOBJ.state_code = AccountMoreDtls.state_code;
            entityOBJ.tbl_accountMoreDtls.Add(tbl_accountMoreDtlsOBJ);
            if (entityOBJ.SaveChanges() > 0)
            {
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ViewAllAccount()
        {
            List<tbl_accountLedgerDtls> tbl_accountLedgerDtls = entityOBJ.tbl_accountLedgerDtls.ToList();
            List<tbl_accountMoreDtls> AccountMoreDtls = entityOBJ.tbl_accountMoreDtls.ToList();
            List<tbl_accountGroupDtls> GroupDetails = entityOBJ.tbl_accountGroupDtls.ToList();

            var accountsledger = "asa";
            return View(accountsledger);
        }

    }
}