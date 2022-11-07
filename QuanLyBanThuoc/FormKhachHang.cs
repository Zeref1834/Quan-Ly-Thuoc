using QuanLyBanThuoc.ADO;
using QuanLyBanThuoc.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace QuanLyBanThuoc
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();


        private void BindGrid(List<KHACHHANG> listkhachhang)
        {
            dgvKhachHang.Rows.Clear();
            foreach (var item in listkhachhang)
            {
                int index = dgvKhachHang.Rows.Add();
                dgvKhachHang.Rows[index].Cells[0].Value = item.MAKH;
                dgvKhachHang.Rows[index].Cells[1].Value = item.HOTENKH;
                dgvKhachHang.Rows[index].Cells[2].Value = item.DIACHIKH;
                dgvKhachHang.Rows[index].Cells[3].Value = item.DIENTHOAI;
                if (item.LOAIKH != null)
                    dgvKhachHang.Rows[index].Cells[4].Value = item.LOAIKH.MALOAIKH;


            }
        }
        private void FillMaLoaiKHCombobox(List<LOAIKH> listloaikh)
        {
            this.cmbLoaiKH.DataSource = listloaikh;
            this.cmbLoaiKH.DisplayMember = "TENLOAIKH";
            this.cmbLoaiKH.ValueMember = "MALOAIKH";
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvKhachHang);
                ModelQLThuoc context = new ModelQLThuoc();
                List<LOAIKH> listloaikh = context.LOAIKHs.ToList();
                List<KHACHHANG> listkhachhang = context.KHACHHANGs.ToList();
                FillMaLoaiKHCombobox(listloaikh);
                BindGrid(listkhachhang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            //dgview.MultiSelect = false;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgview.ReadOnly = true;
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            List<LOAIKH> lst = context.LOAIKHs.ToList();
            DataGridViewRow row = new DataGridViewRow();
            txtMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiachi.Text = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsdt.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
            foreach (var item in lst)
            {
                if (dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString() == item.MALOAIKH)
                {
                    cmbLoaiKH.Text = item.TENLOAIKH;
                }
            }
        }
        private void reset()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            txtsdt.Text = "";
            cmbLoaiKH.SelectedIndex = 0;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            try
            {
                List<LOAIKH> lst = context.LOAIKHs.ToList();
                KHACHHANG s = new KHACHHANG();
                if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiachi.Text == "" ||txtsdt.Text == "" || cmbLoaiKH.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                KHACHHANG dbUpdate = context.KHACHHANGs.FirstOrDefault(p => p.MAKH == txtMaKH.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Mã Khách Hàng trùng. Chọn Yes để Update", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {

                        dbUpdate.HOTENKH = txtTenKH.Text;
                        dbUpdate.DIACHIKH = txtDiachi.Text;
                        dbUpdate.DIENTHOAI = txtsdt.Text;
                        foreach (var item in lst)
                            if (item.TENLOAIKH == cmbLoaiKH.Text)
                            {
                                dbUpdate.MALOAIKH = item.MALOAIKH;
                            }
                        context.SaveChanges();
                        FormKhachHang_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();

                    }
                }
                else
                {  
                    foreach (var tem in lst)
                        if (tem.TENLOAIKH == cmbLoaiKH.Text)
                        {
                            s = new KHACHHANG() { MAKH = txtMaKH.Text, HOTENKH = txtTenKH.Text, DIACHIKH = txtDiachi.Text, DIENTHOAI = txtsdt.Text, MALOAIKH = tem.MALOAIKH };
                            
                        }
                    context.KHACHHANGs.Add(s);
                    context.SaveChanges();
                    FormKhachHang_Load(sender, e);
                    MessageBox.Show("Thêm Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtMaKH.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                KHACHHANG dbDelete = context.KHACHHANGs.FirstOrDefault(p => p.MAKH == txtMaKH.Text);
                if (dbDelete != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
                        List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
                        foreach (var item in listXK)
                            if (item.MAKH == txtMaKH.Text)
                            {
                                context.PHIEUXUATKHOes.Remove(item);
                            }
                        foreach (var itam in listDH)
                            if (itam.MAKH == txtMaKH.Text)
                            {
                                context.PHIEUDATHANGs.Remove(itam);
                            }
                        context.KHACHHANGs.Remove(dbDelete);
                       
                        context.SaveChanges();
                        FormKhachHang_Load(sender, e);
                        MessageBox.Show("Xóa Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            List<KHACHHANG> listkhachhang = context.KHACHHANGs.ToList();
            btnXoachu.Visible = true;
            if (txtKey.Text != null)
            {
                dgvKhachHang.Rows.Clear();
                foreach (var item in listkhachhang)
                {
                    if (item.MAKH.Contains(txtKey.Text) || item.HOTENKH.Contains(txtKey.Text))
                    {
                        int index = dgvKhachHang.Rows.Add();
                        dgvKhachHang.Rows[index].Cells[0].Value = item.MAKH;
                        dgvKhachHang.Rows[index].Cells[1].Value = item.HOTENKH;
                        dgvKhachHang.Rows[index].Cells[2].Value = item.DIACHIKH;
                        dgvKhachHang.Rows[index].Cells[3].Value = item.DIENTHOAI;
                        if (item.LOAIKH != null)
                            dgvKhachHang.Rows[index].Cells[4].Value = item.LOAIKH.MALOAIKH;
                    }
                }
            }
            if (txtKey.Text == "" || txtKey.Text == " Tìm Kiếm")
            {
                FormKhachHang_Load(sender, e);
                btnXoachu.Visible = false;
            }

        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvKhachHang, @"D:\", "Danh Sách Khách Hàng");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtTuKhoa_Click(object sender, EventArgs e)
        {
            if (txtKey.Text == "Tìm Kiếm")
            {
                txtKey.Text = "";
            }
            else
            {
                txtKey.Text = "Tìm Kiếm";
                FormKhachHang_Load(sender, e);
                btnXoachu.Visible = false;
            }
        }

        private void btnXoaChu_Click(object sender, EventArgs e)
        {
            txtKey.Text = "Tìm Kiếm";
            FormKhachHang_Load(sender, e);
            btnXoachu.Visible = false;
        }

        private void FormKhachHang_Click(object sender, EventArgs e)
        {
            
        }

  
        //// Chặn các kí tự

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void cmbLoaiKH_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormLoaiKH dmk = new QuanLyBanThuoc.FormLoaiKH();
            dmk.ShowDialog();
        }
    }
}
