using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using GoClass;
using GoGlass.WebApi.Controllers;

namespace GoGlass.WebApi
{
    public class RoomsController : ApiController
    {
        [HttpGet]
        public Response Get()
        {
           // var response = ParseResponse(GoClassService.GetRooms(request.Time, request.DayWeek));
            return new Response();
        }

        private static Response ParseResponse(IEnumerable<string> rooms)
        {
            var response = new Response();
            foreach (var room in rooms)
            {
                if (room.Contains("L"))
                {
                    response.Leme.Add(room); continue;
                }

                if (room.Contains("K"))
                {
                    response.Kennedy.Add(room); continue;
                }

                if (room.Contains("F"))
                {
                    response.Frings.Add(room);
                }
            }

            return response;
        }
    }
}