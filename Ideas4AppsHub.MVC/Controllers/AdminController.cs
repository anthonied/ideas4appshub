using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ideas4AppsHub.Repositories;
using Ideas4AppsHub.Domain;

namespace Ideas4AppsHub.MVC.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private BusinessRepository _businessRepository = new BusinessRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageBusiness() {
            return View();
        }

        public ActionResult UpdateBusiness() {
            return View();
        }

        [AllowAnonymous]
        public JsonResult CreateBusiness(string name, string description, string telephone, string address1, string address2, string address3, string postalcode, string status, string businesshours, string tags, string weburl, string category, bool active) 
        {
            _businessRepository.CreateBusiness(name);

            var data = new
            {
                isOk = true
            };

            return new JsonResult { Data = data };
        }
    }
}
