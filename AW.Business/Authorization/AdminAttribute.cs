using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AW.Business.Authorization
{
    public class AdminAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as UserPrincipal;
            if (!user.IsInRole("Administrator"))
                filterContext.Result =
                    new RedirectToRouteResult(new RouteValueDictionary(new {controller = "Access", action = "Denied"}));
        }
    }
}