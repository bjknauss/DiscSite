using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiscSite.Startup))]
namespace DiscSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
