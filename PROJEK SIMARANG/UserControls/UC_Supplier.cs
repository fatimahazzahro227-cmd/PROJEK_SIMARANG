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
    public partial class UC_Supplier : UserControl
    {
        private SupplierService _supplierService = new SupplierService();
        private List<Supplier> _listSupplier = new List<Supplier>();
        private int _selectedId = 0;
        private bool _isEdit = false;
        public UC_Supplier()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            panelInput.Visible = false;
            BersihkanForm();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void UC_Supplier_Load(object sender, EventArgs e)
        {
            LoadSupplier();
            panelInput.Visible = false;

            if (SessionHelper.RoleId == 2)
            {
                btnTambah.Visible = false;
                btnEdit.Visible = false;
                btnHapus.Visible = false;
            }
        }

        private void LoadSupplier()
        {
            try
            {
                _listSupplier = _supplierService.GetAll();
                TampilkanData(_listSupplier);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void TampilkanData(List<Supplier> list)
        {
            dgvSupplier.Rows.Clear();
            dgvSupplier.Columns.Clear();

            dgvSupplier.Columns.Add("ID", "ID");
            dgvSupplier.Columns.Add("Nama", "Nama Supplier");
            dgvSupplier.Columns.Add("Alamat", "Alamat");
            dgvSupplier.Columns.Add("NoTelepon", "No. Telepon");
            dgvSupplier.Columns.Add("Email", "Email");
            dgvSupplier.Columns.Add("TanggalDaftar", "Tanggal Daftar");

            foreach (var s in list)
            {
                dgvSupplier.Rows.Add(
                    s.SupplierId,
                    s.NamaSupplier,
                    s.Alamat,
                    s.NoTelepon,
                    s.Email,
                    s.TanggalDaftar.ToString("dd/MM/yyyy")
                );
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            _isEdit = false;
            _selectedId = 0;
            BersihkanForm();
            lblFormTitle.Text = "Tambah Supplier";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih supplier yang ingin diedit.");
                return;
            }

            _isEdit = true;
            _selectedId = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells["ID"].Value);

            var supplier = _listSupplier.Find(s => s.SupplierId == _selectedId);
            if (supplier == null) return;

            txtNamaSupplier.Text = supplier.NamaSupplier;
            txtAlamat.Text = supplier.Alamat;
            txtNoTelepon.Text = supplier.NoTelepon;
            txtEmail.Text = supplier.Email;

            lblFormTitle.Text = "Edit Supplier";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih supplier yang ingin dihapus.");
                return;
            }

            int id = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells["ID"].Value);
            string nama = dgvSupplier.SelectedRows[0].Cells["Nama"].Value.ToString();

            var confirm = MessageBox.Show($"Hapus supplier '{nama}'?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _supplierService.Delete(id);
                    LoadSupplier();
                    MessageBox.Show("Supplier berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus: " + ex.Message);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaSupplier.Text))
            {
                MessageBox.Show("Nama supplier wajib diisi.");
                return;
            }

            try
            {
                var supplier = new Supplier
                {
                    NamaSupplier = txtNamaSupplier.Text.Trim(),
                    Alamat = txtAlamat.Text.Trim(),
                    NoTelepon = txtNoTelepon.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                if (_isEdit)
                {
                    supplier.SupplierId = _selectedId;
                    _supplierService.Update(supplier);
                    MessageBox.Show("Supplier berhasil diupdate.");
                }
                else
                {
                    _supplierService.Add(supplier);
                    MessageBox.Show("Supplier berhasil ditambahkan.");
                }

                panelInput.Visible = false;
                LoadSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                TampilkanData(_listSupplier);
                return;
            }

            var hasil = _listSupplier.FindAll(s =>
                s.NamaSupplier.ToLower().Contains(keyword) ||
                s.Email.ToLower().Contains(keyword)
            );
            TampilkanData(hasil);
        }

        private void BersihkanForm()
        {
            txtNamaSupplier.Text = "";
            txtAlamat.Text = "";
            txtNoTelepon.Text = "";
            txtEmail.Text = "";
        }
    }
}
