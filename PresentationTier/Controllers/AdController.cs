using LogicTier.Providers;
using System.Web.Mvc;
using Common.Models;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdProvider _adProvider;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AdController));

        public AdController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public  ActionResult Index()
        {
            Log.Info("Controller:AdController; Action:Index");

            var ads = _adProvider.GetAds();

            return View(ads);
        }

        public ActionResult AddAd()
        {
            Log.Info("Controller:AdController; Action:AddAd");

            var adViewModel = new AdViewModel
            {
                Title = "Add New Ad",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "Ad")
            };

            return View(adViewModel);
        }

        public ActionResult EditAd(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult DetailsOfAd(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult DeleteAd(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult AddNewAd(string redirecturl)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult AddNewAd (AdViewModel adViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                // ReSharper disable once Mvc.ViewNotResolved
                return View(adViewModel);
            }

            var ad = new Ad
            {
                Name = adViewModel.Name
            };

            _adProvider.AddAd(ad);

            return RedirectToLocal(redirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Ad");
        }
    }
}