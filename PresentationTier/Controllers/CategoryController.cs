using Common.Models;
using LogicTier.Providers;
using System.Linq;
using System.Web.Mvc;

namespace PresentationTier.Controllers
{
    public class CategoryController : Controller
    {
        public log4net.ILog Log = log4net.LogManager.GetLogger(typeof(CategoryController));
        public IAdProvider _adProvider;
        public CategoryController(IAdProvider adProvider) { _adProvider = adProvider; }

        // GET: Category
        public ActionResult _Categories()
        {
            Log.Info("Controller:CategoryController; Action:Categories");
            var categories = _adProvider.GetCategories;
            var catContainer = new CategoryContainer(0, categories);
            return PartialView(catContainer);
        }

        public ActionResult _ParientCategory(int id)
        {
            Log.Info("Controller:CategoryController; Action:_ParientCategory");
            var categories = _adProvider.GetCategories;
            var catContainer = new CategoryContainer(id, categories);
            return PartialView(catContainer);
        }

        //public PartialViewResult Menu(string category = null)
        //{
        //    ViewBag.SelectedCategory = category;
        //    var categories = _adProvider.GetCategories
        //        .Select(x => x.ParientCategoryId)
        //        .Distinct()
        //        .OrderBy(x => x);
        //    return PartialView(categories);
        //}
    }
}