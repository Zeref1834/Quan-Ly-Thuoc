using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using app = Microsoft.Office.Interop.Excel.Application;
using app2 = Microsoft.Office.Interop.Word.Application;
namespace QuanLyBanThuoc.Excel
{
    class ClassExport
    {
        public void Export(DataGridView dt, string duongdan, string tentap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < dt.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = dt.Columns[i - 1].HeaderText;

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = dt.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        public void ExportW(DataGridView dtv,string duongdan,string tentap)
        {
            app2 obj = new app2();
            
        }
    }
}
