using Ninject;
using Ninject.Extensions.Conventions;
using System;

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
}
