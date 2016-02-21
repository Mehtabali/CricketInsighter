using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CricketInsighter.Web.Startup))]
namespace CricketInsighter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
