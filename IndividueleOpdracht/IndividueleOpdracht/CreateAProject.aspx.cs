using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdracht
{
    using IndividueleOpdracht.Controllers;
    using IndividueleOpdracht.Models;

    public partial class CreateAProject : System.Web.UI.Page
    {
        ProjectController projectController = new ProjectController();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<TagModel> tags = projectController.GetAllTags();
            List<CategorieModel> categories = projectController.GetAllCategories();

            foreach (CategorieModel categorie in categories)
            {
                CategorieDD.Items.Add(new ListItem(categorie.Naam,categorie.Id));
            }

            foreach (TagModel tagModel in tags)
            {
                TagsDD.Items.Add(new ListItem(tagModel.Naam,tagModel.Id));
            }

        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            ProjectModel projectModel = projectController.CreateProject(
                ProjectBeschrijvingTextbox.Text,
                ProjectNameTextbox.Text,
                1,
                Convert.ToInt32(CategorieDD.SelectedValue),
                Convert.ToInt32(ProjectGeldNodigTextBox.Text),
                Convert.ToInt32(ProjectTijdNodigTextBox.Text));

            Response.Redirect("ProjectViewer.aspx?id=" + projectModel.Id);
        }
    }
}