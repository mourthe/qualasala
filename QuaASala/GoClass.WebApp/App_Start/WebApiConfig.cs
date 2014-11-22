using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GoGlass.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Rooms",
                routeTemplate: "rooms/{time}/{dayWeek}",
                defaults: new
                {
                    controller = "Rooms",
                    action = "Get"
                }
            );
        }
    }
}
