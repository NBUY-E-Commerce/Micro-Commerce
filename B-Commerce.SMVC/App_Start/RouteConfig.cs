using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace B_Commerce.SMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
             name: "CategoryProduct",
             url: "CategoryProduct/{categoryID}/{name}",
             defaults: new { controller = "Category", action = "Products" },
              new[] { "B_Commerce.SMVC.Controllers" }
         );

            //area eklendiği içim bu roueting rullarına namespace eklemek zorundayız
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { "B_Commerce.SMVC.Controllers" }
            );


        }
    }
}
