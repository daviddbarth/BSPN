using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace BSPN.Security
{
    public class SecurityHelpers
    {
        public static string GetUserId()
        {
            var claims = ((ClaimsPrincipal)HttpContext.Current.User).Claims;
            var userId = claims.First(c => c.Type.Contains("nameidentifier")).Value;

            return userId;
        }
    }
}