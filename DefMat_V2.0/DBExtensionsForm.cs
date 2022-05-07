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
    }
}
