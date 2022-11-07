using QuanLyBanThuoc.ADO;
using QuanLyBanThuoc.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace QuanLyBanThuoc
{
    public partial class Xuất_Kho : Form
    {
        public Xuất_Kho()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void Form1_Load(object sender, EventArgs e)
        {
            SetGridViewStyle(dgvXuatKho);
            ModelQLThuoc context = new ModelQLThuoc();
            List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
            List<NHANVIEN> listNV = context.NHANVIENs.ToList();
            List<KHO> listK = context.KHOes.ToList();
            List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
            FillMaDonDatHangComboBox(listDH);
            FillMaNhanVienComboBox(listNV);
            BindGrid(listXK);
        }
        public void SetGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.DefaultCellStyle.SelectionForeColor = Color.Red;
            dgview.BackgroundColor = Color.White;
            dgview.EnableHeadersVisualStyles = false;
            dgview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgview.AllowUserToDeleteRows = false;
            dgview.AllowUserToAddRows = false;
            dgview.AllowUserToOrderColumns = true;
        
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void reset()
        {
            txtIDXK.Text = "";
            dateX.Text = default;
            cmbDH.SelectedIndex = 0;
            cmbNV.SelectedIndex = 0;
        }
        private void FillMaDonDatHangComboBox(List<PHIEUDATHANG> listDH)
        {
            this.cmbDH.DataSource = listDH;
            this.cmbDH.DisplayMember = "MAPHIEUDH";
            this.cmbDH.ValueMember = "MAPHIEUDH";
        }

        private void FillMaNhanVienComboBox(List<NHANVIEN> listNV)
        {
            this.cmbNV.DataSource = listNV;
            this.cmbNV.DisplayMember = "HOTENNV";
            this.cmbNV.ValueMember = "MANV";
        }
        private void BindGrid(List<PHIEUXUATKHO> listXK)
        {
            dgvXuatKho.Rows.Clear();
            foreach (var item in listXK)
            {
                int index = dgvXuatKho.Rows.Add();
                dgvXuatKho.Rows[index].Cells[0].Value = item.MAPHIEUXK;
                if (item.KHO != null)
                    dgvXuatKho.Rows[index].Cells[5].Value = item.KHO.MAKHO;
                if (item.NHANVIEN != null)
                    dgvXuatKho.Rows[index].Cells[7].Value = item.NHANVIEN.MANV;
                dgvXuatKho.Rows[index].Cells[6].Value = item.NGAYXUAT;
                if (item.PHIEUDATHANG != null)
                {
                    dgvXuatKho.Rows[index].Cells[1].Value = item.MAPHIEUDH;
                    dgvXuatKho.Rows[index].Cells[2].Value = item.PHIEUDATHANG.MAKH;
                    dgvXuatKho.Rows[index].Cells[3].Value = item.PHIEUDATHANG.MATHUOC;
                    dgvXuatKho.Rows[index].Cells[4].Value = item.PHIEUDATHANG.SOLUONG;
                    dgvXuatKho.Rows[index].Cells[6].Value = item.PHIEUDATHANG.NGAYGIAO;
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            
            try
            {
                List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
                List<PHIEUNHAPKHO> listNK = context.PHIEUNHAPKHOes.ToList();
                List<NHANVIEN> listNV = context.NHANVIENs.ToList();
                PHIEUXUATKHO s = new PHIEUXUATKHO();
                if (txtIDXK.Text == ""||cmbDH.Text == "" || cmbNV.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                PHIEUXUATKHO dbUpdateXK = context.PHIEUXUATKHOes.FirstOrDefault(p => p.MAPHIEUXK == txtIDXK.Text);
                if (dbUpdateXK != null)
                {
                    DialogResult dr = MessageBox.Show("Mã đơn hàng trùng. Chọn Yes để Cập Nhật", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (var item in listDH)
                            if (item.MAPHIEUDH == cmbDH.Text)
                            {
                                dbUpdateXK.MAKH = item.MAKH;
                                dbUpdateXK.MATHUOC = item.MATHUOC;
                                dbUpdateXK.SOLUONG = item.SOLUONG;
                                dbUpdateXK.NGAYXUAT = item.NGAYGIAO;
                                foreach (var itam in listNK)
                                    if (itam.MATHUOC == item.MATHUOC)
                                    {
                                        dbUpdateXK.MAKHO = itam.MAKHO;
                                    }
                            }
                        foreach (var item in listNV)
                            if (item.HOTENNV == cmbNV.Text)
                            {
                                dbUpdateXK.MANV = item.MANV;
                            }
                        context.SaveChanges();
                        Form1_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
                else
                {
                    foreach (var item in listDH)
                        if (item.MAPHIEUDH == cmbDH.Text)
                        {
                            foreach (var itam in listNV)
                                if (itam.HOTENNV == cmbNV.Text)
                                {
                                    foreach (var tem in listNK)
                                        if (tem.MATHUOC == item.MATHUOC)
                                        {
                                            s = new PHIEUXUATKHO() { MAPHIEUXK = txtIDXK.Text, MAPHIEUDH = item.MAPHIEUDH, MAKH = item.MAKH, MATHUOC = item.MATHUOC, SOLUONG = item.SOLUONG, MAKHO = tem.MAKHO, NGAYXUAT = item.NGAYGIAO, MANV = itam.MANV };
                                        }
                                }                 
                        }
                            
                    context.PHIEUXUATKHOes.Add(s);
                    context.SaveChanges();
                    Form1_Load(sender, e);
                    MessageBox.Show("Thêm Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                PHIEUXUATKHO dbDelete = context.PHIEUXUATKHOes.FirstOrDefault(p => p.MAPHIEUXK == txtIDXK.Text);
                if (dbDelete != null)
                {
                    DialogResult dr = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Dòng Này!", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        context.PHIEUXUATKHOes.Remove(dbDelete);
                        context.SaveChanges();
                        Form1_Load(sender, e);
                        MessageBox.Show("Xóa Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void dgvXuatKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            List<NHANVIEN> lst = context.NHANVIENs.ToList();
            List<PHIEUDATHANG> lst1 = context.PHIEUDATHANGs.ToList();
            DataGridViewRow row = new DataGridViewRow();
            txtIDXK.Text = dgvXuatKho.Rows[e.RowIndex].Cells[0].Value.ToString();
            dateX.Text = dgvXuatKho.Rows[e.RowIndex].Cells[6].Value.ToString();
            foreach (var item in lst)
            {
                if (dgvXuatKho.Rows[e.RowIndex].Cells[7].Value.ToString() == item.MANV)
                {
                    cmbNV.Text = item.HOTENNV;
                }
            }
            cmbDH.Text = dgvXuatKho.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvXuatKho, @"D:\", "Danh Sách Phiếu Xuất Kho");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            List<PHIEUXUATKHO> listT = context.PHIEUXUATKHOes.ToList();
            btnXoachu.Visible = true;
            if (txtFind.Text != null)
            {
                dgvXuatKho.Rows.Clear();
                foreach (var item in listT)
                {
                    if (item.MAPHIEUXK.Contains(txtFind.Text) || item.MAPHIEUDH.Contains(txtFind.Text))
                    {
                        int index = dgvXuatKho.Rows.Add();
                        dgvXuatKho.Rows[index].Cells[0].Value = item.MAPHIEUXK;
                        if (item.PHIEUDATHANG != null)
                        {
                            dgvXuatKho.Rows[index].Cells[1].Value = item.PHIEUDATHANG.MAPHIEUDH;
                            dgvXuatKho.Rows[index].Cells[2].Value = item.PHIEUDATHANG.MAKH;
                            dgvXuatKho.Rows[index].Cells[3].Value = item.PHIEUDATHANG.MATHUOC;
                            dgvXuatKho.Rows[index].Cells[4].Value = item.PHIEUDATHANG.SOLUONG;
                        }
                        if (item.KHO != null)
                            dgvXuatKho.Rows[index].Cells[5].Value = item.KHO.MAKHO;
                        dgvXuatKho.Rows[index].Cells[6].Value = item.NGAYXUAT;
                        if (item.NHANVIEN != null)
                            dgvXuatKho.Rows[index].Cells[7].Value = item.NHANVIEN.MANV;
                    }


                }
            }
            if (txtFind.Text == "" || txtFind.Text == " Tìm Kiếm")
            {
                Form1_Load(sender, e);
            }
        }
        private void TxtChuSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        private void TxtSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "Tìm Kiếm")
            {
                txtFind.Text = "";
            }
            else
            {
                txtFind.Text = "Tìm Kiếm";
                Form1_Load(sender, e);
                btnXoachu.Visible = false;
            }
        }

        private void btnXoachu_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            Form1_Load(sender, e);
            btnXoachu.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
