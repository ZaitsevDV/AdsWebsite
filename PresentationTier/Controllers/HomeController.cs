using System.Web.Mvc;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
    }
}