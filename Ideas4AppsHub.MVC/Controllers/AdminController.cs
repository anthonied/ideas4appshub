using Ideas4AppsHub.Domain;
using Ideas4AppsHub.MVC.Models;
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

        public ActionResult ManageBusiness() 
        {
            var businessModel = new BusinessModel()
            {
                Status = new Status(),
                Category = new Category(),
            };

            return View(businessModel);
        }

        [HttpPost]
        public ActionResult CreateBusiness(string name) 
        {
            return View();
        }
    }
}
