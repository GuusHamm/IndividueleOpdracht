// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectDetails.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The project viewer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI.WebControls;

    using IndividueleOpdracht.Controllers;
    using IndividueleOpdracht.Models;

    #endregion

    /// <summary>The project viewer.</summary>
    public partial class ProjectDetails : System.Web.UI.Page
    {
        /// <summary>The project controller.</summary>
        private ProjectController projectController = new ProjectController();

        /// <summary>The page_ load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
       [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = this.User.Identity.ToString();
            int id;
            
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                List<ProjectModel> data = this.projectController.GetProjects(id);

                if (data != null)
                {
                    ProjectView.DataSource = data;
                }

                foreach (ProjectModel projectModel in data)
                {
                    projectModel.AddComments(projectController.GetCommentsOfProject(0, projectModel));
                    CommentView.DataSource = projectModel.Comments;
                    projectModel.AddTags(projectController.GetTagOfProject(0, projectModel));
                    ProjectTagView.DataSource = projectModel.Tags;
                    List<TierModel> tierModels = projectController.GetTiersOfProject(0, projectModel);
                    TierViewer.DataSource = tierModels;
                    foreach (TierModel tierModel in tierModels)
                    {
                        TierDD.Items.Add(new ListItem(tierModel.Naam, tierModel.Id));
                    }
                }

                bool newProject = Convert.ToBoolean(Request.QueryString["newproject"]);
                if (newProject)
                {
                    ExtraStuffDiv.InnerHtml = @"<div class=""alert alert-dismissable alert-success"">    <button type=""button"" class=""close"" data-dismiss=""alert"">×</button>    Hier is je nieuwe project!.</div>";
                }
            }
            else
            {
                PageContents.InnerHtml = @"<div class=""alert alert-dismissable alert-danger"">    <button type=""button"" class=""close"" data-dismiss=""alert"">×</button> Om deze pagina weer te geven moet een id worden opgegeven.</div>";
            }
        }

        /// <summary>The page_ pre render.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ProjectView.DataBind();
            ProjectTagView.DataBind();
            CommentView.DataBind();
            TierViewer.DataBind();
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
        }

        /// <summary>The comment view_ on item data bound.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void CommentView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            CommentModel comment = e.Item.DataItem as CommentModel;
            Literal commentCreator = e.Item.FindControl("CommentCreator") as Literal;
            commentCreator.Text = this.Master.AccountController.RetrieveAccount(comment.PosterId).Naam;

            Literal commentText = e.Item.FindControl("CommentText") as Literal;
            commentText.Text = comment.Bericht;
        }

        /// <summary>The project tag view_ on item data bound.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void ProjectTagView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            TagModel tag = e.Item.DataItem as TagModel;
            Literal literalTag = e.Item.FindControl("LiteralTag") as Literal;
            literalTag.Text = tag.Naam;
        }

        /// <summary>The comment button_ on click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void CommentButton_OnClick(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);


                foreach (ProjectModel projectModel in projectController.GetProjects(Convert.ToInt32(Request.QueryString["id"])))
                {
                    List<CommentModel> comments = projectModel.Comments;
                    int accountID = Convert.ToInt32(this.Master.AccountController.GetAccountId(ticket.Name));
                    comments.Add(projectController.CreateComment(CommentTextBox.Text, accountID, Convert.ToInt32(projectModel.Id)));
                    projectModel.AddComments(comments);
                    Response.Redirect(Request.RawUrl);
                }

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                this.ExtraStuffDiv.InnerHtml = @"<div class=""alert alert-dismissable alert-danger"">    <button type=""button"" class=""close"" data-dismiss=""alert"">×</button> Je moet ingelogd zijn om te kunnen commenten.</div>";
            }
            
        }

        /// <summary>The back button_ on click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void BackButton_OnClick(object sender, EventArgs e)
        {
            CommentTextBoxValidator.Enabled = false;
            projectController.CreateBacking("1", TierDD.SelectedValue, Request.QueryString["id"]);
            Response.Redirect(Request.RawUrl);
        }

        /// <summary>The tier viewer_ on item data bound.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
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