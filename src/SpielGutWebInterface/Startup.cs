using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpielGutWebInterface.Startup))]
namespace SpielGutWebInterface
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
