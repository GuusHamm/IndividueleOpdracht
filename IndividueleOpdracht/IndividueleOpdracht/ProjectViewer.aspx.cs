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

    public partial class ProjectViewer : System.Web.UI.Page
    {

        private List<ProjectModel> projectModels;

        private ProjectController projectController = new ProjectController();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProjectModel> data = this.projectController.GetProjects(Convert.ToInt32(Request.QueryString["id"]));
            
            if (data != null)
            {
                ProjectView.DataSource = data;
            }

            foreach (ProjectModel projectModel in data)
            {
                projectModel.AddComments(projectController.GetCommentsOfProject(0, projectModel));
                CommentView.DataSource = projectModel.Comments;
                projectModel.AddTags(projectController.GetTagOfProject(0,projectModel));
                ProjectTagView.DataSource = projectModel.Tags;
                List<TierModel> tierModels = projectController.GetTiersOfProject(0, projectModel);
                TierViewer.DataSource = tierModels;
                foreach (TierModel tierModel in tierModels)
                {
                    TierDD.Items.Add(new ListItem(tierModel.Naam, tierModel.Id));
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ProjectView.DataBind();
            ProjectTagView.DataBind();
            CommentView.DataBind();
            TierViewer.DataBind();
        }


        protected void ProjectView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ProjectModel projectModel = e.Item.DataItem as ProjectModel;
            e.Item.ID = projectModel.Id;
            Literal naamLiteral = e.Item.FindControl("LiteralNaam") as Literal;
            if (naamLiteral != null)
            {
                naamLiteral.Text = projectModel.Naam;
            }

            Literal beschrijvingLiteral = e.Item.FindControl("LiteralBeschrijving") as Literal;
            if (beschrijvingLiteral != null)
            {
                beschrijvingLiteral.Text = projectModel.Beschrijving;
            }

            Literal creatorLiteral = e.Item.FindControl("LiteralCreator") as Literal;
            if (creatorLiteral != null)
            {
                creatorLiteral.Text = projectModel.Creator.Naam;
            }

            Literal viewsLiteral = e.Item.FindControl("LiteralViews") as Literal;
            if (viewsLiteral != null)
            {
                viewsLiteral.Text = projectModel.Views.ToString() + " Views";
            }

            Literal percentageCompleteLiteral = e.Item.FindControl("LiteralPercentageComplete") as Literal;
            if (percentageCompleteLiteral != null)
            {
                decimal percentage = Convert.ToDecimal(projectModel.GeldBehaald) / Convert.ToDecimal(projectModel.GeldNodig);
                percentage = percentage * 100;
                percentage = Decimal.Round(percentage, 0);
                percentageCompleteLiteral.Text = Convert.ToString(percentage) + "% goal behaald";
            }

            Literal categorieLiteral = e.Item.FindControl("LiteralCategorie") as Literal;
            if (categorieLiteral != null)
            {
                categorieLiteral.Text = projectModel.Categorie.Naam;
            }
        }

        protected void CommentView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            CommentModel comment = e.Item.DataItem as CommentModel;
            Literal commentCreator = e.Item.FindControl("CommentCreator") as Literal;
            commentCreator.Text = AccountController.RetrieveAccount(comment.PosterId).Naam;

            Literal commentText = e.Item.FindControl("CommentText") as Literal;
            commentText.Text = comment.Bericht;
        }

        protected void ProjectTagView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            TagModel tag = e.Item.DataItem as TagModel;
            Literal literalTag = e.Item.FindControl("LiteralTag") as Literal;
            literalTag.Text = tag.Naam;
        }

        protected void CommentButton_OnClick(object sender, EventArgs e)
        {
            //todo make dynamic
            foreach (ProjectModel projectModel in projectController.GetProjects(Convert.ToInt32(Request.QueryString["id"])))
            {
                List<CommentModel> comments = projectModel.Comments;
                comments.Add(projectController.CreateComment(CommentTextBox.Text,1,Convert.ToInt32(projectModel.Id)));
                projectModel.AddComments(comments);
                Response.Redirect(Request.RawUrl);
            }
            
        }

        protected void LearnMoreButton_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void BackButton_OnClick(object sender, EventArgs e)
        {
            CommentTextBoxValidator.Enabled = false;
            projectController.CreateBacking("1", TierDD.SelectedValue, Request.QueryString["id"]);
            Response.Redirect(Request.RawUrlz);
        }

        protected void TierViewer_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            TierModel tier = e.Item.DataItem as TierModel;

            Literal tierNaamLiteral = e.Item.FindControl("LiteralTierNaam") as Literal;
            tierNaamLiteral.Text = tier.Naam;

            Literal tierRewardLiteral = e.Item.FindControl("LiteralTierReward") as Literal;
            tierRewardLiteral.Text = tier.Reward;

            Literal tierPrijsLiteral = e.Item.FindControl("LiteralTierPrijs") as Literal;
            tierPrijsLiteral.Text = "€ " + tier.Prijs.ToString();
        }
    }
}