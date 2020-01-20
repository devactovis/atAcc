using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atAcc.Models.ViewModels;
using atAcc.Models.DB;
using System.Data.SqlClient;

namespace atAcc.Controllers
{
    public class ProductController : Controller
    {
        crm_iktisadEntities entityOBJ = new crm_iktisadEntities();
        // GET: Product
        public ActionResult ProductView()
        {
            
            return View();
        }
        public ActionResult ProductDetailsView()
        {
            var rack_capacity = entityOBJ.tbl_rackInfo
            .Where(a => a.remaining >= 0)
            .Select(x => new { x.rack_name, x.capacity,x.id }).ToList();
            ViewBag.data = rack_capacity;

            var taxdetails = entityOBJ.tbl_taxInfo;
            ViewBag.tax = taxdetails;

            var groups = entityOBJ.tbl_productGroupDetails.Select(m => new { m.group_name, m.id }).ToList();
            ViewBag.groups = groups;
            return View();
        }

        [HttpPost]
        public JsonResult CheckQuantity(int rack_id, string quantity)
        {
            string quntity = quantity;
            int id = rack_id;
            var rack_capacity = entityOBJ.tbl_rackInfo
            .Where(a => a.id == id)
            .Select(x => new { x.remaining }).ToList();
            return Json(rack_capacity, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductGroupView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(AddProduct objProduct)
        {
            if (ModelState.IsValid)
            {
                DateTime dt = DateTime.Now;
                
                tbl_productDtls objproduct = new Models.DB.tbl_productDtls();
                var rack_id = objProduct.rack_id; ;
                objproduct.product_code = objProduct.product_code;
                objproduct.rack_id = objProduct.rack_id;
                objproduct.product_name = objProduct.product_name;
                objproduct.product_group = objProduct.product_group;
                objproduct.product_color = objProduct.product_color;
                objproduct.base_unit = objProduct.base_unit;
                objproduct.tax_type = objProduct.tax_type;
                objproduct.quantity = objProduct.quantity;
                objproduct.description = objProduct.description;
                objproduct.hsn_code = objProduct.hsn_code;
                objproduct.minimum = objProduct.minimum;
                objproduct.reorder = objProduct.reorder;
                objproduct.maximum = objProduct.maximum;
                objproduct.purchase_rate = objProduct.purchase_rate;
                objproduct.sales_rate = objProduct.sales_rate;
                objproduct.sales_percent = objProduct.sales_percent;
                objproduct.mrp = objProduct.mrp;
                objproduct.min_salesrate = objProduct.min_salesrate;
                objproduct.created_at = dt;
                objproduct.updated_at = dt;
                entityOBJ.tbl_productDtls.Add(objproduct);
                if (entityOBJ.SaveChanges() > 0)
                {
                    var obj = entityOBJ.tbl_rackInfo.Where(a => a.id == rack_id).FirstOrDefault();
                    if (obj != null)
                    {
                        var balance= obj.remaining;
                        obj.remaining = balance - objproduct.quantity;
                        entityOBJ.SaveChanges();
                    }
                }
            }
            return this.RedirectToAction("ProductDetailsView", "Product");

        }
        
        [HttpPost]
        public ActionResult SaveProductGroup(AddProductGroup objProductGroup)
        {
            if(ModelState.IsValid)
            {
                tbl_productGroupDetails objTable = new Models.DB.tbl_productGroupDetails();
                objTable.hsn_code = objProductGroup.hsn_code;
                objTable.group_name = objProductGroup.group_name;
                objTable.group_head = objProductGroup.group_head;
                objTable.stock_status = objProductGroup.stock_status;
                entityOBJ.tbl_productGroupDetails.Add(objTable);
                if (entityOBJ.SaveChanges() > 0)
                {
                    ViewBag.errormessage = "user registered successfully";
                }
                else
                {
                    ViewBag.errormessage = "Failed";
                }

            }
            return this.RedirectToAction("ProductGroupView", "Product");

        }
    }
    
}