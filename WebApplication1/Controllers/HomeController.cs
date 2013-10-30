using System.Web.Mvc;
using System.Web.Mvc.Filters;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            //custom authentication logic
        }

        protected override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //custom authentication challange logic
        }

        [CustomAuthentication]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //will throw an error
            var color = ((MyCustomPrincipal)ControllerContext.HttpContext.User).HairColor;

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}