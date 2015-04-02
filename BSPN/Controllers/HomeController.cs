using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BSPN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {

            ClaimsPrincipal principal = (ClaimsPrincipal)HttpContext.User;
            string ClaimsString = string.Empty;

            foreach(var claim in principal.Claims)
            {
                ClaimsString += string.Format("{0} - {1}\n", claim.Type, claim.Value);
            }

            ViewBag.Message = ClaimsString;

            return View();
        }
    }
}