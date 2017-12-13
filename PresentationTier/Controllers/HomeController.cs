using System.Web.Mvc;
using LogicTier.Authorization;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            Log.Info("Controller:Home; Action:Index");
            return View();
        }

        [Admin]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}