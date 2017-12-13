using System.Web.Mvc;
using LogicTier.Authorization;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service) { _service = service; }

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
                case Common.Enums.LoginResult.NoError:
                    return RedirectToAction("Index", "Home");
                case Common.Enums.LoginResult.EmptyCredentials:
                    model.Message = "Check user name and password";
                    break;
                case Common.Enums.LoginResult.InvalidCredentials:
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