// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginPage.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The login page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI.WebControls;

    #endregion

    /// <summary>The login page.</summary>
    public partial class LoginPage : System.Web.UI.Page
    {
        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Visible)
            {
                
            }
        }

        /// <summary>The login 1_ on authenticate.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Login1_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = this.CridentialChecker(Login1.UserName, Login1.Password);
            FormsAuthentication.RedirectFromLoginPage(Login1.UserName.ToString(), Login1.DisplayRememberMe);
            e.Authenticated = Authenticated;
        }

        /// <summary>The cridential checker.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool CridentialChecker(string username, string password)
        {
            if (password == this.Master.AccountController.GetPasswordForUser(username))
            {
                return true;
            }

            return false;
        }

        /// <summary>The button 1_ on click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string userData = ticket.UserData;
        }
    }
}