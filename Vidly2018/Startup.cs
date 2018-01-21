using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly2018.Startup))]
namespace Vidly2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
