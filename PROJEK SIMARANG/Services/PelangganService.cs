using System;
using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class PelangganService
    {
        public List<Pelanggan> GetAll()
        {
            var list = new List<Pelanggan>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_pelanggan, nama_pelanggan, alamat, no_telepon, email, jenis_usaha, tanggal_daftar FROM pelanggan ORDER BY id_pelanggan";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pelanggan
                        {
                            PelangganId = reader.GetInt32(0),
                            NamaPelanggan = reader.GetString(1),
                            Alamat = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            NoTelepon = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            JenisUsaha = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            TanggalDaftar = reader.GetDateTime(6)
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Pelanggan p)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO pelanggan (nama_pelanggan, alamat, no_telepon, email, jenis_usaha)
                                 VALUES (@nama, @alamat, @telepon, @email, @jenis)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", p.NamaPelanggan);
                    cmd.Parameters.AddWithValue("alamat", p.Alamat ?? "");
                    cmd.Parameters.AddWithValue("telepon", p.NoTelepon ?? "");
                    cmd.Parameters.AddWithValue("email", p.Email ?? "");
                    cmd.Parameters.AddWithValue("jenis", p.JenisUsaha ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Pelanggan p)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE pelanggan SET 
                                 nama_pelanggan = @nama, alamat = @alamat,
                                 no_telepon = @telepon, email = @email,
                                 jenis_usaha = @jenis
                                 WHERE id_pelanggan = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", p.NamaPelanggan);
                    cmd.Parameters.AddWithValue("alamat", p.Alamat ?? "");
                    cmd.Parameters.AddWithValue("telepon", p.NoTelepon ?? "");
                    cmd.Parameters.AddWithValue("email", p.Email ?? "");
                    cmd.Parameters.AddWithValue("jenis", p.JenisUsaha ?? "");
                    cmd.Parameters.AddWithValue("id", p.PelangganId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int pelangganId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM pelanggan WHERE id_pelanggan = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", pelangganId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}