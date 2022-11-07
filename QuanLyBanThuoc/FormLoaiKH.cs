using QuanLyBanThuoc.ADO;
using QuanLyBanThuoc.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class FormLoaiKH : Form
    {
        public FormLoaiKH()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void FormLoaiKH_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvLoaiKH);
                ModelQLThuoc context = new ModelQLThuoc();
                List<LOAIKH> listLKH = context.LOAIKHs.ToList();
                BindGrid(listLKH);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<LOAIKH> listLKH)
        {
            dgvLoaiKH.Rows.Clear();
            foreach (var item in listLKH)
            {
                int index = dgvLoaiKH.Rows.Add();
                dgvLoaiKH.Rows[index].Cells[0].Value = item.MALOAIKH;
                dgvLoaiKH.Rows[index].Cells[1].Value = item.TENLOAIKH;
            }
        }
        private void reset()
        {
            txtMaLKH.Clear();
            txtTenLKH.Clear();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<LOAIKH> lst = context.LOAIKHs.ToList();
            LOAIKH s = new LOAIKH();
            try
            {
                if (txtMaLKH.Text == "" || txtTenLKH.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                LOAIKH dbUpdate = context.LOAIKHs.FirstOrDefault(p => p.MALOAIKH == txtMaLKH.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Mã loại khách hàng bị trùng. Chọn Yes để cập Nhật", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dbUpdate.TENLOAIKH = txtTenLKH.Text;
                        context.SaveChanges();
                        FormLoaiKH_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();

                    }

                }
                else
                {
                    s = new LOAIKH() { MALOAIKH = txtMaLKH.Text, TENLOAIKH = txtTenLKH.Text };
                    context.LOAIKHs.Add(s);
                    context.SaveChanges();
                    FormLoaiKH_Load(sender, e);
                    MessageBox.Show("Thêm Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLoaiKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> temp = new List<string>();
            if (e.RowIndex < 0)
            {
                return;
            }
            txtMaLKH.Text = dgvLoaiKH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenLKH.Text = dgvLoaiKH.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLKH.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                LOAIKH dbDelete = context.LOAIKHs.FirstOrDefault(p => p.MALOAIKH == txtMaLKH.Text);
                if (dbDelete != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
                        List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
                        List<KHACHHANG> listKH = context.KHACHHANGs.ToList();
                        foreach(var itam in listKH)
                            if(itam.MALOAIKH == txtMaLKH.Text)
                            {
                                foreach (var item in listXK)
                                    if (item.MAKH == itam.MAKH)
                                    {
                                        context.PHIEUXUATKHOes.Remove(item);
                                    }
                                foreach (var tam in listDH)
                                    if (tam.MAKH == itam.MAKH)
                                    {
                                        context.PHIEUDATHANGs.Remove(tam);
                                    }
                                context.KHACHHANGs.Remove(itam);
                            }
                        context.LOAIKHs.Remove(dbDelete);
                        context.SaveChanges();
                        FormLoaiKH_Load(sender, e);
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

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFind.Text != null)
                {
                    btnXoachu.Visible = true;
                    dgvLoaiKH.Rows.Clear();
                    List<LOAIKH> listLKH = context.LOAIKHs.ToList();
                    foreach (var item in listLKH)
                    {
                        if (item.MALOAIKH.Contains(txtFind.Text) || item.TENLOAIKH.Contains(txtFind.Text))
                        {

                            int index = dgvLoaiKH.Rows.Add();
                            dgvLoaiKH.Rows[index].Cells[0].Value = item.MALOAIKH;
                            dgvLoaiKH.Rows[index].Cells[1].Value = item.TENLOAIKH;
                        }
                    }
                    if (txtFind.Text == "" || txtFind.Text == " Tìm Kiếm")
                    {
                        FormLoaiKH_Load(sender, e);
                        btnXoachu.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                FormLoaiKH_Load(sender, e);
                btnXoachu.Visible = false;
            }
        }

        private void FormLoaiKH_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            btnXoachu.Visible = false;
            FormLoaiKH_Load(sender, e);
        }

        private void btnXoachu_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            FormLoaiKH_Load(sender, e);
            btnXoachu.Visible = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvLoaiKH, @"D:\", "Danh Sách Loại Khách Hàng");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtMaLKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) & !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
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
