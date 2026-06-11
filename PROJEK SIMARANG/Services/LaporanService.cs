using System;
using Npgsql;
using PROJEK_SIMARANG.Database;

namespace PROJEK_SIMARANG.Services
{
    public class LaporanService
    {
        public decimal GetTotalPenjualan(DateTime dari, DateTime sampai)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COALESCE(SUM(dp.jumlah * dp.harga_jual), 0)
                                 FROM penjualan pj
                                 JOIN detail_penjualan dp ON pj.id_penjualan = dp.id_penjualan
                                 WHERE pj.tanggal_penjualan BETWEEN @dari AND @sampai";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("dari", dari);
                    cmd.Parameters.AddWithValue("sampai", sampai);
                    return (decimal)cmd.ExecuteScalar();
                }
            }
        }

        public decimal GetTotalPembelian(DateTime dari, DateTime sampai)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COALESCE(SUM(dp.jumlah * dp.harga_beli), 0)
                                 FROM pembelian pb
                                 JOIN detail_pembelian dp ON pb.id_pembelian = dp.id_pembelian
                                 WHERE pb.tanggal_pembelian BETWEEN @dari AND @sampai";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("dari", dari);
                    cmd.Parameters.AddWithValue("sampai", sampai);
                    return (decimal)cmd.ExecuteScalar();
                }
            }
        }

        public int GetTotalProduk()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM produk WHERE status_produk = 'Aktif'";
                using (var cmd = new NpgsqlCommand(query, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetTotalSupplier()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM supplier";
                using (var cmd = new NpgsqlCommand(query, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetTotalPelanggan()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM pelanggan";
                using (var cmd = new NpgsqlCommand(query, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetTotalPenjualanBulanIni()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM penjualan 
                                 WHERE EXTRACT(MONTH FROM tanggal_penjualan) = EXTRACT(MONTH FROM CURRENT_DATE)
                                 AND EXTRACT(YEAR FROM tanggal_penjualan) = EXTRACT(YEAR FROM CURRENT_DATE)";
                using (var cmd = new NpgsqlCommand(query, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetStokMenupis()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM stok WHERE jumlah_stok <= stok_minimum";
                using (var cmd = new NpgsqlCommand(query, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}