using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolDb_Evidence.Startup))]
namespace SchoolDb_Evidence
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
