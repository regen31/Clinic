using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using MyClinic.Logic.Infrastructure;
using MyClinic.WEB.Infrastructure;


namespace MyClinic.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // внедрение зависимостей
            NinjectModule DIModule = new DIModule();
            NinjectModule ServiceModule = new ServiceModule("DBConnection");
            var kernel = new StandardKernel(DIModule, ServiceModule);            
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
