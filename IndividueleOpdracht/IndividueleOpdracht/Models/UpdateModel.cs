// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateModel.cs" company="">
//   
// </copyright>
// <summary>
//   The update model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System;

    #endregion

    /// <summary>The update model.</summary>
    public class UpdateModel : IDatabaseModel
    {
        /// <summary>Gets the bericht.</summary>
        /// <value>The bericht.</value>
        public string Bericht { get; private set; }

        /// <summary>Gets the post date.</summary>
        /// <value>The post date.</value>
        public DateTime PostDate { get; private set; }

        /// <summary>Gets the project id.</summary>
        /// <value>The project id.</value>
        public ProjectModel ProjectId { get; private set; }

        /// <summary>Gets or sets the id.</summary>
        /// <value>The id.</value>
        public string Id { get; set; }
    }
}