using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndividueleOpdracht.Models;
namespace IndividueleOpdracht
{
    using System.Web.Services.Description;

    using IndividueleOpdracht.Controllers;
    public partial class _Default : Page
    {
        private List<ProjectModel> projectModels;

        private ProjectController projectController = new ProjectController();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AccountController.CreateAccount("Karel Hamm", "karelhamm@hotmail.com", "Nederland", "0402523313");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<CommentModel> commentModels = projectController.GetCommentsOfProject(4, null);
        }
      

    }
}