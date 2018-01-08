using AW.Business.Authorization;
using AW.Business.Providers;
using AW.Web.Models;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AW.Web.Controllers
{
    public class ProfileController : Controller
    {
        private IUserProvider _provider;

        public ProfileController(IUserProvider userProvider)
        {
            _provider = userProvider;
        }

        public ActionResult ProfilePage()
        {
            return View();
        }

        public ActionResult UsersList()
        {
            var users = _provider.GetUsers();
            return PartialView("_UsersList", users);
        }

        public ActionResult UserDetails(string id)
        {
            var user = User as UserPrincipal;
            if (string.IsNullOrEmpty(id))
            {
                id = user?.UserName;
            }
            var profile = new UserViewModel
            {
                User = _provider.GetUserByName(id),
                Emails = _provider.GetEmails(id),
                Phones = _provider.GetPhones(id)
            };
            return PartialView("_UserDetails", profile);
        }

        public ActionResult CreateProfile()
        {
            ViewBag.Roles = _provider.GetRoles;
            return PartialView("_CreateProfile");
        }

        [HttpPost]
        public ActionResult CreateProfile(UserViewModel create)
        {
            ViewBag.Roles = _provider.GetRoles;
            if (!ModelState.IsValid) return PartialView("_CreateProfile", create);

            _provider.CreateUser(create.User);

            if (!string.IsNullOrEmpty(create.NewEmail.EmailValue))
            {
                create.NewPhone.UserName = create.User.UserName;
                _provider.CreatePhone(create.NewPhone);
            }

            if (!string.IsNullOrEmpty(create.NewEmail.EmailValue))
            {
                create.NewEmail.UserName = create.User.UserName;
                _provider.CreateEmail(create.NewEmail);
            }

            return RedirectToAction("UpdateProfile", new { id = create.User.UserName });
        }

        public ActionResult UpdateProfile(string id)
        {
            if (string.IsNullOrEmpty(id) && User is UserPrincipal user)
            {
                id = user.UserName;
            }
            var profile = new UserViewModel
            {
                User = _provider.GetUserByName(id),
                Emails = _provider.GetEmails(id),
                Phones = _provider.GetPhones(id)
            };
            ViewBag.Roles = _provider.GetRoles;
            return PartialView("_UpdateProfile", profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserViewModel update)
        {
            ViewBag.Roles = _provider.GetRoles;
            if (!ModelState.IsValid) return PartialView("_UpdateProfile", update);

            if (update.Phones != null)
            {
                foreach (var phone in update.Phones)
                {
                    if (string.IsNullOrEmpty(phone.PhoneNumber))
                    {
                        _provider.DeletePhone(phone.PhoneId);
                    }
                    else
                    {
                        phone.UserName = update.User.UserName;
                        _provider.EditePhone(phone);
                    }
                }
            }

            if (!string.IsNullOrEmpty(update.NewPhone.PhoneNumber))
            {
                update.NewPhone.UserName = update.User.UserName;
                _provider.CreatePhone(update.NewPhone);
            }

            if (update.Emails != null)
            {
                foreach (var email in update.Emails)
                {
                    if (string.IsNullOrEmpty(email.EmailValue))
                    {
                        _provider.DeleteEmail(email.EmailId);
                    }
                    else
                    {
                        email.UserName = update.User.UserName;
                        _provider.EditeEmail(email);
                    }
                }
            }

            if (!string.IsNullOrEmpty(update.NewEmail.EmailValue))
            {
                update.NewEmail.UserName = update.User.UserName;
                _provider.CreateEmail(update.NewEmail);
            }

            _provider.EditeUser(update.User);

            return RedirectToAction("UpdateProfile", new { id = update.User.UserName });
        }

        public ActionResult SetPassword(string id)
        {
            if (string.IsNullOrEmpty(id) && User is UserPrincipal user)
            {
                id = user.UserName;
            }
            var userPassword = new PasswordViewModel
            {
                UserName = id
            };

            return PartialView("_SetPassword", userPassword);
        }

        [HttpPost]
        public ActionResult SetPassword(PasswordViewModel userPassword)
        {
            if (!ModelState.IsValid) return PartialView("_SetPassword");
            var password = Crypto.SHA1(userPassword.Password);
            var userName = userPassword.UserName;
            _provider.EditePassword(userName, password);
            ViewBag.Message = "The password is successfully changed";
            return PartialView("_SetPassword");
        }

        public ActionResult Delete(string id)
        {
            var user = _provider.GetUserByName(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", user);
        }

        public ActionResult DeleteConfirmed(string id)
        {
            var phones = _provider.GetPhones(id);
            foreach (var phone in phones)
            {
                _provider.DeletePhone(phone.PhoneId);
            }
            var emails = _provider.GetEmails(id);
            foreach (var email in emails)
            {
                _provider.DeleteEmail(email.EmailId);
            }
            _provider.DeleteUser(id);
            return RedirectToAction("UsersList");
        }

    }
}