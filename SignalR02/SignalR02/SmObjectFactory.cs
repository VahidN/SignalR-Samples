using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using SignalR02.Services;
using SignalR02.Utils;
using StructureMap;

namespace SignalR02
{
    public static class SmObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            return new Container(cfg =>
            {
                cfg.For<IDependencyResolver>().Singleton().Add<StructureMapDependencyResolver>();
                // the rest ...
                cfg.For<ITestService>().Use<TestService>();
            });
        }
    }
}