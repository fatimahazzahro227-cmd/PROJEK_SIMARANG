using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class PenjualanService
    {
        public List<Penjualan> GetAll()
        {
            var list = new List<Penjualan>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT pj.id_penjualan, pj.tanggal_penjualan, pj.opsi_penyerahan,
                                        pj.status_logistik, pj.alamat_pengiriman,
                                        pj.id_pelanggan, pl.nama_pelanggan,
                                        pj.id_metode, mp.nama_metode,
                                        pj.id_user, u.nama_user,
                                        COALESCE(SUM(dp.jumlah * dp.harga_jual), 0) AS total
                                 FROM penjualan pj
                                 JOIN pelanggan pl ON pj.id_pelanggan = pl.id_pelanggan
                                 JOIN metode_pembayaran mp ON pj.id_metode = mp.id_metode
                                 JOIN users u ON pj.id_user = u.id_user
                                 LEFT JOIN detail_penjualan dp ON pj.id_penjualan = dp.id_penjualan
                                 GROUP BY pj.id_penjualan, pl.nama_pelanggan, mp.nama_metode, u.nama_user
                                 ORDER BY pj.tanggal_penjualan DESC";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Penjualan
                        {
                            PenjualanId = reader.GetInt32(0),
                            TanggalPenjualan = reader.GetDateTime(1),
                            OpsiPenyerahan = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            StatusLogistik = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            AlamatPengiriman = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            PelangganId = reader.GetInt32(5),
                            NamaPelanggan = reader.GetString(6),
                            MetodePembayaranId = reader.GetInt32(7),
                            NamaMetode = reader.GetString(8),
                            UserId = reader.GetInt32(9),
                            NamaUser = reader.GetString(10),
                            TotalPenjualan = reader.GetDecimal(11)
                        });
                    }
                }
            }
            return list;
        }

        public int Add(Penjualan pj)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO penjualan 
                                 (tanggal_penjualan, opsi_penyerahan, status_logistik, alamat_pengiriman,
                                  id_pelanggan, id_metode, id_user)
                                 VALUES (@tgl, @opsi, @status, @alamat, @pelangganid, @metodeid, @userid)
                                 RETURNING id_penjualan";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("tgl", pj.TanggalPenjualan);
                    cmd.Parameters.AddWithValue("opsi", pj.OpsiPenyerahan ?? "Diambil");
                    cmd.Parameters.AddWithValue("status", pj.StatusLogistik ?? "Selesai");
                    cmd.Parameters.AddWithValue("alamat", pj.AlamatPengiriman ?? "");
                    cmd.Parameters.AddWithValue("pelangganid", pj.PelangganId);
                    cmd.Parameters.AddWithValue("metodeid", pj.MetodePembayaranId);
                    cmd.Parameters.AddWithValue("userid", pj.UserId);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void AddDetail(DetailPenjualan dp)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO detail_penjualan (id_penjualan, id_produk, jumlah, harga_jual)
                                 VALUES (@penjualanid, @produkid, @jumlah, @hargajual)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("penjualanid", dp.PenjualanId);
                    cmd.Parameters.AddWithValue("produkid", dp.ProdukId);
                    cmd.Parameters.AddWithValue("jumlah", dp.Jumlah);
                    cmd.Parameters.AddWithValue("hargajual", dp.HargaJual);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DetailPenjualan> GetDetail(int penjualanId)
        {
            var list = new List<DetailPenjualan>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT dp.id_detail_penjualan, dp.id_penjualan,
                                        dp.id_produk, p.nama_produk, dp.harga_jual,
                                        dp.jumlah, (dp.jumlah * dp.harga_jual) AS subtotal
                                 FROM detail_penjualan dp
                                 JOIN produk p ON dp.id_produk = p.id_produk
                                 WHERE dp.id_penjualan = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", penjualanId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DetailPenjualan
                            {
                                DetailPenjualanId = reader.GetInt32(0),
                                PenjualanId = reader.GetInt32(1),
                                ProdukId = reader.GetInt32(2),
                                NamaProduk = reader.GetString(3),
                                HargaJual = reader.GetDecimal(4),
                                Jumlah = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}