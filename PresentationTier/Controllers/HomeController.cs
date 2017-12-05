using System.Threading.Tasks;
using System.Web.Mvc;
using Common.Models;
using LogicTier.Providers;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly IAdProvider _adProvider;
        public HomeController(IAdProvider adProvider) { _adProvider = adProvider; }

        //public ActionResult Index()
        //{
        //    Log.Info("Controller:Home; Action:Index");
        //    return View();
        //}

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            Log.Info("Controller:Home; Action:Index");
            var model = await GetFullAndPartialViewModel();
            return View(model);
        }

        [HttpGet]
        //public async Task<ActionResult> GetCategoryProducts(string categoryId)
        //{
        //    var lookupId = int.Parse(categoryId);
        //    var model = await GetFullAndPartialViewModel(lookupId);
        //    return PartialView("CategoryResults", model);
        //}

        private async Task<IndexViewModel> GetFullAndPartialViewModel(int categoryId = 0)
        {
            var categories = _adProvider.GetCategories;
            var ads = _adProvider.GetAds;
            var indexViewModel = new IndexViewModel(categoryId, categories, ads);
            return indexViewModel;
        }
    }
}