using Microsoft.Owin.Cors;
using Owin;

namespace SignalR02
{
    public static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}