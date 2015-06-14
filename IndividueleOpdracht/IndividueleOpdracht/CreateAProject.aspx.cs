// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateAProject.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The create a project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    using IndividueleOpdracht.Controllers;
    using IndividueleOpdracht.Models;

    #endregion

    /// <summary>The create a project.</summary>
    public partial class CreateAProject : System.Web.UI.Page
    {
        /// <summary>The project controller.</summary>
        ProjectController projectController = new ProjectController();

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TagModel> tags = projectController.GetAllTags();
            List<CategorieModel> categories = projectController.GetAllCategories();

            foreach (CategorieModel categorie in categories)
            {
                CategorieDD.Items.Add(new ListItem(categorie.Naam, categorie.Id));
            }

            foreach (TagModel tagModel in tags)
            {
                TagsDD.Items.Add(new ListItem(tagModel.Naam, tagModel.Id));
            }
        }

        /// <summary>The submit button_ on click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            if (CategorieDD.SelectedValue != "0")
            {
                ProjectModel projectModel = projectController.CreateProject(
                    ProjectBeschrijvingTextbox.Text, 
                    ProjectNameTextbox.Text, 
                    1, 
                    Convert.ToInt32(CategorieDD.SelectedValue), 
                    Convert.ToInt32(ProjectGeldNodigTextBox.Text), 
                    Convert.ToInt32(ProjectTijdNodigTextBox.Text));
                if (TagsDD.SelectedValue != "0")
                {
                    projectController.AddTagToProject(projectModel, Convert.ToInt32(TagsDD.SelectedValue));
                }

                Response.Redirect("ProjectViewer.aspx?id=" + projectModel.Id+ "&newproject=true");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write(
                    @"<SCRIPT LANGUAGE=""JavaScript"">alert(""Kies een categorie"")</SCRIPT>");
            }
        }
    }
}