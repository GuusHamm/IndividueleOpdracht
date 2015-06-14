// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagModel.cs" company="">
//   
// </copyright>
// <summary>
//   The tag model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System;

    #endregion

    /// <summary>The tag model.</summary>
    public class TagModel:IDatabaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="TagModel"/> class.</summary>
        /// <param name="naam">The naam.</param>
        /// <param name="beschrijving">The beschrijving.</param>
        public TagModel(string naam, string beschrijving)
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