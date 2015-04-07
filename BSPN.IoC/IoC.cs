using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPN.IoC
{
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
