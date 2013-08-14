using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ideas4AppsHub.MVC.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageBusiness() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBusiness(string name) {
            return View();
        }
    }
}
