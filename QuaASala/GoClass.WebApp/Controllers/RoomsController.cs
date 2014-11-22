using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoGlass.WebApp;

namespace GoClass.WebApp.Controllers
{
    public class RoomsController : ApiController
    {
        // GET: api/Rooms
        public Response Get(string time, string dayWeek)
        {
            return ParseResponse(GoClassService.GetRooms(time, dayWeek));
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

        // GET: api/Rooms/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rooms
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
        }
    }
}
