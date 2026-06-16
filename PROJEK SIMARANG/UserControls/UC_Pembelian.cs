using PROJEK_SIMARANG.Helpers;
using PROJEK_SIMARANG.Models;
using PROJEK_SIMARANG.Services;
using PROJEK_SIMARANG.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_Pembelian : UserControl
    {
        private PembelianService _pembelianService = new PembelianService();
        private SupplierService _supplierService = new SupplierService();
        private ProdukService _produkService = new ProdukService();
        private StokService _stokService = new StokService();

        private List<Pembelian> _listPembelian = new List<Pembelian>();
        private List<DetailPembelian> _listItem = new List<DetailPembelian>();
        
        public UC_Pembelian()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpanTransaksi_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedItem == null)
            {
                MessageBox.Show("Pilih supplier terlebih dahulu.");
                return;
            }

            if (_listItem.Count == 0)
            {
                MessageBox.Show("Tambahkan minimal 1 produk.");
                return;
            }

            try
            {
                var pembelian = new Pembelian
                {
                    TanggalPembelian = DateTime.Now,
                    StatusPembelian = cmbStatus.Text,
                    UserId = SessionHelper.UserId,
                    SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue)
                };

                _pembelianService.SimpanPembelian(
                pembelian,
                _listItem
            );

                MessageBox.Show("Transaksi pembelian berhasil disimpan.");
                panelInput.Visible = false;
                _listItem.Clear();
                LoadPembelian();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        private void btnBatalTransaksi_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void UC_Pembelian_Load(object sender, EventArgs e)
        {
            LoadSupplier();
            LoadProduk();
            LoadPembelian();
            panelInput.Visible = false;
            panelDetail.Visible = false;

            
            if (SessionHelper.RoleId == 2)
            {
                btnTambah.Visible = false;
            }
        }

        private void LoadSupplier()
        {
            var list = _supplierService.GetAll();
            cmbSupplier.DataSource = list;
            cmbSupplier.DisplayMember = "NamaSupplier";
            cmbSupplier.ValueMember = "SupplierId";
        }

        private void LoadProduk()
        {
            var list = _produkService.GetAll();
            cmbProduk.DataSource = list;
            cmbProduk.DisplayMember = "NamaProduk";
            cmbProduk.ValueMember = "ProdukId";
        }

        private void LoadPembelian()
        {
            try
            {
                _listPembelian = _pembelianService.GetAll();
                TampilkanData(_listPembelian);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void TampilkanData(List<Pembelian> list)
        {
            dgvPembelian.Rows.Clear();
            dgvPembelian.Columns.Clear();

            dgvPembelian.Columns.Add("ID", "ID");
            dgvPembelian.Columns.Add("Tanggal", "Tanggal");
            dgvPembelian.Columns.Add("Supplier", "Supplier");
            dgvPembelian.Columns.Add("Total", "Total");
            dgvPembelian.Columns.Add("Status", "Status");
            dgvPembelian.Columns.Add("User", "Dibuat Oleh");

            foreach (var p in list)
            {
                dgvPembelian.Rows.Add(
                    p.PembelianId,
                    p.TanggalPembelian.ToString("dd/MM/yyyy HH:mm"),
                    p.NamaSupplier,
                    "Rp " + p.TotalPembelian.ToString("N0"),
                    p.StatusPembelian,
                    p.NamaUser
                );
            }
        }

        private void TampilkanItem()
        {
            dgvItem.Rows.Clear();
            dgvItem.Columns.Clear();

            dgvItem.Columns.Add("ProdukId", "ID");
            dgvItem.Columns.Add("NamaProduk", "Nama Produk");
            dgvItem.Columns.Add("HargaBeli", "Harga Beli");
            dgvItem.Columns.Add("Jumlah", "Jumlah");
            dgvItem.Columns.Add("Subtotal", "Subtotal");

            decimal total = 0;
            foreach (var item in _listItem)
            {
                dgvItem.Rows.Add(
                    item.ProdukId,
                    item.NamaProduk,
                    "Rp " + item.HargaBeli.ToString("N0"),
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
            cmbStatus.SelectedIndex = 0;
            lblFormTitle.Text = "Transaksi Pembelian Baru";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnTambahItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpanTransaksi_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBatalTransaksi_Click_1(object sender, EventArgs e)
        {
            panelInput.Visible = false;
            _listItem.Clear();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dgvPembelian.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih transaksi yang ingin dilihat detailnya.");
                return;
            }

            int id = Convert.ToInt32(dgvPembelian.SelectedRows[0].Cells["ID"].Value);

            try
            {
                var detail = _pembelianService.GetDetail(id);

                dgvDetail.Rows.Clear();
                dgvDetail.Columns.Clear();

                dgvDetail.Columns.Add("NamaProduk", "Nama Produk");
                dgvDetail.Columns.Add("HargaBeli", "Harga Beli");
                dgvDetail.Columns.Add("Jumlah", "Jumlah");
                dgvDetail.Columns.Add("Subtotal", "Subtotal");

                decimal total = 0;
                foreach (var d in detail)
                {
                    dgvDetail.Rows.Add(
                        d.NamaProduk,
                        "Rp " + d.HargaBeli.ToString("N0"),
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
                TampilkanData(_listPembelian);
                return;
            }

            var hasil = _listPembelian.FindAll(p =>
                p.NamaSupplier.ToLower().Contains(keyword) ||
                p.StatusPembelian.ToLower().Contains(keyword)
            );
            TampilkanData(hasil);
        }
    }
}
