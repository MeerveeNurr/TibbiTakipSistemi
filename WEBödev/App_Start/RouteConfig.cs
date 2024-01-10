using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEBödev
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Tahlil",
                url: "Tahlil/{action}/{id}",
                defaults: new { controller = "Tahlil", action = "Güncelle", id = UrlParameter.Optional }
);
            routes.MapRoute(
          name: "Hastalık",
          url: "Hastalık/{action}/{id}",
          defaults: new { controller = "Hastalık", action = "Güncelle", id = UrlParameter.Optional }
         
);
            routes.MapRoute(
        name: "HastalıkGüncelle",
         url: "Hastalık/Güncelle/{id}",
         defaults: new { controller = "Hastalık", action = "Güncelle", id = UrlParameter.Optional }
);
            routes.MapRoute(
    name: "TumHastalar",
    url: "Doktor/TumHastalar",
    defaults: new { controller = "Doktor", action = "TumHastalar" }
);
        }

    }
}
