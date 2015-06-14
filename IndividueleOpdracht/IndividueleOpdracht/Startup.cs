// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="">
//   
// </copyright>
// <summary>
//   The startup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using Microsoft.Owin;

#endregion

[assembly: OwinStartup(typeof(IndividueleOpdracht.Startup))]

namespace IndividueleOpdracht
{
    #region

    using IndividueleOpdracht.Controllers;

    using Owin;

    #endregion

    /// <summary>The startup.</summary>
    public partial class Startup 
    {
        /// <summary>The configuration.</summary>
        /// <param name="app">The app.</param>
        public void Configuration(IAppBuilder app)
        {
            DatabaseController.Initialiaze();
            this.ConfigureAuth(app);
        }
    }
}
