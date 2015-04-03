using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace BSPN.Security
{
    public static class ClaimsAuthorization 
    {
        public static bool CheckAccess(string action, string resource)
        {
            return CheckAccess(Thread.CurrentPrincipal as ClaimsPrincipal, action, resource);
        }

        public static bool CheckAccess(ClaimsPrincipal principal, string action, string resource)
        {
            var context = CreateAuthorizationContext(principal, action, resource);

            return CheckAccess(context);
        }

        public static bool CheckAccess(AuthorizationContext context)
        {
            if (!context.Principal.Identity.IsAuthenticated)
                return false;

            if (context.Principal.IsInRole("Admin"))
                return true;
            else
            {
                if (context.Principal.HasClaim(context.Resource.First().Value, context.Action.First().Value))
                    return true;
            }

            return false;
        }

        private static AuthorizationContext CreateAuthorizationContext(ClaimsPrincipal principal, string action, string resource)
        {
            var actionClaims = new Collection<Claim> { new Claim("ActionType", action) };
            var resourceClaims = new Collection<Claim> { new Claim("ResourceType", resource) };

            return new AuthorizationContext(principal, resourceClaims, actionClaims);
        }
    }
}