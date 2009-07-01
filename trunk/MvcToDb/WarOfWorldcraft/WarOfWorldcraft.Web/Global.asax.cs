using System.Collections;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HibernatingRhinos.NHibernate.Profiler.Appender;
using MvcContrib.ControllerFactories;
using MvcContrib.Services;
using MvcContrib.Spring;
using Spring.Context.Support;
using WarOfWorldcraft.Domain;
using WarOfWorldcraft.Utilities.IoC;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Web
{
    public class MvcApplication : HttpApplication
    {
        internal void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ConfigureIoC();
            ApplicationStartup.Run();
            InitNHibernate();
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }

        private void ConfigureIoC()
        {
            var context = new XmlApplicationContext(
                "assembly://WarOfWorldcraft.Domain/WarOfWorldcraft.Domain/objects.xml", 
                "assembly://WarOfWorldcraft.Web/WarOfWorldcraft.Web/objects.xml");
            Container.Initialize(new SpringContainer(context));
            DependencyResolver.InitializeWith(new SpringDependencyResolver(context));
            ControllerBuilder.Current.SetControllerFactory(typeof (IoCControllerFactory));
        }

        private void InitNHibernate()
        {
            Utilities.Repository.Context.Current = new WebContext();
            NHibernateProfiler.Initialize();
        }
    }

    internal class WebContext : IContext
    {
        public IDictionary Items
        {
            get { return HttpContext.Current.Items; }
        }

        public IPrincipal Principal
        {
            get { return HttpContext.Current.User; }
        }
    }
}