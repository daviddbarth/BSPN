using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSPN.Security
{
    public static class ClaimsTransformationExtension
    {
        public static IAppBuilder UseClaimsTransformation(this IAppBuilder app, ClaimsTransformer claimsTransformer)
        {
            Type type = typeof(ClaimsTransformationMiddleware);
            object[] objArray = new object[] { claimsTransformer };
            app.Use(type, objArray);
            return app;
        }
    }
}