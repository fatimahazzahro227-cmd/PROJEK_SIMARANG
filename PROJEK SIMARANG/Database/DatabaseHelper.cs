using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PROJEK_SIMARANG.Database
{
    public class DatabaseHelper
    {
        private static readonly string ConnectionString =
            "Host=localhost;Port=5432;Database=simarang;Username=postgres;Password=yourpassword;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}