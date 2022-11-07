
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanThuoc.Excel;
using QuanLyBanThuoc.ADO;
using Microsoft.Office.Interop.Excel;

namespace QuanLyBanThuoc
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        System.Data.DataTable dt = new System.Data.DataTable("NHANVIEN");
   
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvNhanvien);
                ModelQLThuoc context = new ModelQLThuoc();
                List<NHANVIEN> listnhanvien = context.NHANVIENs.ToList();
                BindGrid(listnhanvien);
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
        }

        private void BindGrid(List<NHANVIEN> listNhanvien)
        {
            dgvNhanvien.Rows.Clear();
            foreach (var item in listNhanvien)
            {
                int index = dgvNhanvien.Rows.Add();
                dgvNhanvien.Rows[index].Cells[0].Value = item.MANV;
                dgvNhanvien.Rows[index].Cells[1].Value = item.HOTENNV;
                dgvNhanvien.Rows[index].Cells[2].Value = item.GIOITINH;
                dgvNhanvien.Rows[index].Cells[3].Value = item.NGAYSINH;
                dgvNhanvien.Rows[index].Cells[4].Value = item.DIACHI;
                dgvNhanvien.Rows[index].Cells[5].Value = item.DIENTHOAI;
                dgvNhanvien.Rows[index].Cells[6].Value = item.LUONG;
                dgvNhanvien.Rows[index].Cells[7].Value = item.TENLOAINV;
                dgvNhanvien.Rows[index].Cells[8].Value = item.TENDN;   
                dgvNhanvien.Rows[index].Cells[9].Value = item.MATKHAU;
                dgvNhanvien.Rows[index].Cells[10].Value = item.HINHANH;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            txtMaNV.Text = dgvNhanvien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanvien.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (dgvNhanvien.Rows[e.RowIndex].Cells[2].Value.ToString() == "Nam")
            {
                optNam.Checked = true;
            }
            else if (dgvNhanvien.Rows[e.RowIndex].Cells[2].Value.ToString() == "Nữ")
            {
                optNu.Checked = true;
            }
            dtNgaysinh.Text = dgvNhanvien.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiachi.Text = dgvNhanvien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsdt.Text = dgvNhanvien.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtluong.Text = dgvNhanvien.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtLoaiNv.Text = dgvNhanvien.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTenDN.Text = dgvNhanvien.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtMK.Text = dgvNhanvien.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox1.Text = dgvNhanvien.Rows[e.RowIndex].Cells[10].Value.ToString();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            List<NHANVIEN> lst = context.NHANVIENs.ToList();
            NHANVIEN s = new NHANVIEN();
            try
            {
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtDiachi.Text == "" || txtsdt.Text == "" || txtluong.Text == "" || txtLoaiNv.Text == "" || txtTenDN.Text == "" || txtMK.Text == "" )
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                NHANVIEN dbUpdate = context.NHANVIENs.FirstOrDefault(p => p.MANV == txtMaNV.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Mã nhân viên bị trùng. Chọn Yes để Cập Nhật", "Thông Báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dbUpdate.HOTENNV = txtTenNV.Text;
                        dbUpdate.GIOITINH = optNam.Checked ? "Nam" : "Nữ";
                        dbUpdate.NGAYSINH = DateTime.Parse(dtNgaysinh.Text);
                        dbUpdate.DIACHI = txtDiachi.Text;
                        dbUpdate.DIENTHOAI = txtsdt.Text;
                        dbUpdate.LUONG = txtluong.Text;
                        dbUpdate.TENLOAINV = txtLoaiNv.Text;
                        dbUpdate.TENDN = txtTenDN.Text;
                        dbUpdate.MATKHAU = txtMK.Text;
                        dbUpdate.HINHANH = textBox1.Text;
                        context.SaveChanges();
                        FormNhanVien_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }

                }
                else
                {
                    s = new NHANVIEN() { MANV = txtMaNV.Text, HOTENNV = txtTenNV.Text, GIOITINH = optNam.Checked ? "Nam" : "Nữ", NGAYSINH = DateTime.Parse(dtNgaysinh.Text),DIACHI = txtDiachi.Text, DIENTHOAI = txtsdt.Text, LUONG = txtluong.Text, TENLOAINV = txtLoaiNv.Text, TENDN = txtTenDN.Text, MATKHAU = txtMK.Text,HINHANH = textBox1.Text };
                    context.NHANVIENs.Add(s);
                    context.SaveChanges();
                    FormNhanVien_Load(sender, e);
                    MessageBox.Show("Thêm Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void reset()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            optNam.Checked = false;
            optNu.Checked = false;
            dtNgaysinh.Text = default;
            txtDiachi.Text = "";
            txtsdt.Text = "";
            txtluong.Text = "";
            txtLoaiNv.Text = "";
            txtTenDN.Text = "";
            txtMK.Text = "";
            textBox1.Text = "";
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text == "" )
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                NHANVIEN dbDelete = context.NHANVIENs.FirstOrDefault(p => p.MANV == txtMaNV.Text);
                if (dbDelete != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
                        List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
                        List<PHIEUNHAPKHO> listNK = context.PHIEUNHAPKHOes.ToList();
                        List<PHIEUTHANHLI> listTL = context.PHIEUTHANHLIs.ToList();
                        foreach (var item in listXK)
                            if (item.MANV == txtMaNV.Text)
                            {
                                context.PHIEUXUATKHOes.Remove(item);
                            }
                        foreach (var itam in listDH)
                            if (itam.MANV == txtMaNV.Text)
                            {
                                context.PHIEUDATHANGs.Remove(itam);
                            }
                        foreach (var tam in listNK)
                            if (tam.MANV == txtMaNV.Text)
                            {
                                context.PHIEUNHAPKHOes.Remove(tam);
                            }
                        foreach (var tl in listTL)
                            if (tl.MANV == txtMaNV.Text)
                            {
                                context.PHIEUTHANHLIs.Remove(tl);
                            }
                        context.NHANVIENs.Remove(dbDelete);
                        context.SaveChanges();
                        FormNhanVien_Load(sender, e);
                        MessageBox.Show("Thêm Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                btnXoaChu.Visible = true;
                if (txtKey.Text != null)
                {
                    List<NHANVIEN> listNhanvien = context.NHANVIENs.ToList();
                    dgvNhanvien.Rows.Clear();
                    foreach (var item in listNhanvien)
                    {
                        if (item.MANV.Contains(txtKey.Text)||item.GIOITINH.Contains(txtKey.Text)||item.HOTENNV.Contains(txtKey.Text)||item.TENDN.Contains(txtKey.Text))
                        {
                            int index = dgvNhanvien.Rows.Add();
                            dgvNhanvien.Rows[index].Cells[0].Value = item.MANV;
                            dgvNhanvien.Rows[index].Cells[1].Value = item.HOTENNV;
                            dgvNhanvien.Rows[index].Cells[2].Value = item.GIOITINH;
                            dgvNhanvien.Rows[index].Cells[3].Value = item.NGAYSINH;
                            dgvNhanvien.Rows[index].Cells[4].Value = item.DIACHI;
                            dgvNhanvien.Rows[index].Cells[5].Value = item.DIENTHOAI;
                            dgvNhanvien.Rows[index].Cells[6].Value = item.LUONG;
                            dgvNhanvien.Rows[index].Cells[7].Value = item.TENLOAINV;
                            dgvNhanvien.Rows[index].Cells[8].Value = item.TENDN;
                            dgvNhanvien.Rows[index].Cells[9].Value = item.MATKHAU;
                            dgvNhanvien.Rows[index].Cells[10].Value = item.HINHANH;
                        }

                    }

                }
                if(txtKey.Text == "" || txtKey.Text == " Tìm Kiếm")
                {
                    FormNhanVien_Load(sender, e);
                    btnXoaChu.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        } 
        private void btnIn_Click(object sender, EventArgs e)
        {
            
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvNhanvien, @"D:\", "Danh Sách Nhân Viên");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btndiachianh_Click(object sender, EventArgs e)
        {
           
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = openFileDialog1.Filter = " JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    textBox1.Text = openFileDialog1.FileName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
        private void txtKey_Click(object sender, EventArgs e)
        {
            if(txtKey.Text == "Tìm Kiếm")
            {
                txtKey.Text= "";
            }
            else
            {
                txtKey.Text = "Tìm Kiếm";
                FormNhanVien_Load(sender, e);
                btnXoaChu.Visible = false;
            }
        }

        private void btnXoaChu_Click(object sender, EventArgs e)
        {
            txtKey.Text = "Tìm Kiếm";
            FormNhanVien_Load(sender, e);
            btnXoaChu.Visible = false;
        }
        private void toolStrip1_Click(object sender, EventArgs e)
        {
            txtKey.Text = "Tìm Kiếm";
            FormNhanVien_Load(sender, e);
            btnXoaChu.Visible = false;
        }

        //// Chặn các ký tự---------------------------------------------------------------------------
        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtTenDN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
