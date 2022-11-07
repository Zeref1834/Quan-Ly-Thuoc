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
    public partial class ReportThanhLi : Form
    {
        public ReportThanhLi()
        {
            InitializeComponent();
        }
        ModelQLThuoc context = new ModelQLThuoc();
        private void ReportThanhLi_Load(object sender, EventArgs e)
        {
            ModelQLThuoc context = new ModelQLThuoc();
            List<PHIEUTHANHLI> listXK = context.PHIEUTHANHLIs.ToList();
            this.reportViewer1.LocalReport.ReportPath = @"D:\QuanLyBanThuoc\Code\QuanLyBanThuoc\Report\ThanhLiReport.rdlc";

            var reportDataSouce = new ReportDataSource("ThanhLiDataSet", listXK);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSouce);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
