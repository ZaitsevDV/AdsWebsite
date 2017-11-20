using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PresentationTier.App_Start;

namespace PresentationTier
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Logger.InitLogger();
        }
    }
}
