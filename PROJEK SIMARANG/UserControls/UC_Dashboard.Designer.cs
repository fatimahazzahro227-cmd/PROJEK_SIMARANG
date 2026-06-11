namespace PROJEK_SIMARANG.UserControls
{
    partial class UC_Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalProdukDesc = new System.Windows.Forms.Label();
            this.lblTotalProduk = new System.Windows.Forms.Label();
            this.lblTotalProdukTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalPenjualanDesc = new System.Windows.Forms.Label();
            this.lblTotalPenjualan = new System.Windows.Forms.Label();
            this.lblTotalPenjualanTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalSupplierDesc = new System.Windows.Forms.Label();
            this.lblTotalSupplier = new System.Windows.Forms.Label();
            this.lblTotalSupplierTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblStokMenipisDesc = new System.Windows.Forms.Label();
            this.lblStokMenipis = new System.Windows.Forms.Label();
            this.lblStokMenipisTitle = new System.Windows.Forms.Label();
            this.panelTransaksi = new System.Windows.Forms.Panel();
            this.dgvTransaksi = new System.Windows.Forms.DataGridView();
            this.lblTransaksiTittle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(443, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(394, 38);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(167, 16);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Ringkasan informasi bisnis";
            this.lblSubtitle.Click += new System.EventHandler(this.lblSubtitle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTotalProdukDesc);
            this.panel1.Controls.Add(this.lblTotalProduk);
            this.panel1.Controls.Add(this.lblTotalProdukTitle);
            this.panel1.Location = new System.Drawing.Point(20, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 90);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblTotalProdukDesc
            // 
            this.lblTotalProdukDesc.AutoSize = true;
            this.lblTotalProdukDesc.Location = new System.Drawing.Point(19, 57);
            this.lblTotalProdukDesc.Name = "lblTotalProdukDesc";
            this.lblTotalProdukDesc.Size = new System.Drawing.Size(102, 16);
            this.lblTotalProdukDesc.TabIndex = 2;
            this.lblTotalProdukDesc.Text = "Produk terdaftar";
            this.lblTotalProdukDesc.Click += new System.EventHandler(this.lblTotalProdukDesc_Click);
            // 
            // lblTotalProduk
            // 
            this.lblTotalProduk.AutoSize = true;
            this.lblTotalProduk.Location = new System.Drawing.Point(19, 41);
            this.lblTotalProduk.Name = "lblTotalProduk";
            this.lblTotalProduk.Size = new System.Drawing.Size(14, 16);
            this.lblTotalProduk.TabIndex = 1;
            this.lblTotalProduk.Text = "0";
            this.lblTotalProduk.Click += new System.EventHandler(this.lblTotalProduk_Click);
            // 
            // lblTotalProdukTitle
            // 
            this.lblTotalProdukTitle.AutoSize = true;
            this.lblTotalProdukTitle.Location = new System.Drawing.Point(19, 16);
            this.lblTotalProdukTitle.Name = "lblTotalProdukTitle";
            this.lblTotalProdukTitle.Size = new System.Drawing.Size(111, 16);
            this.lblTotalProdukTitle.TabIndex = 0;
            this.lblTotalProdukTitle.Text = "TOTAL PRODUK";
            this.lblTotalProdukTitle.Click += new System.EventHandler(this.lblTotalProdukTitle_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTotalPenjualanDesc);
            this.panel2.Controls.Add(this.lblTotalPenjualan);
            this.panel2.Controls.Add(this.lblTotalPenjualanTitle);
            this.panel2.Location = new System.Drawing.Point(252, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 90);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblTotalPenjualanDesc
            // 
            this.lblTotalPenjualanDesc.AutoSize = true;
            this.lblTotalPenjualanDesc.Location = new System.Drawing.Point(13, 60);
            this.lblTotalPenjualanDesc.Name = "lblTotalPenjualanDesc";
            this.lblTotalPenjualanDesc.Size = new System.Drawing.Size(119, 16);
            this.lblTotalPenjualanDesc.TabIndex = 2;
            this.lblTotalPenjualanDesc.Text = "Transaksi bulan ini";
            this.lblTotalPenjualanDesc.Click += new System.EventHandler(this.lblTotalPenjualanDesc_Click);
            // 
            // lblTotalPenjualan
            // 
            this.lblTotalPenjualan.AutoSize = true;
            this.lblTotalPenjualan.Location = new System.Drawing.Point(13, 44);
            this.lblTotalPenjualan.Name = "lblTotalPenjualan";
            this.lblTotalPenjualan.Size = new System.Drawing.Size(14, 16);
            this.lblTotalPenjualan.TabIndex = 1;
            this.lblTotalPenjualan.Text = "0";
            this.lblTotalPenjualan.Click += new System.EventHandler(this.lblTotalPenjualan_Click);
            // 
            // lblTotalPenjualanTitle
            // 
            this.lblTotalPenjualanTitle.AutoSize = true;
            this.lblTotalPenjualanTitle.Location = new System.Drawing.Point(13, 16);
            this.lblTotalPenjualanTitle.Name = "lblTotalPenjualanTitle";
            this.lblTotalPenjualanTitle.Size = new System.Drawing.Size(134, 16);
            this.lblTotalPenjualanTitle.TabIndex = 0;
            this.lblTotalPenjualanTitle.Text = "TOTAL PENJUALAN";
            this.lblTotalPenjualanTitle.Click += new System.EventHandler(this.lblTotalPenjualanTitle_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblTotalSupplierDesc);
            this.panel3.Controls.Add(this.lblTotalSupplier);
            this.panel3.Controls.Add(this.lblTotalSupplierTitle);
            this.panel3.Location = new System.Drawing.Point(484, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 90);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblTotalSupplierDesc
            // 
            this.lblTotalSupplierDesc.AutoSize = true;
            this.lblTotalSupplierDesc.Location = new System.Drawing.Point(18, 61);
            this.lblTotalSupplierDesc.Name = "lblTotalSupplierDesc";
            this.lblTotalSupplierDesc.Size = new System.Drawing.Size(109, 16);
            this.lblTotalSupplierDesc.TabIndex = 2;
            this.lblTotalSupplierDesc.Text = "Supplier terdaftar";
            this.lblTotalSupplierDesc.Click += new System.EventHandler(this.lblTotalSupplierDesc_Click);
            // 
            // lblTotalSupplier
            // 
            this.lblTotalSupplier.AutoSize = true;
            this.lblTotalSupplier.Location = new System.Drawing.Point(13, 41);
            this.lblTotalSupplier.Name = "lblTotalSupplier";
            this.lblTotalSupplier.Size = new System.Drawing.Size(14, 16);
            this.lblTotalSupplier.TabIndex = 1;
            this.lblTotalSupplier.Text = "0";
            this.lblTotalSupplier.Click += new System.EventHandler(this.lblTotalSupplier_Click);
            // 
            // lblTotalSupplierTitle
            // 
            this.lblTotalSupplierTitle.AutoSize = true;
            this.lblTotalSupplierTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTotalSupplierTitle.Name = "lblTotalSupplierTitle";
            this.lblTotalSupplierTitle.Size = new System.Drawing.Size(120, 16);
            this.lblTotalSupplierTitle.TabIndex = 0;
            this.lblTotalSupplierTitle.Text = "TOTAL SUPPLIER";
            this.lblTotalSupplierTitle.Click += new System.EventHandler(this.lblTotalSupplierTitle_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblStokMenipisDesc);
            this.panel4.Controls.Add(this.lblStokMenipis);
            this.panel4.Controls.Add(this.lblStokMenipisTitle);
            this.panel4.Location = new System.Drawing.Point(723, 72);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(210, 90);
            this.panel4.TabIndex = 5;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lblStokMenipisDesc
            // 
            this.lblStokMenipisDesc.AutoSize = true;
            this.lblStokMenipisDesc.Location = new System.Drawing.Point(14, 66);
            this.lblStokMenipisDesc.Name = "lblStokMenipisDesc";
            this.lblStokMenipisDesc.Size = new System.Drawing.Size(123, 16);
            this.lblStokMenipisDesc.TabIndex = 2;
            this.lblStokMenipisDesc.Text = "Produk perlu restok";
            this.lblStokMenipisDesc.Click += new System.EventHandler(this.lblStokMenipisDesc_Click);
            // 
            // lblStokMenipis
            // 
            this.lblStokMenipis.AutoSize = true;
            this.lblStokMenipis.Location = new System.Drawing.Point(14, 40);
            this.lblStokMenipis.Name = "lblStokMenipis";
            this.lblStokMenipis.Size = new System.Drawing.Size(14, 16);
            this.lblStokMenipis.TabIndex = 1;
            this.lblStokMenipis.Text = "0";
            this.lblStokMenipis.Click += new System.EventHandler(this.lblStokMenipis_Click);
            // 
            // lblStokMenipisTitle
            // 
            this.lblStokMenipisTitle.AutoSize = true;
            this.lblStokMenipisTitle.Location = new System.Drawing.Point(14, 13);
            this.lblStokMenipisTitle.Name = "lblStokMenipisTitle";
            this.lblStokMenipisTitle.Size = new System.Drawing.Size(100, 16);
            this.lblStokMenipisTitle.TabIndex = 0;
            this.lblStokMenipisTitle.Text = "STOK MENIPIS";
            this.lblStokMenipisTitle.Click += new System.EventHandler(this.lblStokMenipisTitle_Click);
            // 
            // panelTransaksi
            // 
            this.panelTransaksi.BackColor = System.Drawing.Color.White;
            this.panelTransaksi.Controls.Add(this.dgvTransaksi);
            this.panelTransaksi.Controls.Add(this.lblTransaksiTittle);
            this.panelTransaksi.Location = new System.Drawing.Point(23, 197);
            this.panelTransaksi.Name = "panelTransaksi";
            this.panelTransaksi.Size = new System.Drawing.Size(920, 380);
            this.panelTransaksi.TabIndex = 6;
            this.panelTransaksi.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTransaksi_Paint);
            // 
            // dgvTransaksi
            // 
            this.dgvTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaksi.Location = new System.Drawing.Point(21, 57);
            this.dgvTransaksi.Name = "dgvTransaksi";
            this.dgvTransaksi.RowHeadersWidth = 51;
            this.dgvTransaksi.RowTemplate.Height = 24;
            this.dgvTransaksi.Size = new System.Drawing.Size(890, 320);
            this.dgvTransaksi.TabIndex = 1;
            // 
            // lblTransaksiTittle
            // 
            this.lblTransaksiTittle.AutoSize = true;
            this.lblTransaksiTittle.Location = new System.Drawing.Point(24, 23);
            this.lblTransaksiTittle.Name = "lblTransaksiTittle";
            this.lblTransaksiTittle.Size = new System.Drawing.Size(118, 16);
            this.lblTransaksiTittle.TabIndex = 0;
            this.lblTransaksiTittle.Text = "Transaksi Terbaru";
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTransaksi);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(980, 660);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelTransaksi.ResumeLayout(false);
            this.panelTransaksi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalProduk;
        private System.Windows.Forms.Label lblTotalProdukTitle;
        private System.Windows.Forms.Label lblTotalProdukDesc;
        private System.Windows.Forms.Label lblTotalPenjualanTitle;
        private System.Windows.Forms.Label lblTotalPenjualan;
        private System.Windows.Forms.Label lblTotalPenjualanDesc;
        private System.Windows.Forms.Label lblTotalSupplier;
        private System.Windows.Forms.Label lblTotalSupplierTitle;
        private System.Windows.Forms.Label lblTotalSupplierDesc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStokMenipisTitle;
        private System.Windows.Forms.Label lblStokMenipis;
        private System.Windows.Forms.Label lblStokMenipisDesc;
        private System.Windows.Forms.Panel panelTransaksi;
        private System.Windows.Forms.Label lblTransaksiTittle;
        private System.Windows.Forms.DataGridView dgvTransaksi;
    }
}
