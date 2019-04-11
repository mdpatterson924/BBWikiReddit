using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.MVC.Startup))]
namespace Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
