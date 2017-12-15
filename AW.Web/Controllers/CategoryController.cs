using System.Web.Mvc;
using AW.Business.Providers;
using log4net;

namespace AW.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IAdProvider _adProvider;
        public ILog Log = LogManager.GetLogger(typeof(CategoryController));

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