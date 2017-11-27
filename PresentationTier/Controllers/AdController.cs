using System.Linq;
using LogicTier.Providers;
using System.Web.Mvc;
using Dependecies.Dependencies;
using PresentationTier.DependencyResolution;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class AdController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AdController));

        private readonly IAdProvider _adProvider;

        //public AdController()
        //{
        //    var con = IoC.Initialize();
        //    _adProvider = con.GetInstance<IAdProvider>();
        //}


        public AdController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public ActionResult Index()
        {
            Log.Info("Controller:AdController; Action:Index");

            var ads = _adProvider.GetAds;
            return View(ads);
        }

        public ActionResult Details(int id)
        {
            Log.Info("Controller:AdController; Action:Details");

            var model = _adProvider.GetAdDetails(id);

            return View(model);
        }
    }
}