using Owin;

namespace WebFormsSample03
{
    public static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}