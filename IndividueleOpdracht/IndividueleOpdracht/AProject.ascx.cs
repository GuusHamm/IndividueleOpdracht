// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AProject.ascx.cs" company="">
//   
// </copyright>
// <summary>
//   The a project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;

    using IndividueleOpdracht.Controllers;
    using IndividueleOpdracht.Models;

    #endregion

    /// <summary>The a project.</summary>
    public partial class AProject : System.Web.UI.UserControl
    {
        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>The fill uc.</summary>
        /// <param name="projectModel">The project model.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public void FillUC(ProjectModel projectModel,int backings)
        {

            LiteralNaam.Text = projectModel.Naam;
            LiteralBeschrijving.Text = projectModel.Beschrijving;

            LiteralCreator.Text = projectModel.Creator.Naam;

            LiteralViews.Text = projectModel.Views.ToString() + " Views";
            decimal percentage = Convert.ToDecimal(projectModel.GeldBehaald) / Convert.ToDecimal(projectModel.GeldNodig);
            percentage = percentage * 100;
            percentage = decimal.Round(percentage, 0);
            LiteralPercentageComplete.Text = Convert.ToString(percentage) + "% goal behaald";

            LiteralBackings.Text = backings + " backings";
            LiteralCategorie.Text = projectModel.Categorie.Naam;

            
        }
    }
}