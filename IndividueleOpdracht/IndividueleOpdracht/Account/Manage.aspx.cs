// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Manage.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The manage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Account
{
    #region

    using System;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    #endregion

    /// <summary>The manage.</summary>
    public partial class Manage : System.Web.UI.Page
    {
        /// <summary>Gets the success message.</summary>
        /// <value>The success message.</value>
        protected string SuccessMessage
        {
            get;
            private set;
        }

        /// <summary>Gets a value indicating whether has phone number.</summary>
        /// <value>The has phone number.</value>
        public bool HasPhoneNumber { get; private set; }

        /// <summary>Gets a value indicating whether two factor enabled.</summary>
        /// <value>The two factor enabled.</value>
        public bool TwoFactorEnabled { get; private set; }

        /// <summary>Gets a value indicating whether two factor browser remembered.</summary>
        /// <value>The two factor browser remembered.</value>
        public bool TwoFactorBrowserRemembered { get; private set; }

        /// <summary>Gets or sets the logins count.</summary>
        /// <value>The logins count.</value>
        public int LoginsCount { get; set; }

        /// <summary>The has password.</summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        /// <summary>The page_ load.</summary>
        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = string.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            // PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;
            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : string.Empty;
                    successMessage.Visible = !string.IsNullOrEmpty(SuccessMessage);
                }
            }
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

        // Remove phonenumber from user
        /// <summary>The remove phone_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }

            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        /// <summary>The two factor disable_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        // EnableTwoFactorAuthentication 
        /// <summary>The two factor enable_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }
    }
}