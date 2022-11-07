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
    public partial class FormPhieuNhapKho : Form
    {
        public FormPhieuNhapKho()
        {
            InitializeComponent();
        }
   
        ModelQLThuoc context = new ModelQLThuoc();

        private void reset()
        {
            TxtMaPhieuNK.Text = "";
            DateTimePickerNgayNhapKho.Text = default;
            cmbMaNV.SelectedIndex = 0;
            cmbMaKho.SelectedIndex = 0;
            cmbMaThuoc.SelectedIndex = 0;

        }

        private void FormPhieuNhapKho_Load(object sender, EventArgs e)
        {
            try
            {

                SetGridViewStyle(dgvPhieuNK);
                ModelQLThuoc context = new ModelQLThuoc();
                List<NHANVIEN> listnhanvien = context.NHANVIENs.ToList();
                List<KHO> listKHO = context.KHOes.ToList();
                List<PHIEUNHAPKHO> listphieunk = context.PHIEUNHAPKHOes.ToList();
                FillMaKhoCombobox(listKHO);
                FillMaNVCombobox(listnhanvien);
                List<THUOC> listTHUOC = context.THUOCs.ToList();
                FillMaThuocCombobox(listTHUOC);
                BindGrid(listphieunk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindGrid(List<PHIEUNHAPKHO> listphieunk)
        {
            dgvPhieuNK.Rows.Clear();
            foreach (var item in listphieunk)
            {
                int index = dgvPhieuNK.Rows.Add();
                dgvPhieuNK.Rows[index].Cells[0].Value = item.MAPHIEUNK;
                dgvPhieuNK.Rows[index].Cells[1].Value = item.NGAYNK;
                if (item.MANV != null)
                    dgvPhieuNK.Rows[index].Cells[2].Value = item.MANV;
                if (item.MAKHO != null)
                    dgvPhieuNK.Rows[index].Cells[3].Value = item.MAKHO;
                if (item.MATHUOC != null)
                    dgvPhieuNK.Rows[index].Cells[4].Value = item.MATHUOC;
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

        private void FillMaNVCombobox(List<NHANVIEN> listmanv)
        {
            this.cmbMaNV.DataSource = listmanv;
            this.cmbMaNV.DisplayMember = "HOTENNV";
            this.cmbMaNV.ValueMember = "MANV";    
                
           
        }
        private void FillMaKhoCombobox(List<KHO> listmakho)
        {
            this.cmbMaKho.DataSource = listmakho;
            this.cmbMaKho.DisplayMember = "TENKHO";
            this.cmbMaKho.ValueMember = "MAKHO";
        }
        private void FillMaThuocCombobox(List<THUOC> listmathuoc)
        {
            this.cmbMaThuoc.DataSource = listmathuoc;
            this.cmbMaThuoc.DisplayMember = "TENTHUOC";
            this.cmbMaThuoc.ValueMember = "MATHUOC";
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            List<NHANVIEN> lst = context.NHANVIENs.ToList();
            List<KHO> lst1 = context.KHOes.ToList();
            List<THUOC> list2 = context.THUOCs.ToList();
            PHIEUNHAPKHO s = new PHIEUNHAPKHO();

            try
            {
                if (TxtMaPhieuNK.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                
                PHIEUNHAPKHO dbUpdateNK = context.PHIEUNHAPKHOes.FirstOrDefault(p => p.MAPHIEUNK == TxtMaPhieuNK.Text);
                if (dbUpdateNK != null)
                {
                    DialogResult dr = MessageBox.Show("Mã phiếu bị trùng. Chọn Yes để Cập Nhật", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {

                        dbUpdateNK.NGAYNK = DateTime.Parse(DateTimePickerNgayNhapKho.Text);
                        foreach (var item in lst)
                        {
                            if (item.HOTENNV == cmbMaNV.Text)
                            {
                                dbUpdateNK.MANV = item.MANV;
                            }
                        }
                        foreach (var tem in lst1)
                        {
                            if (tem.TENKHO == cmbMaKho.Text)
                            {
                                dbUpdateNK.MAKHO = tem.MAKHO;
                            }
                        }
                        foreach (var tam in list2)
                        {
                            if (tam.TENTHUOC == cmbMaThuoc.Text)
                            {
                                dbUpdateNK.MATHUOC = tam.MATHUOC;
                            }
                        }
                        context.SaveChanges();
                        FormPhieuNhapKho_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();

                    }
                }
                else
                {
                    foreach (var item in lst)
                        if (item.HOTENNV == cmbMaNV.Text)
                        {
                            foreach (var tem in lst1)
                                if (tem.TENKHO == cmbMaKho.Text)
                                {
                                    foreach (var tam in list2)
                                        if (tam.TENTHUOC == cmbMaThuoc.Text)
                                        {
                                            s = new PHIEUNHAPKHO() { MAPHIEUNK = TxtMaPhieuNK.Text, NGAYNK = DateTime.Parse(DateTimePickerNgayNhapKho.Text), MANV = item.MANV, MAKHO = tem.MAKHO, MATHUOC = tam.MATHUOC };
                                           
                                        }
                                        

                                }
                                    
                        }
                    context.PHIEUNHAPKHOes.Add(s);
                    context.SaveChanges();
                    FormPhieuNhapKho_Load(sender, e);
                    MessageBox.Show("Thêm Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtMaPhieuNK.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                PHIEUNHAPKHO dbDelete = context.PHIEUNHAPKHOes.FirstOrDefault(p => p.MAPHIEUNK == TxtMaPhieuNK.Text);
                if (dbDelete != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        context.PHIEUNHAPKHOes.Remove(dbDelete);
                        context.SaveChanges();
                        FormPhieuNhapKho_Load(sender, e);
                        MessageBox.Show("Xóa Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPhieuNK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            List<NHANVIEN> lst = context.NHANVIENs.ToList();
            List<KHO> lst1 = context.KHOes.ToList();
            List<THUOC> list2 = context.THUOCs.ToList();
            DataGridViewRow row = new DataGridViewRow();
            TxtMaPhieuNK.Text = dgvPhieuNK.Rows[e.RowIndex].Cells[0].Value.ToString();
            DateTimePickerNgayNhapKho.Text = dgvPhieuNK.Rows[e.RowIndex].Cells[1].Value.ToString();
            foreach (var item in lst)
            {
                if (dgvPhieuNK.Rows[e.RowIndex].Cells[2].Value.ToString() == item.MANV)
                {
                    cmbMaNV.Text = item.HOTENNV;
                }
            }
            foreach (var tem in lst1)
            {
                if (dgvPhieuNK.Rows[e.RowIndex].Cells[3].Value.ToString() == tem.MAKHO)
                {
                    cmbMaKho.Text = tem.TENKHO;
                }
            }
            foreach (var tam in list2)
            {
                if (dgvPhieuNK.Rows[e.RowIndex].Cells[4].Value.ToString() == tam.MATHUOC)
                {
                    cmbMaThuoc.Text = tam.TENTHUOC;
                }
            }


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvPhieuNK, @"D:\", "Danh Sách Phiếu Nhập Kho");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                btnXoachu.Visible = true;
                if (txtFind.Text != null)
                {
                    List<PHIEUNHAPKHO> listphieunk = context.PHIEUNHAPKHOes.ToList();
                    dgvPhieuNK.Rows.Clear();
                    foreach (var item in listphieunk)
                    {
                        if (item.MAPHIEUNK.Contains(txtFind.Text) || item.MANV.Contains(txtFind.Text) || item.MATHUOC.Contains(txtFind.Text))
                        {

                            int index = dgvPhieuNK.Rows.Add();
                            dgvPhieuNK.Rows[index].Cells[0].Value = item.MAPHIEUNK;
                            dgvPhieuNK.Rows[index].Cells[1].Value = item.NGAYNK;
                            if (item.MANV != null)
                                dgvPhieuNK.Rows[index].Cells[2].Value = item.MANV;
                            if (item.MAKHO != null)
                                dgvPhieuNK.Rows[index].Cells[3].Value = item.MAKHO;
                            if (item.MATHUOC != null)
                                dgvPhieuNK.Rows[index].Cells[4].Value = item.MATHUOC;
                        }
                    }
                }
                if (txtFind.Text == "" || txtFind.Text == " Tìm Kiếm")
                {
                    FormPhieuNhapKho_Load(sender, e);
                    btnXoachu.Visible = false;
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
                FormPhieuNhapKho_Load(sender, e);
                btnXoachu.Visible = false;
            }
        }

        private void btnXoachu_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            FormPhieuNhapKho_Load(sender, e);
            btnXoachu.Visible = false;
        }

        private void TxtMaPhieuNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }



        private void cmbMaKho_KeyPress(object sender, KeyPressEventArgs e)
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
