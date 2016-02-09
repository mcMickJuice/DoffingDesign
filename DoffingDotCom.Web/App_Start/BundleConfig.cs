using System.Web;
using System.Web.Optimization;

namespace DoffingDotCom.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/utility.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/styles/site.css",
                      "~/Content/styles/footer.css",
                      "~/Content/styles/header.css",
                      "~/Content/styles/project-index.css",
                      "~/Content/styles/project-view.css",
                      "~/Content/styles/global.css",
                      "~/Content/styles/about.css",
                      "~/Content/styles/newsletter.css"));

            bundles.Add(new StyleBundle("~/Content/homeCss").Include(
                        "~/Content/styles/home.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/projectViewCss")
                .Include("~/Content/styles/project-view.css"));


            //load in project admin module only
            bundles.Add(new StyleBundle("~/Content/adminCss"));

            bundles.Add(new ScriptBundle("~/bundles/projectAdmin")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-ui-router.js")
                .Include("~/client/common-services/services.module.js")
                .IncludeDirectory("~/client/common-services","*.js",true)
                .Include("~/client/home/home.module.js")
                .IncludeDirectory("~/client/home", "*.js", true)
                .Include("~/client/project/project.module.js")
                .IncludeDirectory("~/client/project", "*.js", true)
                .Include("~/client/app-components.module.js")

                //always last!
                .Include("~/client/doffing-admin.module.js")
                );
        }
    }
}
