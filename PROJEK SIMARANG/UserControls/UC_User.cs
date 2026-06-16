using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROJEK_SIMARANG.Models;
using PROJEK_SIMARANG.Services;

namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_User : UserControl
    {
        private UserService _userService = new UserService();
        private RoleService _roleService = new RoleService();
        private List<User> _listUser = new List<User>();
        private int _selectedId = 0;
        private bool _isEdit = false;

        public UC_User()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void UC_User_Load(object sender, EventArgs e)
        {
            LoadRole();
            LoadUser();
            panelInput.Visible = false;
        }


        private void LoadRole()
        {
            var list = _roleService.GetAll();
            cmbRole.DataSource = list;
            cmbRole.DisplayMember = "NamaRole";
            cmbRole.ValueMember = "RoleId";
        }

        private void LoadUser()
        {
            try
            {
                _listUser = _userService.GetAll();
                TampilkanData(_listUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void TampilkanData(List<User> list)
        {
            dgvUser.Rows.Clear();
            dgvUser.Columns.Clear();

            dgvUser.Columns.Add("ID", "ID");
            dgvUser.Columns.Add("NamaUser", "Nama User");
            dgvUser.Columns.Add("Username", "Username");
            dgvUser.Columns.Add("NoHp", "No. HP");
            dgvUser.Columns.Add("Role", "Role");
            dgvUser.Columns.Add("Status", "Status Akun");
            dgvUser.Columns.Add("TanggalDaftar", "Tanggal Daftar");

            foreach (var u in list)
            {
                dgvUser.Rows.Add(
                    u.UserId,
                    u.NamaUser,
                    u.Username,
                    u.NoHp,
                    u.NamaRole,
                    u.StatusAkun,
                    u.TanggalDaftar.ToString("dd/MM/yyyy")
                );
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            _isEdit = false;
            _selectedId = 0;
            BersihkanForm();
            lblFormTitle.Text = "Tambah User";
            txtPassword.Enabled = true;
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user yang ingin diedit.");
                return;
            }

            _isEdit = true;
            _selectedId = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["ID"].Value);

            var user = _listUser.Find(u => u.UserId == _selectedId);
            if (user == null) return;

            txtNamaUser.Text = user.NamaUser;
            txtUsername.Text = user.Username;
            txtPassword.Text = "";
            txtNoHp.Text = user.NoHp;
            txtAlamat.Text = user.Alamat;
            cmbStatus.Text = user.StatusAkun;
            cmbRole.SelectedValue = user.RoleId;

            lblFormTitle.Text = "Edit User";
            txtPassword.Enabled = false;
            panelInput.Visible = true;
            panelInput.BringToFront();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user yang ingin dihapus.");
                return;
            }

            int id = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["ID"].Value);
            string nama = dgvUser.SelectedRows[0].Cells["NamaUser"].Value.ToString();

            var confirm = MessageBox.Show($"Hapus user '{nama}'?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _userService.Delete(id);
                    LoadUser();
                    MessageBox.Show("User berhasil dihapus.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus: " + ex.Message);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaUser.Text) ||
                string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Nama user dan username wajib diisi.");
                return;
            }

            if (!_isEdit && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password wajib diisi.");
                return;
            }

            try
            {
                var user = new User
                {
                    NamaUser = txtNamaUser.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    NoHp = txtNoHp.Text.Trim(),
                    Alamat = txtAlamat.Text.Trim(),
                    StatusAkun = cmbStatus.Text,
                    RoleId = Convert.ToInt32(cmbRole.SelectedValue)
                };

                if (_isEdit)
                {
                    user.UserId = _selectedId;
                    _userService.Update(user);
                    MessageBox.Show("User berhasil diupdate.");
                }
                else
                {
                    _userService.Add(user);
                    MessageBox.Show("User berhasil ditambahkan.");
                }

                panelInput.Visible = false;
                LoadUser();
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
                TampilkanData(_listUser);
                return;
            }

            var hasil = _listUser.FindAll(u =>
                u.NamaUser.ToLower().Contains(keyword) ||
                u.Username.ToLower().Contains(keyword) ||
                u.NamaRole.ToLower().Contains(keyword)
            );
            TampilkanData(hasil);
        }

        private void BersihkanForm()
        {
            txtNamaUser.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNoHp.Text = "";
            txtAlamat.Text = "";
            if (cmbStatus.Items.Count > 0)      // ← tambah pengecekan
                cmbStatus.SelectedIndex = 0;
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
        }
    }
}
