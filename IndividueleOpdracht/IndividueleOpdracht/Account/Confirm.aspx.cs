// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Confirm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The confirm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Account
{
    #region

    using System;
    using System.Web;
    using System.Web.UI;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    #endregion

    /// <summary>The confirm.</summary>
    public partial class Confirm : Page
    {
        /// <summary>Gets the status message.</summary>
        /// <value>The status message.</value>
        protected string StatusMessage
        {
            get;
            private set;
        }

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            string userId = IdentityHelper.GetUserIdFromRequest(Request);
            if (code != null && userId != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var result = manager.ConfirmEmail(userId, code);
                if (result.Succeeded)
                {
                    successPanel.Visible = true;
                    return;
                }
            }

            successPanel.Visible = false;
            errorPanel.Visible = true;
        }
    }
}