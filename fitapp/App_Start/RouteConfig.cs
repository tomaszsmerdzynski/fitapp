﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace fitapp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Search",
                url: "produkt-{id}",
                defaults: new { controller = "Home", action = "Search"}
            );

            //routes.MapRoute(
            //    name: "Details",
            //    url: "produkt-{id}",
            //    defaults: new { controller = "Home", action = "Details" }
            //);

            routes.MapRoute(
                name: "ProductsList",
                url: "Products-List/page-{page}",
                defaults: new { controller = "Home", action = "ProductsList" }
            );

            routes.MapRoute(
                name: "StaticPages",
                url: "{viewname}",
                defaults: new { controller = "Home", action = "StaticContent" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
