using AW.Business.Providers;
using AW.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace AW.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAdProvider _adProvider;

        public SearchController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public ActionResult SearchList()
        {
            var model = new FilterViewModel
            {
                Categories = _adProvider.GetCategories,
                Ads = _adProvider.GetAds.ToList(),
                Types = _adProvider.GetTypes
            };

            return View(model);
        }

        public ActionResult GetSearchResult()
        {
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult GetSearchResult(FilterViewModel filter)
        {
            ViewBag.Result = true;

            if (!string.IsNullOrEmpty(filter.Title) || 
                filter.CategoryId != default(int) ||
                filter.TypeId != default(int))
            {
                var ads = _adProvider.GetAds;

                if (!string.IsNullOrEmpty(filter.Title))
                {
                    ads = ads.Where(x => x.Title.Contains(filter.Title)).ToList();
                }

                if (filter.CategoryId != default(int))
                {
                    ads = _adProvider.GetAdsByCategory(filter.CategoryId);
                }

                if (filter.TypeId != default(int))
                {
                    ads = ads.Where(x => x.TypeId == filter.TypeId).ToList();
                }

                if (ads.Any())
                {
                    return PartialView("_SearchResult", ads);
                }
            }

            ViewBag.Result = false;

            ViewBag.Message = "Ads not found";

            return PartialView("_SearchResult");
        }
    }
}