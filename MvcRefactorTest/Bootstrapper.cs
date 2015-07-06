using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MvcRefactor.Data;
using MvcRefactor.Logging;
using MvcRefactor.Service;
using MvcRefactor.Service.Implementation;
using Unity.Mvc4;

namespace MvcRefactorTest
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILogger, FileLogManager>(new PerThreadLifetimeManager())
                                  .RegisterType<IDALContext, DALContext>();
            container.RegisterType<IUserService, UserService>(new PerThreadLifetimeManager())
                          .RegisterType<IDALContext, DALContext>();         
        }
    }
}