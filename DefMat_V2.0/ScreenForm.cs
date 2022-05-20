using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using Image = System.Drawing.Image;
using System.IO;

namespace DefMat_V2._0
{
    public partial class ScreenForm : Form
    {
        private Bitmap image = null;

        private string filename;

        public ScreenForm(Image image)
        {
            this.image = (Bitmap)image;
            InitializeComponent();
        }
        
        private void ExitScreenButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            filename = $"WCVC_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.jpg";
            if(image is null)
            {
                MessageBox.Show("Убедитесь, что изображение выведено на экран", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ScreenPB.Image = image;
            }
        }

        private void SaveScreenButton_Click(object sender, EventArgs e)
        {
            string filedate = DateTime.Now.ToShortDateString();

            string basepath = AppDomain.CurrentDomain.BaseDirectory;

            string newpath = Path.Combine(basepath, filedate);

            if (!Directory.Exists(newpath))
            {
                try
                {
                    Directory.CreateDirectory(newpath);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);

                    throw ex;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                }
            }

            SaveFileDialog sd = new SaveFileDialog();

            sd.InitialDirectory = newpath;
            string filename = filedate + "_" + DateTime.Now.ToLongTimeString().Replace(':', '-');
            sd.FileName = filename;
            sd.Filter = "JPEG image (.jpg)|*.jpg|Все файлы (*.*)|*.*";
            sd.Title = "Укажите имя файла для сохранения:";

            if (sd.ShowDialog() == DialogResult.OK)
            {
                string newfilename = sd.FileName;
                ScreenPB.Image.Save(newfilename, ImageFormat.Jpeg);
                Close();
            }
        }
    }
}
