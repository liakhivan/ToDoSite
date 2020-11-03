using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToDoSite.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{id}",
            //    defaults: new { controller = "Task", action = "Index", id = "Completed" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{type}",
                defaults: new { controller = "Task", action = "Index", type = "All"  }
            );
        }
    }
}
