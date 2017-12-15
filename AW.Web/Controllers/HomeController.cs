using System.Web.Mvc;
using AW.Business.Authorization;
using log4net;

namespace AW.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

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