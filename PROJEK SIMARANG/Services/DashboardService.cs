using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace PROJEK_SIMARANG.Services
{
    public class DashboardService
    {
        public DataTable GetProdukTerlaris()
        {
            string query = @"
            SELECT
                p.nama_produk,
                SUM(dp.jumlah) AS total_terjual
            FROM detail_penjualan dp
            JOIN produk p
            ON dp.produk_id = p.produk_id
            GROUP BY p.nama_produk";

            NpgsqlConnection conn =
                Database.DatabaseHelper.GetConnection();

            DataTable dt = new DataTable();

            using (NpgsqlDataAdapter da =
                   new NpgsqlDataAdapter(query, conn))
            {
                da.Fill(dt);
            }

            return dt;
        }
    }
}