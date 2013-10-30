using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;

            //Demo purpose only. The custom principal could be retrived via the current context.
            filterContext.Principal = new MyCustomPrincipal(filterContext.HttpContext.User.Identity, new[] { "Admin" }, "Red");
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var color = ((MyCustomPrincipal)filterContext.HttpContext.User).HairColor;
            var user = filterContext.HttpContext.User;

            if (color == "Red" && !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}