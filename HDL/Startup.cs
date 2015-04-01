using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HDL.Startup))]
namespace HDL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
