using PROJEK_SIMARANG.Helpers;
using PROJEK_SIMARANG.Models;
using PROJEK_SIMARANG.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_Pelanggan : UserControl
    {
        private PelangganService _pelangganService = new PelangganService();
        private List<Pelanggan> _listPelanggan = new List<Pelanggan>();
        private int _selectedId = 0;
        private bool _isEdit = false;

        public UC_Pelanggan()
        {
            InitializeComponent();
        }

        private void UC_Pelanggan_Load(object sender, EventArgs e)
        {
            LoadPelanggan();
            panelInput.Visible = false;

            if (SessionHelper.RoleId == 1)
            {
                btnTambah.Visible = false;
                btnEdit.Visible = false;
                btnHapus.Visible = false;
            }
        }

        private void LoadPelanggan()
        {
            try
            {
                _listPelanggan = _pelangganService.GetAll();
                TampilkanData(_listPelanggan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void TampilkanData(List<Pelanggan> list)
        {
            dgvPelanggan.Rows.Clear();
            dgvPelanggan.Columns.Clear();

            dgvPelanggan.Columns.Add("ID", "ID");
            dgvPelanggan.Columns.Add("Nama", "Nama Pelanggan");
            dgvPelanggan.Columns.Add("Alamat", "Alamat");
            dgvPelanggan.Columns.Add("NoTelepon", "No. Telepon");
            dgvPelanggan.Columns.Add("Email", "Email");
            dgvPelanggan.Columns.Add("JenisUsaha", "Jenis Usaha");

            foreach (var p in list)
            {
                dgvPelanggan.Rows.Add(
                    p.PelangganId,
                    p.NamaPelanggan,
                    p.Alamat,
                    p.NoTelepon,
                    p.Email,
                    p.JenisUsaha
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            _isEdit = false;
            _selectedId = 0;
            BersihkanForm();
            lblFormTitle.Text = "Tambah Pelanggan";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPelanggan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih pelanggan yang ingin diedit.");
                return;
            }

            _isEdit = true;
            _selectedId = Convert.ToInt32(dgvPelanggan.SelectedRows[0].Cells["ID"].Value);

            var pelanggan = _listPelanggan.Find(p => p.PelangganId == _selectedId);
            if (pelanggan == null) return;

            txtNamaPelanggan.Text = pelanggan.NamaPelanggan;
            txtAlamat.Text = pelanggan.Alamat;
            txtNoTelepon.Text = pelanggan.NoTelepon;
            txtEmail.Text = pelanggan.Email;
            txtJenisUsaha.Text = pelanggan.JenisUsaha;

            lblFormTitle.Text = "Edit Pelanggan";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPelanggan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih pelanggan yang ingin dihapus.");
                return;
            }

            int id = Convert.ToInt32(dgvPelanggan.SelectedRows[0].Cells["ID"].Value);
            string nama = dgvPelanggan.SelectedRows[0].Cells["Nama"].Value.ToString();

            var confirm = MessageBox.Show($"Hapus pelanggan '{nama}'?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _pelangganService.Delete(id);
                    LoadPelanggan();
                    MessageBox.Show("Pelanggan berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus: " + ex.Message);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaPelanggan.Text))
            {
                MessageBox.Show("Nama pelanggan wajib diisi.");
                return;
            }

            try
            {
                var pelanggan = new Pelanggan
                {
                    NamaPelanggan = txtNamaPelanggan.Text.Trim(),
                    Alamat = txtAlamat.Text.Trim(),
                    NoTelepon = txtNoTelepon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    JenisUsaha = txtJenisUsaha.Text.Trim()
                };

                if (_isEdit)
                {
                    pelanggan.PelangganId = _selectedId;
                    _pelangganService.Update(pelanggan);
                    MessageBox.Show("Pelanggan berhasil diupdate.");
                }
                else
                {
                    _pelangganService.Add(pelanggan);
                    MessageBox.Show("Pelanggan berhasil ditambahkan.");
                }

                panelInput.Visible = false;
                LoadPelanggan();
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

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                TampilkanData(_listPelanggan);
                return;
            }

            var hasil = _listPelanggan.FindAll(p =>
                p.NamaPelanggan.ToLower().Contains(keyword) ||
                p.JenisUsaha.ToLower().Contains(keyword)
            );
            TampilkanData(hasil);
        }

        private void BersihkanForm()
        {
            txtNamaPelanggan.Text = "";
            txtAlamat.Text = "";
            txtNoTelepon.Text = "";
            txtEmail.Text = "";
            txtJenisUsaha.Text = "";
        }
    }
}
