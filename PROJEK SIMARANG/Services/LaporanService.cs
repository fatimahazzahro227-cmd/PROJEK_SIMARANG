using Npgsql;
using NpgsqlTypes;
using PROJEK_SIMARANG.Database;
using System;
using System.Data;

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
                string query = "SELECT COUNT(*) FROM v_monitoring_stok WHERE status_stok IN ('Kritis','Habis')";
                using (var cmd = new NpgsqlCommand(query, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable GetDetailPenjualanLengkap(DateTime dari, DateTime sampai)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT tanggal_penjualan, nama_pelanggan, jenis_usaha,
                   kasir, metode_bayar, opsi_penyerahan, status_logistik,
                   nama_produk, nama_kategori, jumlah, harga_jual,
                   subtotal, laba_item
            FROM v_detail_penjualan_lengkap
            WHERE DATE(tanggal_penjualan) BETWEEN @dari AND @sampai
            ORDER BY tanggal_penjualan DESC";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("dari", dari);
                    cmd.Parameters.AddWithValue("sampai", sampai);
                    var dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetLabaRugiBulanan()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM v_laporan_laba_rugi_bulanan";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    var dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public decimal GetTotalSatuPenjualan(int idPenjualan)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT fn_total_penjualan(@id)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", idPenjualan);
                    return (decimal)cmd.ExecuteScalar();
                }
            }
        }

        public (decimal Pendapatan, decimal Modal, decimal LabaKotor, decimal MarginPersen)
    GetLabaKotorPeriode(DateTime dari, DateTime sampai)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT total_pendapatan, total_modal, laba_kotor, margin_persen
            FROM fn_laba_kotor_periode(@dari, @sampai)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("dari", NpgsqlTypes.NpgsqlDbType.Date)
                    {
                        Value = dari.Date
                    });
                    cmd.Parameters.Add(new NpgsqlParameter("sampai", NpgsqlTypes.NpgsqlDbType.Date)
                    {
                        Value = sampai.Date
                    });

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                reader.GetDecimal(0),
                                reader.GetDecimal(1),
                                reader.GetDecimal(2),
                                reader.IsDBNull(3) ? 0 : reader.GetDecimal(3)
                            );
                        }
                    }
                }
            }
            return (0, 0, 0, 0);
        }
    }
}