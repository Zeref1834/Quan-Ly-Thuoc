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
    public partial class ReportXuatKho : Form
    {
        public ReportXuatKho()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void ReportXuatKho_Load(object sender, EventArgs e)
        {
            ModelQLThuoc context = new ModelQLThuoc();
            List<PHIEUXUATKHO> listXK = context.PHIEUXUATKHOes.ToList();
            this.reportViewer1.LocalReport.ReportPath = @"D:\QuanLyBanThuoc\Code\QuanLyBanThuoc\Report\XuatKhoReport.rdlc";

            var reportDataSouce = new ReportDataSource("XuatKhoDataSet", listXK);
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
