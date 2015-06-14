using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Controllers
{
    using System.IO;

    using System.Data.Sql;

    using Npgsql;

    public static class DatabaseController
    {
        public static NpgsqlConnection Connection { get; private set;}

        public static NpgsqlCommand PostgresCommand { get; set; }
        public static void Initialiaze()
        {
            string connectionString = "Server=localhost;Database=SE;User ID=postgres;port=5433;Password=password;";
            Connection = new NpgsqlConnection(connectionString);
            Connection.Open();
        }

       

    }
}