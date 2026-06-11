using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class RoleService
    {
        public List<Role> GetAll()
        {
            var list = new List<Role>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_role, nama_role FROM role ORDER BY id_role";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Role
                        {
                            RoleId = reader.GetInt32(0),
                            NamaRole = reader.GetString(1)
                        });
                    }
                }
            }
            return list;
        }
    }
}