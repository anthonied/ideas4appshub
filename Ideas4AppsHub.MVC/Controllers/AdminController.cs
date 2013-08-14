using Ideas4AppsHub.Domain;
using Ideas4AppsHub.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ideas4AppsHub.Repositories;
using System.Collections;
using System.IO;

namespace Ideas4AppsHub.MVC.Controllers
{
   
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        BusinessRepository _businessRepository = new BusinessRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadPhoto(HttpPostedFileWrapper photo)
        {
            byte[] _photoInMemory;

            int photoLength = (int)idFile.InputStream.Length;
            Stream photoStream = idFile.InputStream;
            _idInMemory = new byte[photoLength];
            photoStream.Read(_photoInMemory, 0, photoLength);

            var result = new
            {
                success = true,
            };
            return Json(new { Result = result });
        }

        public ActionResult ManageBusiness() 
        {
            var businessModel = new BusinessModel()
            {
                Status = Enum.GetValues(typeof(Status)).Cast<Status>().Select(v => v.ToString()).ToList(),
                Category = Enum.GetValues(typeof(Category)).Cast<Category>().Select(v => v.ToString()).ToList()
            };

            return View(businessModel);
        }

        [AllowAnonymous]
        public JsonResult CreateBusiness(string name, string description, string telephone, string address1, string address2, string address3, string postalcode, string status, 
            string businesshours, string tags, string weburl, string category, bool active) 
        {
            var business = new Business()
            {
                Name = name,
                Description=description,
                TelephoneNumber = telephone,
                Address = new Address
                {
                    Address1 = address1,
                    Address2 = address2,
                    Address3 = address3,
                    PostalCode = postalcode,
                },
                Status = (Status)Enum.Parse(typeof(Status), status),
                BusinessHours = businesshours,
                Tags = tags,
                WebUrl = weburl,
                Category = (Category)Enum.Parse(typeof(Category), category),
                Active = active
            };
            _businessRepository.AddBusiness(business);

            var data = new
            {
                isOk = true
            };

            return new JsonResult { Data = data };
        }

    }
}
