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
    public partial class FormKho : Form
    {
        public FormKho()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void FormKho_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvKho);
                ModelQLThuoc context = new ModelQLThuoc();
                List<KHO> listKho = context.KHOes.ToList();
                BindGrid(listKho);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindGrid(List<KHO> listKho)
        {
            dgvKho.Rows.Clear();
            foreach (var item in listKho)
            {
                int index = dgvKho.Rows.Add();
                dgvKho.Rows[index].Cells[0].Value = item.MAKHO;
                dgvKho.Rows[index].Cells[1].Value = item.TENKHO;
                dgvKho.Rows[index].Cells[2].Value = item.DIADIEM;
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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            List<KHO> lst = context.KHOes.ToList();
            KHO s = new KHO();
            try
            {
                if (txtMakho.Text == "" || txtTenkho.Text == ""||TxtDiaDiem.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                KHO dbUpdate = context.KHOes.FirstOrDefault(p => p.MAKHO == txtMakho.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Mã kho bị trùng. Chọn Yes để cập Nhật", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dbUpdate.TENKHO = txtTenkho.Text;
                        dbUpdate.DIADIEM = TxtDiaDiem.Text;
                        context.SaveChanges();
                        FormKho_Load(sender, e);
                        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset(); 

                    }

                }
                else
                {
                    s = new KHO() { MAKHO = txtMakho.Text, TENKHO = txtTenkho.Text, DIADIEM = TxtDiaDiem.Text };
                    context.KHOes.Add(s);
                    context.SaveChanges();
                    FormKho_Load(sender, e);
                    MessageBox.Show("Thêm Dữ Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> temp = new List<string>();
            if(e.RowIndex < 0) {
                return;    
            }
            txtMakho.Text = dgvKho.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenkho.Text = dgvKho.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtDiaDiem.Text = dgvKho.Rows[e.RowIndex].Cells[2].Value.ToString();
  

        }
        private void reset()
        {
            txtTenkho.Text = "";
            txtMakho.Text = "";
            TxtDiaDiem.Text = "";
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtMakho.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                KHO dbDelete = context.KHOes.FirstOrDefault(p => p.MAKHO == txtMakho.Text);
                if (dbDelete != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
                        List<PHIEUNHAPKHO> listNK = context.PHIEUNHAPKHOes.ToList();
                        List<PHIEUTHANHLI> listTL = context.PHIEUTHANHLIs.ToList();
                        foreach (var item in listXK)
                            if (item.MAKHO == txtMakho.Text)
                            {
                                context.PHIEUXUATKHOes.Remove(item);
                            }
                        foreach (var tam in listNK)
                            if (tam.MAKHO == txtMakho.Text)
                            {
                                context.PHIEUNHAPKHOes.Remove(tam);
                            }
                        foreach (var tl in listTL)
                            if (tl.MAKHO == txtMakho.Text)
                            {
                                context.PHIEUTHANHLIs.Remove(tl);
                            }
                        context.KHOes.Remove(dbDelete);
                        reset();
                        context.SaveChanges();
                        FormKho_Load(sender, e);
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
        private void FormKho_FormClosing(object sender, FormClosingEventArgs e)
        {

        }



        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFind.Text != null)
                {
                    btnXoachu.Visible = true;
                    dgvKho.Rows.Clear();
                    List<KHO> listKho = context.KHOes.ToList();
                    foreach (var item in listKho)
                    {
                        if (item.MAKHO.Contains(txtFind.Text) || item.TENKHO.Contains(txtFind.Text))
                        {

                            int index = dgvKho.Rows.Add();
                            dgvKho.Rows[index].Cells[0].Value = item.MAKHO;
                            dgvKho.Rows[index].Cells[1].Value = item.TENKHO;
                            dgvKho.Rows[index].Cells[2].Value = item.DIADIEM;
                        }


                    }
                }
                if (txtFind.Text == "" || txtFind.Text == " Tìm Kiếm")
                {
                    FormKho_Load(sender, e);
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
                FormKho_Load(sender, e);
                btnXoachu.Visible = false;
            }
        }

        private void btnXoaChu_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            FormKho_Load(sender, e);
            btnXoachu.Visible = false;
        }

        private void FormKho_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Tìm Kiếm";
            btnXoachu.Visible = false;
            FormKho_Load(sender, e);
        }

      

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                ClassExport export = new ClassExport();
                export.Export(dgvKho, @"D:\", "Danh Sách Kho");
                MessageBox.Show("Xuất ra file excel thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMakho_KeyPress(object sender, KeyPressEventArgs e)
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
