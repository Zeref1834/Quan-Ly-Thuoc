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
    public partial class Thuốc : Form
    {
        public Thuốc()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void FillLoaiThuocCombobox(List<LOAITHUOC> listLoaiThuoc)
        {
            this.cmbLoai.DataSource = listLoaiThuoc;
            this.cmbLoai.DisplayMember = "TENLOAI";
            this.cmbLoai.ValueMember = "MALOAITHUOC";
        }

        private void FillDVTCombobox(List<DVTINH> listDVT)
        {
            this.cmbDVT.DataSource = listDVT;
            this.cmbDVT.DisplayMember = "TENDVT";
            this.cmbDVT.ValueMember = "MADVT";
        }
        private void BindGrid(List<THUOC> listThuoc)
        {
            List<LOTHUOC> listLoThuoc = context.LOTHUOCs.ToList();
            dgvThuoc.Rows.Clear();
            foreach (var item in listThuoc)
            {
                int index = dgvThuoc.Rows.Add();
                dgvThuoc.Rows[index].Cells[0].Value = item.MATHUOC;
                dgvThuoc.Rows[index].Cells[1].Value = item.TENTHUOC;
                if (item.DVTINH != null)
                    dgvThuoc.Rows[index].Cells[2].Value = item.DVTINH.MADVT;
                dgvThuoc.Rows[index].Cells[3].Value = item.SOLUONG;
                dgvThuoc.Rows[index].Cells[4].Value = item.DONGIAMUA;
                dgvThuoc.Rows[index].Cells[5].Value = item.DONGIABAN;
                if (item.LOAITHUOC != null)
                    dgvThuoc.Rows[index].Cells[6].Value = item.LOAITHUOC.MALOAITHUOC;
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

        private void reset()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtGB.Text = "";
            txtGM.Text = "";
            cmbDVT.SelectedIndex = 0;
            cmbLoai.SelectedIndex = 0;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            List<LOAITHUOC> lst = context.LOAITHUOCs.ToList();
            List<DVTINH> lstDVT = context.DVTINHs.ToList();
            List<LOTHUOC> listLoThuoc = context.LOTHUOCs.ToList();
            THUOC s = new THUOC();
            try
            {
                if (txtID.Text == "" || txtName.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                THUOC dbUpdate = context.THUOCs.FirstOrDefault(p => p.MATHUOC == txtID.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Mã Thuốc trùng. Chọn Yes để Update", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        dbUpdate.TENTHUOC = txtName.Text;
                        foreach (var item in lstDVT)
                            if (item.TENDVT == cmbDVT.Text)
                                dbUpdate.MADVT = item.MADVT;
                        dbUpdate.DONGIAMUA = int.Parse(txtGM.Text);
                        dbUpdate.DONGIABAN = int.Parse(txtGB.Text);
                        dbUpdate.SOLUONG = dbUpdate.SOLUONG;
                        foreach (var item in lst)
                            if (item.TENLOAI == cmbLoai.Text)
                                dbUpdate.MALOAITHUOC = item.MALOAITHUOC;
                        context.SaveChanges();
                        Form1_Load(sender, e);
                        reset();
                    }
                }
                else
                {
                    foreach (var tem in lst)
                        if (tem.TENLOAI == cmbLoai.Text)
                            foreach (var tam in lstDVT)
                                if (tam.TENDVT == cmbDVT.Text)
                                {
                                    s = new THUOC() { MATHUOC = txtID.Text, TENTHUOC = txtName.Text, MADVT = tam.MADVT, SOLUONG = 0, DONGIAMUA = int.Parse(txtGM.Text), DONGIABAN = int.Parse(txtGB.Text), MALOAITHUOC = tem.MALOAITHUOC };
                                }
                    context.THUOCs.Add(s);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            /*try
            {*/
                SetGridViewStyle(dgvThuoc);
                ModelQLThuoc context = new ModelQLThuoc();
                List<LOAITHUOC> listLoaiThuoc = context.LOAITHUOCs.ToList();
                List<THUOC> listThuoc = context.THUOCs.ToList();
                List<DVTINH> listDVT = context.DVTINHs.ToList();
                FillLoaiThuocCombobox(listLoaiThuoc);
                FillDVTCombobox(listDVT);
                BindGrid(listThuoc);
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            List<LOAITHUOC> lst1 = context.LOAITHUOCs.ToList();
            List<DVTINH> lstDVT = context.DVTINHs.ToList();
            DataGridViewRow row = new DataGridViewRow();
            txtID.Text = dgvThuoc.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvThuoc.Rows[e.RowIndex].Cells[1].Value.ToString();
            foreach (var item in lstDVT)
            {
                if (dgvThuoc.Rows[e.RowIndex].Cells[2].Value.ToString() == item.MADVT)
                {
                    cmbDVT.Text = item.TENDVT;
                }
            }
            txtGM.Text = dgvThuoc.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtGB.Text = dgvThuoc.Rows[e.RowIndex].Cells[5].Value.ToString();
            foreach (var item in lst1)
            {
                if (dgvThuoc.Rows[e.RowIndex].Cells[6].Value.ToString() == item.MALOAITHUOC)
                {
                    cmbLoai.Text = item.TENLOAI;
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
            List<PHIEUDATHANG> listDH = context.PHIEUDATHANGs.ToList();
            List<PHIEUNHAPKHO> listNK = context.PHIEUNHAPKHOes.ToList();
            List<PHIEUTHANHLI> listTL = context.PHIEUTHANHLIs.ToList();
            List<LOTHUOC> listLT = context.LOTHUOCs.ToList();
            THUOC dbDelete = context.THUOCs.FirstOrDefault(p => p.MATHUOC == txtID.Text);
            if (dbDelete != null)
            {
                if (MessageBox.Show("Bạn Có Muốn Xóa Thông Tin Này ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var item in listTL)
                        if (item.MATHUOC == txtID.Text)
                        {
                            context.PHIEUTHANHLIs.Remove(item);
                        }
                    foreach (var item in listXK) 
                        if (item.MATHUOC == txtID.Text)
                        {
                            context.PHIEUXUATKHOes.Remove(item);
                        }
                    foreach (var item in listNK)
                        if (item.MATHUOC == txtID.Text)
                        {
                            context.PHIEUNHAPKHOes.Remove(item);
                        }
                    foreach (var item in listDH)
                        if (item.MATHUOC == txtID.Text)
                        {
                            context.PHIEUDATHANGs.Remove(item);
                        }
                    foreach (var item in listLT)
                        if (item.MATHUOC == txtID.Text)
                        {
                            context.LOTHUOCs.Remove(item);
                        }
                    context.THUOCs.Remove(dbDelete);
                    context.SaveChanges();
                    Form1_Load(sender, e);
                    reset();
                }
            }
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvThuoc, @"D:\", "Danh Sách Thuốc");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

  

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            toolStripButton5.Visible = true;
            List<THUOC> listT = context.THUOCs.ToList();
            if (txtFind.Text != null)
            {
                dgvThuoc.Rows.Clear();
                foreach (var item in listT)
                {
                    if (item.MATHUOC.Contains(txtFind.Text) || item.TENTHUOC.Contains(txtFind.Text))
                    {
                        int index = dgvThuoc.Rows.Add();
                        dgvThuoc.Rows[index].Cells[0].Value = item.MATHUOC;
                        dgvThuoc.Rows[index].Cells[1].Value = item.TENTHUOC;
                        dgvThuoc.Rows[index].Cells[2].Value = item.MADVT;
                        dgvThuoc.Rows[index].Cells[3].Value = item.SOLUONG;
                        dgvThuoc.Rows[index].Cells[4].Value = item.DONGIAMUA;
                        dgvThuoc.Rows[index].Cells[5].Value = item.DONGIABAN;
                        if (item.LOAITHUOC != null)
                            dgvThuoc.Rows[index].Cells[6].Value = item.LOAITHUOC.TENLOAI;
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
            if ( !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '-')
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

  
    }
}
