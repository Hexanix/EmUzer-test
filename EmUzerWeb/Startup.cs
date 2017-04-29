using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmUzerWeb.Startup))]
namespace EmUzerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
