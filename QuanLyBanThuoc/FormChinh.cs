using QuanLyBanThuoc.ADO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanThuoc
{
    public partial class FormChinh : Form
    {
        string username = FormDangNhap.user;
        public FormChinh()
        { 
            
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void tipmnuDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        
        }

        private void tipmnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

      

        private void NhanVien_Click(object sender, EventArgs e)
        {
            
            if (!CheckExistForm("FormNhanVien"))
            {

                FormNhanVien fnv = new FormNhanVien();
                fnv.MdiParent = this;
                fnv.Dock = DockStyle.Fill;
                fnv.Show();
            }
            else

                ActiveChildForm("FormNhanVien");
        }
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                   
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void tipPhieuNK_Click_1(object sender, EventArgs e)
        {

            if (!CheckExistForm("FormPhieuNhapKho"))
            {
                FormPhieuNhapKho fpnk = new FormPhieuNhapKho();
                fpnk.MdiParent = this;
                fpnk.Dock = DockStyle.Fill;
                fpnk.Show();
            }
            else
                ActiveChildForm("FormPhieuNhapKho");
        }

        private void KhachHang_Click(object sender, EventArgs e)
        {
    
            if (!CheckExistForm("FormKhachHang"))
            {
                FormKhachHang fkh = new FormKhachHang();
                fkh.MdiParent = this;
                fkh.Dock = DockStyle.Fill;
                fkh.Show();
            }
            else
                ActiveChildForm("FormKhachHang");
        }

        private void Kho_Click(object sender, EventArgs e)
        {
        
            if (!CheckExistForm("FormKho"))
            {
                FormKho fk = new FormKho();
                fk.MdiParent = this;
                fk.Dock = DockStyle.Fill;
                fk.Show();
            }
            else
                ActiveChildForm("FormKho");
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {
           
            btnuser.Text = username;     
            if(username == "admin" )
            {
                tipmnuNV.Enabled = true;
                tipbtnQLNV.Enabled = true;
            }
            FormChinh fc = new FormChinh();
        }



        private void NguoiThietKe_Click(object sender, EventArgs e)
        {
                FormThongTinNguoiTK ftt = new FormThongTinNguoiTK();
                ftt.Show();  
        }

     
        private List<Form> _children = new List<Form>();
        private void trangChủ_Click(object sender, EventArgs e)
        {
           
            Form[] childArray = this.MdiChildren;
            foreach (Form childForm in childArray)
            {
                childForm.Close();
            }
        }

        private void ThongKeNV_Click(object sender, EventArgs e)
        {
    
            if (!CheckExistForm("FormReportNhanVien"))
            {
                ReportNhanVien frptnv = new ReportNhanVien();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
                frptnv.ForeColor = Color.Black;
            }
            else
                ActiveChildForm("FormReportNhanVien");
        }

        private void Thanh_Lí_Click(object sender, EventArgs e)
        {
           
            if (!CheckExistForm("Thanh_Lí"))
            {
                Thanh_Lí frptnv = new Thanh_Lí();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("Thanh_Lí");
        }

        private void Xuất_Kho_Click(object sender, EventArgs e)
        {
            
            if (!CheckExistForm("Xuất_Kho"))
            {
                Xuất_Kho frptnv = new Xuất_Kho();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("Xuất_Kho");
        }

        private void Đặt_Hàng_Click(object sender, EventArgs e)
        {
        
            if (!CheckExistForm("Đặt_Hàng"))
            {
                Đặt_Hàng frptnv = new Đặt_Hàng();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("Đặt_Hàng");
        }

        private void btn_Thuoc_Click(object sender, EventArgs e)
        {
          
            if (!CheckExistForm("Thuốc"))
            {
                FormThuoc frptnv = new FormThuoc();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("Thuốc");
        }

        private void btn_LoThuoc_Click(object sender, EventArgs e)
        {
         
            if (!CheckExistForm("Lô_Thuốc"))
            {
                Lô_Thuốc frptnv = new Lô_Thuốc();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("Lô_Thuốc");
        }

        private void ReportDatHang_Click(object sender, EventArgs e)
        {
         
            if (!CheckExistForm("ReportDatHang"))
            {
                ReportDatHang frptnv = new ReportDatHang();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("ReportDatHang");
        }

        private void ReportThanhLi_Click(object sender, EventArgs e)
        {
         
            if (!CheckExistForm("ReportThanhLi"))
            {
                ReportThanhLi frptnv = new ReportThanhLi();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("ReportThanhLi");
        }

        private void ReportXuatKho_Click(object sender, EventArgs e)
        {
         
            if (!CheckExistForm("ReportXuatKho"))
            {
                ReportXuatKho frptnv = new ReportXuatKho();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("ReportXuatKho");
        }

        private void ReportThuoc_Click(object sender, EventArgs e)
        {
       
            if (!CheckExistForm("ReportThuoc"))
            {
                ReportThuoc frptnv = new ReportThuoc();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("ReportThuoc");
        }

        private void ReportNK_Click(object sender, EventArgs e)
        {
           
            if (!CheckExistForm("ReportNhapKho"))
            {
                ReportNhapKho frptnv = new ReportNhapKho();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("ReportNhapKho");
        }

        private void ReportKH_Click(object sender, EventArgs e)
        {
           
            if (!CheckExistForm("ReportKhachHang"))
            {
                ReportKhachHang frptnv = new ReportKhachHang();
                frptnv.MdiParent = this;
                frptnv.Dock = DockStyle.Fill;
                frptnv.Show();
            }
            else
                ActiveChildForm("ReportKhachHang");
        }

        private void tipmnuThongTinTK_Click(object sender, EventArgs e)
        {   
                FormThongTinTK dmk = new  QuanLyBanThuoc.FormThongTinTK();
                dmk.ShowDialog();

        }
    }
}
