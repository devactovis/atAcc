using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atAcc.Models.AjaxModels;
using atAcc.Models.DB;
using System.Web.Services;
using Newtonsoft.Json;
using System.Collections;

namespace atAcc.Controllers
{
    public class InventoryController : Controller
    {
        crm_iktisadEntities entityOBJ = new crm_iktisadEntities();
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DepotwiseInventoryView()
        {
            return View();
        }

       
        [HttpPost]
        public JsonResult Sample_ajax(Inventory_filter_values filter)
        {

            string fltertype = filter.fltertype;    
            DateTime datefrom = filter.datefrom;
            DateTime dateto = filter.dateto;
            string productname = filter.productname;
            string productgroup = filter.productgroup;
            var query = entityOBJ.tbl_productDtls.Where(a => a.id >= 1);
            if(fltertype == "1")
            {
                query = query.Where(a => a.quantity <=5);
            }
            if(fltertype == "2")
            {
                query = query.Where(a => a.created_at >= filter.datefrom && a.created_at <filter.dateto && a.product_group==filter.productgroup);
            }
            if (fltertype == "3")
            {
                query = query.Where(a => a.product_name == filter.productname);
            }
            if (fltertype == "4")
            {
                query = query.Where(a => a.product_group == filter.productgroup);
            }
            var Products = query
            .Select(x => new { x.product_code, x.product_name, x.product_group,x.product_color,x.base_unit,x.hsn_code,x.purchase_rate,x.sales_rate,x.sales_percent,x.mrp }).ToList();
            return Json(Products, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NegativeStockView()
        {
            return View();
        }
        public ActionResult StockLedgerView()
        {
            return View();
        }
        public ActionResult StockListView()
        {
            return View();
        }
        public ActionResult TransactionAnalysisView()
        {
            return View();
        }
        public ActionResult FastMovingItemView()
        {
            return View();
        }
        public ActionResult StockAgeingView()
        {
            return View();
        }
        public ActionResult StockLevelView()
        {
            return View();
        }
        public ActionResult StockValuationView()
        {
            return View();
        }
    }
}