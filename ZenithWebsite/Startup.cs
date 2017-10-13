using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZenithDataLib.Startup))]
namespace ZenithDataLib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
