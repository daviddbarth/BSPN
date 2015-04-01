using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BSPN.Startup))]
namespace BSPN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
