using Microsoft.Reporting.WinForms;
using QuanLyBanThuoc.ADO;
using QuanLyBanThuoc.ClassReport;
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
    public partial class FormReportNhanVien : Form
    {
        public FormReportNhanVien()
        {
            InitializeComponent();
        }

        private void FormReportNhanVien_Load(object sender, EventArgs e)
        {
            ModelQLThuoc context = new ModelQLThuoc();
            List<NHANVIEN> listnhanvien = context.NHANVIENs.ToList();
            List<ClassNhanVienReport> listReport = new List<ClassNhanVienReport>();
            foreach (NHANVIEN i in listnhanvien)
            {
                ClassNhanVienReport temp = new ClassNhanVienReport();
                temp.MANV = i.MANV;
                temp.HOTENNV = i.HOTENNV;
                temp.GIOITINH = i.GIOITINH;
                temp.NGAYSINH = i.NGAYSINH;
                temp.DIACHI = i.DIACHI;
                temp.DIENTHOAI = i.DIENTHOAI;
                temp.LUONG = i.LUONG;
                temp.TENLOAINV = i.TENLOAINV;
                listReport.Add(temp);
            }

            this.reportViewer1.LocalReport.ReportPath = "D:\\Lập trình trên Windows\\Đồ Án\\QuanLyBanThuoc\\Code\\QuanLyBanThuoc\\Report\\rptNhanVienReport.rdlc";
            var reportDataSource = new ReportDataSource("NhanVienDataSet", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();

        }
    }
}
