﻿using System;
using System.Collections.Generic;
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
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DoffingDesign.Common;
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
            builder.RegisterType<SystemClock>().As<IClock>();

            //contact services
            builder.RegisterType<SqlContactService>().As<IContactService>();
            builder.RegisterType<ContactMapper>().As<IContactMapper>();
            
            var credentials = ThirdPartyCredentials.GetCredentialsForEnvironment();

            builder.Register(c =>
            {
                var httpClient = c.Resolve<IHttpClient>();
                var serializer = c.Resolve<IJsonSerializer>();
                return new MailChimpService(httpClient, serializer, credentials);
            }).As<INewsletterService>();

            builder.RegisterType<HttpClientWrapper>().As<IHttpClient>();
            builder.RegisterType<JsonNetSerializer>().As<IJsonSerializer>();


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

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            var logger = new DiagnosticLogger();

            var msg = string.Format("Error in DoffingDotCom: {0}", ex.Message);

            logger.LogError(msg);

        }
    }
}
