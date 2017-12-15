using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AW.Business.Authorization;
using AW.Common.Models;
using Newtonsoft.Json;

namespace AW.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        public void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var auth = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (auth == null) return;
            var ticket = FormsAuthentication.Decrypt(auth.Value);
            var model = JsonConvert.DeserializeObject<User>(ticket.UserData);
            var principal = new UserPrincipal(ticket.Name)
            {
                UserName = model.UserName,
                Roles = model.Roles.Select(x => x.RoleName).ToArray()
            };
            HttpContext.Current.User = principal;
        }
    }
}