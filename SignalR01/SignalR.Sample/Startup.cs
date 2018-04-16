using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Microsoft.AspNet.SignalR.StockTicker.Startup))]

namespace Microsoft.AspNet.SignalR.StockTicker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureSignalR(app);
        }

        public static void ConfigureSignalR(IAppBuilder app)
        {
             app.MapSignalR();
        }
    }
}