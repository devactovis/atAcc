using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace atAcc.Controllers
{
    public class InitialiseController : Controller
    {
        // GET: Initialise
        public ActionResult InitialiseBudgetView()
        {
            return View();
        }
        public ActionResult InitialiseDepositView()
        {
            return View();
        }
        public ActionResult InitialiseCreditCardView()
        {
            return View();
        }
    }
}