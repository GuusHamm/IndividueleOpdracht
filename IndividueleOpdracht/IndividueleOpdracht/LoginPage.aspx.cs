using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdracht
{
    using System.Web.Security;

    using Microsoft.SqlServer.Server;

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

        protected void Login1_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = this.CridentialChecker(Login1.UserName, Login1.Password);
            FormsAuthentication.RedirectFromLoginPage(Login1.UserName.ToString(),Login1.DisplayRememberMe);
            e.Authenticated = Authenticated;
        }

        private bool CridentialChecker(string username, string password)
        {
            if (password == this.Master.AccountController.GetPasswordForUser(username))
            {
                return true;
            }
            return false;
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string userData = ticket.UserData;
        }
    }
}