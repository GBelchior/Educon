using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Educon.Startup))]

namespace Educon
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
