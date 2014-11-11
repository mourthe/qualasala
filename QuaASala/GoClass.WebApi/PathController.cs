using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace GoClass.WebApi
{
    public class PathController : ApiController
    {
        [HttpGet]
        public PathResponse Get(string request)
        {
            var response = new PathResponse();

            var rooms = GoClass.Service.GetRooms(request);       

            return null;
        }
    }
}