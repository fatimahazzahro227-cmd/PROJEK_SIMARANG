namespace PROJEK_SIMARANG.UserControls
{
    partial class UC_Pembelian
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
            this.cmbProduk = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.btnTambahItem = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSimpanTransaksi = new System.Windows.Forms.Button();
            this.btnBatalTransaksi = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.dgvPembelian = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.btnTutupDetail = new System.Windows.Forms.Button();
            this.lblTotalDetail = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembelian)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProduk
            // 
            this.cmbProduk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProduk.FormattingEnabled = true;
            this.cmbProduk.Location = new System.Drawing.Point(310, 64);
            this.cmbProduk.Name = "cmbProduk";
            this.cmbProduk.Size = new System.Drawing.Size(300, 24);
            this.cmbProduk.TabIndex = 6;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Selesai",
            "Pending"});
            this.cmbStatus.Location = new System.Drawing.Point(23, 123);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.TabIndex = 5;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJumlah.Location = new System.Drawing.Point(310, 125);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(100, 22);
            this.txtJumlah.TabIndex = 8;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(23, 64);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(200, 24);
            this.cmbSupplier.TabIndex = 2;
            // 
            // btnTambahItem
            // 
            this.btnTambahItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTambahItem.Location = new System.Drawing.Point(310, 153);
            this.btnTambahItem.Name = "btnTambahItem";
            this.btnTambahItem.Size = new System.Drawing.Size(120, 30);
            this.btnTambahItem.TabIndex = 9;
            this.btnTambahItem.Text = "+ Tambah Item";
            this.btnTambahItem.UseVisualStyleBackColor = true;
            this.btnTambahItem.Click += new System.EventHandler(this.btnTambahItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(30, 269);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 16);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total : Rp 0";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // btnSimpanTransaksi
            // 
            this.btnSimpanTransaksi.Location = new System.Drawing.Point(23, 336);
            this.btnSimpanTransaksi.Name = "btnSimpanTransaksi";
            this.btnSimpanTransaksi.Size = new System.Drawing.Size(160, 38);
            this.btnSimpanTransaksi.TabIndex = 12;
            this.btnSimpanTransaksi.Text = "Simpan Transaksi";
            this.btnSimpanTransaksi.UseVisualStyleBackColor = true;
            this.btnSimpanTransaksi.Click += new System.EventHandler(this.btnSimpanTransaksi_Click);
            // 
            // btnBatalTransaksi
            // 
            this.btnBatalTransaksi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatalTransaksi.Location = new System.Drawing.Point(450, 336);
            this.btnBatalTransaksi.Name = "btnBatalTransaksi";
            this.btnBatalTransaksi.Size = new System.Drawing.Size(160, 38);
            this.btnBatalTransaksi.TabIndex = 13;
            this.btnBatalTransaksi.Text = "Batal";
            this.btnBatalTransaksi.UseVisualStyleBackColor = true;
            this.btnBatalTransaksi.Click += new System.EventHandler(this.btnBatalTransaksi_Click_1);
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Black;
            this.btnTambah.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTambah.Location = new System.Drawing.Point(13, 12);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(100, 35);
            this.btnTambah.TabIndex = 4;
            this.btnTambah.Text = "+ Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnCari
            // 
            this.btnCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCari.BackColor = System.Drawing.Color.Black;
            this.btnCari.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCari.Location = new System.Drawing.Point(846, 12);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(80, 35);
            this.btnCari.TabIndex = 3;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtCari
            // 
            this.txtCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCari.Location = new System.Drawing.Point(440, 18);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(400, 22);
            this.txtCari.TabIndex = 2;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // dgvPembelian
            // 
            this.dgvPembelian.AllowUserToAddRows = false;
            this.dgvPembelian.AllowUserToDeleteRows = false;
            this.dgvPembelian.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPembelian.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPembelian.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvPembelian.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPembelian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembelian.Location = new System.Drawing.Point(22, 160);
            this.dgvPembelian.Name = "dgvPembelian";
            this.dgvPembelian.ReadOnly = true;
            this.dgvPembelian.RowHeadersWidth = 51;
            this.dgvPembelian.RowTemplate.Height = 24;
            this.dgvPembelian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPembelian.Size = new System.Drawing.Size(940, 460);
            this.dgvPembelian.TabIndex = 15;
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.btnDetail);
            this.panelTop.Controls.Add(this.txtCari);
            this.panelTop.Controls.Add(this.btnTambah);
            this.panelTop.Controls.Add(this.btnCari);
            this.panelTop.Location = new System.Drawing.Point(22, 90);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(940, 59);
            this.panelTop.TabIndex = 16;
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.Black;
            this.btnDetail.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDetail.Location = new System.Drawing.Point(134, 12);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(106, 35);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "Lihat Detail";
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // panelInput
            // 
            this.panelInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.btnTambahItem);
            this.panelInput.Controls.Add(this.label5);
            this.panelInput.Controls.Add(this.txtJumlah);
            this.panelInput.Controls.Add(this.label4);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.lblFormTitle);
            this.panelInput.Controls.Add(this.btnBatalTransaksi);
            this.panelInput.Controls.Add(this.cmbSupplier);
            this.panelInput.Controls.Add(this.cmbProduk);
            this.panelInput.Controls.Add(this.btnSimpanTransaksi);
            this.panelInput.Controls.Add(this.lblTotal);
            this.panelInput.Controls.Add(this.cmbStatus);
            this.panelInput.Controls.Add(this.dgvItem);
            this.panelInput.Location = new System.Drawing.Point(170, 174);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(640, 400);
            this.panelInput.TabIndex = 5;
            this.panelInput.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Jumlah";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Produk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Supplier";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Location = new System.Drawing.Point(20, 15);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(166, 16);
            this.lblFormTitle.TabIndex = 14;
            this.lblFormTitle.Text = "Transaksi Pembelian Baru";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Location = new System.Drawing.Point(14, 257);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(610, 130);
            this.dgvItem.TabIndex = 19;
            // 
            // panelDetail
            // 
            this.panelDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetail.BackColor = System.Drawing.SystemColors.Control;
            this.panelDetail.Controls.Add(this.btnTutupDetail);
            this.panelDetail.Controls.Add(this.lblTotalDetail);
            this.panelDetail.Controls.Add(this.lblDetailTitle);
            this.panelDetail.Controls.Add(this.dgvDetail);
            this.panelDetail.Location = new System.Drawing.Point(22, 160);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(940, 476);
            this.panelDetail.TabIndex = 20;
            this.panelDetail.Visible = false;
            // 
            // btnTutupDetail
            // 
            this.btnTutupDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTutupDetail.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTutupDetail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTutupDetail.Location = new System.Drawing.Point(790, 430);
            this.btnTutupDetail.Name = "btnTutupDetail";
            this.btnTutupDetail.Size = new System.Drawing.Size(120, 38);
            this.btnTutupDetail.TabIndex = 3;
            this.btnTutupDetail.Text = "Tutup";
            this.btnTutupDetail.UseVisualStyleBackColor = false;
            this.btnTutupDetail.Click += new System.EventHandler(this.btnTutupDetail_Click);
            // 
            // lblTotalDetail
            // 
            this.lblTotalDetail.AutoSize = true;
            this.lblTotalDetail.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDetail.Location = new System.Drawing.Point(27, 444);
            this.lblTotalDetail.Name = "lblTotalDetail";
            this.lblTotalDetail.Size = new System.Drawing.Size(89, 21);
            this.lblTotalDetail.TabIndex = 1;
            this.lblTotalDetail.Text = "Total : Rp 0";
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTitle.Location = new System.Drawing.Point(26, 19);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(137, 22);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Detail Pembelian";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(30, 44);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 24;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(880, 380);
            this.dgvDetail.TabIndex = 2;
            // 
            // UC_Pembelian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROJEK_SIMARANG.Properties.Resources.pembelian;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.dgvPembelian);
            this.Name = "UC_Pembelian";
            this.Size = new System.Drawing.Size(980, 660);
            this.Load += new System.EventHandler(this.UC_Pembelian_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembelian)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProduk;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnTambahItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSimpanTransaksi;
        private System.Windows.Forms.Button btnBatalTransaksi;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.DataGridView dgvPembelian;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label lblTotalDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnTutupDetail;
        private System.Windows.Forms.Button btnDetail;
    }
}
