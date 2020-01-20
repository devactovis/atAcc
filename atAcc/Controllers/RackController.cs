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
    public class RackController : Controller
    {
        crm_iktisadEntities objEntity = new crm_iktisadEntities();
        // GET: Rack
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRack(RackModel objRack)
        {
            if (ModelState != null)
            {
                if (ModelState.IsValid)
                {
                    tbl_rackInfo objTable = new Models.DB.tbl_rackInfo();
                    objTable.rack_name = objRack.rack_name;
                    objTable.capacity = objRack.capacity;
                    objTable.remaining = objRack.capacity;

                    objEntity.tbl_rackInfo.Add(objTable);
                    objEntity.SaveChanges();

                }


            }

            return RedirectToAction("Index", "Rack");
        }

        public ActionResult ViewRack()
        {
            var racks = objEntity.tbl_rackInfo.Select(m => new { m.rack_name, m.id }).ToList();
            ViewBag.data = racks;
            return View();
        }
    }
}