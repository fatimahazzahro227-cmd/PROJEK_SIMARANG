namespace PROJEK_SIMARANG.UserControls
{
    partial class UC_Laporan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Laporan));
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpDari = new System.Windows.Forms.DateTimePicker();
            this.dtpSampai = new System.Windows.Forms.DateTimePicker();
            this.lblTotalPenjualan = new System.Windows.Forms.Label();
            this.lblTotalPembelian = new System.Windows.Forms.Label();
            this.lblKeuntungan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblKeuntunganTitle = new System.Windows.Forms.Label();
            this.cardKeuntungan = new System.Windows.Forms.Panel();
            this.lblMargin = new System.Windows.Forms.Label();
            this.lblPembelianTitle = new System.Windows.Forms.Label();
            this.cardPembelian = new System.Windows.Forms.Panel();
            this.lblPenjualanTitle = new System.Windows.Forms.Label();
            this.cardPenjualan = new System.Windows.Forms.Panel();
            this.tabLaporan = new System.Windows.Forms.TabControl();
            this.tabPenjualan = new System.Windows.Forms.TabPage();
            this.dgvPenjualan = new System.Windows.Forms.DataGridView();
            this.tabPembelian = new System.Windows.Forms.TabPage();
            this.dgvPembelian = new System.Windows.Forms.DataGridView();
            this.tabKeuntungan = new System.Windows.Forms.TabPage();
            this.dgvKeuntungan = new System.Windows.Forms.DataGridView();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.panelFilter.SuspendLayout();
            this.cardKeuntungan.SuspendLayout();
            this.cardPembelian.SuspendLayout();
            this.cardPenjualan.SuspendLayout();
            this.tabLaporan.SuspendLayout();
            this.tabPenjualan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenjualan)).BeginInit();
            this.tabPembelian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembelian)).BeginInit();
            this.tabKeuntungan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeuntungan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFilter.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFilter.Location = new System.Drawing.Point(540, 5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 35);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Tampilkan";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click_1);
            // 
            // dtpDari
            // 
            this.dtpDari.CalendarForeColor = System.Drawing.SystemColors.ControlDark;
            this.dtpDari.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dtpDari.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpDari.CalendarTitleForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtpDari.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpDari.Location = new System.Drawing.Point(56, 14);
            this.dtpDari.Name = "dtpDari";
            this.dtpDari.Size = new System.Drawing.Size(150, 22);
            this.dtpDari.TabIndex = 3;
            // 
            // dtpSampai
            // 
            this.dtpSampai.Location = new System.Drawing.Point(322, 13);
            this.dtpSampai.Name = "dtpSampai";
            this.dtpSampai.Size = new System.Drawing.Size(150, 22);
            this.dtpSampai.TabIndex = 4;
            // 
            // lblTotalPenjualan
            // 
            this.lblTotalPenjualan.AutoSize = true;
            this.lblTotalPenjualan.Location = new System.Drawing.Point(107, 49);
            this.lblTotalPenjualan.Name = "lblTotalPenjualan";
            this.lblTotalPenjualan.Size = new System.Drawing.Size(35, 16);
            this.lblTotalPenjualan.TabIndex = 1;
            this.lblTotalPenjualan.Text = "Rp 0";
            // 
            // lblTotalPembelian
            // 
            this.lblTotalPembelian.AutoSize = true;
            this.lblTotalPembelian.Location = new System.Drawing.Point(127, 49);
            this.lblTotalPembelian.Name = "lblTotalPembelian";
            this.lblTotalPembelian.Size = new System.Drawing.Size(35, 16);
            this.lblTotalPembelian.TabIndex = 1;
            this.lblTotalPembelian.Text = "Rp 0";
            // 
            // lblKeuntungan
            // 
            this.lblKeuntungan.AutoSize = true;
            this.lblKeuntungan.Location = new System.Drawing.Point(14, 49);
            this.lblKeuntungan.Name = "lblKeuntungan";
            this.lblKeuntungan.Size = new System.Drawing.Size(35, 16);
            this.lblKeuntungan.TabIndex = 1;
            this.lblKeuntungan.Text = "Rp 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(261, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sampai";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dari";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelFilter.Controls.Add(this.btnFilter);
            this.panelFilter.Controls.Add(this.dtpDari);
            this.panelFilter.Controls.Add(this.dtpSampai);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Location = new System.Drawing.Point(20, 90);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(940, 50);
            this.panelFilter.TabIndex = 2;
            // 
            // lblKeuntunganTitle
            // 
            this.lblKeuntunganTitle.AutoSize = true;
            this.lblKeuntunganTitle.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeuntunganTitle.Location = new System.Drawing.Point(101, 11);
            this.lblKeuntunganTitle.Name = "lblKeuntunganTitle";
            this.lblKeuntunganTitle.Size = new System.Drawing.Size(111, 21);
            this.lblKeuntunganTitle.TabIndex = 0;
            this.lblKeuntunganTitle.Text = "KEUNTUNGAN";
            // 
            // cardKeuntungan
            // 
            this.cardKeuntungan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cardKeuntungan.Controls.Add(this.lblMargin);
            this.cardKeuntungan.Controls.Add(this.lblKeuntungan);
            this.cardKeuntungan.Controls.Add(this.lblKeuntunganTitle);
            this.cardKeuntungan.Location = new System.Drawing.Point(670, 160);
            this.cardKeuntungan.Name = "cardKeuntungan";
            this.cardKeuntungan.Size = new System.Drawing.Size(290, 80);
            this.cardKeuntungan.TabIndex = 5;
            this.cardKeuntungan.Paint += new System.Windows.Forms.PaintEventHandler(this.cardKeuntungan_Paint);
            // 
            // lblMargin
            // 
            this.lblMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMargin.AutoSize = true;
            this.lblMargin.Location = new System.Drawing.Point(228, 49);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(44, 16);
            this.lblMargin.TabIndex = 7;
            this.lblMargin.Text = "label4";
            this.lblMargin.Click += new System.EventHandler(this.lblMargin_Click);
            // 
            // lblPembelianTitle
            // 
            this.lblPembelianTitle.AutoSize = true;
            this.lblPembelianTitle.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPembelianTitle.Location = new System.Drawing.Point(81, 11);
            this.lblPembelianTitle.Name = "lblPembelianTitle";
            this.lblPembelianTitle.Size = new System.Drawing.Size(141, 21);
            this.lblPembelianTitle.TabIndex = 0;
            this.lblPembelianTitle.Text = "TOTAL PEMBELIAN";
            // 
            // cardPembelian
            // 
            this.cardPembelian.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cardPembelian.Controls.Add(this.lblTotalPembelian);
            this.cardPembelian.Controls.Add(this.lblPembelianTitle);
            this.cardPembelian.Location = new System.Drawing.Point(342, 160);
            this.cardPembelian.Name = "cardPembelian";
            this.cardPembelian.Size = new System.Drawing.Size(290, 80);
            this.cardPembelian.TabIndex = 4;
            // 
            // lblPenjualanTitle
            // 
            this.lblPenjualanTitle.AutoSize = true;
            this.lblPenjualanTitle.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPenjualanTitle.Location = new System.Drawing.Point(65, 11);
            this.lblPenjualanTitle.Name = "lblPenjualanTitle";
            this.lblPenjualanTitle.Size = new System.Drawing.Size(141, 21);
            this.lblPenjualanTitle.TabIndex = 0;
            this.lblPenjualanTitle.Text = "TOTAL PENJUALAN";
            // 
            // cardPenjualan
            // 
            this.cardPenjualan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cardPenjualan.Controls.Add(this.lblTotalPenjualan);
            this.cardPenjualan.Controls.Add(this.lblPenjualanTitle);
            this.cardPenjualan.Location = new System.Drawing.Point(20, 160);
            this.cardPenjualan.Name = "cardPenjualan";
            this.cardPenjualan.Size = new System.Drawing.Size(290, 80);
            this.cardPenjualan.TabIndex = 3;
            // 
            // tabLaporan
            // 
            this.tabLaporan.Controls.Add(this.tabPenjualan);
            this.tabLaporan.Controls.Add(this.tabPembelian);
            this.tabLaporan.Controls.Add(this.tabKeuntungan);
            this.tabLaporan.Location = new System.Drawing.Point(20, 264);
            this.tabLaporan.Name = "tabLaporan";
            this.tabLaporan.SelectedIndex = 0;
            this.tabLaporan.Size = new System.Drawing.Size(556, 319);
            this.tabLaporan.TabIndex = 6;
            // 
            // tabPenjualan
            // 
            this.tabPenjualan.Controls.Add(this.dgvPenjualan);
            this.tabPenjualan.Location = new System.Drawing.Point(4, 25);
            this.tabPenjualan.Name = "tabPenjualan";
            this.tabPenjualan.Size = new System.Drawing.Size(548, 290);
            this.tabPenjualan.TabIndex = 0;
            this.tabPenjualan.Text = "Laporan Penjualan";
            this.tabPenjualan.UseVisualStyleBackColor = true;
            // 
            // dgvPenjualan
            // 
            this.dgvPenjualan.AllowUserToAddRows = false;
            this.dgvPenjualan.AllowUserToDeleteRows = false;
            this.dgvPenjualan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPenjualan.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPenjualan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPenjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenjualan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPenjualan.Location = new System.Drawing.Point(0, 0);
            this.dgvPenjualan.Name = "dgvPenjualan";
            this.dgvPenjualan.ReadOnly = true;
            this.dgvPenjualan.RowHeadersWidth = 51;
            this.dgvPenjualan.RowTemplate.Height = 24;
            this.dgvPenjualan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPenjualan.Size = new System.Drawing.Size(548, 290);
            this.dgvPenjualan.TabIndex = 0;
            this.dgvPenjualan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPenjualan_CellContentClick);
            // 
            // tabPembelian
            // 
            this.tabPembelian.Controls.Add(this.dgvPembelian);
            this.tabPembelian.Location = new System.Drawing.Point(4, 25);
            this.tabPembelian.Name = "tabPembelian";
            this.tabPembelian.Size = new System.Drawing.Size(548, 290);
            this.tabPembelian.TabIndex = 1;
            this.tabPembelian.Text = "Laporan Pembelian";
            this.tabPembelian.UseVisualStyleBackColor = true;
            // 
            // dgvPembelian
            // 
            this.dgvPembelian.AllowUserToAddRows = false;
            this.dgvPembelian.AllowUserToDeleteRows = false;
            this.dgvPembelian.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPembelian.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPembelian.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPembelian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembelian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPembelian.Location = new System.Drawing.Point(0, 0);
            this.dgvPembelian.Name = "dgvPembelian";
            this.dgvPembelian.RowHeadersWidth = 51;
            this.dgvPembelian.RowTemplate.Height = 24;
            this.dgvPembelian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPembelian.Size = new System.Drawing.Size(548, 290);
            this.dgvPembelian.TabIndex = 0;
            this.dgvPembelian.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPembelian_CellContentClick);
            // 
            // tabKeuntungan
            // 
            this.tabKeuntungan.Controls.Add(this.dgvKeuntungan);
            this.tabKeuntungan.Location = new System.Drawing.Point(4, 25);
            this.tabKeuntungan.Name = "tabKeuntungan";
            this.tabKeuntungan.Size = new System.Drawing.Size(548, 290);
            this.tabKeuntungan.TabIndex = 2;
            this.tabKeuntungan.Text = "Laporan Keuntungan";
            this.tabKeuntungan.UseVisualStyleBackColor = true;
            // 
            // dgvKeuntungan
            // 
            this.dgvKeuntungan.AllowUserToAddRows = false;
            this.dgvKeuntungan.AllowUserToDeleteRows = false;
            this.dgvKeuntungan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKeuntungan.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvKeuntungan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKeuntungan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeuntungan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKeuntungan.Location = new System.Drawing.Point(0, 0);
            this.dgvKeuntungan.Name = "dgvKeuntungan";
            this.dgvKeuntungan.ReadOnly = true;
            this.dgvKeuntungan.RowHeadersWidth = 51;
            this.dgvKeuntungan.RowTemplate.Height = 24;
            this.dgvKeuntungan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKeuntungan.Size = new System.Drawing.Size(548, 290);
            this.dgvKeuntungan.TabIndex = 0;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot1.Location = new System.Drawing.Point(603, 292);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(357, 284);
            this.formsPlot1.TabIndex = 1;
            this.formsPlot1.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // UC_Laporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tabLaporan);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.cardKeuntungan);
            this.Controls.Add(this.cardPembelian);
            this.Controls.Add(this.cardPenjualan);
            this.Controls.Add(this.panelFilter);
            this.Name = "UC_Laporan";
            this.Size = new System.Drawing.Size(980, 660);
            this.Load += new System.EventHandler(this.UC_Laporan_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.cardKeuntungan.ResumeLayout(false);
            this.cardKeuntungan.PerformLayout();
            this.cardPembelian.ResumeLayout(false);
            this.cardPembelian.PerformLayout();
            this.cardPenjualan.ResumeLayout(false);
            this.cardPenjualan.PerformLayout();
            this.tabLaporan.ResumeLayout(false);
            this.tabPenjualan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenjualan)).EndInit();
            this.tabPembelian.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembelian)).EndInit();
            this.tabKeuntungan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeuntungan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpDari;
        private System.Windows.Forms.DateTimePicker dtpSampai;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblTotalPenjualan;
        private System.Windows.Forms.Label lblTotalPembelian;
        private System.Windows.Forms.Label lblKeuntungan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblKeuntunganTitle;
        private System.Windows.Forms.Panel cardKeuntungan;
        private System.Windows.Forms.Label lblPembelianTitle;
        private System.Windows.Forms.Panel cardPembelian;
        private System.Windows.Forms.Label lblPenjualanTitle;
        private System.Windows.Forms.Panel cardPenjualan;
        private System.Windows.Forms.TabControl tabLaporan;
        private System.Windows.Forms.TabPage tabPenjualan;
        private System.Windows.Forms.TabPage tabPembelian;
        private System.Windows.Forms.TabPage tabKeuntungan;
        private System.Windows.Forms.DataGridView dgvPenjualan;
        private System.Windows.Forms.DataGridView dgvPembelian;
        private System.Windows.Forms.DataGridView dgvKeuntungan;
        private System.Windows.Forms.Label lblMargin;
        private ScottPlot.FormsPlot formsPlot1;
    }
}
