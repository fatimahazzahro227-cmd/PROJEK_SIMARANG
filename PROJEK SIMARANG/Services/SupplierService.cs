using System;
using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class SupplierService
    {
        public List<Supplier> GetAll()
        {
            var list = new List<Supplier>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_supplier, nama_supplier, alamat, no_telepon, email, tanggal_daftar FROM supplier ORDER BY id_supplier";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Supplier
                        {
                            SupplierId = reader.GetInt32(0),
                            NamaSupplier = reader.GetString(1),
                            Alamat = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            NoTelepon = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            TanggalDaftar = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5)
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Supplier s)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO supplier (nama_supplier, alamat, no_telepon, email, tanggal_daftar)
                                 VALUES (@nama, @alamat, @telepon, @email, @tgl)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", s.NamaSupplier);
                    cmd.Parameters.AddWithValue("alamat", s.Alamat ?? "");
                    cmd.Parameters.AddWithValue("telepon", s.NoTelepon ?? "");
                    cmd.Parameters.AddWithValue("email", s.Email ?? "");
                    cmd.Parameters.AddWithValue("tgl", DateTime.Today);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Supplier s)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE supplier SET 
                                 nama_supplier = @nama, alamat = @alamat,
                                 no_telepon = @telepon, email = @email
                                 WHERE id_supplier = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", s.NamaSupplier);
                    cmd.Parameters.AddWithValue("alamat", s.Alamat ?? "");
                    cmd.Parameters.AddWithValue("telepon", s.NoTelepon ?? "");
                    cmd.Parameters.AddWithValue("email", s.Email ?? "");
                    cmd.Parameters.AddWithValue("id", s.SupplierId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int supplierId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM supplier WHERE id_supplier = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", supplierId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}