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

namespace QuanLyBanThuoc
{
    public partial class Đặt_Hàng : Form
    {
        public Đặt_Hàng()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvDatHang);
                ModelQLThuoc context = new ModelQLThuoc();
                List<LOAIKH> listLKH = context.LOAIKHs.ToList();
                List<NHANVIEN> listNV = context.NHANVIENs.ToList();
                List<THUOC> listT = context.THUOCs.ToList();
                List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
                List<KHACHHANG> listKH = context.KHACHHANGs.ToList();
                List<HT_THANHTOAN> listHT = context.HT_THANHTOAN.ToList();
                FillKhachHangComboBox(listKH);
                FillMaNhanVienComboBox(listNV);
                FillMaThuocComboBox(listT);
                FillHinhThucThanhToanComboBox(listHT);
                BindGrid(listDH);
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
        private void FillKhachHangComboBox(List<KHACHHANG> listKH)
        {
            this.cmbIDKH.DataSource = listKH;
            this.cmbIDKH.DisplayMember = "HOTENKH";
            this.cmbIDKH.ValueMember = "MAKH";
        }
        private void FillHinhThucThanhToanComboBox(List<HT_THANHTOAN> listHT)
        {
            this.cmbHT.DataSource = listHT;
            this.cmbHT.DisplayMember = "TENHT";
            this.cmbHT.ValueMember = "MAHT";
        }
        private void BindGrid(List<PHIEUDATHANG> listDH)
        {
            dgvDatHang.Rows.Clear();
            foreach (var item in listDH)
            {
                int index = dgvDatHang.Rows.Add();
                dgvDatHang.Rows[index].Cells[0].Value = item.MAPHIEUDH;
                if (item.KHACHHANG != null)
                    dgvDatHang.Rows[index].Cells[1].Value = item.KHACHHANG.MAKH;
                if (item.THUOC != null)
                    dgvDatHang.Rows[index].Cells[3].Value = item.THUOC.MATHUOC;
                dgvDatHang.Rows[index].Cells[4].Value = item.SOLUONG;
                dgvDatHang.Rows[index].Cells[5].Value = item.NGAYGIAO;
                dgvDatHang.Rows[index].Cells[6].Value = item.NOIGIAO;
                dgvDatHang.Rows[index].Cells[7].Value = item.NGAYLAP;
                if (item.NHANVIEN != null)
                    dgvDatHang.Rows[index].Cells[9].Value = item.NHANVIEN.MANV;
                if (item.HT_THANHTOAN != null)
                    dgvDatHang.Rows[index].Cells[2].Value = item.HT_THANHTOAN.MAHT;
                dgvDatHang.Rows[index].Cells[8].Value = (item.SOLUONG * item.THUOC.DONGIABAN);
            }
        }
        private void reset()
        {
            txtIDDH.Text = "";
            txtNG.Text = "";
            txtSL.Text = "";
            dateG.Text = default;
            dateL.Text = default;
            cmbMT.SelectedIndex = 0;
            cmbIDKH.SelectedIndex = 0;
            cmbHT.SelectedIndex = 0;
            cmbNV.SelectedIndex = 0;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            List<THUOC> listT = context.THUOCs.ToList();
            List<KHACHHANG> listKH = context.KHACHHANGs.ToList();
            List<NHANVIEN> listNV = context.NHANVIENs.ToList();
            List<HT_THANHTOAN> listHT = context.HT_THANHTOAN.ToList();
            PHIEUDATHANG s = new PHIEUDATHANG();
            try
            {
                if (txtIDDH.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                }
                PHIEUDATHANG dbUpdateDH = context.PHIEUDATHANGs.FirstOrDefault(p => p.MAPHIEUDH == txtIDDH.Text);
                THUOC dbUpdateT = context.THUOCs.FirstOrDefault(p => p.TENTHUOC == cmbMT.Text);
                if (dbUpdateDH != null)
                {
                    DialogResult dr = MessageBox.Show("Mã đơn hàng trùng. Chọn Yes để Update", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (var item in listKH)
                            if (item.HOTENKH == cmbIDKH.Text)
                            {
                                dbUpdateDH.MAKH = item.MAKH; ;
                            }
                        foreach (var item in listT)
                            if (item.TENTHUOC == cmbMT.Text)
                            {
                                dbUpdateDH.MATHUOC = item.MATHUOC;
                            }
                        dbUpdateDH.SOLUONG = int.Parse(txtSL.Text);
                        dbUpdateDH.NGAYGIAO = DateTime.Parse(dateG.Text);
                        dbUpdateDH.NOIGIAO = txtNG.Text;
                        dbUpdateDH.NGAYLAP = DateTime.Parse(dateL.Text);
                        foreach (var item in listNV)
                            if (item.HOTENNV == cmbNV.Text)
                            {
                                dbUpdateDH.MANV = item.MANV;
                            }
                        foreach (var item in listHT)
                            if (item.TENHT == cmbHT.Text)
                            {
                                dbUpdateDH.MAHT = item.MAHT;
                            }
                        context.SaveChanges();
                        Form1_Load(sender, e);
                        reset();
                    }
                }
                else
                {
                    foreach (var item in listKH)
                        if (item.HOTENKH == cmbIDKH.Text)
                            foreach (var tem in listHT)
                                if (tem.TENHT == cmbHT.Text)
                                    foreach (var itam in listT)
                                        if (itam.TENTHUOC == cmbMT.Text)
                                            foreach (var tam in listNV)
                                                if (tam.HOTENNV == cmbNV.Text)
                                                {
                                                    if (itam.SOLUONG < int.Parse(txtSL.Text))
                                                    {
                                                        MessageBox.Show("Số Lượng Vượt Quá Số Lượng Đang Có Xin Vui Long Nhập Lại");
                                                    }
                                                    else
                                                    {
                                                        s = new PHIEUDATHANG() { MAPHIEUDH = txtIDDH.Text, MAKH = item.MAKH, MAHT = tem.MAHT, MATHUOC = itam.MATHUOC, SOLUONG = int.Parse(txtSL.Text), NGAYGIAO = DateTime.Parse(dateG.Text), NOIGIAO = txtNG.Text, NGAYLAP = DateTime.Parse(dateL.Text), TONGTIEN = (int.Parse(txtSL.Text) * itam.DONGIABAN), MANV = tam.MANV };
                                                        dbUpdateT.SOLUONG = itam.SOLUONG - int.Parse(txtSL.Text);
                                                    }
                                                }
                    context.PHIEUDATHANGs.Add(s);
                    context.SaveChanges();
                    Form1_Load(sender, e);
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
            List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
            List<THUOC> lst = context.THUOCs.ToList();
            THUOC dbUpdateT = context.THUOCs.FirstOrDefault(p => p.TENTHUOC == cmbMT.Text);
            PHIEUDATHANG dbDelete = context.PHIEUDATHANGs.FirstOrDefault(p => p.MAPHIEUDH == txtIDDH.Text);
            /*PHIEUXUATKHO dbDeleteXK = context.PHIEUXUATKHOes.FirstOrDefault(p => p.MAPHIEUDH == txtIDDH.Text);*/
            if (dbDelete != null)
            {
                foreach (var tem in lst)
                    if (tem.TENTHUOC == cmbMT.Text)
                    {
                        dbUpdateT.SOLUONG = tem.SOLUONG + dbDelete.SOLUONG;
                    }
                foreach (var item in listXK)
                    if (item.MAPHIEUDH == txtIDDH.Text)
                        context.PHIEUXUATKHOes.Remove(item);
                context.PHIEUDATHANGs.Remove(dbDelete);
                context.SaveChanges();
                Form1_Load(sender, e);
                reset();
            }
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvDatHang, @"D:\", "Danh Sách Phiếu Đặt Hàng");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void dgvDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            List<THUOC> listT = context.THUOCs.ToList();
            List<KHACHHANG> listKH = context.KHACHHANGs.ToList();
            List<NHANVIEN> listNV = context.NHANVIENs.ToList();
            List<HT_THANHTOAN> listHT = context.HT_THANHTOAN.ToList();
            DataGridViewRow row = new DataGridViewRow();
            txtIDDH.Text = dgvDatHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (var item in listKH)
            {
                if (dgvDatHang.Rows[e.RowIndex].Cells[1].Value.ToString() == item.MAKH)
                {
                    cmbIDKH.Text = item.HOTENKH;
                }
            }
            foreach (var item in listT)
            {
                if (dgvDatHang.Rows[e.RowIndex].Cells[3].Value.ToString() == item.MATHUOC)
                {
                    cmbMT.Text = item.TENTHUOC;
                }
            }
            txtSL.Text = dgvDatHang.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateG.Text = dgvDatHang.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtNG.Text = dgvDatHang.Rows[e.RowIndex].Cells[6].Value.ToString();
            dateL.Text = dgvDatHang.Rows[e.RowIndex].Cells[7].Value.ToString();
            foreach (var item in listNV)
            {
                if (dgvDatHang.Rows[e.RowIndex].Cells[8].Value.ToString() == item.MANV)
                {
                    cmbNV.Text = item.HOTENNV;
                }
            }
            foreach (var item in listHT)
            {
                if (dgvDatHang.Rows[e.RowIndex].Cells[2].Value.ToString() == item.MAHT)
                {
                    cmbHT.Text = item.TENHT;
                }
            }
        }


        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            toolStripButton5.Visible = true;
            List<PHIEUDATHANG> listT = context.PHIEUDATHANGs.ToList();
            if (txtFind.Text != null)
            {
                dgvDatHang.Rows.Clear();
                foreach (var item in listT)
                {
                    if (item.MAPHIEUDH.Contains(txtFind.Text) || item.MAKH.Contains(txtFind.Text))
                    {
                        int index = dgvDatHang.Rows.Add();
                        dgvDatHang.Rows[index].Cells[0].Value = item.MAPHIEUDH;
                        if (item.KHACHHANG != null)
                            dgvDatHang.Rows[index].Cells[1].Value = item.KHACHHANG.MAKH;
                        if (item.HT_THANHTOAN != null)
                            dgvDatHang.Rows[index].Cells[2].Value = item.HT_THANHTOAN.MAHT;
                        if (item.THUOC != null)
                            dgvDatHang.Rows[index].Cells[3].Value = item.THUOC.MATHUOC;
                        dgvDatHang.Rows[index].Cells[4].Value = item.SOLUONG;
                        dgvDatHang.Rows[index].Cells[5].Value = item.NGAYGIAO;
                        dgvDatHang.Rows[index].Cells[6].Value = item.NOIGIAO;
                        dgvDatHang.Rows[index].Cells[7].Value = item.NGAYLAP;
                        dgvDatHang.Rows[index].Cells[8].Value = item.TONGTIEN;
                        if (item.NHANVIEN != null)
                            dgvDatHang.Rows[index].Cells[9].Value = item.NHANVIEN.MANV;
                    }


                }
            }
            if (txtFind.Text == "" || txtFind.Text == " Tìm Kiếm")
            {
                Form1_Load(sender, e);
                toolStripButton5.Visible = false;
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
                toolStripButton5.Visible = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            toolStripButton5.Visible = false;
        }

 

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
