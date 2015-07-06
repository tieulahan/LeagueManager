using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using MvcRefactor.Data;
using MvcRefactor.Service;
using MvcRefactor.Service.Implementation;


namespace MvcRefactorTest
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Bootstrapper.Initialise();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //private void RegisterUnityContainer()
        //{
        //    var container = new UnityContainer();
        //    container.RegisterType<IContenService, ContenService>(new PerThreadLifetimeManager())
        //                  .RegisterType<IDALContext, DALContext>();
        //    container.RegisterType<IUserService, UserService>(new PerThreadLifetimeManager())
        //                  .RegisterType<IDALContext, DALContext>();
        //    DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        //}
    }
}