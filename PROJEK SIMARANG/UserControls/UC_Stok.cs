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
    public partial class UC_Stok : UserControl
    {
        private StokService _stokService = new StokService();
        private List<Stok> _listStok = new List<Stok>();
        private int _selectedProdukId = 0;

        public UC_Stok()
        {
            InitializeComponent();
        }

        private void UC_Stok_Load(object sender, EventArgs e)
        {
            LoadStok();
            panelInput.Visible = false;

            if (SessionHelper.RoleId == 1)
            {
                btnUpdate.Visible = false;
            }
        }

        private void LoadStok()
        {
            try
            {
                _listStok = _stokService.GetAll();
                TampilkanData(_listStok);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void TampilkanData(List<Stok> list)
        {
            dgvStok.Rows.Clear();
            dgvStok.Columns.Clear();

            dgvStok.Columns.Add("ID", "ID");
            dgvStok.Columns.Add("NamaProduk", "Nama Produk");
            dgvStok.Columns.Add("Satuan", "Satuan");
            dgvStok.Columns.Add("JumlahStok", "Jumlah Stok");
            dgvStok.Columns.Add("StokMinimum", "Stok Minimum");
            dgvStok.Columns.Add("TanggalUpdate", "Terakhir Update");
            dgvStok.Columns.Add("Status", "Status");

            foreach (var s in list)
            {
                string status = s.JumlahStok <= s.StokMinimum ? "Menipis" : "Aman";
                var row = dgvStok.Rows.Add(
                    s.ProdukId,
                    s.NamaProduk,
                    s.Satuan,
                    s.JumlahStok,
                    s.StokMinimum,
                    s.TanggalUpdate.ToString("dd/MM/yyyy HH:mm"),
                    status
                );

                if (s.JumlahStok <= s.StokMinimum)
                    dgvStok.Rows[row].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStok.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih produk yang ingin diupdate stoknya.");
                return;
            }

            _selectedProdukId = Convert.ToInt32(dgvStok.SelectedRows[0].Cells["ID"].Value);
            string namaProduk = dgvStok.SelectedRows[0].Cells["NamaProduk"].Value.ToString();
            string jumlahStok = dgvStok.SelectedRows[0].Cells["JumlahStok"].Value.ToString();
            string stokMinimum = dgvStok.SelectedRows[0].Cells["StokMinimum"].Value.ToString();

            txtNamaProduk.Text = namaProduk;
            txtJumlahStok.Text = jumlahStok;
            txtStokMinimum.Text = stokMinimum;

            lblFormTitle.Text = "Update Stok";
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJumlahStok.Text) ||
              string.IsNullOrEmpty(txtStokMinimum.Text))
            {
                MessageBox.Show("Jumlah stok dan stok minimum wajib diisi.");
                return;
            }

            try
            {
                int jumlah = int.Parse(txtJumlahStok.Text.Trim());
                int minimum = int.Parse(txtStokMinimum.Text.Trim());

                _stokService.Update(_selectedProdukId, jumlah);
                LoadStok();
                panelInput.Visible = false;
                MessageBox.Show("Stok berhasil diupdate.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            panelInput.Visible = false;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                TampilkanData(_listStok);
                return;
            }

            var hasil = _listStok.FindAll(s =>
                s.NamaProduk.ToLower().Contains(keyword)
            );
            TampilkanData(hasil);
        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}
