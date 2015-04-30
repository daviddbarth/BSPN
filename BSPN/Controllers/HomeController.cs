using BSPN.Security;
using BSPN.Services;
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
        public HomeController(IRaceService raceService)
        {
            var races = raceService.GetRaces(2015);
        }

        [ClaimsAuthorize("View", "Home")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ClaimsAuthorize("Write", "DriverPicks")]
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