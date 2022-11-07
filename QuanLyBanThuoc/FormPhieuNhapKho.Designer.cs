namespace QuanLyBanThuoc
{
    partial class FormPhieuNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhieuNhapKho));
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuNK = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtFind = new System.Windows.Forms.ToolStripTextBox();
            this.btnXoachu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DateTimePickerNgayNhapKho = new System.Windows.Forms.DateTimePicker();
            this.cmbMaKho = new System.Windows.Forms.ComboBox();
            this.cmbMaThuoc = new System.Windows.Forms.ComboBox();
            this.Mathuoc = new System.Windows.Forms.Label();
            this.cmbMaNV = new System.Windows.Forms.ComboBox();
            this.TxtMaPhieuNK = new System.Windows.Forms.TextBox();
            this.lblMaKho = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblNgayNhapKho = new System.Windows.Forms.Label();
            this.lblMaPhieuNK = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNK)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Ngày Nhập Kho";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvPhieuNK);
            this.groupBox6.Controls.Add(this.toolStrip1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(0, 134);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(800, 254);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Danh Sách phiếu nhập kho";
            // 
            // dgvPhieuNK
            // 
            this.dgvPhieuNK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column1});
            this.dgvPhieuNK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuNK.Location = new System.Drawing.Point(3, 57);
            this.dgvPhieuNK.Name = "dgvPhieuNK";
            this.dgvPhieuNK.ReadOnly = true;
            this.dgvPhieuNK.Size = new System.Drawing.Size(794, 194);
            this.dgvPhieuNK.TabIndex = 11;
            this.dgvPhieuNK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNK_CellClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã Phiếu";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Ngày Nhập Kho";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mã Nhân Viên";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Mã Kho";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Thuốc";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator6,
            this.btnXoa,
            this.toolStripSeparator7,
            this.btnExcel,
            this.toolStripSeparator8,
            this.btnExit,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txtFind,
            this.btnXoachu,
            this.toolStripSeparator9,
            this.toolStripSeparator10});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 39);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::QuanLyBanThuoc.Properties.Resources.SoftMgr_logo16_20002;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 36);
            this.btnAdd.Text = "Thêm / Cập nhật";
            this.btnAdd.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QuanLyBanThuoc.Properties.Resources.delete;
            this.btnXoa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(71, 36);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::QuanLyBanThuoc.Properties.Resources.print_pref;
            this.btnExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(140, 36);
            this.btnExcel.Text = "Xuất File Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 39);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::QuanLyBanThuoc.Properties.Resources.logout;
            this.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 36);
            this.btnExit.Text = "Thoát";
            this.btnExit.ToolTipText = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel2.Image = global::QuanLyBanThuoc.Properties.Resources.desktopsearch_shortcut;
            this.toolStripLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(32, 36);
            this.toolStripLabel2.Text = "toolStripLabel1";
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(150, 39);
            this.txtFind.Text = "Tìm Kiếm";
            this.txtFind.Click += new System.EventHandler(this.txtFind_Click);
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // btnXoachu
            // 
            this.btnXoachu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnXoachu.Image = global::QuanLyBanThuoc.Properties.Resources.Untitled__231_2;
            this.btnXoachu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoachu.Name = "btnXoachu";
            this.btnXoachu.Size = new System.Drawing.Size(23, 36);
            this.btnXoachu.Text = "toolStripButton4";
            this.btnXoachu.Visible = false;
            this.btnXoachu.Click += new System.EventHandler(this.btnXoachu_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DateTimePickerNgayNhapKho);
            this.groupBox2.Controls.Add(this.cmbMaKho);
            this.groupBox2.Controls.Add(this.cmbMaThuoc);
            this.groupBox2.Controls.Add(this.Mathuoc);
            this.groupBox2.Controls.Add(this.cmbMaNV);
            this.groupBox2.Controls.Add(this.TxtMaPhieuNK);
            this.groupBox2.Controls.Add(this.lblMaKho);
            this.groupBox2.Controls.Add(this.lblMaNV);
            this.groupBox2.Controls.Add(this.lblNgayNhapKho);
            this.groupBox2.Controls.Add(this.lblMaPhieuNK);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 134);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "THÔNG TIN PHIẾU NHẬP KHO";
            // 
            // DateTimePickerNgayNhapKho
            // 
            this.DateTimePickerNgayNhapKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePickerNgayNhapKho.Location = new System.Drawing.Point(141, 70);
            this.DateTimePickerNgayNhapKho.Name = "DateTimePickerNgayNhapKho";
            this.DateTimePickerNgayNhapKho.Size = new System.Drawing.Size(268, 22);
            this.DateTimePickerNgayNhapKho.TabIndex = 18;
            // 
            // cmbMaKho
            // 
            this.cmbMaKho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaKho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaKho.FormattingEnabled = true;
            this.cmbMaKho.Location = new System.Drawing.Point(538, 58);
            this.cmbMaKho.Name = "cmbMaKho";
            this.cmbMaKho.Size = new System.Drawing.Size(221, 24);
            this.cmbMaKho.TabIndex = 7;
            this.cmbMaKho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMaKho_KeyPress);
            // 
            // cmbMaThuoc
            // 
            this.cmbMaThuoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaThuoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaThuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaThuoc.FormattingEnabled = true;
            this.cmbMaThuoc.Location = new System.Drawing.Point(538, 88);
            this.cmbMaThuoc.Name = "cmbMaThuoc";
            this.cmbMaThuoc.Size = new System.Drawing.Size(221, 24);
            this.cmbMaThuoc.TabIndex = 3;
            // 
            // Mathuoc
            // 
            this.Mathuoc.AutoSize = true;
            this.Mathuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mathuoc.ForeColor = System.Drawing.Color.Black;
            this.Mathuoc.Location = new System.Drawing.Point(429, 91);
            this.Mathuoc.Name = "Mathuoc";
            this.Mathuoc.Size = new System.Drawing.Size(74, 16);
            this.Mathuoc.TabIndex = 1;
            this.Mathuoc.Text = "Mã thuốc:";
            // 
            // cmbMaNV
            // 
            this.cmbMaNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaNV.FormattingEnabled = true;
            this.cmbMaNV.Location = new System.Drawing.Point(538, 28);
            this.cmbMaNV.Name = "cmbMaNV";
            this.cmbMaNV.Size = new System.Drawing.Size(221, 24);
            this.cmbMaNV.TabIndex = 6;
            // 
            // TxtMaPhieuNK
            // 
            this.TxtMaPhieuNK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaPhieuNK.Location = new System.Drawing.Point(141, 42);
            this.TxtMaPhieuNK.MaxLength = 6;
            this.TxtMaPhieuNK.Name = "TxtMaPhieuNK";
            this.TxtMaPhieuNK.Size = new System.Drawing.Size(268, 22);
            this.TxtMaPhieuNK.TabIndex = 4;
            this.TxtMaPhieuNK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMaPhieuNK_KeyPress);
            // 
            // lblMaKho
            // 
            this.lblMaKho.AutoSize = true;
            this.lblMaKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKho.ForeColor = System.Drawing.Color.Black;
            this.lblMaKho.Location = new System.Drawing.Point(429, 61);
            this.lblMaKho.Name = "lblMaKho";
            this.lblMaKho.Size = new System.Drawing.Size(62, 16);
            this.lblMaKho.TabIndex = 3;
            this.lblMaKho.Text = "Mã kho:";
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.ForeColor = System.Drawing.Color.Black;
            this.lblMaNV.Location = new System.Drawing.Point(429, 33);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(103, 16);
            this.lblMaNV.TabIndex = 2;
            this.lblMaNV.Text = "Mã nhân viên:";
            // 
            // lblNgayNhapKho
            // 
            this.lblNgayNhapKho.AutoSize = true;
            this.lblNgayNhapKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhapKho.ForeColor = System.Drawing.Color.Black;
            this.lblNgayNhapKho.Location = new System.Drawing.Point(19, 75);
            this.lblNgayNhapKho.Name = "lblNgayNhapKho";
            this.lblNgayNhapKho.Size = new System.Drawing.Size(116, 16);
            this.lblNgayNhapKho.TabIndex = 1;
            this.lblNgayNhapKho.Text = "Ngày nhập kho:";
            // 
            // lblMaPhieuNK
            // 
            this.lblMaPhieuNK.AutoSize = true;
            this.lblMaPhieuNK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuNK.ForeColor = System.Drawing.Color.Black;
            this.lblMaPhieuNK.Location = new System.Drawing.Point(19, 45);
            this.lblMaPhieuNK.Name = "lblMaPhieuNK";
            this.lblMaPhieuNK.Size = new System.Drawing.Size(75, 16);
            this.lblMaPhieuNK.TabIndex = 0;
            this.lblMaPhieuNK.Text = "Mã phiếu:";
            // 
            // FormPhieuNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 388);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPhieuNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phiếu Nhập Kho";
            this.Load += new System.EventHandler(this.FormPhieuNhapKho_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNK)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
       
        //private System.Windows.Forms.DataGridViewTextBoxColumn mAPHIEUNKDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn nGAYNKDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn mANVDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn mAKHODataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker DateTimePickerNgayNhapKho;
        private System.Windows.Forms.ComboBox cmbMaKho;
        private System.Windows.Forms.ComboBox cmbMaThuoc;
        private System.Windows.Forms.Label Mathuoc;
        private System.Windows.Forms.ComboBox cmbMaNV;
        private System.Windows.Forms.TextBox TxtMaPhieuNK;
        private System.Windows.Forms.Label lblMaKho;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblNgayNhapKho;
        private System.Windows.Forms.Label lblMaPhieuNK;
        private System.Windows.Forms.DataGridView dgvPhieuNK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripButton btnXoachu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}