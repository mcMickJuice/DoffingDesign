using System;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DoffingDesign.DAL;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.DAL.Mapping;
using DoffingDesign.Service;
using DoffingDesign.Service.Markdown;
using DoffingDotCom.Web.Secrets;
using DoffingDotCom.Web.Services;
using Newtonsoft.Json.Serialization;

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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlProjectService>().As<IProjectService>();
            builder.RegisterType<ProjectMapper>().As<IProjectMapper>();
            builder.RegisterType<ProjectItemMapper>().As<IProjectItemMapper>();
            builder.RegisterType<MarkdownService>().As<IMarkdownService>();
            builder.RegisterType<SqlProjectEnumService>().As<IProjectEnumService>();
            builder.RegisterType<DiagnosticLogger>().As<IDiagnosticLogger>();

            //database connection
            //TODO THIS NEEDS TO COME FROM A SERVICE!
            var connString = EnvironmentSettings.GetConnectionString();
            builder.RegisterType<DoffingDotComModel>().As<IDoffingDotComModel>()
                .WithParameter("connectionString", connString)
                .InstancePerRequest();

            //web api config
            var httpConfiguration = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var jsonSerializer = GlobalConfiguration.Configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonSerializer.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var container = builder.Build();

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Application_BeginRequest()
        {
            if (ConfigProvider.Environment == "production")
            {
                //get request Url
                var preferredDomain = "http://www.alexandradoffing.com";
                var requestUri = Request.Url;

                //determine if it's to doffingdesign.com
                var isDoffingDesign = requestUri.Host.ToLowerInvariant().Contains("doffingdesign");

                //if it is, respond with redirect to alexandradoffing.com
                if (isDoffingDesign)
                {
                    var redirectUri = new Uri(preferredDomain);
                    if (requestUri.PathAndQuery.Length > 1)
                    {
                        redirectUri = new Uri(redirectUri, requestUri.PathAndQuery);
                    }

                    Response.RedirectPermanent(redirectUri.ToString());
                }
            }

        }
    }
}
