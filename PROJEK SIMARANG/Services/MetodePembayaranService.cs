using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class MetodePembayaranService
    {
        public List<MetodePembayaran> GetAll()
        {
            var list = new List<MetodePembayaran>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_metode, nama_metode FROM metode_pembayaran ORDER BY id_metode";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MetodePembayaran
                        {
                            MetodePembayaranId = reader.GetInt32(0),
                            NamaMetode = reader.GetString(1)
                        });
                    }
                }
            }
            return list;
        }

        public void Add(MetodePembayaran m)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO metode_pembayaran (nama_metode) VALUES (@nama)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", m.NamaMetode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM metode_pembayaran WHERE id_metode = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}