namespace PROJEK_SIMARANG.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProduk = new System.Windows.Forms.Button();
            this.btnPelanggan = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnStok = new System.Windows.Forms.Button();
            this.btnPembelian = new System.Windows.Forms.Button();
            this.btnPenjualan = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelContent.Location = new System.Drawing.Point(200, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(982, 653);
            this.panelContent.TabIndex = 1;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Silver;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 60);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.Silver;
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnProduk);
            this.panelSidebar.Controls.Add(this.btnPelanggan);
            this.panelSidebar.Controls.Add(this.btnSupplier);
            this.panelSidebar.Controls.Add(this.btnStok);
            this.panelSidebar.Controls.Add(this.btnPembelian);
            this.panelSidebar.Controls.Add(this.btnPenjualan);
            this.panelSidebar.Controls.Add(this.btnLaporan);
            this.panelSidebar.Controls.Add(this.btnUser);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(200, 653);
            this.panelSidebar.TabIndex = 12;
            this.panelSidebar.Visible = false;
            // 
            // btnProduk
            // 
            this.btnProduk.FlatAppearance.BorderSize = 0;
            this.btnProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduk.Location = new System.Drawing.Point(3, 69);
            this.btnProduk.Name = "btnProduk";
            this.btnProduk.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProduk.Size = new System.Drawing.Size(200, 60);
            this.btnProduk.TabIndex = 2;
            this.btnProduk.Text = "Produk";
            this.btnProduk.UseVisualStyleBackColor = true;
            this.btnProduk.Click += new System.EventHandler(this.btnProduk_Click);
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.FlatAppearance.BorderSize = 0;
            this.btnPelanggan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPelanggan.Location = new System.Drawing.Point(3, 135);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPelanggan.Size = new System.Drawing.Size(200, 60);
            this.btnPelanggan.TabIndex = 3;
            this.btnPelanggan.Text = "Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Location = new System.Drawing.Point(3, 201);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSupplier.Size = new System.Drawing.Size(200, 60);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnStok
            // 
            this.btnStok.FlatAppearance.BorderSize = 0;
            this.btnStok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStok.Location = new System.Drawing.Point(3, 267);
            this.btnStok.Name = "btnStok";
            this.btnStok.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnStok.Size = new System.Drawing.Size(200, 60);
            this.btnStok.TabIndex = 5;
            this.btnStok.Text = "Stok";
            this.btnStok.UseVisualStyleBackColor = true;
            this.btnStok.Click += new System.EventHandler(this.btnStok_Click);
            // 
            // btnPembelian
            // 
            this.btnPembelian.FlatAppearance.BorderSize = 0;
            this.btnPembelian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPembelian.Location = new System.Drawing.Point(3, 333);
            this.btnPembelian.Name = "btnPembelian";
            this.btnPembelian.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPembelian.Size = new System.Drawing.Size(200, 60);
            this.btnPembelian.TabIndex = 6;
            this.btnPembelian.Text = "Pembelian";
            this.btnPembelian.UseVisualStyleBackColor = true;
            this.btnPembelian.Click += new System.EventHandler(this.btnPembelian_Click);
            // 
            // btnPenjualan
            // 
            this.btnPenjualan.FlatAppearance.BorderSize = 0;
            this.btnPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPenjualan.Location = new System.Drawing.Point(3, 399);
            this.btnPenjualan.Name = "btnPenjualan";
            this.btnPenjualan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPenjualan.Size = new System.Drawing.Size(200, 60);
            this.btnPenjualan.TabIndex = 7;
            this.btnPenjualan.Text = "Penjualan";
            this.btnPenjualan.UseVisualStyleBackColor = true;
            this.btnPenjualan.Click += new System.EventHandler(this.btnPenjualan_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.FlatAppearance.BorderSize = 0;
            this.btnLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaporan.Location = new System.Drawing.Point(3, 465);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLaporan.Size = new System.Drawing.Size(200, 60);
            this.btnLaporan.TabIndex = 8;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnUser
            // 
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Location = new System.Drawing.Point(3, 531);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(200, 60);
            this.btnUser.TabIndex = 9;
            this.btnUser.Text = "Kelola User";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(3, 597);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 60);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIMARANG - Sistem Manajemen Penjualan Arang";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnProduk;
        private System.Windows.Forms.Button btnPelanggan;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnStok;
        private System.Windows.Forms.Button btnPembelian;
        private System.Windows.Forms.Button btnPenjualan;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel panelSidebar;
    }
}