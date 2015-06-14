// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManageLogins.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The manage logins.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Account
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    #endregion

    /// <summary>The manage logins.</summary>
    public partial class ManageLogins : System.Web.UI.Page
    {
        /// <summary>Gets the success message.</summary>
        /// <value>The success message.</value>
        protected string SuccessMessage
        {
            get;
            private set;
        }

        /// <summary>Gets a value indicating whether can remove external logins.</summary>
        /// <value>The can remove external logins.</value>
        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        /// <summary>The has password.</summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

            SuccessMessage = string.Empty;
            successMessage.Visible = !string.IsNullOrEmpty(SuccessMessage);
        }

        /// <summary>The get logins.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<UserLoginInfo> GetLogins()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1 || HasPassword(manager);
            return accounts;
        }

        /// <summary>The remove login.</summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        public void RemoveLogin(string loginProvider, string providerKey)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.RemoveLogin(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            string msg = string.Empty;
            if (result.Succeeded)
            {
                var user = manager.FindById(User.Identity.GetUserId());
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                msg = "?m=RemoveLoginSuccess";
            }

            Response.Redirect("~/Account/ManageLogins" + msg);
        }
    }
}