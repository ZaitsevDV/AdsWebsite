using System.Threading.Tasks;
using LogicTier.Providers;
using System.Web.Mvc;
using Common.Models;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdProvider _adProvider;

        public AdController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public async Task<ActionResult> Index()
        {
            object ads = await _adProvider.GetAdsAsync();

            return View(ads);
        }

        public ActionResult AddAd()
        {
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
        public async Task<ActionResult> AddNewAd (AdViewModel adViewModel, string redirectUrl)
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

            await _adProvider.AddAdAsync(ad);

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