using System.Web.Mvc;

namespace AW.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Logger.Log.Info("Controller:Home; Action:Index");
            return View();
        }
    }
}