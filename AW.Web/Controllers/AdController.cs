using AW.Business.Authorization;
using AW.Business.Providers;
using AW.Common.Models;
using AW.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AW.Web.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdProvider _adProvider;
        private readonly IUserProvider _userProvider;

        public AdController(IAdProvider adProvider, IUserProvider userProvider)
        {
            _adProvider = adProvider;
            _userProvider = userProvider;
        }

        public ActionResult Index()
        {
            Logger.Log.Info("Controller:AdController; Action:Index");
            return View();
        }

        [User]
        public ActionResult CreateAd(int id)
        {
            ViewBag.Conditions = _adProvider.GetConditions.OrderBy(x => x.ConditionName).ToList();
            ViewBag.AdType = _adProvider.GetTypes.OrderBy(x => x.TypeName).ToList();
            ViewBag.Locations = _adProvider.GetLocations;
            var adView = new AdViewModel
            {
                Ad = new Ad
                {
                    Category = id,
                    CreationDate = DateTime.Now
                }
            };
            return View("CreateAd", adView);
        }

        [HttpPost]
        public ActionResult CreateAd(AdViewModel adView)
        {
            ViewBag.Locations = _adProvider.GetLocations;
            ViewBag.AdType = _adProvider.GetTypes.OrderBy(x => x.TypeName).ToList();

            if (!ModelState.IsValid) return View("CreateAd", adView);

            var typeId = adView.Ad.TypeId;
            int condition;
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

            var imgName = GetNewImageName(adView.UploadImage);

            if (adView.UploadImage == null || !CheckExtention(adView.UploadImage))
            {
                imgName = "No-image-found.jpg";
            }

            if (!string.IsNullOrEmpty(imgName) && imgName != "No-image-found.jpg")
            {
                adView.UploadImage?.SaveAs(Server.MapPath("~/Images/" + imgName));
            }

            _adProvider.CreateAd(
                new Ad
                {
                    UserName = GetCurrentUser(),
                    Title = adView.Ad.Title,
                    Description = adView.Ad.Description,
                    Picture = GetImagePath(adView.UploadImage, imgName),
                    Price = adView.Ad.Price,
                    Category = adView.Ad.Category,
                    CreationDate = adView.Ad.CreationDate,
                    LocationId = adView.Ad.LocationId,
                    TypeId = typeId,
                    Condition = condition
                });
            return RedirectToAction("Index");
        }

        public ActionResult EditeAd(int id)
        {
            ViewBag.Conditions = _adProvider.GetConditions.OrderBy(x => x.ConditionName).ToList();
            ViewBag.AdType = _adProvider.GetTypes.OrderBy(x => x.TypeName).ToList();
            ViewBag.Locations = _adProvider.GetLocations;
            var adView = new AdViewModel { Ad = _adProvider.GetAds.FirstOrDefault(ad => ad.Id == id) };
            return View("EditeAd", adView);
        }

        [HttpPost]
        public ActionResult EditeAd(AdViewModel adView)
        {
            ViewBag.Locations = _adProvider.GetLocations;
            ViewBag.AdType = _adProvider.GetTypes.OrderBy(x => x.TypeName).ToList();

            if (!ModelState.IsValid) return View("EditeAd", adView);

            var typeId = adView.Ad.TypeId;
            int condition;
            string imagePath;

            //ad condition may be new (condition = 1) or used (condition = 2) only if ad type not "service"
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

            var imgName = GetNewImageName(adView.UploadImage);

            if (adView.UploadImage == null || !CheckExtention(adView.UploadImage))
            {
                imgName = "No-image-found.jpg";
            }

            if (!string.IsNullOrEmpty(imgName) && imgName != "No-image-found.jpg")
            {
                adView.UploadImage?.SaveAs(Server.MapPath("~/Images/" + imgName));
            }

            if (adView.UploadImage != null && GetImagePath(adView.UploadImage, imgName) != adView.Ad.Picture)
            {
                imagePath = GetImagePath(adView.UploadImage, imgName);
            }
            else
            {
                imagePath = adView.Ad.Picture;
            }

            _adProvider.EditeAd(
                new Ad
                {
                    Id = adView.Ad.Id,
                    UserName = GetCurrentUser(),
                    Title = adView.Ad.Title,
                    Description = adView.Ad.Description,
                    Picture = imagePath,
                    Price = adView.Ad.Price,
                    Category = adView.Ad.Category,
                    CreationDate = adView.Ad.CreationDate,
                    LocationId = adView.Ad.LocationId,
                    TypeId = typeId,
                    Condition = condition
                });
            return RedirectToAction("Index");
        }

        private string GetCurrentUser()
        {
            var user = User as UserPrincipal;
            return user?.UserName;
        }

        private static string GetNewImageName(HttpPostedFileBase image)
        {
            if (image == null) return null;
            var extension = Path.GetExtension(image.FileName);
            var hashCode = image.GetHashCode().ToString();
            return hashCode + extension;
        }

        private static string GetImagePath(HttpPostedFileBase image, string name)
        {
            if (image == null) return "~/Images/No-image-found.jpg";
            return Path.Combine("~/Images/" + name);
        }

        private static bool CheckExtention(HttpPostedFileBase image)
        {
            var extFormat = new[] { ".jpg", ".jpeg", ".gif", ".png" };
            var extension = Path.GetExtension(image.FileName);
            return extFormat.Contains(extension);
        }

        public ActionResult Details(int id)
        {
            Logger.Log.Info("Controller:AdController; Action:Details");
            var ad = _adProvider.GetAdDetails(id);
            var model = new AdDetailsViewModel
            {
                Ad = ad,
                Phones = _userProvider.GetPhones(ad.UserName),
                Emails = _userProvider.GetEmails(ad.UserName)
            };
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
            return PartialView("_List", ads);
        }

        public ActionResult Delete(int id)
        {
            var ad = _adProvider.GetAdDetails(id);

            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            _adProvider.DeleteAd(id);
            return RedirectToAction("Index");
        }
    }
}