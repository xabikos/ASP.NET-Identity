using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Asp.Identity.EntityFramework.Web.Startup))]
namespace Asp.Identity.EntityFramework.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
