using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class KategoriService
    {
        public List<KategoriProduk> GetAll()
        {
            var list = new List<KategoriProduk>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_kategori, nama_kategori, deskripsi FROM kategori_produk ORDER BY id_kategori";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KategoriProduk
                        {
                            KategoriProdukId = reader.GetInt32(0),
                            NamaKategori = reader.GetString(1),
                            Deskripsi = reader.IsDBNull(2) ? "" : reader.GetString(2)
                        });
                    }
                }
            }
            return list;
        }

        public void Add(KategoriProduk k)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO kategori_produk (nama_kategori, deskripsi) VALUES (@nama, @desc)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", k.NamaKategori);
                    cmd.Parameters.AddWithValue("desc", k.Deskripsi ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(KategoriProduk k)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE kategori_produk SET nama_kategori = @nama, deskripsi = @desc WHERE id_kategori = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", k.NamaKategori);
                    cmd.Parameters.AddWithValue("desc", k.Deskripsi ?? "");
                    cmd.Parameters.AddWithValue("id", k.KategoriProdukId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM kategori_produk WHERE id_kategori = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}