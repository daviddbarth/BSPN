using System.Web.Mvc;

namespace BSPN.Security
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private string _action;
        private string _resource;
        private const string _authLabel = "BSPN.Security.ClaimsAuthorizeAttribute";

        public ClaimsAuthorizeAttribute() { }

        public ClaimsAuthorizeAttribute(string action, string resource)
        {
            _action = action;
            _resource = resource;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Items[_authLabel] = filterContext;
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            if (!string.IsNullOrWhiteSpace(_action))
            {
                return ClaimsAuthorization.CheckAccess(_action, _resource);
            }
            else
            {
                var filterContext = (AuthorizationContext)httpContext.Items[_authLabel];
                return ChecAccess(filterContext);
            }

        }

        private bool ChecAccess(System.Web.Mvc.AuthorizationContext filterContext)
        {
            var action = filterContext.RouteData.Values["action"] as string;
            var controller = filterContext.RouteData.Values["controller"] as string;

            return ClaimsAuthorization.CheckAccess(action, controller);
        }

    }
}