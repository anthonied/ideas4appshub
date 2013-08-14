using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ideas4AppsHub.Domain;
using Ideas4AppsHub.Repositories;
using Ideas4AppsHub.WebAPI.Domain;
using Newtonsoft.Json;

namespace Ideas4ApssHub.WebAPI.Controllers
{
    public class BusinessController : ApiController
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET api/business
        [HttpGet]
        public string Get()
        {
            SolutionServerResult<List<Business>> solJsonResult;
            try
            {
                List<Business> businessList = new BusinessRepository().GetAllBusiness();
                solJsonResult = new SolutionServerResult<List<Business>>()
                {
                    IsOk = true,
                    Message = String.Format("Sending '{0}' businesses", businessList.Count),
                    Data = businessList
                };
                _log.Debug(String.Format("Sending {0} businesses", businessList.Count));
                return JsonConvert.SerializeObject(solJsonResult);
            }
            catch(Exception ex)
            {
                solJsonResult = new SolutionServerResult<List<Business>>()
                {
                    IsOk = false,
                    Message = String.Format("Internal failure getting ALL businesses: '{0}'", ex.Message),
                    Data = null
                };
                _log.Error("Error getting businesses: ", ex);
                return JsonConvert.SerializeObject(solJsonResult);
            }
        }

        // GET api/business/int id
        public string Get(int id)
        {
            SolutionServerResult<Business> solJsonResult;
            try
            {
                Business business = new BusinessRepository().GetBusinessById(id);
                solJsonResult = new SolutionServerResult<Business>()
                {
                    IsOk = true,
                    Message = String.Format("Sending business '{0}'", business.Name),
                    Data = business
                };
                _log.Debug(String.Format("Sending business '{0}'", business.Name));
                return JsonConvert.SerializeObject(solJsonResult);
            }
            catch (Exception ex)
            {
                solJsonResult = new SolutionServerResult<Business>()
                {
                    IsOk = false,
                    Message = String.Format("Internal failure getting business with ID '{0}'\n{1}", id, ex.Message),
                    Data = null
                };
                _log.Error("Error getting business: ", ex);
                return JsonConvert.SerializeObject(solJsonResult);
            }
        }

        /*// POST api/business
        public void Post([FromBody]string value)
        {
        }

        // PUT api/business/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/business/5
        public void Delete(int id)
        {
        }*/
    }
}
