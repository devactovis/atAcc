using atAcc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace atAcc.Controllers
{
    public class LoginController : Controller
    {
        string username = "admin";
        string passwd = "admin123";

        // GET: Login

        public ActionResult LoginView()
        {
                return View();
          
            
          
        }
       
        [HttpPost]
        public ActionResult AjaxMethod(string email, string password)
        {
            UserProfile log = new UserProfile
            {
                EmailId = email,
                Password = password
            };

            if (email == username && password == passwd)
            {
                //return Json(Redirect("~/Views/Company/CompanyView.html"));
                return RedirectToAction("Index", "Dash");

            }
            else
            {
                Response.Write("Invaild username and password");
            }
            return View();
            
        }
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always  
                //required NameSpace: using System.Web.Security;  
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication  
                //required NameSpace: using System.Security.Principal;  
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place  
                // this clears the Request.IsAuthenticated flag since this triggers a new request  
                return View();
            }
            catch
            {
                throw;
            }
        }



    }
}