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
    public partial class FormLoaiThuoc : Form
    {
        public FormLoaiThuoc()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();

        private void FormLoaiThuoc_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvLoaiTH);
                ModelQLThuoc context = new ModelQLThuoc();
                List<LOAITHUOC> listLT = context.LOAITHUOCs.ToList();
                BindGrid(listLT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<LOAITHUOC> listLT)
        {
            dgvLoaiTH.Rows.Clear();
            foreach (var item in listLT)
            {
                int index = dgvLoaiTH.Rows.Add();
                dgvLoaiTH.Rows[index].Cells[0].Value = item.MALOAITHUOC;
                dgvLoaiTH.Rows[index].Cells[1].Value = item.TENLOAI;
                dgvLoaiTH.Rows[index].Cells[2].Value = item.HESOLUONG;
            }
        }
        private void reset()
        {
            txtMaTH.Clear();
            txtTenTH.Clear();
            TxtHeSoLuong.Clear();
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
            List<LOAITHUOC> lst = context.LOAITHUOCs.ToList();
            LOAITHUOC s = new LOAITHUOC();
            try
            {
                if (txtMaTH.Text == "" || txtTenTH.Text == "" || TxtHeSoLuong.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                LOAITHUOC dbUpdate = context.LOAITHUOCs.FirstOrDefault(p => p.MALOAITHUOC == txtMaTH.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Mã loại thuốc bị trùng. Chọn Yes để cập Nhật", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dbUpdate.TENLOAI = txtTenTH.Text;
                        dbUpdate.HESOLUONG = int.Parse(TxtHeSoLuong.Text);
                        context.SaveChanges();
                        FormLoaiThuoc_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();

                    }

                }
                else
                {
                    s = new LOAITHUOC() { MALOAITHUOC = txtMaTH.Text, TENLOAI = txtTenTH.Text, HESOLUONG = int.Parse(TxtHeSoLuong.Text) };
                    context.LOAITHUOCs.Add(s);
                    context.SaveChanges();
                    FormLoaiThuoc_Load(sender, e);
                    MessageBox.Show("Thêm Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLoaiTH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> temp = new List<string>();
            if (e.RowIndex < 0)
            {
                return;
            }
            txtMaTH.Text = dgvLoaiTH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenTH.Text = dgvLoaiTH.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtHeSoLuong.Text = dgvLoaiTH.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTH.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
                List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
                List<PHIEUNHAPKHO> listNK = context.PHIEUNHAPKHOes.ToList();
                List<PHIEUTHANHLI> listTL = context.PHIEUTHANHLIs.ToList();
                List<THUOC> listT = context.THUOCs.ToList();
                List<LOTHUOC> listLT = context.LOTHUOCs.ToList();
                LOAITHUOC dbDelete = context.LOAITHUOCs.FirstOrDefault(p => p.MALOAITHUOC == txtMaTH.Text);
                if (dbDelete != null)
                {
                    if (MessageBox.Show("Bạn Có Muốn Xóa Thông Tin Này ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (var itam in listT)
                            if (itam.MALOAITHUOC == txtMaTH.Text)
                            {
                                foreach (var item in listTL)
                                    if (item.MATHUOC == itam.MATHUOC)
                                    {
                                        context.PHIEUTHANHLIs.Remove(item);
                                    }
                                foreach (var tm in listXK)
                                    if (tm.MATHUOC == itam.MATHUOC)
                                    {
                                        context.PHIEUXUATKHOes.Remove(tm);
                                    }
                                foreach (var tem in listNK)
                                    if (tem.MATHUOC == itam.MATHUOC)
                                    {
                                        context.PHIEUNHAPKHOes.Remove(tem);
                                    }
                                foreach (var tam in listDH)
                                    if (tam.MATHUOC == itam.MATHUOC)
                                    {
                                        context.PHIEUDATHANGs.Remove(tam);
                                    }
                                foreach (var team in listLT)
                                    if (team.MATHUOC == itam.MATHUOC)
                                    {
                                        context.LOTHUOCs.Remove(team);
                                    }
                                context.THUOCs.Remove(itam);
                            }
                        context.LOAITHUOCs.Remove(dbDelete);
                        context.SaveChanges();
                        FormLoaiThuoc_Load(sender, e);
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
                    dgvLoaiTH.Rows.Clear();
                    List<LOAITHUOC> listLT = context.LOAITHUOCs.ToList();
                    foreach (var item in listLT)
                    {
                        if (item.MALOAITHUOC.Contains(txtFind.Text) || item.TENLOAI.Contains(txtFind.Text))
                        {

                            int index = dgvLoaiTH.Rows.Add();
                            dgvLoaiTH.Rows[index].Cells[0].Value = item.MALOAITHUOC;
                            dgvLoaiTH.Rows[index].Cells[1].Value = item.TENLOAI;
                            dgvLoaiTH.Rows[index].Cells[2].Value = item.HESOLUONG;
                        }
                    }
                    if (txtFind.Text == "" || txtFind.Text == " Tìm Kiếm")
                    {
                        FormLoaiThuoc_Load(sender, e);
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
                FormLoaiThuoc_Load(sender, e);
                btnXoachu.Visible = false;
            }
        }

        private void FormLoaiThuoc_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            btnXoachu.Visible = false;
            FormLoaiThuoc_Load(sender, e);
        }
        private void btnXoaChu_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            FormLoaiThuoc_Load(sender, e);
            btnXoachu.Visible = false;
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvLoaiTH, @"D:\", "Danh Sách Loại Thuốc");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtMaLT_KeyPress(object sender, KeyPressEventArgs e)
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
