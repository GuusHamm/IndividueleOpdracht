// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterExternalLogin.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The register external login.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Account
{
    #region

    using System;
    using System.Web;

    using IndividueleOpdracht.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    #endregion

    /// <summary>The register external login.</summary>
    public partial class RegisterExternalLogin : System.Web.UI.Page
    {
        /// <summary>Gets the provider name.</summary>
        /// <value>The provider name.</value>
        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? string.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        /// <summary>Gets the provider account key.</summary>
        /// <value>The provider account key.</value>
        protected string ProviderAccountKey
        {
            get { return (string)ViewState["ProviderAccountKey"] ?? string.Empty; }
            private set { ViewState["ProviderAccountKey"] = value; }
        }

        /// <summary>The redirect on fail.</summary>
        private void RedirectOnFail()
        {
            Response.Redirect(User.Identity.IsAuthenticated ? "~/Account/Manage" : "~/Account/Login");
        }

        /// <summary>The page_ load.</summary>
        protected void Page_Load()
        {
            // Process the result from an auth provider in the request
            ProviderName = IdentityHelper.GetProviderNameFromRequest(Request);
            if (string.IsNullOrEmpty(ProviderName))
            {
                RedirectOnFail();
                return;
            }

            if (!IsPostBack)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    RedirectOnFail();
                    return;
                }

                var user = manager.Find(loginInfo.Login);
                if (user != null)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else if (User.Identity.IsAuthenticated)
                {
                    // Apply Xsrf check when linking
                    var verifiedloginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo(IdentityHelper.XsrfKey, User.Identity.GetUserId());
                    if (verifiedloginInfo == null)
                    {
                        RedirectOnFail();
                        return;
                    }

                    var result = manager.AddLogin(User.Identity.GetUserId(), verifiedloginInfo.Login);
                    if (result.Succeeded)
                    {
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }
                    else
                    {
                        AddErrors(result);
                        return;
                    }
                }
                else
                {
                    email.Text = loginInfo.Email;
                }
            }
        }

        /// <summary>The log in_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void LogIn_Click(object sender, EventArgs e)
        {
            CreateAndLoginUser();
        }

        /// <summary>The create and login user.</summary>
        private void CreateAndLoginUser()
        {
            if (!IsValid)
            {
                return;
            }

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = email.Text, Email = email.Text };
            IdentityResult result = manager.Create(user);
            if (result.Succeeded)
            {
                var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    RedirectOnFail();
                    return;
                }

                result = manager.AddLogin(user.Id, loginInfo.Login);
                if (result.Succeeded)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // var code = manager.GenerateEmailConfirmationToken(user.Id);
                    // Send this link via email: IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    return;
                }
            }

            AddErrors(result);
        }

        /// <summary>The add errors.</summary>
        /// <param name="result">The result.</param>
        private void AddErrors(IdentityResult result) 
        {
            foreach (var error in result.Errors) 
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}