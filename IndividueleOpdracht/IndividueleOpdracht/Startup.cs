using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndividueleOpdracht.Startup))]
namespace IndividueleOpdracht
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
