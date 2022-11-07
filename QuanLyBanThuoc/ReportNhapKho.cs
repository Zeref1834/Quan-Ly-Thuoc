using Microsoft.Reporting.WinForms;
using QuanLyBanThuoc.ADO;
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
    public partial class ReportNhapKho : Form
    {
        public ReportNhapKho()
        {
            InitializeComponent();
        }

        private void ReportNhapKho_Load(object sender, EventArgs e)
        {
            ModelQLThuoc context = new ModelQLThuoc();
            List<PHIEUNHAPKHO> listXK = context.PHIEUNHAPKHOes.ToList();
            this.reportViewer1.LocalReport.ReportPath = @"D:\QuanLyBanThuoc\Code\QuanLyBanThuoc\Report\rptNhapKhoReport.rdlc";

            var reportDataSouce = new ReportDataSource("NhapKhoDataSet", listXK);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSouce);
            this.reportViewer1.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
