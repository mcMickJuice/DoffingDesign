using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoffingDotCom.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProjectSpecific",
                url: "Project/{projectType}/{projectId}",
                defaults: new {controller = "Project", action = "Project"}
                );

            routes.MapRoute(
                name: "ProjectTypeIndex",
                url: "Project/{projectType}",
                defaults: new {controller = "Project", action = "IndexByType"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
