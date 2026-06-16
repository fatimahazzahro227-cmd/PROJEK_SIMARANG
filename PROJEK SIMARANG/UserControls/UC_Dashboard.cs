using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROJEK_SIMARANG.Services;

namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        private LaporanService _laporanService = new LaporanService();
        private PenjualanService _penjualanService = new PenjualanService();
        private PembelianService _pembelianService = new PembelianService();

        public UC_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            LoadStatistik();
            LoadTransaksiTerbaru();
        }

        private void LoadStatistik()
        {
            try
            {
                lblTotalProduk.Text = _laporanService.GetTotalProduk().ToString();
                lblTotalPenjualan.Text = _laporanService.GetTotalPenjualanBulanIni().ToString();
                lblTotalSupplier.Text = _laporanService.GetTotalSupplier().ToString();
                lblStokMenipis.Text = _laporanService.GetStokMenupis().ToString();

                if (_laporanService.GetStokMenupis() > 0)
                    lblStokMenipis.ForeColor = System.Drawing.Color.Red;
                else
                    lblStokMenipis.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat statistik: " + ex.Message);
            }
        }

        private void LoadTransaksiTerbaru()
        {
            try
            {
                dgvTransaksi.Columns.Clear();
                dgvTransaksi.Rows.Clear();

                dgvTransaksi.Columns.Add("Tanggal", "Tanggal");
                dgvTransaksi.Columns.Add("Jenis", "Jenis");
                dgvTransaksi.Columns.Add("PelangganSupplier", "Pelanggan / Supplier");
                dgvTransaksi.Columns.Add("Total", "Total");
                dgvTransaksi.Columns.Add("Status", "Status");

                var penjualanList = _penjualanService.GetAll();
                foreach (var p in penjualanList)
                {
                    dgvTransaksi.Rows.Add(
                        p.TanggalPenjualan.ToString("dd/MM/yyyy"),
                        "Penjualan",
                        p.NamaPelanggan,
                        "Rp " + p.TotalPenjualan.ToString("N0"),
                        "Selesai"
                    );
                }

                var pembelianList = _pembelianService.GetAll();
                foreach (var p in pembelianList)
                {
                    dgvTransaksi.Rows.Add(
                        p.TanggalPembelian.ToString("dd/MM/yyyy"),
                        "Pembelian",
                        p.NamaSupplier,
                        "Rp " + p.TotalPembelian.ToString("N0"),
                        p.StatusPembelian
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat transaksi: " + ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStokMenipis_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalProdukTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalProduk_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalProdukDesc_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPenjualanTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPenjualan_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPenjualanDesc_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalSupplierTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalSupplier_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalSupplierDesc_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStokMenipisTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblStokMenipisDesc_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTransaksi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTransaksiTittle_Click(object sender, EventArgs e)
        {

        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (panelTransaksi != null)
            {
                panelTransaksi.Width = this.Width - 40;
                panelTransaksi.Height = this.Height - 220;
                dgvTransaksi.Width = panelTransaksi.Width - 30;
                dgvTransaksi.Height = panelTransaksi.Height - 60;
            }

            if (cardProduk != null)
            {
                int totalWidth = this.Width - 40;
                int cardWidth = (totalWidth - 30) / 4;

                cardProduk.Location = new System.Drawing.Point(20, 100);
                cardProduk.Width = cardWidth;

                cardPenjualan.Location = new System.Drawing.Point(20 + cardWidth + 10, 100);
                cardPenjualan.Width = cardWidth;

                cardSupplier.Location = new System.Drawing.Point(20 + (cardWidth + 10) * 2, 100);
                cardSupplier.Width = cardWidth;

                cardStokMenipis.Location = new System.Drawing.Point(20 + (cardWidth + 10) * 3, 100);
                cardStokMenipis.Width = cardWidth;
            }

            if (lblTransaksiTittle != null)
            {
                lblTransaksiTittle.Location = new System.Drawing.Point(15, 15);
            }

        }
    }
}
