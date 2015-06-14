// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TierModel.cs" company="">
//   
// </copyright>
// <summary>
//   The tier model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System;

    #endregion

    /// <summary>The tier model.</summary>
    public class TierModel : DatabaseModel
    {
        /// <summary>Initializes a new instance of the <see cref="TierModel"/> class.</summary>
        /// <param name="projectId">The project id.</param>
        /// <param name="naam">The naam.</param>
        /// <param name="reward">The reward.</param>
        /// <param name="prijs">The prijs.</param>
        public TierModel(string projectId, string naam, string reward, int prijs)
        {
            this.ProjectId = projectId;
            this.Naam = naam;
            this.Reward = reward;
            this.Prijs = prijs;
        }

        /// <summary>Gets the project id.</summary>
        /// <value>The project id.</value>
        public string ProjectId { get; private set; }

        /// <summary>Gets the naam.</summary>
        /// <value>The naam.</value>
        public string Naam { get; private set; }

        /// <summary>Gets the reward.</summary>
        /// <value>The reward.</value>
        public string Reward { get; private set; }

        /// <summary>Gets the prijs.</summary>
        /// <value>The prijs.</value>
        public int Prijs { get; private set; }

        /// <summary>Gets or sets the id.</summary>
        /// <value>The id.</value>
        public string Id { get; set; }

    }
}