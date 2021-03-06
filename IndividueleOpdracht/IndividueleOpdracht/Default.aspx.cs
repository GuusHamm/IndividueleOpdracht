﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Web.UI.WebControls;

    using IndividueleOpdracht.Controllers;
    using IndividueleOpdracht.Models;

    #endregion

    /// <summary>The _ default.</summary>
    public partial class _Default : Page
    {
        /// <summary>The project controller.</summary>
        private ProjectController projectController = new ProjectController();

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProjectModel> data = this.projectController.GetPopulairProjects(3);
            if (data != null)
            {
                ProjectView.DataSource = data;
            }
        }

        /// <summary>The page_ pre render.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ProjectView.DataBind();
        }

        /// <summary>The project view_ on item data bound.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void ProjectView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ProjectModel projectModel = e.Item.DataItem as ProjectModel;

            AProject aProject = e.Item.FindControl("AProject") as AProject;

            aProject.FillUC(
                projectModel, 
                projectController.GetNumberOfBackingsOfProject(Convert.ToInt32(projectModel.Id)));

            this.ProjectSelectionDD.Items.Add(new ListItem(projectModel.Naam, projectModel.Id));
        }

        /// <summary>The btn goto project_ on click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void BtnGotoProject_OnClick(object sender, EventArgs e)
        {
            this.Response.Redirect("ProjectDetails.aspx?id=" + this.ProjectSelectionDD.SelectedValue);
        }
    }
}