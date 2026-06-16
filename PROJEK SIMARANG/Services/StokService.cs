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
                string query = @"
                SELECT
                    id_stok,
                    id_produk,
                    nama_produk,
                    jumlah_stok,
                    stok_minimum,
                    tanggal_update
                FROM v_monitoring_stok
                ORDER BY nama_produk";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Stok
                        {
                            StokId = reader.GetInt32(0),
                            ProdukId = reader.GetInt32(1),
                            NamaProduk = reader.GetString(2),
                            JumlahStok = reader.GetInt32(3),
                            StokMinimum = reader.GetInt32(4),
                            TanggalUpdate = reader.GetDateTime(5)
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
                string query = @"SELECT
                    id_stok,
                    id_produk,
                    nama_produk,
                    nama_kategori,
                    satuan,
                    jumlah_stok,
                    stok_minimum,
                    selisih_stok,
                    status_stok,
                    tanggal_update
                FROM v_monitoring_stok
                ORDER BY nama_produk";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Stok
                        {
                            StokId = reader.GetInt32(0),
                            ProdukId = reader.GetInt32(1),
                            NamaProduk = reader.GetString(2),
                            NamaKategori = reader.GetString(3),
                            Satuan = reader.GetString(4),
                            JumlahStok = reader.GetInt32(5),
                            StokMinimum = reader.GetInt32(6),
                            SelisihStok = reader.GetInt32(7),
                            StatusStok = reader.GetString(8),
                            TanggalUpdate = reader.GetDateTime(9)
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
                                 WHERE id_produk = @produkid";
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
