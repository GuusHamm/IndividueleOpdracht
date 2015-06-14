// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectModel.cs" company="">
//   
// </copyright>
// <summary>
//   The project model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>The project model.</summary>
    public class ProjectModel : DatabaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="ProjectModel"/> class.</summary>
        /// <param name="beschrijving">The beschrijving.</param>
        /// <param name="naam">The naam.</param>
        /// <param name="creator">The creator.</param>
        /// <param name="geldNodig">The geld nodig.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="geldBehaald">The geld behaald.</param>
        /// <param name="views">The views.</param>
        /// <param name="categorieModel">The categorie model.</param>
        public ProjectModel(string beschrijving, string naam, AccountModel creator, int geldNodig, DateTime startDate, DateTime endDate, int geldBehaald, int views, CategorieModel categorieModel)
        {
            this.Comments = new List<CommentModel>();
            this.Tags = new List<TagModel>();


            this.Beschrijving = beschrijving;
            this.Naam = naam;
            this.Creator = creator;
            this.GeldNodig = geldNodig;
            if (geldBehaald != 0)
            {
                this.GeldBehaald = geldBehaald;
            }
            else
            {
                this.GeldBehaald = 0;
            }
            
            this.StartDate = startDate;
            this.EndDate = endDate;

            if (views != 0)
            {
                this.Views = views;
            }
            else
            {
                this.Views = 0;
            }

            this.Categorie = categorieModel;
        }

        /// <summary>Gets the beschrijving.</summary>
        /// <value>The beschrijving.</value>
        public string Beschrijving { get; private set; }

        /// <summary>Gets the naam.</summary>
        /// <value>The naam.</value>
        public string Naam { get; private set; }

        /// <summary>Gets the creator.</summary>
        /// <value>The creator.</value>
        public AccountModel Creator { get; private set; }

        /// <summary>Gets the categorie.</summary>
        /// <value>The categorie.</value>
        public CategorieModel Categorie { get; private set; }

        /// <summary>Gets the geld nodig.</summary>
        /// <value>The geld nodig.</value>
        public int GeldNodig { get; private set; }

        /// <summary>Gets the geld behaald.</summary>
        /// <value>The geld behaald.</value>
        public int GeldBehaald { get; private set; }

        /// <summary>Gets the start date.</summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; private set; }

        /// <summary>Gets the end date.</summary>
        /// <value>The end date.</value>
        public DateTime EndDate { get; private set; }

        /// <summary>Gets the views.</summary>
        /// <value>The views.</value>
        public int Views { get; private set; }

        /// <summary>Gets the tags.</summary>
        /// <value>The tags.</value>
        public List<TagModel> Tags { get; private set; }

        /// <summary>Gets the comments.</summary>
        /// <value>The comments.</value>
        public List<CommentModel> Comments { get; private set; }

        /// <summary>The add comments.</summary>
        /// <param name="comments">The comments.</param>
        public void AddComments(List<CommentModel> comments)
        {
            this.Comments = comments;
        }

        /// <summary>The add tags.</summary>
        /// <param name="tags">The tags.</param>
        public void AddTags(List<TagModel> tags)
        {
            this.Tags = tags;
        }

        /// <summary>The add backing.</summary>
        /// <param name="amount">The amount.</param>
        public void AddBacking(int amount)
        {
            this.GeldBehaald += amount;
        }
    }
}