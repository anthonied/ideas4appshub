using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ideas4AppsHub.WebAPI.Domain;
using Newtonsoft.Json;

namespace Ideas4ApssHub.WebAPI.Controllers
{
    public class ConnectivityController : ApiController
    {
        //api/Connectivity
        public string Get()
        {
            SolutionServerResult<string> solJsonResult = new SolutionServerResult<string>()
            {
                IsOk = true,
                Message = "Connectivity is good",
                Data = "Connectivity is good"
            };
            return JsonConvert.SerializeObject(solJsonResult);
        }
    }
}
