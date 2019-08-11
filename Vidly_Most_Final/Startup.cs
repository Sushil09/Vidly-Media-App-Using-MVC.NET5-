using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_Most_Final.Startup))]
namespace Vidly_Most_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
