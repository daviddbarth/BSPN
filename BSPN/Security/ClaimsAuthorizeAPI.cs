using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BSPN.Security
{
    public class ClaimsAuthorizeAPI : AuthorizeAttribute
    {
        private string _action;
        private string _resource;

        public ClaimsAuthorizeAPI(string action, string resource)
        {
            _action = action;
            _resource = resource;
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if(!string.IsNullOrWhiteSpace(_action))
            {
                if (!ClaimsAuthorization.CheckAccess(_action, _resource))
                    base.HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}