using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeProject.Startup))]
namespace PracticeProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
