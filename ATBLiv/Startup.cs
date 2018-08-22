using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATBLiv.Startup))]
namespace ATBLiv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
