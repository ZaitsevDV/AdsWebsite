using System.Web.Mvc;
using AW.Business.Authorization;
using AW.Common.Enums;
using AW.Web.Models;

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
        public ActionResult Login(string userName, string password)
        {
            var result = _service.Login(userName, password);
            var model = new LoginViewModel();

            switch (result)
            {
                case LoginResult.NoError:
                    return RedirectToAction("Index", "Home");
                case LoginResult.EmptyCredentials:
                    model.Message = "Check user name and password";
                    break;
                case LoginResult.InvalidCredentials:
                    model.Message = "The user is not valid";
                    break;
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            _service.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}