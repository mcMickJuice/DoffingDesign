using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoffingDotCom.Web.Startup))]
namespace DoffingDotCom.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
