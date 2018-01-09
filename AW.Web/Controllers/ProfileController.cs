using AW.Business.Authorization;
using AW.Business.Providers;
using AW.Web.Models;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AW.Web.Controllers
{
    [User]
    public class ProfileController : Controller
    {
        private IUserProvider _userProvider;

        public ProfileController(IUserProvider userUserProvider)
        {
            _userProvider = userUserProvider;
        }

        public ActionResult ProfilePage()
        {
            return View();
        }

        public ActionResult UsersList()
        {
            var users = _userProvider.GetUsers();
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
                User = _userProvider.GetUserByName(id),
                Emails = _userProvider.GetEmails(id),
                Phones = _userProvider.GetPhones(id)
            };
            return PartialView("_UserDetails", profile);
        }

        public ActionResult CreateProfile()
        {
            ViewBag.Roles = _userProvider.GetRoles;
            return PartialView("_CreateProfile");
        }

        [HttpPost]
        public ActionResult CreateProfile(UserViewModel create)
        {
            ViewBag.Roles = _userProvider.GetRoles;
            if (!ModelState.IsValid) return PartialView("_CreateProfile", create);

            _userProvider.CreateUser(create.User);

            var userName = create.User.UserName;
            var password = Crypto.SHA1(create.User.Password);
            _userProvider.EditePassword(userName, password);

            if (!string.IsNullOrEmpty(create.NewEmail.EmailValue))
            {
                create.NewPhone.UserName = create.User.UserName;
                _userProvider.CreatePhone(create.NewPhone);
            }

            if (!string.IsNullOrEmpty(create.NewEmail.EmailValue))
            {
                create.NewEmail.UserName = create.User.UserName;
                _userProvider.CreateEmail(create.NewEmail);
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
                User = _userProvider.GetUserByName(id),
                Emails = _userProvider.GetEmails(id),
                Phones = _userProvider.GetPhones(id)
            };
            ViewBag.Roles = _userProvider.GetRoles;
            return PartialView("_UpdateProfile", profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserViewModel update)
        {
            ViewBag.Roles = _userProvider.GetRoles;
            if (!ModelState.IsValid) return PartialView("_UpdateProfile", update);

            if (update.Phones != null)
            {
                foreach (var phone in update.Phones)
                {
                    if (string.IsNullOrEmpty(phone.PhoneNumber))
                    {
                        _userProvider.DeletePhone(phone.PhoneId);
                    }
                    else
                    {
                        phone.UserName = update.User.UserName;
                        _userProvider.EditePhone(phone);
                    }
                }
            }

            if (!string.IsNullOrEmpty(update.NewPhone.PhoneNumber))
            {
                update.NewPhone.UserName = update.User.UserName;
                _userProvider.CreatePhone(update.NewPhone);
            }

            if (update.Emails != null)
            {
                foreach (var email in update.Emails)
                {
                    if (string.IsNullOrEmpty(email.EmailValue))
                    {
                        _userProvider.DeleteEmail(email.EmailId);
                    }
                    else
                    {
                        email.UserName = update.User.UserName;
                        _userProvider.EditeEmail(email);
                    }
                }
            }

            if (!string.IsNullOrEmpty(update.NewEmail.EmailValue))
            {
                update.NewEmail.UserName = update.User.UserName;
                _userProvider.CreateEmail(update.NewEmail);
            }

            _userProvider.EditeUser(update.User);

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
            _userProvider.EditePassword(userName, password);
            ViewBag.Message = "The password is successfully changed";
            return PartialView("_SetPassword");
        }

        public ActionResult Delete(string id)
        {
            var user = _userProvider.GetUserByName(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", user);
        }

        public ActionResult DeleteConfirmed(string id)
        {
            var phones = _userProvider.GetPhones(id);
            foreach (var phone in phones)
            {
                _userProvider.DeletePhone(phone.PhoneId);
            }
            var emails = _userProvider.GetEmails(id);
            foreach (var email in emails)
            {
                _userProvider.DeleteEmail(email.EmailId);
            }
            _userProvider.DeleteUser(id);
            return RedirectToAction("UsersList");
        }

    }
}