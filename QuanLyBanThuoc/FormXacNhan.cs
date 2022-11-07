using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace QuanLyBanThuoc
{
    public partial class FormXacNhan : Form
    {
       

        public static string to;
        public FormXacNhan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {

        }
  

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"data source=.\SQLEXPRESS;initial catalog=QLBANTHUOC1;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            con.Open();
            string tk = txtTenDN.Text;
            String sqlDN = "SELECT * FROM NHANVIEN WHERE TENDN LIKE '" + tk + "'COLLATE SQL_Latin1_General_CP1_CS_AS AND MANV  LIKE '" +txtMaNV.Text +"' " ;
            SqlCommand cmd = new SqlCommand(sqlDN, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                to = txtTenDN.Text;
                FormDoiMK fdmk = new FormDoiMK();          
                this.Hide();
                fdmk.ShowDialog();
                this.Show();
            }
            else {
                MessageBox.Show("Sai Mã Nhân Viên hoặc Tên Đăng Nhập","Cảnh Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
             }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
