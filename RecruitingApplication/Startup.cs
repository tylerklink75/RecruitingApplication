using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecruitingApplication.Startup))]
namespace RecruitingApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
