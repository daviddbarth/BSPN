using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace BSPN.IoC
{
    public static class KernelExtensions
    {
        public static void BindAssemblies(this IKernel kernel, 
            Func<Ninject.Activation.IContext, object> scopeExpression, 
            params string[] assemblies)
        {
            kernel.Bind(x => x.FromAssembliesMatching(assemblies)
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(config => config.InScope(scopeExpression)));
        }
    }

    public static class IoC
    {
        private static IKernel _kernel;
        private static bool _initialized;

        private static void Initialize()
        {
            if (_initialized)
                return;

            _kernel = new StandardKernel();
            RegisterServices();
        }

        private static void RegisterServices()
        {

        }

    }
}
