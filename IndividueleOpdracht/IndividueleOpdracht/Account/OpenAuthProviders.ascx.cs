// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenAuthProviders.ascx.cs" company="">
//   
// </copyright>
// <summary>
//   The open auth providers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Account
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    #endregion

    /// <summary>The open auth providers.</summary>
    public partial class OpenAuthProviders : System.Web.UI.UserControl
    {
        /// <summary>Gets or sets the return url.</summary>
        /// <value>The return url.</value>
        public string ReturnUrl { get; set; }

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var provider = Request.Form["provider"];
                if (provider == null)
                {
                    return;
                }

                // Request a redirect to the external login provider
                string redirectUrl =
                    ResolveUrl(
                        string.Format(
                            CultureInfo.InvariantCulture, 
                            "~/Account/RegisterExternalLogin?{0}={1}&returnUrl={2}", 
                            IdentityHelper.ProviderNameKey, 
                            provider, 
                            ReturnUrl));
                var properties = new AuthenticationProperties() { RedirectUri = redirectUrl };

                // Add xsrf verification when linking accounts
                if (Context.User.Identity.IsAuthenticated)
                {
                    properties.Dictionary[IdentityHelper.XsrfKey] = Context.User.Identity.GetUserId();
                }

                Context.GetOwinContext().Authentication.Challenge(properties, provider);
                Response.StatusCode = 401;
                Response.End();
            }
        }

        /// <summary>The get provider names.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<string> GetProviderNames()
        {
            return Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes().Select(t => t.AuthenticationType);
        }
    }
}