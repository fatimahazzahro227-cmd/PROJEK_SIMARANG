using System;
using System.Collections.Generic;
using Npgsql;
using PROJEK_SIMARANG.Database;
using PROJEK_SIMARANG.Models;

namespace PROJEK_SIMARANG.Services
{
    public class PembelianService
    {
        public List<Pembelian> GetAll()
        {
            var list = new List<Pembelian>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT pb.id_pembelian, pb.tanggal_pembelian, pb.status_pembelian,
                                        pb.id_user, u.nama_user, pb.id_supplier, s.nama_supplier,
                                        COALESCE(SUM(dp.jumlah * dp.harga_beli), 0) AS total
                                 FROM pembelian pb
                                 JOIN users u ON pb.id_user = u.id_user
                                 JOIN supplier s ON pb.id_supplier = s.id_supplier
                                 LEFT JOIN detail_pembelian dp ON pb.id_pembelian = dp.id_pembelian
                                 GROUP BY pb.id_pembelian, u.nama_user, s.nama_supplier
                                 ORDER BY pb.tanggal_pembelian DESC";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pembelian
                        {
                            PembelianId = reader.GetInt32(0),
                            TanggalPembelian = reader.GetDateTime(1),
                            StatusPembelian = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            UserId = reader.GetInt32(3),
                            NamaUser = reader.GetString(4),
                            SupplierId = reader.GetInt32(5),
                            NamaSupplier = reader.GetString(6),
                            TotalPembelian = reader.GetDecimal(7)
                        });
                    }
                }
            }
            return list;
        }

        public int Add(Pembelian pb)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO pembelian (tanggal_pembelian, status_pembelian, id_user, id_supplier)
                                 VALUES (@tgl, @status, @userid, @supplierid)
                                 RETURNING id_pembelian";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("tgl", pb.TanggalPembelian);
                    cmd.Parameters.AddWithValue("status", pb.StatusPembelian ?? "Selesai");
                    cmd.Parameters.AddWithValue("userid", pb.UserId);
                    cmd.Parameters.AddWithValue("supplierid", pb.SupplierId);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void AddDetail(DetailPembelian dp)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO detail_pembelian (id_pembelian, id_produk, jumlah, harga_beli)
                                 VALUES (@pembelianid, @produkid, @jumlah, @hargabeli)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("pembelianid", dp.PembelianId);
                    cmd.Parameters.AddWithValue("produkid", dp.ProdukId);
                    cmd.Parameters.AddWithValue("jumlah", dp.Jumlah);
                    cmd.Parameters.AddWithValue("hargabeli", dp.HargaBeli);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DetailPembelian> GetDetail(int pembelianId)
        {
            var list = new List<DetailPembelian>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT dp.id_detail_pembelian, dp.id_pembelian,
                                        dp.id_produk, p.nama_produk, dp.harga_beli,
                                        dp.jumlah, (dp.jumlah * dp.harga_beli) AS subtotal
                                 FROM detail_pembelian dp
                                 JOIN produk p ON dp.id_produk = p.id_produk
                                 WHERE dp.id_pembelian = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", pembelianId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DetailPembelian
                            {
                                DetailPembelianId = reader.GetInt32(0),
                                PembelianId = reader.GetInt32(1),
                                ProdukId = reader.GetInt32(2),
                                NamaProduk = reader.GetString(3),
                                HargaBeli = reader.GetDecimal(4),
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