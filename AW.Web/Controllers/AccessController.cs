using System.Web.Mvc;

namespace AW.Web.Controllers
{
    public class AccessController : Controller
    {
        public ActionResult Denied()
        {
            return View();
        }
    }
}