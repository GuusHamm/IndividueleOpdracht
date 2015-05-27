namespace IndividueleOpdracht.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using Oracle.DataAccess.Client;

    public static class DatabaseController
    {
        private static OracleConnection oracleConnection;

        public static void Initialize()
        {
            oracleConnection = new OracleConnection
                                   {
                                       ConnectionString =
                                           string.Format(
                                               "User Id={0};Password={1};Data Source=//{2}:{3}/{4}",
                                               "Guus",
                                               "password",
                                               "localhost",
                                               "1521",
                                               "xe")
                                   };
        }
    }
}