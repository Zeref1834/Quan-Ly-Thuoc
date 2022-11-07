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
    public partial class Thanh_Lí : Form
    {
        public Thanh_Lí()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void Form1_Load(object sender, EventArgs e)
        {
            SetGridViewStyle(dgvThanhLi);
            ModelQLThuoc context = new ModelQLThuoc();
            List<THUOC> listT = context.THUOCs.ToList();
            List<NHANVIEN> listNV = context.NHANVIENs.ToList();
            List<KHO> listK = context.KHOes.ToList();
            List<PHIEUTHANHLI> listTL = context.PHIEUTHANHLIs.ToList();
            FillMaThuocComboBox(listT);
            FillMaNhanVienComboBox(listNV);
            BindGrid(listTL);
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

        private void FillMaThuocComboBox(List<THUOC> listT)
        {
            this.cmbMT.DataSource = listT;
            this.cmbMT.DisplayMember = "TENTHUOC";
            this.cmbMT.ValueMember = "MATHUOC";
        }

        private void FillMaNhanVienComboBox(List<NHANVIEN> listNV)
        {
            this.cmbNV.DataSource = listNV;
            this.cmbNV.DisplayMember = "HOTENNV";
            this.cmbNV.ValueMember = "MANV";
        }
        private void BindGrid(List<PHIEUTHANHLI> listTL)
        {
            dgvThanhLi.Rows.Clear();
            foreach (var item in listTL)
            {
                int index = dgvThanhLi.Rows.Add();
                dgvThanhLi.Rows[index].Cells[0].Value = item.MAPHIEUTL;
                if (item.KHO != null)
                    dgvThanhLi.Rows[index].Cells[3].Value = item.KHO.MAKHO;
                if (item.NHANVIEN != null)
                    dgvThanhLi.Rows[index].Cells[5].Value = item.NHANVIEN.MANV;
                dgvThanhLi.Rows[index].Cells[4].Value = item.NGAYTHANH;
                if (item.THUOC != null)
                    dgvThanhLi.Rows[index].Cells[1].Value = item.THUOC.MATHUOC;
                dgvThanhLi.Rows[index].Cells[2].Value = item.SOLUONG;
            }
        }
        private void reset()
        {
            txtID.Text = "";
            txtSL.Text = "";
            dateTL.Text = default;
            cmbMT.SelectedIndex = 0;
            cmbNV.SelectedIndex = 0;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            
            try
            {
                List<THUOC> listT = context.THUOCs.ToList();
                List<PHIEUNHAPKHO> listNK = context.PHIEUNHAPKHOes.ToList();
                List<NHANVIEN> listNV = context.NHANVIENs.ToList();
                List<KHO> listK = context.KHOes.ToList();
                List<PHIEUTHANHLI> listTL = context.PHIEUTHANHLIs.ToList();
                List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
                List<LOTHUOC> lstLT = context.LOTHUOCs.ToList();
                PHIEUTHANHLI s = new PHIEUTHANHLI();
                if (txtID.Text == "" ||txtSL.Text == "" )
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                PHIEUTHANHLI dbUpdateTL = context.PHIEUTHANHLIs.FirstOrDefault(p => p.MAPHIEUTL == txtID.Text);
                THUOC dbUpdateT = context.THUOCs.FirstOrDefault(p => p.TENTHUOC == cmbMT.Text);
                if (dbUpdateTL != null)
                {
                    DialogResult dr = MessageBox.Show("Mã đơn hàng trùng. Chọn Yes để Cập Nhật", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (var item in listT)
                            if (item.TENTHUOC == cmbMT.Text)
                            {
                                dbUpdateTL.MATHUOC = item.MATHUOC;
                                dbUpdateTL.SOLUONG = int.Parse(txtSL.Text);
                                foreach (var itam in listNK)
                                    if (itam.MATHUOC == item.MATHUOC)
                                    {
                                        dbUpdateTL.MAKHO = itam.MAKHO;
                                    }
                            }
                        foreach (var item in listNV)
                            if (item.HOTENNV == cmbNV.Text)
                            {
                                dbUpdateTL.MANV = item.MANV;
                            }
                        foreach (var tem in listT)
                            if (tem.TENTHUOC == cmbMT.Text)
                            {
                                dbUpdateT.SOLUONG = 0;
                                foreach (var tam in lstLT)
                                    if (tam.MATHUOC == tem.MATHUOC)
                                    {
                                        dbUpdateT.SOLUONG = tem.SOLUONG + tam.SOLUONG;
                                        foreach (var itam in listTL)
                                            if (itam.MATHUOC == tam.MATHUOC)
                                            {
                                                dbUpdateT.SOLUONG = tem.SOLUONG - itam.SOLUONG;
                                                foreach (var item in listDH)
                                                    if (item.MATHUOC == tam.MATHUOC)
                                                    {
                                                        dbUpdateT.SOLUONG = tem.SOLUONG - item.SOLUONG;
                                                    }
                                            }
                                    }
                            }
                        dbUpdateTL.NGAYTHANH = DateTime.Parse(dateTL.Text);
                        context.SaveChanges();
                        Form1_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
                else
                {
                    foreach (var item in listT)
                        if (item.TENTHUOC == cmbMT.Text)
                        {
                            foreach (var itam in listNV)
                                if (itam.HOTENNV == cmbNV.Text)
                                {
                                    foreach (var tem in listNK)
                                        if (tem.MATHUOC == item.MATHUOC)
                                        {
                                            s = new PHIEUTHANHLI() { MAPHIEUTL = txtID.Text, MATHUOC = item.MATHUOC, SOLUONG = int.Parse(txtSL.Text), MAKHO = tem.MAKHO, NGAYTHANH = DateTime.Parse(dateTL.Text), MANV = itam.MANV };
                                            dbUpdateT.SOLUONG = item.SOLUONG - int.Parse(txtSL.Text);
                                        }
                                }
                                   
                        }
                    context.PHIEUTHANHLIs.Add(s);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                List<THUOC> lst = context.THUOCs.ToList();
                THUOC dbUpdateT = context.THUOCs.FirstOrDefault(p => p.TENTHUOC == cmbMT.Text);
                PHIEUTHANHLI dbDelete = context.PHIEUTHANHLIs.FirstOrDefault(p => p.MAPHIEUTL == txtID.Text);
                if (dbDelete != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (var tem in lst)
                            if (tem.TENTHUOC == cmbMT.Text)
                            {
                                dbUpdateT.SOLUONG = tem.SOLUONG + dbDelete.SOLUONG;
                            }
                        context.PHIEUTHANHLIs.Remove(dbDelete);
                        context.SaveChanges();
                        Form1_Load(sender, e);
                        MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvThanhLi, @"D:\", "Danh Sách Thanh Lí");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvThanhLi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            List<THUOC> listT = context.THUOCs.ToList();
            List<NHANVIEN> listNV = context.NHANVIENs.ToList();
            DataGridViewRow row = new DataGridViewRow();
            txtID.Text = dgvThanhLi.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (var item in listT)
            {
                if (dgvThanhLi.Rows[e.RowIndex].Cells[1].Value.ToString() == item.MATHUOC)
                {
                    cmbMT.Text = item.TENTHUOC;
                }
            }
            dateTL.Text = dgvThanhLi.Rows[e.RowIndex].Cells[4].Value.ToString();
            foreach (var item in listNV)
            {
                if (dgvThanhLi.Rows[e.RowIndex].Cells[5].Value.ToString() == item.MANV)
                {
                    cmbNV.Text = item.HOTENNV;
                }
            }
            txtSL.Text = dgvThanhLi.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            btnXoachu.Visible = true;
            List<PHIEUTHANHLI> listT = context.PHIEUTHANHLIs.ToList();
            if (txtFind.Text != null)
            {
                dgvThanhLi.Rows.Clear();
                foreach (var item in listT)
                {
                    if (item.MAPHIEUTL.Contains(txtFind.Text) || item.MATHUOC.Contains(txtFind.Text))
                    {
                        int index = dgvThanhLi.Rows.Add();
                        dgvThanhLi.Rows[index].Cells[0].Value = item.MAPHIEUTL;
                        if (item.THUOC != null)
                            dgvThanhLi.Rows[index].Cells[1].Value = item.THUOC.MATHUOC;
                        dgvThanhLi.Rows[index].Cells[2].Value = item.SOLUONG;
                        if (item.KHO != null)
                            dgvThanhLi.Rows[index].Cells[3].Value = item.KHO.MAKHO;
                        dgvThanhLi.Rows[index].Cells[4].Value = item.NGAYTHANH;
                        if (item.NHANVIEN != null)
                            dgvThanhLi.Rows[index].Cells[5].Value = item.NHANVIEN.MANV;
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
