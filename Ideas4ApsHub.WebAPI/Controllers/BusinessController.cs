using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ideas4AppsHub.Domain;
using Ideas4AppsHub.WebAPI.Domain;
using Newtonsoft.Json;

namespace Ideas4ApssHub.WebAPI.Controllers
{
    public class BusinessController : ApiController
    {
        private SolutionServerResult<List<Business>> _solJsonResult;
        // GET api/business
        public string Get()
        {
            List<Business> businessList = new List<Business>();
            try
            {
                _solJsonResult = new SolutionServerResult<List<Business>>()
                {
                    IsOk = true,
                    Message = String.Format("Sending '{0}' businesses", businessList.Count),
                    Data = businessList
                };
                return JsonConvert.SerializeObject(_solJsonResult);
            }
            catch(Exception ex)
            {
                _solJsonResult = new SolutionServerResult<List<Business>>()
                {
                    IsOk = false,
                    Message = String.Format("Internal failure: Could not serialize List<Business> with error message '{0}'", ex.Message),
                    Data = null
                };
                return JsonConvert.SerializeObject(_solJsonResult);
            }
        }

     /*   // GET api/business/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/business
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
