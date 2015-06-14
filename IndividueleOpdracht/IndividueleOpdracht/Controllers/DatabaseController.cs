// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseController.cs" company="">
//   
// </copyright>
// <summary>
//   The database controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Controllers
{
    #region

    using Npgsql;

    #endregion

    /// <summary>The database controller.</summary>
    public static class DatabaseController
    {
        /// <summary>Gets the connection.</summary>
        /// <value>The connection.</value>
        public static NpgsqlConnection Connection { get; private set;}

        /// <summary>Gets or sets the postgres command.</summary>
        /// <value>The postgres command.</value>
        public static NpgsqlCommand PostgresCommand { get; set; }

        /// <summary>The initialiaze.</summary>
        public static void Initialiaze()
        {
            string connectionString = "Server=localhost;Database=SE;User ID=postgres;port=5433;Password=password;";
            Connection = new NpgsqlConnection(connectionString);
            Connection.Open();
        }
    }
}