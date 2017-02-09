using System.Web.Mvc;
using System.Web.Routing;
using MusicLibrary.App_Start;

namespace MusicLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.Configure();
            AutomapperConfig.Configure();
        }
    }
}
