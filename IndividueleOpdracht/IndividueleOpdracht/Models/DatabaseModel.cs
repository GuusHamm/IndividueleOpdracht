// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseModel.cs" company="">
//   
// </copyright>
// <summary>
//   The database model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using IndividueleOpdracht.Controllers;

    using Npgsql;

    #endregion

    /// <summary>The database model.</summary>
    public abstract class DatabaseModel : IDatabaseModel
    {
        /// <summary>The connection.</summary>
        private NpgsqlConnection connection = DatabaseController.Connection;

        /// <summary>Gets or sets the postgres command.</summary>
        /// <value>The postgres command.</value>
        protected virtual NpgsqlCommand PostgresCommand { get; set; }

        /// <summary>Gets or sets the id.</summary>
        /// <value>The id.</value>
        public string Id { get; set; }
    }
}