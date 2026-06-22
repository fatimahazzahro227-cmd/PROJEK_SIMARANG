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

        public void AddViaProcedure(int idSupplier, int idUser, int idProduk, int jumlah, decimal hargaBeli)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("CALL sp_input_pembelian(@sup, @usr, @pro, @jml, @hrg)", conn))
                {
                    cmd.Parameters.AddWithValue("sup", idSupplier);
                    cmd.Parameters.AddWithValue("usr", idUser);
                    cmd.Parameters.AddWithValue("pro", idProduk);
                    cmd.Parameters.AddWithValue("jml", jumlah);
                    cmd.Parameters.AddWithValue("hrg", hargaBeli);
                    cmd.ExecuteNonQuery();
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

        public void SimpanPembelian(
    Pembelian pembelian,
    List<DetailPembelian> items)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        int pembelianId;

                        string headerQuery = @"
                INSERT INTO pembelian
                (
                    tanggal_pembelian,
                    status_pembelian,
                    id_user,
                    id_supplier
                )
                VALUES
                (
                    @tgl,
                    @status,
                    @userid,
                    @supplierid
                )
                RETURNING id_pembelian";

                        using (var cmd = new NpgsqlCommand(headerQuery, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("tgl", pembelian.TanggalPembelian);
                            cmd.Parameters.AddWithValue("status", pembelian.StatusPembelian);
                            cmd.Parameters.AddWithValue("userid", pembelian.UserId);
                            cmd.Parameters.AddWithValue("supplierid", pembelian.SupplierId);

                            pembelianId = (int)cmd.ExecuteScalar();
                        }

                        foreach (var item in items)
                        {
                            string detailQuery = @"
                    INSERT INTO detail_pembelian
                    (
                        id_pembelian,
                        id_produk,
                        jumlah,
                        harga_beli
                    )
                    VALUES
                    (
                        @pembelianid,
                        @produkid,
                        @jumlah,
                        @harga
                    )";

                            using (var cmd = new NpgsqlCommand(detailQuery, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("pembelianid", pembelianId);
                                cmd.Parameters.AddWithValue("produkid", item.ProdukId);
                                cmd.Parameters.AddWithValue("jumlah", item.Jumlah);
                                cmd.Parameters.AddWithValue("harga", item.HargaBeli);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}