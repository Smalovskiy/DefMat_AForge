using DefMat_V2._0.Model;
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
using Microsoft.Office.Interop.Excel;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DefMat_V2._0
{
    public partial class DBMaterialForm<T> : Form
        where T : class
    {
        DbSet<T> set;
        DefMatContext db;

        public DBMaterialForm(DbSet<T> set)
        {
            InitializeComponent();

            this.set = set;
            db = new DefMatContext();
            db.Materials.Load();
            set.Load();
            dataGridView.DataSource = db.Materials.Local.ToBindingList();
            dataGridView.Columns["Results"].Visible = false;
            dataGridView.RowHeadersVisible = false;
        }
        
        private void ExitScreenButton_Click(object sender, EventArgs e)
        {
            Close();
 
        }

        private void DBMaterialForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void copyAlltoClipboard()
        {
            dataGridView.SelectAll();
            DataObject dataObj = dataGridView.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
                
        }

        private void SaveDbbutton2_Click(object sender, EventArgs e)
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
            xlWorkSheet.PasteSpecial(CR, false, false, Type.Missing, Type.Missing, Type.Missing, true);  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMaterialForm addMaterial = new AddMaterialForm();
            DialogResult result = addMaterial.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Materials material = new Materials();
            material.Material = addMaterial.textBox1.Text;
            if (string.IsNullOrEmpty(addMaterial.textBox2.Text))
            {
                addMaterial.textBox2.Text = "0";
            } else if (string.IsNullOrEmpty(addMaterial.textBox3.Text))
            {
                addMaterial.textBox3.Text = "0";
            }
            else
            {
                material.Thicksness = Convert.ToDouble(addMaterial.textBox2.Text);
                material.Density = Convert.ToDouble(addMaterial.textBox3.Text);
            }
           
            
            var results = new List<ValidationResult>();
            var context = new ValidationContext(material);
            if (!Validator.TryValidateObject(material, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                db.Materials.Add(material);
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Materials material = db.Materials.Find(id);

                AddMaterialForm addMaterial = new AddMaterialForm();

                addMaterial.textBox1.Text = material.Material;
                addMaterial.textBox2.Text = Convert.ToString(material.Thicksness);
                addMaterial.textBox3.Text = Convert.ToString(material.Density);

                DialogResult result = addMaterial.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                material.Material = addMaterial.textBox1.Text;
                material.Thicksness = Convert.ToDouble(addMaterial.textBox2.Text);
                material.Density = Convert.ToDouble(addMaterial.textBox3.Text);

                db.SaveChanges();
                dataGridView.Refresh(); 

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int index = dataGridView.SelectedRows[0].Index;
                int id;
                bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Materials material = db.Materials.Find(id);
                db.Materials.Remove(material);
                db.SaveChanges();

            }
        }
    }
}
