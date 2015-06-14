// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The _ default.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    using IndividueleOpdracht.Controllers;
    using IndividueleOpdracht.Models;

    #endregion

    /// <summary>The _ default.</summary>
    public partial class _Default : Page
    {
        /// <summary>The project controller.</summary>
        private ProjectController projectController = new ProjectController();

        /// <summary>The project models.</summary>
        private List<ProjectModel> projectModels;

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>The button 1_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            AccountController.CreateAccount("Karel Hamm", "karelhamm@hotmail.com", "Nederland", "0402523313");
        }

        /// <summary>The button 2_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            List<CommentModel> commentModels = projectController.GetCommentsOfProject(4, null);
        }
    }
}