using BSPN.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSPN.Controllers
{
    public class NASCARController : Controller
    {
        [ClaimsAuthorize("View", "NASCARIndex")]
        public ActionResult Index()
        {
            return View();
        }
    }
}