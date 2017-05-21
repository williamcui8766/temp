using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(exportdemo.Startup))]
namespace exportdemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
