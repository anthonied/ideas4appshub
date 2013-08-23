using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using log4net;
using UserAuthenticationDomain.Repository;
using SolutionServerWebSession;

namespace Ideas4AppsHub.MVC.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult RegisterNewAccount(string fullName, string email, string password)
        {
            FlatFileRepository flatFileRepo = new FlatFileRepository();
            if (flatFileRepo.RegisterNewAccount(fullName, email, password, 0))
            {
                var data = new { isOk = true, errorMessage = "Registration Successfull" };
                return new JsonResult { Data = data };
            }
            else
            {
                var data = new { isOk = false, errorMessage = "Registration Failed" };
                return new JsonResult { Data = data };
            }
        }

        [AllowAnonymous]
        public JsonResult CheckLogin(string fullName, string email, string password)
        {
            _log.Debug("Checklogin called");
            FlatFileRepository flatFileRepo = new FlatFileRepository();
            if (flatFileRepo.CheckLogin(fullName, email, password))
            {
                RegisteredUserBase user = new RegisteredUserBase()
                {
                    UserName = fullName,
                    Email = email,
                    Password = password
                };
                UserSession.LoggedInUser = user;
                var data = new { isOk = true, errorMessage = "User login successfull" };
                return new JsonResult { Data = data };
            }
            else
            {
                var data = new { isOk = false, errorMessage = "User login failed" };
                return new JsonResult { Data = data };
            }
        }
    }
}
