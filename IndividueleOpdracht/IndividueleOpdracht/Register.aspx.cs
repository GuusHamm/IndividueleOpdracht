// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Register.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;

    #endregion

    /// <summary>The registration.</summary>
    public partial class Registration : System.Web.UI.Page
    {
        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>The submit button_ on click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (AccountTypeDD.SelectedValue == "Regular")
                {
                    this.Master.AccountController.CreateAccount(
                        NaamTB.Text, 
                        MailTB.Text, 
                        LandTB.Text, 
                        TelefoonnummerTB.Text.Normalize(), 
                        UsernameTB.Text.Normalize(), 
                        PasswordTB.Text);
                }

            }
        }

        /// <summary>The account type_ on selected index changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void AccountType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (AccountTypeDD.SelectedValue == "Creator")
            {
                BiografieTB.CssClass = "control-label";
                BiografieTBValidator.Enabled = true;

                AdresTB.CssClass = "control-label";
                AdresTBValidator.Enabled = true;

                PostcodeTB.CssClass = "control-label";
                PostcodeTBRegex.Enabled = true;
                PostcodeTBValidator.Enabled = true;

                WoonplaatsTB.CssClass = "control-label";
                WoonplaatsTBValidator.Enabled = true;

                BetalingsGegevensTB.CssClass = "control-label";
                BetalingsGegevensTBValidator.Enabled = true;
            }
        }
    }
}