using Common.Models;
using LogicTier.Providers;
using System.Web.Mvc;

namespace PresentationTier.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(CategoryController));
        private readonly IAdProvider _adProvider;
        public CategoryController(IAdProvider adProvider) { _adProvider = adProvider; }

        // GET: Category
        public ActionResult Categories()
        {
            Log.Info("Controller:CategoryController; Action:Categories");
            var categories = _adProvider.GetCategories;
            var model = new CategoryContainer(0, categories);
            return View(model);
        }
    }
}