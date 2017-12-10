using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LogicTier.Providers;
using System.Web.Mvc;
using Common.Models;

namespace PresentationTier.Controllers
{
    public class AdController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AdController));
        private readonly IAdProvider _adProvider;
        public AdController(IAdProvider adProvider) { _adProvider = adProvider; }

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

        public ActionResult _AdList(List<Ad> ads, int category = 0)
        {
            if (ads == null)
            {
                ads = _adProvider.GetAds.ToList();
            }
            var childId = GetChildCategoriesList(category);

            //model.Reminders = _provider.GetReminders
            //    .Where(c => category == null || c.CategoryId == category)
            //    .OrderBy(c => c.ReminderId);


            var selectedList = ads.Where(x => x.Category.Equals(category)).Select(item => new Ad()
            {
                Id = item.Id,
                UserName = item.UserName,
                Name = item.Name,
                Description = item.Description,
                Picture = item.Picture,
                Price = item.Price,
                Category = item.Category,
                CreationDate = item.CreationDate,
                LocationId = item.LocationId,
                Type = item.Type,
                Condition = item.Condition
            }).ToList();
            Log.Info("Controller:AdController; Action:_AdList");
            return PartialView(ads);
        }

        public List<int> GetChildCategoriesList(int categoryId)
        {
            var categories = _adProvider.GetCategories.ToList();
            var nums = new List<int>
            {
                categoryId
            };

            foreach (int firstLevel in nums)
            {
                nums = (from item in categories where item.ParentCategoryId == firstLevel select item.CategoryId).ToList();

                foreach (int secondLevel in nums)
                {
                    nums = (from item in categories where item.ParentCategoryId == secondLevel select item.CategoryId).ToList();

                    foreach (int thirdLevel in nums)
                    {
                        nums = (from item in categories where item.ParentCategoryId == thirdLevel select item.CategoryId).ToList();
                    }
                }
            }

            return nums;
        }
    }
}