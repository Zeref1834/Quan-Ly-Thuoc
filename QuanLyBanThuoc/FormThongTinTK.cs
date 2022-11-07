using QuanLyBanThuoc.ADO;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanThuoc
{
   

    public partial class FormThongTinTK : Form
    {
        string username = FormDangNhap.user;
        ModelQLThuoc context = new ModelQLThuoc();
        public FormThongTinTK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormThongTinTK.ActiveForm.Close();
        }

        private void FormThongTinTK_Load(object sender, EventArgs e)
        {
            try 
            {
                
                ModelQLThuoc context = new ModelQLThuoc();
                NHANVIEN NV = new NHANVIEN();
                NHANVIEN dbUpdate = context.NHANVIENs.FirstOrDefault(p => p.TENDN == username);
                List<NHANVIEN> lst = new List<NHANVIEN>();
                if (dbUpdate != null)
                {
                    textBox5.Text = username;
                    textBox4.Text = dbUpdate.HOTENNV;
                    textBox1.Text = dbUpdate.MATKHAU;
                    textBox2.Text = dbUpdate.NGAYSINH.ToString();
                    textBox3.Text = dbUpdate.GIOITINH;
                    if(dbUpdate.HINHANH == "")
                    {
                        MessageBox.Show("Nhân Viên Này Chưa Có Hình!", "Thông Bấo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pictureBox1.Image = pictureBox1.ErrorImage;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox1.Image = Image.FromFile(dbUpdate.HINHANH);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
             
               
            
        }


        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {   
                List<NHANVIEN> lst = context.NHANVIENs.ToList();
                NHANVIEN s = new NHANVIEN();
                NHANVIEN dbUpdate = context.NHANVIENs.FirstOrDefault(p => p.TENDN == textBox5.Text);
                if (dbUpdate != null)
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn lưu thông tin không!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dbUpdate.MATKHAU = textBox1.Text;
                        dbUpdate.GIOITINH = textBox3.Text;
                        dbUpdate.NGAYSINH = DateTime.Parse(textBox2.Text);
                        context.SaveChanges();
                        FormThongTinTK_Load(sender, e);
                        MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
    }
}
