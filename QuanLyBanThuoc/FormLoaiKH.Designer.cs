namespace QuanLyBanThuoc
{
    partial class FormLoaiKH
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTenLKH = new System.Windows.Forms.TextBox();
            this.txtMaLKH = new System.Windows.Forms.TextBox();
            this.lblTenkho = new System.Windows.Forms.Label();
            this.lblMakho = new System.Windows.Forms.Label();
            this.TBoxTenKho = new System.Windows.Forms.TextBox();
            this.TBoxMaKho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvLoaiKH = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.txtFind = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnXoachu = new System.Windows.Forms.ToolStripButton();
            this.MaLoaiKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiKH)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTenLKH);
            this.groupBox2.Controls.Add(this.txtMaLKH);
            this.groupBox2.Controls.Add(this.lblTenkho);
            this.groupBox2.Controls.Add(this.lblMakho);
            this.groupBox2.Controls.Add(this.TBoxTenKho);
            this.groupBox2.Controls.Add(this.TBoxMaKho);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 123);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "THÔNG TIN LOẠI KH";
            // 
            // txtTenLKH
            // 
            this.txtTenLKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLKH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTenLKH.Location = new System.Drawing.Point(172, 54);
            this.txtTenLKH.Name = "txtTenLKH";
            this.txtTenLKH.Size = new System.Drawing.Size(405, 22);
            this.txtTenLKH.TabIndex = 1;
            // 
            // txtMaLKH
            // 
            this.txtMaLKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLKH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMaLKH.Location = new System.Drawing.Point(172, 28);
            this.txtMaLKH.MaxLength = 6;
            this.txtMaLKH.Name = "txtMaLKH";
            this.txtMaLKH.Size = new System.Drawing.Size(405, 22);
            this.txtMaLKH.TabIndex = 0;
            this.txtMaLKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaLKH_KeyPress);
            // 
            // lblTenkho
            // 
            this.lblTenkho.AutoSize = true;
            this.lblTenkho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenkho.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTenkho.Location = new System.Drawing.Point(30, 57);
            this.lblTenkho.Name = "lblTenkho";
            this.lblTenkho.Size = new System.Drawing.Size(101, 16);
            this.lblTenkho.TabIndex = 23;
            this.lblTenkho.Text = "Tên Loại KH :";
            // 
            // lblMakho
            // 
            this.lblMakho.AutoSize = true;
            this.lblMakho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMakho.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMakho.Location = new System.Drawing.Point(30, 31);
            this.lblMakho.Name = "lblMakho";
            this.lblMakho.Size = new System.Drawing.Size(95, 16);
            this.lblMakho.TabIndex = 22;
            this.lblMakho.Text = "Mã Loại KH :";
            // 
            // TBoxTenKho
            // 
            this.TBoxTenKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBoxTenKho.Location = new System.Drawing.Point(174, -102);
            this.TBoxTenKho.Name = "TBoxTenKho";
            this.TBoxTenKho.Size = new System.Drawing.Size(388, 20);
            this.TBoxTenKho.TabIndex = 21;
            // 
            // TBoxMaKho
            // 
            this.TBoxMaKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBoxMaKho.Location = new System.Drawing.Point(174, -128);
            this.TBoxMaKho.Name = "TBoxMaKho";
            this.TBoxMaKho.Size = new System.Drawing.Size(197, 20);
            this.TBoxMaKho.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, -72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Địa điểm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, -98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tên kho:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, -124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mã kho:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvLoaiKH);
            this.groupBox3.Controls.Add(this.toolStrip1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 302);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Loại KH";
            // 
            // dgvLoaiKH
            // 
            this.dgvLoaiKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiKH,
            this.TenLoaiKH});
            this.dgvLoaiKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoaiKH.Location = new System.Drawing.Point(3, 57);
            this.dgvLoaiKH.Name = "dgvLoaiKH";
            this.dgvLoaiKH.ReadOnly = true;
            this.dgvLoaiKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiKH.Size = new System.Drawing.Size(769, 242);
            this.dgvLoaiKH.TabIndex = 11;
            this.dgvLoaiKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiKH_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator1,
            this.btnXoa,
            this.toolStripSeparator2,
            this.btnExcel,
            this.toolStripSeparator3,
            this.btnExit,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.txtFind,
            this.btnXoachu,
            this.toolStripSeparator4,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(769, 39);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::QuanLyBanThuoc.Properties.Resources.desktopsearch_shortcut;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 36);
            this.toolStripLabel1.Text = "toolStripLabel1";
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
            // MaLoaiKH
            // 
            this.MaLoaiKH.HeaderText = "Mã Loại KH";
            this.MaLoaiKH.Name = "MaLoaiKH";
            this.MaLoaiKH.ReadOnly = true;
            // 
            // TenLoaiKH
            // 
            this.TenLoaiKH.HeaderText = "Tên Loại KH";
            this.TenLoaiKH.Name = "TenLoaiKH";
            this.TenLoaiKH.ReadOnly = true;
            // 
            // FormLoaiKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormLoaiKH";
            this.Text = "FormLoaiKH";
            this.Load += new System.EventHandler(this.FormLoaiKH_Load);
            this.Click += new System.EventHandler(this.FormLoaiKH_Click);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiKH)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTenLKH;
        private System.Windows.Forms.TextBox txtMaLKH;
        private System.Windows.Forms.Label lblTenkho;
        private System.Windows.Forms.Label lblMakho;
        private System.Windows.Forms.TextBox TBoxTenKho;
        private System.Windows.Forms.TextBox TBoxMaKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvLoaiKH;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripButton btnXoachu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiKH;
    }
}