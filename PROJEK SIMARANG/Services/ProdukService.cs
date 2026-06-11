using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class ProdukService
    {
        public List<Produk> GetAll()
        {
            var list = new List<Produk>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.id_produk, p.nama_produk, p.satuan, p.harga_beli, 
                                        p.harga_jual, p.deskripsi, p.status_produk,
                                        p.id_kategori, k.nama_kategori
                                 FROM produk p
                                 JOIN kategori_produk k ON p.id_kategori = k.id_kategori
                                 ORDER BY p.id_produk";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Produk
                        {
                            ProdukId = reader.GetInt32(0),
                            NamaProduk = reader.GetString(1),
                            Satuan = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            HargaBeli = reader.GetDecimal(3),
                            HargaJual = reader.GetDecimal(4),
                            Deskripsi = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            StatusProduk = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            KategoriProdukId = reader.GetInt32(7),
                            NamaKategori = reader.GetString(8)
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Produk p)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO produk 
                                 (nama_produk, satuan, harga_beli, harga_jual, deskripsi, status_produk, id_kategori)
                                 VALUES (@nama, @satuan, @hargabeli, @hargajual, @desc, @status, @kategori)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", p.NamaProduk);
                    cmd.Parameters.AddWithValue("satuan", p.Satuan ?? "");
                    cmd.Parameters.AddWithValue("hargabeli", p.HargaBeli);
                    cmd.Parameters.AddWithValue("hargajual", p.HargaJual);
                    cmd.Parameters.AddWithValue("desc", p.Deskripsi ?? "");
                    cmd.Parameters.AddWithValue("status", p.StatusProduk ?? "Aktif");
                    cmd.Parameters.AddWithValue("kategori", p.KategoriProdukId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Produk p)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE produk SET 
                                 nama_produk = @nama, satuan = @satuan,
                                 harga_beli = @hargabeli, harga_jual = @hargajual,
                                 deskripsi = @desc, status_produk = @status,
                                 id_kategori = @kategori
                                 WHERE id_produk = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama", p.NamaProduk);
                    cmd.Parameters.AddWithValue("satuan", p.Satuan ?? "");
                    cmd.Parameters.AddWithValue("hargabeli", p.HargaBeli);
                    cmd.Parameters.AddWithValue("hargajual", p.HargaJual);
                    cmd.Parameters.AddWithValue("desc", p.Deskripsi ?? "");
                    cmd.Parameters.AddWithValue("status", p.StatusProduk ?? "Aktif");
                    cmd.Parameters.AddWithValue("kategori", p.KategoriProdukId);
                    cmd.Parameters.AddWithValue("id", p.ProdukId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int produkId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM produk WHERE id_produk = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", produkId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}