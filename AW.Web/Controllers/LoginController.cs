using System.Web.Helpers;
using AW.Business.Authorization;
using AW.Common.Enums;
using AW.Web.Models;
using System.Web.Mvc;

namespace AW.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid) return View(loginView);
            var passwordHash = Crypto.SHA1(loginView.Password);
            var result = _service.Login(loginView.Login, passwordHash);

            switch (result)
            {
                case LoginResult.NoError:
                    return RedirectToAction("Index", "Ad");
                case LoginResult.EmptyCredentials:
                    loginView.Message = "Check user name and password";
                    break;
                case LoginResult.InvalidCredentials:
                    loginView.Message = "User is not valid";
                    break;
                default:
                    return View(loginView);
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            _service.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}