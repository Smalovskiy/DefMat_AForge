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
    public partial class DBExtensionsForm<T> : Form
         where T : class
    {
        DbSet<T> set;

        public DBExtensionsForm(DbSet<T> set)
        {
            InitializeComponent();

            this.set = set;
            set.Load();
            dGVExtension.DataSource = set.Local.ToBindingList();
        }

        private void ExitScreenButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DBExtensionsForm_Load(object sender, EventArgs e)
        {

        }

        public void copyAlltoClipboard()
        {
            dGVExtension.SelectAll();
            DataObject dataObj = dGVExtension.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void SaveDbbutton3_Click(object sender, EventArgs e)
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
