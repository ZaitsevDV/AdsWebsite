using System.Web.Mvc;
using LogicTier.Providers;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdProvider _adProvider;
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(HomeController));

        public HomeController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public ActionResult Index()
        {
            Log.Info("Controller:Home; Action:Index");
            var model = new AdViewModel()
            {
                Name = _adProvider.GetAd(1).Name
            };

            return View(model);
        }
    }
}