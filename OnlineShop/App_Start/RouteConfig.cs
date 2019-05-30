﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          //  routes.MapRoute(null,
          //    "",
          //    new
          //    {
          //        controller = "CarModel",
          //        action = "List",
          //        category = (string)null,
          //        page = 1
          //    }
          //);

          //  routes.MapRoute(
          //  name: null,
          //  url: "Page{page}",
          //  defaults: new { controller = "CarModel", action = "List", category = (string)null },
          //  constraints: new { page = @"\d+" }
          //  );
          //  routes.MapRoute(null,
          //    "{category}",
          //    new { controller = "CarModel", action = "List", page = 1 }
          //);

          //  routes.MapRoute(null,
          //    "{category}/Page{page}",
          //    new { controller = "CarModel", action = "List" },
          //    new { page = @"\d+" }
          //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CarModel", action = "List", id = UrlParameter.Optional }
            );
         //   routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
