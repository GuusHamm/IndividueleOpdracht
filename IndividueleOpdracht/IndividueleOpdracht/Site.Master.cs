// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Site.Master.cs" company="">
//   
// </copyright>
// <summary>
//   The site master.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using IndividueleOpdracht.Controllers;

    #endregion

    /// <summary>The site master.</summary>
    public partial class SiteMaster : MasterPage
    {
        /// <summary>The anti xsrf token key.</summary>
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";

        /// <summary>The anti xsrf user name key.</summary>
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";

        /// <summary>The _anti xsrf token value.</summary>
        private string _antiXsrfTokenValue;

        /// <summary>The page_ init.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true, 
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }

                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        /// <summary>The master_ page_ pre load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <exception cref="InvalidOperationException"></exception>
        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? string.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? string.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>The unnamed_ logging out.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void SearchButton_OnClick(object sender, EventArgs e)
        {
         Response.Redirect("Project.aspx?search="+ SearchBox.Text);  
        }
    }

}