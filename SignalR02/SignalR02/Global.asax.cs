using System;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR02
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalHost.DependencyResolver = SmObjectFactory.Container.GetInstance<IDependencyResolver>();
        }
    }
}