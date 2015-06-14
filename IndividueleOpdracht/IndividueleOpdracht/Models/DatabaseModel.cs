using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdracht.Models
{
    using IndividueleOpdracht.Controllers;

    using Npgsql;

    public abstract class DatabaseModel : IDatabaseModel
    {
        private NpgsqlConnection connection = DatabaseController.Connection;

        public string Id { get; set; }

        protected virtual NpgsqlCommand PostgresCommand { get; set; }

        public virtual bool Create()
        {
            // TODO
            return false;
        }

        public virtual bool Read()
        {
            // TODO
            return false;
        }

        public virtual bool Update()
        {
            // TODO
            return false;
        }

        public virtual bool Destroy()
        {
            // TODO
            return false;
        }
    }
}