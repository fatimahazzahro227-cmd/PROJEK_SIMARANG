using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEK_SIMARANG.Services
{
    public class StokService
    {
        public List<Stok> GetAll()
        {
            var list = new List<Stok>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT s.stok_id, s.jumlah_stok, s.stok_minimum, s.tanggal_update,
                                        s.produk_id, p.nama_produk, p.satuan
                                 FROM stok s
                                 JOIN produk p ON s.produk_id = p.produk_id
                                 ORDER BY p.nama_produk";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Stok
                        {
                            StokId = reader.GetInt32(0),
                            JumlahStok = reader.GetInt32(1),
                            StokMinimum = reader.GetInt32(2),
                            TanggalUpdate = reader.GetDateTime(3),
                            ProdukId = reader.GetInt32(4),
                            NamaProduk = reader.GetString(5),
                            Satuan = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                }
            }
            return list;
        }

        public List<Stok> GetStokMenupis()
        {
            var list = new List<Stok>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT s.stok_id, s.jumlah_stok, s.stok_minimum, s.tanggal_update,
                                        s.produk_id, p.nama_produk, p.satuan
                                 FROM stok s
                                 JOIN produk p ON s.produk_id = p.produk_id
                                 WHERE s.jumlah_stok <= s.stok_minimum
                                 ORDER BY s.jumlah_stok ASC";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Stok
                        {
                            StokId = reader.GetInt32(0),
                            JumlahStok = reader.GetInt32(1),
                            StokMinimum = reader.GetInt32(2),
                            TanggalUpdate = reader.GetDateTime(3),
                            ProdukId = reader.GetInt32(4),
                            NamaProduk = reader.GetString(5),
                            Satuan = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                }
            }
            return list;
        }

        public void Update(int produkId, int jumlahBaru)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE stok SET jumlah_stok = @jumlah, 
                                 tanggal_update = CURRENT_TIMESTAMP 
                                 WHERE produk_id = @produkid";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("jumlah", jumlahBaru);
                    cmd.Parameters.AddWithValue("produkid", produkId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
