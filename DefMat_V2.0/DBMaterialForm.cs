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

        private void SaveDbbutton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMaterialForm addMaterial = new AddMaterialForm();
            DialogResult result = addMaterial.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Materials material = new Materials();
            material.Material = addMaterial.textBox1.Text;
            material.Density = Convert.ToDouble(addMaterial.textBox3.Text);

            db.Materials.Add(material);
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");

        }
    }
}
