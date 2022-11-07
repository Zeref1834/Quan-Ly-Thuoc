using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanThuoc
{
    public partial class FormDangNhap : Form
    {
        public static string user;
        public FormDangNhap()
        {
            InitializeComponent();
        }
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LSMSV6O;Initial Catalog=QLBANTHUOC1;Integrated Security=True");
                con.Open();
                string tk = txtTenDN.Text;
                string mk = txtMK.Text;
                user = txtTenDN.Text;
                String sqlDN = "SELECT * FROM NHANVIEN WHERE TENDN LIKE '" +tk + "'COLLATE SQL_Latin1_General_CP1_CS_AS AND MATKHAU LIKE '" + mk + "' COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlCommand cmd = new SqlCommand(sqlDN, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    

                    MessageBox.Show("Đăng Nhập Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                    FormChinh f = new FormChinh();
                    f.ShowDialog();
                    this.Close();

                }
                else if (txtTenDN.Text == "" || txtMK.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu! Vui Lòng Thử Lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            
            txtTenDN.Text = Properties.Settings.Default.UserName;
            txtMK.Text = Properties.Settings.Default.Password;
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblQuenMK_Click(object sender, EventArgs e)
        {
            FormXacNhan fgm = new FormXacNhan();
            this.Hide();
            fgm.ShowDialog();
            this.Show();
        }
        //Chặn các Kí Tự
        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar)& (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & (Keys)e.KeyChar!= Keys.Back & e.KeyChar != '-')
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

        private void hint_Click(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = false;
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
            hint.Visible = true;
        }

        private void hint_MouseLeave(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
