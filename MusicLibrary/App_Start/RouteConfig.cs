using System.Web.Mvc;
using System.Web.Routing;

namespace MusicLibrary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.LowercaseUrls = true;

            routes.MapRoute("Index", "", new {controller = "Index", action = "Index"});
        }
    }
}
