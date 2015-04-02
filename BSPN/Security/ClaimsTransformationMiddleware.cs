using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BSPN.Security
{
    public class ClaimsTransformationMiddleware : OwinMiddleware
    {
        private ClaimsTransformer _claimsTransformer;

        public ClaimsTransformationMiddleware(OwinMiddleware next, ClaimsTransformer claimsTransformer)
            : base(next)
        {
            if (claimsTransformer == null)
            {
                throw new ArgumentNullException("claimsTransformer");
            }
            this._claimsTransformer = claimsTransformer;
        }

        public override Task Invoke(IOwinContext context)
        {
            if (context.Authentication.User != null)
            {
                context.Authentication.User = _claimsTransformer.Authenticate(context.Request.Uri.AbsoluteUri, context.Authentication.User);
            }

            return base.Next.Invoke(context);
        }
    }
}