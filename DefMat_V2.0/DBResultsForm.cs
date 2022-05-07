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
    }
}
