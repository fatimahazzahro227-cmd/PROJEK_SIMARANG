using PROJEK_SIMARANG.Helpers;
using PROJEK_SIMARANG.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROJEK_SIMARANG.Forms;

namespace PROJEK_SIMARANG.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            HideAllButtons();
            panelSidebar.Visible = false;
            panelContent.Location = new System.Drawing.Point(0, 0);
            panelContent.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height);
            ShowUserControl(new UC_Login());
        }

        private void HideAllButtons()
        {
            btnDashboard.Visible = false;
            btnProduk.Visible = false;
            btnPelanggan.Visible = false;
            btnSupplier.Visible = false;
            btnStok.Visible = false;
            btnPembelian.Visible = false;
            btnPenjualan.Visible = false;
            btnLaporan.Visible = false;
            btnUser.Visible = false;
            btnLogout.Visible = false;
        }

        public void ShowSidebar()
        {
            panelSidebar.Visible = true;
            panelContent.Location = new System.Drawing.Point(200, 0);
            panelContent.Size = new System.Drawing.Size(this.ClientSize.Width - 200, this.ClientSize.Height);
            SetMenuByRole();
            btnLogout.Visible = true;
            ShowUserControl(new UC_Dashboard());
        }

        public void ShowUserControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void SetMenuByRole()
        {
            btnDashboard.Visible = true;
            btnProduk.Visible = true;
            btnPelanggan.Visible = true;
            btnStok.Visible = true;
            btnPenjualan.Visible = true;
            btnLaporan.Visible = true;
            btnPembelian.Visible = true;
            btnSupplier.Visible = true;

            btnUser.Visible = false;

            if (SessionHelper.RoleId == 1)
            {
                btnUser.Visible = true;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Dashboard());
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Produk());
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Pelanggan());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Supplier());
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Stok());
        }

        private void btnPembelian_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Pembelian());
        }

        private void btnPenjualan_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Penjualan());
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Laporan());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_User());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Yakin ingin logout?", "Logout",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                SessionHelper.Clear();
                panelSidebar.Visible = false;
                ShowUserControl(new UC_Login());
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (panelSidebar == null || panelContent == null) return;

            if (panelSidebar.Visible)
            {
                panelSidebar.Size = new System.Drawing.Size(200, this.ClientSize.Height);
                panelContent.Location = new System.Drawing.Point(200, 0);
                panelContent.Size = new System.Drawing.Size(this.ClientSize.Width - 200, this.ClientSize.Height);
            }
            else
            {
                panelContent.Location = new System.Drawing.Point(0, 0);
                panelContent.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height);
            }

            if (panelContent.Controls.Count > 0)
            {
                var uc = panelContent.Controls[0];
                uc.Size = panelContent.Size;
            }
        }
    }

}
