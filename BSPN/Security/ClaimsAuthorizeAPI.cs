using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

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

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if(!string.IsNullOrWhiteSpace(_action))
            {
                if (!ClaimsAuthorization.CheckAccess(_action, _resource))
                    HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("You are not authorized to perform this action."),
                ReasonPhrase = "Invalid Request"
            };

            throw new HttpResponseException(resp);
        }
    }
}