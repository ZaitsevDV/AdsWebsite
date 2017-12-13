using System.Web.Mvc;

namespace PresentationTier.Controllers
{
    public class AccessController : Controller
    {
        public ActionResult Denied()
        {
            return View();
        }
    }
}