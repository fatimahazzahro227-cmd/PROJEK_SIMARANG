using PROJEK_SIMARANG.Helpers;
using PROJEK_SIMARANG.Models;
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

namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_Produk : UserControl
    {
        private ProdukService _produkService = new ProdukService();
        private KategoriService _kategoriService = new KategoriService();
        private List<Produk> _listProduk = new List<Produk>();
        private int _selectedId = 0;
        private bool _isEdit = false;
        public UC_Produk()
        {
            InitializeComponent();
        }

        private void UC_Produk_Load(object sender, EventArgs e)
        {
            LoadKategori();
            LoadProduk();
            panelInput.Visible = false;

            if (SessionHelper.RoleId == 2)
            {
                btnTambah.Visible = false;
                btnEdit.Visible = false;
                btnHapus.Visible = false;
            }
        }

        private void LoadKategori()
        {
            var list = _kategoriService.GetAll();
            cmbKategori.DataSource = list;
            cmbKategori.DisplayMember = "NamaKategori";
            cmbKategori.ValueMember = "KategoriProdukId";

        }

        private void LoadProduk()
        {
            try
            {
                _listProduk = _produkService.GetAll();
                TampilkanData(_listProduk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void TampilkanData(List<Produk> list)
        {
            dgvProduk.Rows.Clear();
            dgvProduk.Columns.Clear();

            dgvProduk.Columns.Add("ID", "ID");
            dgvProduk.Columns.Add("NamaProduk", "Nama Produk");
            dgvProduk.Columns.Add("Kategori", "Kategori");
            dgvProduk.Columns.Add("Satuan", "Satuan");
            dgvProduk.Columns.Add("HargaBeli", "Harga Beli");
            dgvProduk.Columns.Add("HargaJual", "Harga Jual");
            dgvProduk.Columns.Add("Status", "Status");

            foreach (var p in list)
            {
                dgvProduk.Rows.Add(
                    p.ProdukId,
                    p.NamaProduk,
                    p.NamaKategori,
                    p.Satuan,
                    "Rp " + p.HargaBeli.ToString("N0"),
                    "Rp " + p.HargaJual.ToString("N0"),
                    p.StatusProduk
                );
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                TampilkanData(_listProduk);
                return;
            }

            var hasil = _listProduk.FindAll(p =>
                p.NamaProduk.ToLower().Contains(keyword) ||
                p.NamaKategori.ToLower().Contains(keyword)
            );
            TampilkanData(hasil);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            _isEdit = false;
            _selectedId = 0;
            BersihkanForm();
            lblFormTitle.Text = "Tambah Produk";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProduk.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih produk yang ingin diedit.");
                return;
            }

            _isEdit = true;
            _selectedId = Convert.ToInt32(dgvProduk.SelectedRows[0].Cells["ID"].Value);

            var produk = _listProduk.Find(p => p.ProdukId == _selectedId);
            if (produk == null) return;

            txtNamaProduk.Text = produk.NamaProduk;
            txtSatuan.Text = produk.Satuan;
            txtHargaBeli.Text = produk.HargaBeli.ToString();
            txtHargaJual.Text = produk.HargaJual.ToString();
            txtDeskripsi.Text = produk.Deskripsi;
            cmbStatus.Text = produk.StatusProduk;
            cmbKategori.SelectedValue = produk.KategoriProdukId;

            lblFormTitle.Text = "Edit Produk";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvProduk.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih produk yang ingin dihapus.");
                return;
            }

            int id = Convert.ToInt32(dgvProduk.SelectedRows[0].Cells["ID"].Value);
            string nama = dgvProduk.SelectedRows[0].Cells["NamaProduk"].Value.ToString();

            var confirm = MessageBox.Show($"Hapus produk '{nama}'?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _produkService.Delete(id);
                    LoadProduk();
                    MessageBox.Show("Produk berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus: " + ex.Message);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaProduk.Text) ||
                string.IsNullOrEmpty(txtHargaBeli.Text) ||
                string.IsNullOrEmpty(txtHargaJual.Text))
            {
                MessageBox.Show("Nama produk, harga beli, dan harga jual wajib diisi.");
                return;
            }

            try
            {
                var produk = new Produk
                {
                    NamaProduk = txtNamaProduk.Text.Trim(),
                    Satuan = txtSatuan.Text.Trim(),
                    HargaBeli = decimal.Parse(txtHargaBeli.Text.Trim()),
                    HargaJual = decimal.Parse(txtHargaJual.Text.Trim()),
                    Deskripsi = txtDeskripsi.Text.Trim(),
                    StatusProduk = cmbStatus.Text,
                    KategoriProdukId = Convert.ToInt32(cmbKategori.SelectedValue)
                };

                if (_isEdit)
                {
                    produk.ProdukId = _selectedId;
                    _produkService.Update(produk);
                    MessageBox.Show("Produk berhasil diupdate.");
                }
                else
                {
                    _produkService.Add(produk);
                    MessageBox.Show("Produk berhasil ditambahkan.");
                }

                panelInput.Visible = false;
                LoadProduk();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            panelInput.Visible = false; 
            BersihkanForm();
        }

        private void BersihkanForm()
        {
            txtNamaProduk.Text = "";
            txtSatuan.Text = "";
            txtHargaBeli.Text = "";
            txtHargaJual.Text = "";
            txtDeskripsi.Text = "";
            cmbStatus.SelectedIndex = 0;
            if (cmbKategori.Items.Count > 0)
                cmbKategori.SelectedIndex = 0;
        }

        private void textDeskripsi_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtsatuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
