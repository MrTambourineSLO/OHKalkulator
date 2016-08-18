using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OhKalkulator.Startup))]
namespace OhKalkulator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
