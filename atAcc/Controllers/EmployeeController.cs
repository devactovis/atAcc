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
    public class EmployeeController : Controller
    {
        crm_iktisadEntities objentity = new crm_iktisadEntities();
        // GET: Employee


        [HttpGet]
        public ActionResult EmployeeView()
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                ViewBag.id = id;
                ViewBag.name = "id";
                ViewBag.type = "Edit Employee";
                ViewBag.action = "/Employee/UpdateEmployee";
                int parse = int.Parse(id);
                var objEmployee = objentity.tbl_employeeDtls
                .Where(a => a.id == parse).ToList();
                EmployeeDetails tblOBJ = new EmployeeDetails();
                tblOBJ.emp_id = objEmployee[0].emp_id;
                tblOBJ.emp_name = objEmployee[0].emp_name;
                tblOBJ.department = objEmployee[0].department;
                tblOBJ.type = objEmployee[0].type;
                tblOBJ.emp_addr = objEmployee[0].emp_addr;
                tblOBJ.city = objEmployee[0].city;
                tblOBJ.postal_code = objEmployee[0].postal_code;
                tblOBJ.state = objEmployee[0].state;
                tblOBJ.nationality = objEmployee[0].nationality;
                tblOBJ.remarks = objEmployee[0].remarks;
                tblOBJ.tel_no = objEmployee[0].tel_no;
                tblOBJ.email_id = objEmployee[0].email_id;
                tblOBJ.passport_no = objEmployee[0].passport_no;
                tblOBJ.visa_status = objEmployee[0].visa_status;
                tblOBJ.psprt_expdate = objEmployee[0].psprt_expdate;
                tblOBJ.visa_date = objEmployee[0].visa_date;
                tblOBJ.join_date = objEmployee[0].join_date;
                tblOBJ.is_contract = Convert.ToInt32(objEmployee[0].is_contract);
                tblOBJ.contract_end = objEmployee[0].contract_end;
                tblOBJ.is_employee = Convert.ToInt32(objEmployee[0].is_employee);
                return View(tblOBJ);
            }
            else
            {
                ViewBag.id = "";
                ViewBag.name = "";
                ViewBag.action = "/Employee/SaveEmployee";
                ViewBag.type = "Add Employee";
                return View();
            }

        }



        [HttpPost]
        public ActionResult SaveEmployee(EmployeeDetails objEmployee)
        {
            //if(ModelState.IsValid)
            // {
            tbl_accounts accOBJ = new tbl_accounts();
            accOBJ.username = objEmployee.username;
            accOBJ.password = objEmployee.paswd;
            accOBJ.status = "1";
            accOBJ.role = "employee";
            objentity.tbl_accounts.Add(accOBJ);


            if (objentity.SaveChanges() > 0)
            {

                int id = objentity.tbl_accounts.Max(item => item.id);

                tbl_employeeDtls tblOBJ = new Models.DB.tbl_employeeDtls();
                tblOBJ.emp_id = objEmployee.emp_id;
                tblOBJ.holder_id = id;
                tblOBJ.emp_name = objEmployee.emp_name;
                tblOBJ.department = objEmployee.department;
                tblOBJ.type = objEmployee.type;
                tblOBJ.emp_addr = objEmployee.emp_addr;
                tblOBJ.city = objEmployee.city;
                tblOBJ.postal_code = objEmployee.postal_code;
                tblOBJ.state = objEmployee.state;
                tblOBJ.nationality = objEmployee.nationality;
                tblOBJ.remarks = objEmployee.remarks;
                tblOBJ.tel_no = objEmployee.tel_no;
                tblOBJ.email_id = objEmployee.email_id;
                tblOBJ.passport_no = objEmployee.passport_no;
                tblOBJ.visa_status = objEmployee.visa_status;
                tblOBJ.psprt_expdate = objEmployee.psprt_expdate;
                tblOBJ.visa_date = objEmployee.visa_date;
                tblOBJ.join_date = objEmployee.join_date;
                tblOBJ.is_contract = objEmployee.is_contract;
                tblOBJ.contract_end = objEmployee.contract_end;
                tblOBJ.is_employee = objEmployee.is_employee;
                tblOBJ.username = objEmployee.username;
                tblOBJ.paswd = objEmployee.paswd;
                objentity.tbl_employeeDtls.Add(tblOBJ);
                objentity.SaveChanges();

                // return RedirectToAction("EmployeeView", "Employee");
            }
            //}
            return this.RedirectToAction("EmployeeView", "Employee");
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeDetails objEmployee)
        {

            var tblOBJ = objentity.tbl_employeeDtls.Where(a => a.id == objEmployee.id).FirstOrDefault();
            if (tblOBJ != null)
            {
                tblOBJ.emp_id = objEmployee.emp_id;
                tblOBJ.emp_name = objEmployee.emp_name;
                tblOBJ.department = objEmployee.department;
                tblOBJ.type = objEmployee.type;
                tblOBJ.emp_addr = objEmployee.emp_addr;
                tblOBJ.city = objEmployee.city;
                tblOBJ.postal_code = objEmployee.postal_code;
                tblOBJ.state = objEmployee.state;
                tblOBJ.nationality = objEmployee.nationality;
                tblOBJ.remarks = objEmployee.remarks;
                tblOBJ.tel_no = objEmployee.tel_no;
                tblOBJ.email_id = objEmployee.email_id;
                tblOBJ.passport_no = objEmployee.passport_no;
                tblOBJ.visa_status = objEmployee.visa_status;
                tblOBJ.psprt_expdate = objEmployee.psprt_expdate;
                tblOBJ.visa_date = objEmployee.visa_date;
                tblOBJ.join_date = objEmployee.join_date;
                tblOBJ.is_contract = objEmployee.is_contract;
                tblOBJ.contract_end = objEmployee.contract_end;
                tblOBJ.is_employee = objEmployee.is_employee;
                objentity.SaveChanges();
            }
            return this.RedirectToAction("viewemployee", "Employee");
        }

        public ActionResult viewemployee()
        {
            var Data = objentity.tbl_employeeDtls.ToList();
            ViewBag.data = Data;
            return View();
        }

        [HttpPost]
        public JsonResult Delete_employee(int id)
        {
            string status;
            var itemToRemove = objentity.tbl_employeeDtls.SingleOrDefault(x => x.id == id); //returns a single item.

            if (itemToRemove != null)
            {
                objentity.tbl_employeeDtls.Remove(itemToRemove);
                objentity.SaveChanges();
                status = "true";
            }
            else
                status = "true";
            return Json(status, JsonRequestBehavior.AllowGet);
        }

    }
}