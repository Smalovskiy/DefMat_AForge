using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefMat_V2._0
{
    public partial class DBResultsForm<T> : Form
         where T : class
    {
        DbSet<T> set;

        public DBResultsForm(DbSet<T> set)
        {
            InitializeComponent();

            this.set = set;
            set.Load();
            dGVResults.DataSource = set.Local.ToBindingList();
        }

        private void ExitScreenButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DBResultsForm_Load(object sender, EventArgs e)
        {

        }

        public void copyAlltoClipboard()
        {
            dGVResults.SelectAll();
            DataObject dataObj = dGVResults.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void SaveDbbutton1_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Range CR = (Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}
