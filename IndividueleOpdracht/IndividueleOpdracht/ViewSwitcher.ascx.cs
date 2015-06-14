// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewSwitcher.ascx.cs" company="">
//   
// </copyright>
// <summary>
//   The view switcher.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Web;
    using System.Web.Routing;

    using Microsoft.AspNet.FriendlyUrls.Resolvers;

    #endregion

    /// <summary>The view switcher.</summary>
    public partial class ViewSwitcher : System.Web.UI.UserControl
    {
        /// <summary>Gets the current view.</summary>
        /// <value>The current view.</value>
        protected string CurrentView { get; private set; }

        /// <summary>Gets the alternate view.</summary>
        /// <value>The alternate view.</value>
        protected string AlternateView { get; private set; }

        /// <summary>Gets the switch url.</summary>
        /// <value>The switch url.</value>
        protected string SwitchUrl { get; private set; }

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Determine current view
            var isMobile = WebFormsFriendlyUrlResolver.IsMobileView(new HttpContextWrapper(Context));
            CurrentView = isMobile ? "Mobile" : "Desktop";

            // Determine alternate view
            AlternateView = isMobile ? "Desktop" : "Mobile";

            // Create switch URL from the route, e.g. ~/__FriendlyUrls_SwitchView/Mobile?ReturnUrl=/Page
            var switchViewRouteName = "AspNet.FriendlyUrls.SwitchView";
            var switchViewRoute = RouteTable.Routes[switchViewRouteName];
            if (switchViewRoute == null)
            {
                // Friendly URLs is not enabled or the name of the switch view route is out of sync
                this.Visible = false;
                return;
            }

            var url = GetRouteUrl(switchViewRouteName, new { view = AlternateView, __FriendlyUrls_SwitchViews = true });
            url += "?ReturnUrl=" + HttpUtility.UrlEncode(Request.RawUrl);
            SwitchUrl = url;
        }
    }
}