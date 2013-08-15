﻿using Ideas4AppsHub.Domain;
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
        BusinessRepository _businessRepository = new BusinessRepository();

        public ActionResult Index()
        {
            var businessModels = new List<BusinessInfoModel>();

            var businesses = _businessRepository.GetAllBusiness();

            foreach (var business in businesses)
            {
                var businessModel = new BusinessInfoModel
                {
                    Business = business
                };
                businessModels.Add(businessModel);
            }

            return View(businessModels);
        }

        public ActionResult UploadPhoto(HttpPostedFileWrapper photo, string id)
        {
            if (photo != null)
            {
                int photoLength = (int)photo.InputStream.Length;
                Stream photoStream = photo.InputStream;
                var _photoInMemory = new byte[photoLength];
                photoStream.Read(_photoInMemory, 0, photoLength);
            }

            var result = new
            {
                success = true,
                
            };
            return Json(new { Result = result });
        }

        public ActionResult Edit(int id) 
        {
            var business = _businessRepository.GetBusinessById(id);
            var businessInfoModel = new BusinessInfoModel()
            {
               Business = business
            };
            return View(businessInfoModel);
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
            string businesshours, string tags, string weburl, string category, bool active, string longitude, string latitude) 
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
                Category = category,
                GPS = new GPS
                {
                    Latitude = latitude,
                    Longitude = longitude
                },
                Active = active
            };
            _businessRepository.AddBusiness(business);            

            var data = new
            {
                isOk = true,
                projectId = 1
            };

            return new JsonResult { Data = data };
        }

        [AllowAnonymous]
        public JsonResult RemoveBusiness(int id)
        {
            var selectedBusiness = _businessRepository.GetBusinessById(id);
            selectedBusiness.Status = Status.Deleted;
            selectedBusiness.Active = false;

            _businessRepository.UpdateBusiness(selectedBusiness);

            var data = new
            {
                isOk = true
            };

            return new JsonResult { Data = data};
        }
    }
}
