using BSPN.Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace BSPN.Security
{
    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        public ClaimsTransformer()
        {
        }

        private void AddRoleClaims(ClaimsPrincipal incomingPrinicipal)
        {
            Repository<AspNetUser> repository = new Repository<AspNetUser>(new SportsEntities());
            AspNetUser aspNetUser = repository.FindAll(u => u.UserName == incomingPrinicipal.Identity.Name).First<AspNetUser>();
            foreach (AspNetRole aspNetRole in aspNetUser.AspNetRoles)
            {
                foreach (BSPN.Data.Claim securityClaim in aspNetRole.Claims)
                {
                    ((ClaimsIdentity)incomingPrinicipal.Identity).AddClaim(new System.Security.Claims.Claim(securityClaim.ClaimType, securityClaim.ClaimValue));
                }
            }
        }

        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (incomingPrincipal == null || !incomingPrincipal.Identity.IsAuthenticated)
            {
                return base.Authenticate(resourceName, incomingPrincipal);
            }

            this.AddRoleClaims(incomingPrincipal);

            return incomingPrincipal;
        }

        //private void EstablishSession(ClaimsPrincipal incomingPrincipal)
        //{
        //    SessionSecurityToken sessionSecurityToken = new SessionSecurityToken(incomingPrincipal, TimeSpan.FromHours(1));
        //    FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionSecurityToken);
        //}
    }
}