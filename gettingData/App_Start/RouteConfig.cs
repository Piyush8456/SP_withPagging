using System.Web.Mvc;
using System.Web.Routing;

namespace gettingData
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{Employees}/{Index}/{id}",
            //    defaults: new { controller = "Employees", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
