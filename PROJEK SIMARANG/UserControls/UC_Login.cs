using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROJEK_SIMARANG.Helpers;
using PROJEK_SIMARANG.Services;
using PROJEK_SIMARANG.Forms;

namespace PROJEK_SIMARANG.UserControls
{
    public partial class UC_Login : UserControl
    {
        private UserService _userService = new UserService();

        public UC_Login()
        {
            InitializeComponent();
        }

        private void lblPassword_Click(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Username dan password tidak boleh kosong.";
                return;
            }

            try
            {
                var user = _userService.Login(username, password);

                if (user == null)
                {
                    lblError.Text = "Username atau password salah";
                    return;
                }

                SessionHelper.UserId = user.UserId;
                SessionHelper.NamaUser = user.NamaUser;
                SessionHelper.Username = user.Username;
                SessionHelper.RoleId = user.RoleId;
                SessionHelper.NamaRole = user.NamaRole;

                var mainForm = (MainForm)this.ParentForm;
                mainForm.ShowSidebar();
            }
            catch (Exception)
            {
                lblError.Text = "Gagal terhubung ke database";
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblSubtitle_Click(object sender, EventArgs e) { }
        private void lblUsername_Click(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "USERNAME DAN PASSWORD TIDAK BOLEH KOSONG";
                return;
            }

            try
            {
                var user = _userService.Login(username, password);

                if (user == null)
                {
                    lblError.Text = "USERNAME ATAU PASSWORD SALAH";
                    return;
                }

                SessionHelper.UserId = user.UserId;
                SessionHelper.NamaUser = user.NamaUser;
                SessionHelper.Username = user.Username;
                SessionHelper.RoleId = user.RoleId;
                SessionHelper.NamaRole = user.NamaRole;

                var mainForm = (MainForm)this.ParentForm;
                mainForm.ShowSidebar();
            }
            catch (Exception)
            {
                lblError.Text = "Gagal terhubung ke database";
            }
        }

        private void lblTitle_Click_1(object sender, EventArgs e)
        {

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (panelForm != null)
            {
                panelForm.Location = new System.Drawing.Point(
                    (this.Width - panelForm.Width) / 2,
                    (this.Height - panelForm.Height) / 2
                );
            }
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click_1(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click_1(object sender, EventArgs e)
        {

        }

        private void lblSubtitle_Click_1(object sender, EventArgs e)
        {

        }
    }
}