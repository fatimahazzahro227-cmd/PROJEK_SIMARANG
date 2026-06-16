using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROJEK_SIMARANG.Models;
using PROJEK_SIMARANG.Services;
using PROJEK_SIMARANG.Helpers;


namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_Penjualan : UserControl
    {
        private PenjualanService _penjualanService = new PenjualanService();
        private PelangganService _pelangganService = new PelangganService();
        private ProdukService _produkService = new ProdukService();
        private MetodePembayaranService _metodeService = new MetodePembayaranService();
        private StokService _stokService = new StokService();

        private List<Penjualan> _listPenjualan = new List<Penjualan>();
        private List<DetailPenjualan> _listItem = new List<DetailPenjualan>();

        public UC_Penjualan()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAlamatPengiriman_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Penjualan_Load(object sender, EventArgs e)
        {
            LoadOpsi();
            LoadPelanggan();
            LoadProduk();
            LoadMetode();
            LoadPenjualan();
            panelInput.Visible = false;
            panelDetail.Visible = false;

            if (SessionHelper.RoleId == 1)
            {
                btnTambah.Visible = false;
            }
        }

        private void LoadPelanggan()
        {
            var list = _pelangganService.GetAll();
            cmbPelanggan.DataSource = list;
            cmbPelanggan.DisplayMember = "NamaPelanggan";
            cmbPelanggan.ValueMember = "PelangganId";
        }

        private void LoadProduk()
        {
            var list = _produkService.GetAll();
            cmbProduk.DataSource = list;
            cmbProduk.DisplayMember = "NamaProduk";
            cmbProduk.ValueMember = "ProdukId";
        }

        private void LoadMetode()
        {
            var list = _metodeService.GetAll();
            cmbMetode.DataSource = list;
            cmbMetode.DisplayMember = "NamaMetode";
            cmbMetode.ValueMember = "MetodePembayaranId";
        }

        private void LoadPenjualan()
        {
            try
            {
                _listPenjualan = _penjualanService.GetAll();
                TampilkanData(_listPenjualan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void LoadOpsi()
        {
            cmbOpsi.Items.Clear();
            cmbOpsi.Items.Add("Diambil");
            cmbOpsi.Items.Add("Dikirim");
        }

        private void TampilkanData(List<Penjualan> list)
        {
            dgvPenjualan.Rows.Clear();
            dgvPenjualan.Columns.Clear();

            dgvPenjualan.Columns.Add("ID", "ID");
            dgvPenjualan.Columns.Add("Tanggal", "Tanggal");
            dgvPenjualan.Columns.Add("Pelanggan", "Pelanggan");
            dgvPenjualan.Columns.Add("Metode", "Metode Bayar");
            dgvPenjualan.Columns.Add("Opsi", "Penyerahan");
            dgvPenjualan.Columns.Add("Total", "Total");
            dgvPenjualan.Columns.Add("Status", "Status");

            foreach (var p in list)
            {
                dgvPenjualan.Rows.Add(
                    p.PenjualanId,
                    p.TanggalPenjualan.ToString("dd/MM/yyyy HH:mm"),
                    p.NamaPelanggan,
                    p.NamaMetode,
                    p.OpsiPenyerahan,
                    "Rp " + p.TotalPenjualan.ToString("N0"),
                    p.StatusLogistik
                );
            }
        }

        private void TampilkanItem()
        {
            dgvItem.Rows.Clear();
            dgvItem.Columns.Clear();

            dgvItem.Columns.Add("ProdukId", "ID");
            dgvItem.Columns.Add("NamaProduk", "Nama Produk");
            dgvItem.Columns.Add("HargaJual", "Harga Jual");
            dgvItem.Columns.Add("Jumlah", "Jumlah");
            dgvItem.Columns.Add("Subtotal", "Subtotal");

            decimal total = 0;
            foreach (var item in _listItem)
            {
                dgvItem.Rows.Add(
                    item.ProdukId,
                    item.NamaProduk,
                    "Rp " + item.HargaJual.ToString("N0"),
                    item.Jumlah,
                    "Rp " + item.Subtotal.ToString("N0")
                );
                total += item.Subtotal;
            }

            lblTotal.Text = "Total: Rp " + total.ToString("N0");
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            _listItem.Clear();
            TampilkanItem();

            if (cmbOpsi.Items.Count > 0)
                cmbOpsi.SelectedIndex = 0;

            lblFormTitle.Text = "Transaksi Penjualan Baru";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnTambahItem_Click(object sender, EventArgs e)
        {
            if (cmbProduk.SelectedItem == null)
            {
                MessageBox.Show("Pilih produk terlebih dahulu.");
                return;
            }

            if (string.IsNullOrEmpty(txtJumlah.Text))
            {
                MessageBox.Show("Jumlah wajib diisi.");
                return;
            }

            var produk = (Produk)cmbProduk.SelectedItem;
            int jumlah = int.Parse(txtJumlah.Text.Trim());

            var stok = _stokService.GetAll().Find(s => s.ProdukId == produk.ProdukId);
            if (stok != null && jumlah > stok.JumlahStok)
            {
                MessageBox.Show($"Stok tidak mencukupi. Stok tersedia: {stok.JumlahStok}");
                return;
            }

            var existing = _listItem.Find(i => i.ProdukId == produk.ProdukId);
            if (existing != null)
            {
                existing.Jumlah += jumlah;
            }
            else
            {
                _listItem.Add(new DetailPenjualan
                {
                    ProdukId = produk.ProdukId,
                    NamaProduk = produk.NamaProduk,
                    HargaJual = produk.HargaJual,
                    Jumlah = jumlah
                });
            }

            TampilkanItem();
            txtJumlah.Text = "";
        }

        private void btnSimpanTransaksi_Click(object sender, EventArgs e)
        {
            if (cmbPelanggan.SelectedItem == null)
            {
                MessageBox.Show("Pilih pelanggan terlebih dahulu.");
                return;
            }

            if (_listItem.Count == 0)
            {
                MessageBox.Show("Tambahkan minimal 1 produk.");
                return;
            }

            try
            {
                string statusLogistik = cmbOpsi.Text == "Diambil" ? "Selesai" : "Proses Pengiriman";

                var penjualan = new Penjualan
                {
                    TanggalPenjualan = DateTime.Now,
                    OpsiPenyerahan = cmbOpsi.Text,
                    StatusLogistik = statusLogistik,
                    AlamatPengiriman = txtAlamatPengiriman.Text.Trim(),
                    PelangganId = Convert.ToInt32(cmbPelanggan.SelectedValue),
                    MetodePembayaranId = Convert.ToInt32(cmbMetode.SelectedValue),
                    UserId = SessionHelper.UserId
                };

                int penjualanId = _penjualanService.Add(penjualan);

                foreach (var item in _listItem)
                {
                    item.PenjualanId = penjualanId;
                    _penjualanService.AddDetail(item);
                }

                MessageBox.Show("Transaksi penjualan berhasil disimpan.");
                panelInput.Visible = false;
                _listItem.Clear();
                LoadPenjualan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        private void btnBatalTransaksi_Click(object sender, EventArgs e)
        {
            panelInput.Visible = false;
            _listItem.Clear();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dgvPenjualan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih transaksi yang ingin dilihat detailnya.");
                return;
            }

            int id = Convert.ToInt32(dgvPenjualan.SelectedRows[0].Cells["ID"].Value);

            try
            {
                var detail = _penjualanService.GetDetail(id);

                dgvDetail.Rows.Clear();
                dgvDetail.Columns.Clear();

                dgvDetail.Columns.Add("NamaProduk", "Nama Produk");
                dgvDetail.Columns.Add("HargaJual", "Harga Jual");
                dgvDetail.Columns.Add("Jumlah", "Jumlah");
                dgvDetail.Columns.Add("Subtotal", "Subtotal");

                decimal total = 0;
                foreach (var d in detail)
                {
                    dgvDetail.Rows.Add(
                        d.NamaProduk,
                        "Rp " + d.HargaJual.ToString("N0"),
                        d.Jumlah,
                        "Rp " + d.Subtotal.ToString("N0")
                    );
                    total += d.Subtotal;
                }

                lblTotalDetail.Text = "Total: Rp " + total.ToString("N0");
                panelDetail.Visible = true;
                panelDetail.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat detail: " + ex.Message);
            }
        }

        private void btnTutupDetail_Click(object sender, EventArgs e)
        {
            panelDetail.Visible = false;
        }
        
        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                TampilkanData(_listPenjualan);
                return;
            }

            var hasil = _listPenjualan.FindAll(p =>
                p.NamaPelanggan.ToLower().Contains(keyword) ||
                p.NamaMetode.ToLower().Contains(keyword)
            );
            TampilkanData(hasil);
        }

        private void cmbPelanggan_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
