// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategorieModel.cs" company="">
//   
// </copyright>
// <summary>
//   The categorie model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    /// <summary>The categorie model.</summary>
    public class CategorieModel : IDatabaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="CategorieModel"/> class.</summary>
        /// <param name="naam">The naam.</param>
        /// <param name="beschrijving">The beschrijving.</param>
        public CategorieModel(string naam, string beschrijving)
        {
            this.Naam = naam;
            this.Beschrijving = beschrijving;
        }

        /// <summary>Gets the naam.</summary>
        /// <value>The naam.</value>
        public string Naam { get; private set; }

        /// <summary>Gets the beschrijving.</summary>
        /// <value>The beschrijving.</value>
        public string Beschrijving { get; private set; }

        /// <summary>Gets or sets the id.</summary>
        /// <value>The id.</value>
        public string Id { get; set; }
    }
}