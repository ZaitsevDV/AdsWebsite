using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AW.Business.Authorization
{
    public class UserAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as UserPrincipal;

            if (user == null || !(user.IsInRole("Admin") || user.IsInRole("Editor") || user.IsInRole("User")))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Access", action = "Denied", area = "" }));
        }
    }
}
