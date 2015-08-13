using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using DoffingDesign.DAL;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.DAL.Mapping;
using DoffingDesign.Service;
using DoffingDesign.Service.Markdown;
using DoffingDotCom.Web.Secrets;

namespace DoffingDotCom.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.RegisterType<SqlProjectService>().As<IProjectService>();
            builder.RegisterType<ProjectMapper>().As<IProjectMapper>();
            builder.RegisterType<ProjectItemMapper>().As<IProjectItemMapper>();
            builder.RegisterType<MarkdownService>().As<IMarkdownService>();

            //database connection
            //TODO THIS NEEDS TO COME FROM A SERVICE!
            var connString = EnvironmentSettings.GetConnectionString();
            builder.RegisterType<DoffingDotComModel>().As<IDoffingDotComModel>()
                .WithParameter("connectionString", connString);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
