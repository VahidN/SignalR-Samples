using Microsoft.Owin;
using Owin;

// this namespace is important.
namespace SignalR01
{
    public static class Startup
    {
        // its name is Configuration and not ConfigureSignalR or anything else.
        public static void Configuration(IAppBuilder app)
        {
             app.MapSignalR();
        }
    }
}