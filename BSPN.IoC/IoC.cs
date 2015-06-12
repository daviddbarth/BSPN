using Ninject;
using Ninject.Extensions.Conventions;
using System;
using AutoMapper;

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
            
            kernel.Bind<IMappingEngine>().ToMethod(context => Mapper.Engine);
            kernel.Bind<IConfigurationProvider>().ToMethod(context => Mapper.Engine.ConfigurationProvider);
        }
    }
}
