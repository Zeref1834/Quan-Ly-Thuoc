using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyBanThuoc
{
    public partial class FormDoiMK : Form
    {
        string username = FormXacNhan.to;
        public FormDoiMK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtresetMK.Text == txtxacnhanMK.Text)
            {
                SqlConnection con = new SqlConnection(@"data source=.\SQLEXPRESS;initial catalog=QLBANTHUOC1;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
                con.Open();
                string mk = txtresetMK.Text;
                String sqlDN = "UPDATE  NHANVIEN SET  MATKHAU  = '" + txtresetMK.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS WHERE TENDN like '" + username+ "'  COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlCommand cmd = new SqlCommand(sqlDN, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnlogin.Visible = true;
               con.Close();
            }
            else
            {
                MessageBox.Show("Xác nhận không giống mới mật khẩu mới", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            FormDoiMK fdmk = this;
            this.Hide();       
            FormDangNhap form = new FormDangNhap();
            form.Show();
            
        }

        private void FormDoiMK_Load(object sender, EventArgs e)
        {

        }
    }
}
