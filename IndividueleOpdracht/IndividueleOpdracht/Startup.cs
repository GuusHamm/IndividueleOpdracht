using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndividueleOpdracht.Startup))]

namespace IndividueleOpdracht
{
    using IndividueleOpdracht.Controllers;

    public partial class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseController.Initialiaze();
            this.ConfigureAuth(app);
        }
    }
}
