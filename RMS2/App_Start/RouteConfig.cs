using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RMS2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Login",
               url: "Areas/Admin/Controllers/{Login}/{action}",
               defaults: new { controller = "Login", action = "Index"}
           );

            routes.MapRoute(
               name: "Home",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "Index" }
            
           );

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            //routes.MapRoute(
            //name: "Default",
            //url: "Home/Index",
            //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

        );
            routes.MapRoute(
            name: "AdminLogin",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }

        );
          //  routes.MapRoute(
          //    name: "Default",
          //    url: ".../Home/Index",
          //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

          //);



        }
    }
}
