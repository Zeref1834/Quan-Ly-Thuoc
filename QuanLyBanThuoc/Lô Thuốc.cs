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
    public partial class Lô_Thuốc : Form
    {
        public Lô_Thuốc()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvLoThuoc);
                ModelQLThuoc context = new ModelQLThuoc();
                List<THUOC> listThuoc = context.THUOCs.ToList();
                List<LOTHUOC> listLoThuoc = context.LOTHUOCs.ToList();
                FillMaThuocCombobox(listThuoc);
                BindGrid(listLoThuoc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillMaThuocCombobox(List<THUOC> listThuoc)
        {
            this.cmbMT.DataSource = listThuoc;
            this.cmbMT.DisplayMember = "TENTHUOC";
            this.cmbMT.ValueMember = "MATHUOC";
        }
        private void BindGrid(List<LOTHUOC> listLoThuoc)
        {
            dgvLoThuoc.Rows.Clear();
            foreach (var item in listLoThuoc)
            {
                int index = dgvLoThuoc.Rows.Add();
                dgvLoThuoc.Rows[index].Cells[0].Value = item.MALO;
                dgvLoThuoc.Rows[index].Cells[1].Value = item.TENLO;
                dgvLoThuoc.Rows[index].Cells[2].Value = item.NGAYSX;
                dgvLoThuoc.Rows[index].Cells[3].Value = item.NGAYHH;
                dgvLoThuoc.Rows[index].Cells[4].Value = item.SOLUONG;
                if (item.THUOC != null)
                    dgvLoThuoc.Rows[index].Cells[5].Value = item.THUOC.MATHUOC;
                dgvLoThuoc.Rows[index].Cells[6].Value = (item.THUOC.DONGIAMUA * item.SOLUONG);
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
            txtSL.Text = "";
            txtNSX.Text = default;
            txtNHH.Text = default;
            cmbMT.SelectedIndex = 0;
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            /*List<THUOC> lst = context.THUOCs.ToList();*/
            List<LOTHUOC> lstLT = context.LOTHUOCs.ToList();
            /*THUOC dbUpdateT = context.THUOCs.FirstOrDefault(p => p.TENTHUOC == cmbMT.Text);*/
            LOTHUOC dbDelete = context.LOTHUOCs.FirstOrDefault(p => p.MALO == txtID.Text);
            if (dbDelete != null)
            {
                /*foreach(var item in lstLT)
                {
                    foreach (var tem in lst)
                        if (tem.MATHUOC == cmbMT.Text)
                        {
                            dbUpdateT.SOLUONG = tem.SOLUONG - item.SOLUONG;
                        }
                }*/
                context.LOTHUOCs.Remove(dbDelete);
                context.SaveChanges();
                Form1_Load(sender, e);
                reset();
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            List<THUOC> lst = context.THUOCs.ToList();
            List<LOTHUOC> lstLT = context.LOTHUOCs.ToList();
            LOTHUOC s = new LOTHUOC();
            try
            {
                if (txtID.Text == "" || txtName.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                LOTHUOC dbUpdate = context.LOTHUOCs.FirstOrDefault(p => p.MALO == txtID.Text);
                THUOC dbUpdateT = context.THUOCs.FirstOrDefault(p => p.TENTHUOC == cmbMT.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Mã Lô Thuốc trùng. Chọn Yes để Update", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        dbUpdate.TENLO = txtName.Text;
                        dbUpdate.NGAYSX = DateTime.Parse(txtNSX.Text);
                        dbUpdate.NGAYHH = DateTime.Parse(txtNHH.Text);
                        dbUpdate.SOLUONG = int.Parse(txtSL.Text);
                        foreach (var item in lst)
                            if (item.TENTHUOC == cmbMT.Text)
                            {
                                dbUpdate.MATHUOC = item.MATHUOC;
                                dbUpdate.THANHTIEN = (int.Parse(txtSL.Text) * item.DONGIAMUA);
                            }
                        /*foreach (var tem in lst)
                            if (tem.TENTHUOC == cmbMT.Text)
                            {
                                dbUpdateT.SOLUONG = 0; 
                            }*/
                        /*foreach (var tem in lst)
                            if (tem.TENTHUOC == cmbMT.Text)
                                foreach (var tam in lstLT)
                                    if (tam.MATHUOC == tem.MATHUOC)
                                    {
                                        dbUpdateT.SOLUONG = tem.SOLUONG + tam.SOLUONG;
                                    }*/
                        context.SaveChanges();
                        Form1_Load(sender, e);
                        reset();
                    }
                }
                else
                {
                    foreach (var tem in lst)
                        if (tem.TENTHUOC == cmbMT.Text)
                        {
                            s = new LOTHUOC() { MALO = txtID.Text, TENLO = txtName.Text, NGAYSX = DateTime.Parse(txtNSX.Text), NGAYHH = DateTime.Parse(txtNHH.Text), SOLUONG = int.Parse(txtSL.Text), MATHUOC = tem.MATHUOC, THANHTIEN = (int.Parse(txtSL.Text) * tem.DONGIAMUA) };
                            dbUpdateT.SOLUONG = tem.SOLUONG + int.Parse(txtSL.Text);
                        }
                    context.LOTHUOCs.Add(s);
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

        private void dgvLoThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            List<THUOC> list2 = context.THUOCs.ToList();
            DataGridViewRow row = new DataGridViewRow();
            txtID.Text = dgvLoThuoc.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvLoThuoc.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNSX.Text = dgvLoThuoc.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNHH.Text = dgvLoThuoc.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSL.Text = dgvLoThuoc.Rows[e.RowIndex].Cells[4].Value.ToString();
            foreach (var tam in list2)
            {
                if (dgvLoThuoc.Rows[e.RowIndex].Cells[5].Value.ToString() == tam.MATHUOC)
                {
                    cmbMT.Text = tam.TENTHUOC;
                }
            }
        }

        private void Excel_Click(object sender, EventArgs e)
        {

            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvLoThuoc, @"D:\", "Danh Sách Lô Thuốc");
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
            List<LOTHUOC> listT = context.LOTHUOCs.ToList();
            if (txtFind.Text != null)
            {
                dgvLoThuoc.Rows.Clear();
                foreach (var item in listT)
                {
                    if (item.MALO.Contains(txtFind.Text) ||item.TENLO.Contains(txtFind.Text)|| item.MATHUOC.Contains(txtFind.Text))
                    {
                        int index = dgvLoThuoc.Rows.Add();
                        dgvLoThuoc.Rows[index].Cells[0].Value = item.MALO;
                        dgvLoThuoc.Rows[index].Cells[1].Value = item.TENLO;
                        dgvLoThuoc.Rows[index].Cells[2].Value = item.NGAYSX;
                        dgvLoThuoc.Rows[index].Cells[3].Value = item.NGAYHH;
                        dgvLoThuoc.Rows[index].Cells[4].Value = item.SOLUONG;
                        dgvLoThuoc.Rows[index].Cells[6].Value = item.THANHTIEN;
                        if (item.THUOC != null)
                            dgvLoThuoc.Rows[index].Cells[5].Value = item.THUOC.MATHUOC;
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
