﻿using atAcc.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atAcc.Models.ViewModels;
using atAcc.Models.Join;

namespace atAcc.Controllers
{
    public class InvoiceController : Controller
    {
        crm_iktisadEntities entityOBJ = new crm_iktisadEntities();
        // GET: Invoice
        public ActionResult InvoiceView()
        {
            return View();
        }
        public ActionResult ViewInvoice()
        {
            string invoice_id = Request["invoice_id"];
            string invoice_type = Request["invoice_type"];
            string invoice_start = Request["invoice_start"];
            string invoice_end = Request["invoice_end"];
            if (invoice_end == null || invoice_id == null || invoice_start == null || invoice_end == null)
            {
                var data = entityOBJ.tbl_invoice.ToList();
                ViewBag.data = data;
            }
            else
            {
                var query = entityOBJ.tbl_invoice.Where(a => a.id >= 1);
                if (invoice_id != "")
                {
                    query = query.Where(a => a.invoice_id == invoice_id);
                }
                if (invoice_type != "0")
                {
                    query = query.Where(a => a.type == invoice_type);
                }
                if (invoice_start != "" && invoice_end != "")
                {
                    query = query.Where(a => a.date >= Convert.ToDateTime(invoice_start) && a.date <= Convert.ToDateTime(invoice_end));
                }
                var data = query.ToList();
                ViewBag.data = data;
            }

            return View();
        }
        public ActionResult PurchaseInvoiceView()
        {
            var accnts = entityOBJ.tbl_accountLedgerDtls.ToList();
            ViewBag.data = accnts;
            string id = Request.QueryString["id"];
            if (id != null)
            {
                ViewBag.id = id;
                ViewBag.name = "id";
                ViewBag.type = "Edit Invoice";
                ViewBag.action = "/Invoice/UpdateEmployee";
                int parse = int.Parse(id);
                var invoice = entityOBJ.tbl_invoice
                .Where(a => a.id == parse).ToList();
                ViewBag.tableData = invoice;
                var invoice_id = invoice[0].invoice_id;
                if (invoice[0].acc_id == "custom")
                {
                    var custome = entityOBJ.tbl_custominvoice.Where(m => m.invoice_id == invoice_id).ToList();
                    ViewBag.custome = custome;
                }
                var products = entityOBJ.tbl_purchaseInvoice.Where(m => m.invoice_id == id).ToList();
                ViewBag.products = products;
                return View();
            }
            else
            {
                ViewBag.products = null;
                ViewBag.tableData = null;
                ViewBag.custome = null;
                ViewBag.id = null;
                ViewBag.name = null;
                ViewBag.action = "/Invoice/getInvoice";
                ViewBag.type = "Add Invoice";
                return View();
            }
        }
        public ActionResult SalesInvoiceView()
        {
            return View();
        }
        public ActionResult PurchaseReturnView()
        {
            return View();
        }
        public ActionResult SalesReturnView()
        {
            return View();
        }
        public JsonResult DeleteInvoice(string value)
        {
            string status;
            int id = Convert.ToInt32(value);
            string idint = value;
            var singleRec = entityOBJ.tbl_invoice.FirstOrDefault(x => x.id == id);
            entityOBJ.tbl_invoice.Remove(singleRec);

            List<tbl_purchaseInvoice> deps = entityOBJ.tbl_purchaseInvoice.Where(x => x.invoice_id == idint).ToList();
            entityOBJ.tbl_purchaseInvoice.RemoveRange(deps);
            entityOBJ.SaveChanges();
            if (entityOBJ.SaveChanges() > 0)
            {
                status = "success";
            }
            else
            {
                status = "failed";
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getProductCode(string keyword)
        {
            var codes = from m in entityOBJ.tbl_productDtls
                        where m.product_code.StartsWith(keyword)
                        select m.product_code;
            return Json(codes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProduct(string id)
        {
            List<tbl_productDtls> productdtl = entityOBJ.tbl_productDtls.Where(m => m.product_code == id).ToList();
            List<tbl_taxInfo> taxinfo = entityOBJ.tbl_taxInfo.ToList();

            var products = from e in productdtl
                           join d in taxinfo on e.tax_type equals d.id into table1
                           from d in table1.ToList()
                           select new ProductDtlsModel
                           {
                               products = e,
                               taxprcnt = d.taxprcnt.ToString()
                           };

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getInvoice(InvoiceBasic obj)
        {
            var id = "";
            tbl_invoice objuser = new tbl_invoice();
            string voucher = obj.voucher;
            string invoice_id = voucher;
            string actionType = obj.actionType;
            if (actionType == "insert")
            {
                objuser.invoice_id = invoice_id;
                objuser.voucher = obj.voucher;
                objuser.voucherArabic = obj.voucherArabic;
                objuser.cash_party_acc = obj.cash_party_acc;
                objuser.type = obj.type;
                objuser.acc_id = obj.acc_id;
                objuser.remarks = obj.remarks;
                objuser.depot_loc = obj.depot_loc;
                objuser.purchase_acc = obj.purchase_acc;
                objuser.date = obj.date;
                objuser.party_vno = obj.party_vno;
                objuser.spl_disc = obj.spl_disc;
                objuser.gst = obj.gst;
                objuser.addl_per = obj.addl_per;
                objuser.invoice_type = "2";
                objuser.created_at = DateTime.Now;
                objuser.updated_at = DateTime.Now;
                objuser.tot_net = obj.tot_net;
                objuser.tot_qty = obj.tot_qty;
                objuser.tot_gross = obj.tot_gross;
                entityOBJ.tbl_invoice.Add(objuser);
                if (entityOBJ.SaveChanges() > 0)
                {
                    id = Convert.ToString(entityOBJ.tbl_invoice.Max(item => item.id));
                    if (obj.acc_id == "custom")
                    {
                        tbl_custominvoice customeOBJ = new tbl_custominvoice();
                        customeOBJ.invoice_id = obj.voucher;
                        customeOBJ.party_name = obj.party_name;
                        customeOBJ.party_name = obj.party_name;
                        customeOBJ.party_vno = obj.party_vno;
                        entityOBJ.tbl_custominvoice.Add(customeOBJ);
                        entityOBJ.SaveChanges();
                    }
                }
                else
                {
                    id = "failed";
                }
            }
            else
            {
                id = Convert.ToString(obj.id);
                int idint = obj.id;
                var singleRec = entityOBJ.tbl_invoice.FirstOrDefault(x => x.id == idint);
                entityOBJ.tbl_invoice.Remove(singleRec);

                List<tbl_purchaseInvoice> deps = entityOBJ.tbl_purchaseInvoice.Where(x => x.invoice_id == id).ToList();
                entityOBJ.tbl_purchaseInvoice.RemoveRange(deps);

                entityOBJ.SaveChanges();
                objuser.invoice_id = invoice_id;
                objuser.voucher = obj.voucher;
                objuser.voucherArabic = obj.voucherArabic;
                objuser.cash_party_acc = obj.cash_party_acc;
                objuser.type = obj.type;
                objuser.acc_id = obj.acc_id;
                objuser.remarks = obj.remarks;
                objuser.depot_loc = obj.depot_loc;
                objuser.purchase_acc = obj.purchase_acc;
                objuser.date = obj.date;
                objuser.party_vno = obj.party_vno;
                objuser.spl_disc = obj.spl_disc;
                objuser.gst = obj.gst;
                objuser.addl_per = obj.addl_per;
                objuser.invoice_type = "2";
                objuser.created_at = DateTime.Now;
                objuser.updated_at = DateTime.Now;
                objuser.tot_net = obj.tot_net;
                objuser.tot_qty = obj.tot_qty;
                objuser.tot_gross = obj.tot_gross;
                entityOBJ.tbl_invoice.Add(objuser);
                if (entityOBJ.SaveChanges() > 0)
                {
                    id = Convert.ToString(entityOBJ.tbl_invoice.Max(item => item.id));
                    if (obj.acc_id == "custom")
                    {
                        tbl_custominvoice customeOBJ = new tbl_custominvoice();
                        customeOBJ.invoice_id = obj.voucher;
                        customeOBJ.party_name = obj.party_name;
                        customeOBJ.party_name = obj.party_name;
                        customeOBJ.party_vno = obj.party_vno;
                        entityOBJ.tbl_custominvoice.Add(customeOBJ);
                        entityOBJ.SaveChanges();
                    }
                }
                else
                {
                    id = "failed";
                }

            }

            return Json(id, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getInvoiceDetails(PurchaseInvoice obj)
        {
            string status;
            tbl_purchaseInvoice purchaseInvoice = new tbl_purchaseInvoice();
            purchaseInvoice.invoice_id = obj.id;
            purchaseInvoice.code = obj.code;
            purchaseInvoice.product_name = obj.product_name;
            purchaseInvoice.quantity = obj.quantity;
            purchaseInvoice.amount = obj.amount;
            purchaseInvoice.spl_per = obj.spl_per;
            purchaseInvoice.spl_disc = obj.spl_disc;
            purchaseInvoice.addl_disc = obj.addl_disc;
            purchaseInvoice.total_tax = obj.total_tax;
            purchaseInvoice.net_amt = obj.net_amt;
            purchaseInvoice.gst_per = obj.gst_per;
            purchaseInvoice.discount = obj.discount;
            purchaseInvoice.gst = obj.gst;
            purchaseInvoice.mrp = obj.mrp;
            purchaseInvoice.imeno = obj.imeno;
            entityOBJ.tbl_purchaseInvoice.Add(purchaseInvoice);
            if (entityOBJ.SaveChanges() > 0)
            {
                status = "true";

            }
            else
            {
                status = "true";
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewInvoices(string invoiceID)
        {
            var Basic = entityOBJ.tbl_invoice.Where(e => e.invoice_id == invoiceID).ToList();
            string id = Convert.ToString(Basic[0].id);
            var Products = entityOBJ.tbl_purchaseInvoice.Where(e => e.invoice_id == id).ToList();
            var data = new { Basic = Basic, Products = Products };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListPurchaseInvoice(string type)
        {
            var invoice = entityOBJ.tbl_invoice.Where(m => m.type == type).ToList();

            return Json(invoice, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadProducts(string id)
        {
            var products = entityOBJ.tbl_purchaseInvoice.Where(m => m.invoice_id == id).ToList();
            ViewBag.data = products;
            return PartialView("../_PurchaseInvoiceProducts");
        }

        public JsonResult getInvoiceList()
        {
            var products = entityOBJ.tbl_invoice.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getInvoiceListFilter(string id)
        {
            var products = entityOBJ.tbl_invoice.Where(m => m.invoice_id == id).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Print()
        {
            string param1 = this.Request.QueryString["id"];
            ViewBag.id = param1;
            return View();
        }

        public JsonResult InvoicePrint(string id)
        {
            string param1 = this.Request.QueryString["id"];
            List<tbl_invoice> Invoice = entityOBJ.tbl_invoice.Where(m => m.invoice_id == id).ToList();
            List<tbl_purchaseInvoice> PurchaseInvoice = entityOBJ.tbl_purchaseInvoice.ToList();

            var data = from e in Invoice
                       join d in PurchaseInvoice on e.id equals Convert.ToInt32(d.invoice_id) into table1
                       from d in table1.ToList()
                       select new JoinPurchaseInvoice
                       {
                           tbl_invoice = e,
                           tbl_purchaseInvoice = d
                       };
            ViewBag.data = data;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult invoiceCustome(string acc_id)
        {
            var data = entityOBJ.tbl_custominvoice.Where(m => m.invoice_id == acc_id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public JsonResult invoiceAccount(string acc_id)
        {
            var data = entityOBJ.tbl_accountMoreDtls.Where(m => m.ledger_id == acc_id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}


