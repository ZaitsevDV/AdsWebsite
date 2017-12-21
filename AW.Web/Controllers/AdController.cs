using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AW.Business.Authorization;
using AW.Business.Providers;
using AW.Common.Models;
using AW.Web.Models;

namespace AW.Web.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdProvider _adProvider;

        public AdController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }

        public ActionResult Index()
        {
            Logger.Log.Info("Controller:AdController; Action:Index");
            return View();
        }


        public ActionResult CreateAd(int id)
        {
            ViewBag.Conditions = _adProvider.GetConditions.OrderBy(x => x.ConditionName).ToList();
            ViewBag.AdType = _adProvider.GetTypes.OrderBy(x => x.TypeName).ToList();
            ViewBag.Locations = _adProvider.GetLocations;
            var adView = new AdViewModel();
            adView.Ad = new Ad();
            adView.Ad.Category = id;
            adView.Ad.CreationDate = DateTime.Now;
            return View("CreateAd", adView);
        }

        [HttpPost]
        public ActionResult CreateAd(AdViewModel adView)
        {
            ViewBag.Locations = _adProvider.GetLocations;
            ViewBag.AdType = _adProvider.GetTypes.OrderBy(x => x.TypeName).ToList();
            if (adView.Image != null && !CheckExtention(adView.Image))
            {
                return View("CreateAd", adView);
            }

            if (!ModelState.IsValid) return View("CreateAd", adView);

            var typeId = adView.Ad.TypeId;
            int condition;
            var imgName = GetNewImageName(adView.Image);
            if (adView.New)
            {
                condition = 1;
            }
            else if (adView.Ad.TypeId == 4)
            {
                condition = 3;
            }
            else
            {
                condition = 2;
            }

            _adProvider.CreateAd(
                new Ad
                {
                    UserName = GetCurrentUser(),
                    Title = adView.Ad.Title,
                    Description = adView.Ad.Description,
                    Picture = GetImagePath(adView.Image, imgName),
                    Price = adView.Ad.Price,
                    Category = adView.Ad.Category,
                    CreationDate = adView.Ad.CreationDate,
                    LocationId = adView.Ad.LocationId,
                    TypeId = typeId,
                    Condition = condition
                });
            if (adView.Image != null && !string.IsNullOrEmpty(imgName))
            {
                SaveImage(adView.Image, imgName);
            }
            return View("CreateAd", adView);
        }


        private string GetCurrentUser()
        {
            var user = User as UserPrincipal;
            return user.UserName;
        }

        private static string GetImagePath(HttpPostedFileBase image, string name)
        {
            if (image != null) return Path.Combine("../Images/" + name);
            return "../Images/No-image-found.jpg";
        }

        private void SaveImage(HttpPostedFileBase image, string name)
        {
            image?.SaveAs(Server.MapPath("~/Images/" + name));
        }

        private static bool CheckExtention(HttpPostedFileBase image)
        {

            var exFormat = new[] { ".jpg", ".jpeg", ".gif", ".png" };
            var ex = Path.GetExtension(image.FileName);

            return exFormat.Contains(ex);
        }

        private static string GetNewImageName(HttpPostedFileBase image)
        {
            if (image == null) return null;
            var ex = Path.GetExtension(image.FileName);
            var name = Path.GetFileNameWithoutExtension(image.FileName);
            var nameRandom = new Random().Next(1, 1000000).ToString();

            return name + nameRandom + ex;
        }

        public ActionResult Details(int id)
        {
            Logger.Log.Info("Controller:AdController; Action:Details");
            var model = _adProvider.GetAdDetails(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult List(int? id)
        {
            var category = 0;
            if (id != null)
                category = (int)id;
            var ads = _adProvider.GetAdsByCategory(category);
            ViewBag.Category = category;
            Logger.Log.Info("Controller:AdController; Action:List");
            return PartialView(ads);
        }
    }
}