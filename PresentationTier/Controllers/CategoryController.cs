using LogicTier.Providers;
using System.Web.Mvc;

namespace PresentationTier.Controllers
{
    public class CategoryController : Controller
    {
        public log4net.ILog Log = log4net.LogManager.GetLogger(typeof(CategoryController));
        private readonly IAdProvider _adProvider;

        public CategoryController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public ActionResult _Categories()
        {
            ViewBag.Menu = _adProvider.GetCategories;
            return PartialView();
        }
    }
}

