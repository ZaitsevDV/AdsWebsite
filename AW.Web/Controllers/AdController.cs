using System.Web.Mvc;
using AW.Business.Providers;
using log4net;

namespace AW.Web.Controllers
{
    public class AdController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AdController));
        private readonly IAdProvider _adProvider;

        public AdController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public ActionResult Index()
        {
            Log.Info("Controller:AdController; Action:Index");
            return View();
        }

        public ActionResult Details(int id)
        {
            Log.Info("Controller:AdController; Action:Details");
            var model = _adProvider.GetAdDetails(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult List(int? id)
        {
            var category = 0;
            if (id != null)
                category = (int) id;
            var ads = _adProvider.GetAdsByCategory(category);

            Log.Info("Controller:AdController; Action:_AdList");
            return PartialView(ads);
        }
    }
}