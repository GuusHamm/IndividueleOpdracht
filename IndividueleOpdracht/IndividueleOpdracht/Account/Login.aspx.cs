﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Login.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The login.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Account
{
    #region

    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using IndividueleOpdracht.Controllers;

    using Microsoft.AspNet.Identity.Owin;

    #endregion

    /// <summary>The login.</summary>
    public partial class Login : Page
    {
        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";

            // Enable this once you have account confirmation enabled for password reset functionality
            // ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!string.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        /// <summary>The log in.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void LogIn(object sender, EventArgs e)
        {
            AuthenticateEventArgs f =(AuthenticateEventArgs)e;
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                SignInStatus result;

                if (Password.Text == AccountController.GetPasswordForUser(Email.Text))
                {
                    result = SignInStatus.Success;
                    
                }
                else
                {
                    result = SignInStatus.Failure;
                }

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        f.Authenticated = true;
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(string.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"], 
                                                        RememberMe.Checked), 
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        f.Authenticated = false;
                        break;
                }
            }
        }
    }
}