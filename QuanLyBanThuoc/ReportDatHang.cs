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
    public partial class ReportDatHang : Form
    {
        public ReportDatHang()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void ReportDatHang_Load(object sender, EventArgs e)
        {

            ModelQLThuoc context = new ModelQLThuoc();
            List<PHIEUDATHANG> listXK = context.PHIEUDATHANGs.ToList();
            this.reportViewer1.LocalReport.ReportPath = @"D:\QuanLyBanThuoc\Code\QuanLyBanThuoc\Report\DatHangReport.rdlc";

            var reportDataSouce = new ReportDataSource("DatHangDataSet", listXK);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSouce);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
