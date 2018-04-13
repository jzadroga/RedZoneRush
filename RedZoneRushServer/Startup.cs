using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RedZoneRushServer.Startup))]

namespace RedZoneRushServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}