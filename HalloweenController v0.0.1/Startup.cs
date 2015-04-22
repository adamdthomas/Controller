using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HalloweenController_v0._0._1.Startup))]
namespace HalloweenController_v0._0._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
