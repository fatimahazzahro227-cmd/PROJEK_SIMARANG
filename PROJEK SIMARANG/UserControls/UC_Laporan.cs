using PROJEK_SIMARANG.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_Laporan : UserControl
    {
        private LaporanService _laporanService = new LaporanService();
        private PenjualanService _penjualanService = new PenjualanService();
        private PembelianService _pembelianService = new PembelianService();
        
        public UC_Laporan()
        {
            InitializeComponent();
        }

        private void UC_Laporan_Load(object sender, EventArgs e)
        {
            dtpDari.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpSampai.Value = DateTime.Now;
            LoadLaporan();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cardPembelian_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadLaporan();
        }

        private void cardKeuntungan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPembelian_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPenjualan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            LoadLaporan();
        }

        private void LoadLaporan()
        {
            try
            {
                DateTime dari = dtpDari.Value.Date;
                DateTime sampai = dtpSampai.Value.Date.AddDays(1).AddSeconds(-1);

                var hasil = _laporanService.GetLabaKotorPeriode(dari, sampai);

                lblTotalPenjualan.Text = "Rp " + hasil.Pendapatan.ToString("N0");
                lblTotalPembelian.Text = "Rp " + hasil.Modal.ToString("N0");
                lblKeuntungan.Text = "Rp " + hasil.LabaKotor.ToString("N0");
                lblMargin.Text = hasil.MarginPersen.ToString("N2") + "%";

                if (hasil.LabaKotor < 0)
                    lblKeuntungan.ForeColor = System.Drawing.Color.Red;
                else
                    lblKeuntungan.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

                LoadTabelPenjualan(dari, sampai);
                LoadTabelPembelian(dari, sampai);
                LoadTabelKeuntungan(hasil.Pendapatan, hasil.Modal, hasil.LabaKotor);
                LoadGrafikPenjualan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message);
            }
        }

        private void LoadTabelPenjualan(DateTime dari, DateTime sampai)
        {
            dgvPenjualan.Rows.Clear();
            dgvPenjualan.Columns.Clear();

            dgvPenjualan.Columns.Add("Tanggal", "Tanggal");
            dgvPenjualan.Columns.Add("Pelanggan", "Pelanggan");
            dgvPenjualan.Columns.Add("Metode", "Metode Bayar");
            dgvPenjualan.Columns.Add("Opsi", "Penyerahan");
            dgvPenjualan.Columns.Add("Total", "Total");
            dgvPenjualan.Columns.Add("Status", "Status");

            var list = _penjualanService.GetAll();
            foreach (var p in list)
            {
                if (p.TanggalPenjualan >= dari && p.TanggalPenjualan <= sampai)
                {
                    dgvPenjualan.Rows.Add(
                        p.TanggalPenjualan.ToString("dd/MM/yyyy HH:mm"),
                        p.NamaPelanggan,
                        p.NamaMetode,
                        p.OpsiPenyerahan,
                        "Rp " + p.TotalPenjualan.ToString("N0"),
                        p.StatusLogistik
                    );
                }
            }
        }

        private void LoadTabelPembelian(DateTime dari, DateTime sampai)
        {
            dgvPembelian.Rows.Clear();
            dgvPembelian.Columns.Clear();

            dgvPembelian.Columns.Add("Tanggal", "Tanggal");
            dgvPembelian.Columns.Add("Supplier", "Supplier");
            dgvPembelian.Columns.Add("Total", "Total");
            dgvPembelian.Columns.Add("Status", "Status");

            var list = _pembelianService.GetAll();
            foreach (var p in list)
            {
                if (p.TanggalPembelian >= dari && p.TanggalPembelian <= sampai)
                {
                    dgvPembelian.Rows.Add(
                        p.TanggalPembelian.ToString("dd/MM/yyyy HH:mm"),
                        p.NamaSupplier,
                        "Rp " + p.TotalPembelian.ToString("N0"),
                        p.StatusPembelian
                    );
                }
            }
        }

        private void LoadTabelKeuntungan(decimal totalPenjualan, decimal totalPembelian, decimal keuntungan)
        {
            dgvKeuntungan.Rows.Clear();
            dgvKeuntungan.Columns.Clear();

            dgvKeuntungan.Columns.Add("Keterangan", "Keterangan");
            dgvKeuntungan.Columns.Add("Nominal", "Nominal");

            dgvKeuntungan.Rows.Add("Total Penjualan", "Rp " + totalPenjualan.ToString("N0"));
            dgvKeuntungan.Rows.Add("Total Pembelian", "Rp " + totalPembelian.ToString("N0"));
            dgvKeuntungan.Rows.Add("Keuntungan", "Rp " + keuntungan.ToString("N0"));
        }

        private void LoadGrafikPenjualan()
{
    try
    {
        var dt = _laporanService.GetLabaRugiBulanan();

        var bulan = new List<string>();
        var pendapatan = new List<double>();
        var labaKotor = new List<double>();

        foreach (DataRow row in dt.Rows)
        {
            bulan.Add(row["bulan"].ToString());
            pendapatan.Add(Convert.ToDouble(row["total_pendapatan"]));
            labaKotor.Add(Convert.ToDouble(row["laba_kotor"]));
        }

        formsPlot1.Plot.Clear();

        double[] posisi = Enumerable.Range(0, bulan.Count).Select(i => (double)i).ToArray();

        var barPendapatan = formsPlot1.Plot.AddBar(pendapatan.ToArray(), posisi);
        barPendapatan.Label = "Pendapatan";

        formsPlot1.Plot.XTicks(posisi, bulan.ToArray());
        formsPlot1.Plot.Title("Grafik Pendapatan per Bulan");
        formsPlot1.Plot.YLabel("Rupiah");
        formsPlot1.Plot.Legend();

        formsPlot1.Refresh();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Gagal memuat grafik: " + ex.Message);
    }
}

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (panelFilter != null)
            {
                panelFilter.Width = this.Width - 40;
            }

            if (cardPenjualan != null)
            {
                int totalWidth = this.Width - 40;
                int cardWidth = (totalWidth - 20) / 3;

                cardPenjualan.Location = new System.Drawing.Point(20, 160);
                cardPenjualan.Width = cardWidth;

                cardPembelian.Location = new System.Drawing.Point(20 + cardWidth + 10, 160);
                cardPembelian.Width = cardWidth;

                cardKeuntungan.Location = new System.Drawing.Point(20 + (cardWidth + 10) * 2, 160);
                cardKeuntungan.Width = cardWidth;
            }

            int grafikWidth = (this.Width - 60) / 3;
            int grafikX = this.Width - grafikWidth - 20;
            int tabWidth = this.Width - 60 - grafikWidth;
            int contentY = 270;
            int contentHeight = this.Height - 290;

            if (tabLaporan != null)
            {
                tabLaporan.Location = new System.Drawing.Point(20, contentY);
                tabLaporan.Width = tabWidth;
                tabLaporan.Height = contentHeight;
            }

            if (formsPlot1 != null)
            {
                formsPlot1.Location = new System.Drawing.Point(grafikX, contentY);
                formsPlot1.Width = grafikWidth;
                formsPlot1.Height = contentHeight;
            }
        }

        private void lblMargin_Click(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }
    }
}
    

