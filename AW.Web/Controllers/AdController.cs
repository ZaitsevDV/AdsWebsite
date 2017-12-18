using System.Linq;
using System.Web.Mvc;
using AW.Business.Authorization;
using AW.Business.Providers;
using AW.Common.Models;
using AW.Web.Models;

namespace AW.Web.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdProvider _adProvider;

        public AdController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public ActionResult Index()
        {
            Logger.Log.Info("Controller:AdController; Action:Index");
            return View();
        }

        public ActionResult CreateAd()
        {
            var model = new AdViewModel
            {
                User = User as UserPrincipal,
                Categories = _adProvider.GetCategories.OrderBy(x => x.CategoryName).ToList(),
                Conditions = _adProvider.GetConditions.OrderBy(x => x.ConditionName).ToList(),
                Locations = _adProvider.GetLocations.OrderBy(x => x.LocationName).ToList(),
                Types = _adProvider.GetTypes.OrderBy(x => x.TypeName).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAd(AdDetails newAd)
        {
            return View("CreateAd");
        }


        public ActionResult Details(int id)
        {
            Logger.Log.Info("Controller:AdController; Action:Details");
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

            Logger.Log.Info("Controller:AdController; Action:List");
            return PartialView(ads);
        }
    }
}