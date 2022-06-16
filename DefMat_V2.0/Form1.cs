using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using DefMat_V2._0.Model;

namespace DefMat_V2._0
{
    public partial class Form1 : Form
    {
        #region Init
        DefMatContext db;
        FilterInfoCollection device;
        Graphics graph;
        VideoCaptureDevice captureDevice;
        Bitmap bitmapEdgeImage, bitmapBinaryImage, bitmapGreyImage, bitmapBlurImage, colorFilterImage, BsourceFrame;
        EuclideanColorFiltering colorFilter = new EuclideanColorFiltering();

        SobelEdgeDetector edgeFilter = new SobelEdgeDetector();
        Font font = new Font("Times New Roman", 14, FontStyle.Bold);
        SolidBrush brush = new SolidBrush(Color.Black);
        Pen pictureboxPen = new Pen(Color.Black, 5);
        Pen greenPen = new Pen(Color.Green, 6);
        Pen greenLine = new Pen(Color.Green, 2);
        AForge.Point center;
        Blob[] blobPoints;
        Rectangle[] rects;
        List<int> pointsX = new List<int>();
        List<int> pointsY = new List<int>();

        bool clickInImage;
        float radius;
        int centroid_X;
        int centroid_Y;
        int ipenWidth = 2;
        int number;
        int iThreshold = 40, iRadius = 40;
        int iColorMode = 1, iRedValue = 220, iGreenValue = 30, iBlueValue = 30;
        bool blurFlag = false;
        float cr1_X, cr1_Y, cr2_X, cr2_Y, cr3_X, cr3_Y, cr4_X, cr4_Y;
        double longat = 0.264583;
        string p;

        #endregion
        public Form1()
        {
            InitializeComponent();
            db = new DefMatContext();
            numericUpDown1.Value = 2;
            textBox1.Text = "0,2645833333333";
        }
        #region Components
        private void sbGreenColor_Scroll(object sender, ScrollEventArgs e)
        {
           iGreenValue = sbGreenColor.Value;
        }

        private void sbBlueColor_Scroll(object sender, ScrollEventArgs e)
        {
           iBlueValue = sbBlueColor.Value;
        }

        private void sbRedColor_Scroll(object sender, ScrollEventArgs e)
        {
            iRedValue = sbRedColor.Value;
        }

        private void sbRadius_Scroll(object sender, ScrollEventArgs e)
        {
            iRadius = sbRadius.Value;
        }

        private void rbBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBlue.Checked == true)
            {
                iColorMode = 2;
                sbRadius.Value = 420;
                sbThreshold.Value = 250;
                iRadius = sbRadius.Value;
                iThreshold = sbThreshold.Value;

                sbRedColor.Value = 30;
                sbGreenColor.Value = 30;
                sbBlueColor.Value = 240;

            }
        }

        private void CloseCapture()
        {
            if (captureDevice != null)
            {
                captureDevice.Stop();
                captureDevice = null;
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
                pictureBox3.Image.Dispose();
                pictureBox3.Image = null;
                pictureBox4.Image.Dispose();
                pictureBox4.Image = null;
                rbRed.Checked = true;
                label7.Text = null;
                label8.Text = null;
                label18.Text = null;
                label17.Text = null;
                label13.Text = null;
                label14.Text = null;
                pointsX.Clear();
                pointsY.Clear();
                
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
              CloseCapture();
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGreen.Checked == true)
            {
                iColorMode = 3;
                sbRadius.Value = 420;
                sbThreshold.Value = 250;
                iRadius = sbRadius.Value;
                iThreshold = sbThreshold.Value;

                sbRedColor.Value = 5;
                sbGreenColor.Value = 240;
                sbBlueColor.Value = 5;

            }
        }

        private void cbBlur_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBlur.Checked)
                blurFlag = true;
            else
                blurFlag = false;
        }

        private void rbRed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRed.Checked == true)
            {
                iColorMode = 1;
                sbRadius.Value = 420;
                sbThreshold.Value = 250;
                iRadius = sbRadius.Value;
                iThreshold = sbThreshold.Value;

                sbRedColor.Value = 220;
                sbGreenColor.Value = 30;
                sbBlueColor.Value = 30;

            }
        }

        private void sbThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            iThreshold = sbThreshold.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value < 2 || numericUpDown1.Value > 4)
            {
                MessageBox.Show("Допустимый дипазон значений 2-4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Value = 2;
            }
            else
            {
                if (numericUpDown1.Value == 3)
                {
                    label9.Show();
                    label12.Show();
                    label13.Show();
                    label14.Show();
                    label7.Show();
                    label8.Show();
                    label10.Show();
                    label11.Show();
                    label15.Hide();
                    label16.Hide();
                    label17.Hide();
                    label18.Hide();
                }
                else if (numericUpDown1.Value == 4)
                {
                    label7.Hide();
                    label8.Hide();
                    label10.Hide();
                    label11.Hide();
                    label15.Show();
                    label16.Show();
                    label17.Show();
                    label18.Show();
                }
                else
                {
                    label7.Show();
                    label8.Show();
                    label10.Show();
                    label11.Show();
                    label9.Hide();
                    label12.Hide();
                    label13.Hide();
                    label14.Hide();
                    label15.Hide();
                    label16.Hide();
                    label17.Hide();
                    label18.Hide();
                }
            }
            
        }

        private void OpenGraphsFormButton_Click(object sender, EventArgs e)
        {
            GraphsForm graphs = new GraphsForm();
            graphs.Show();

        }

        private void OpenScreenshotsFormButton_Click(object sender, EventArgs e)
        {
            ScreenForm screen = new ScreenForm(BsourceFrame);
            screen.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)                   //Кнопка запуска видеопотока
        {
            try
            {
                SrartCameras(toolStripComboBox1.SelectedIndex);                           //Запуск потока с выбранной камеры
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                                              //Ошибка
            }
        }


        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checked {};
            var catalogMaterials = new DBMaterialForm<Materials>(db.Materials);
            catalogMaterials.Show();
        }

        protected void ExtensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogExtensoins = new DBExtensionsForm<Extensions>(db.Extensions);
            catalogExtensoins.Show();
        }

        protected void ResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogResults = new DBResultsForm<Results>(db.Results);
            catalogResults.Show();
        }
        #endregion
       

        private void SrartCameras(int deviceindex)                                        
        {
            try
            {
                captureDevice = new VideoCaptureDevice(device[deviceindex].MonikerString);
                captureDevice.VideoResolution = selectResolution(captureDevice);
                captureDevice.NewFrame += new NewFrameEventHandler(get_Frame);             
                captureDevice.Start();                                                    
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите видеоустройство","Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);                                              //Ошибка
            }
        }
        private static VideoCapabilities selectResolution(VideoCaptureDevice device)
        {
            foreach (var cap in device.VideoCapabilities)
            {
                if (cap.FrameSize.Height == 480)
                    return cap;
                if (cap.FrameSize.Width == 640)
                    return cap;
            }
            return device.VideoCapabilities.Last();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы действительно хотите выйти из программы?", "Завершение программы", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                device = new FilterInfoCollection(FilterCategory.VideoInputDevice);        //Вывод списка камер в ComboBox 
                for (var i = 0; i < device.Count; i++)
                    toolStripComboBox1.Items.Add(device[i].Name);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void get_Frame(object sender, NewFrameEventArgs eventArgs)                
        {
            BsourceFrame = (Bitmap)eventArgs.Frame.Clone();                               
            pictureBox1.Image = BlobDetection(BsourceFrame);                              
            pictureBox2.Image = bitmapEdgeImage;                                          
            pictureBox3.Image = bitmapBinaryImage;
            pictureBox4.Image = colorFilterImage;

        }

        #region BlobDetection
        private Bitmap BlobDetection(Bitmap bitmapSourceImage)                           
        {     
            switch (iColorMode)                                                           
            {
                case 1:
                    iRedValue = sbRedColor.Value;
                    iBlueValue = sbBlueColor.Value;
                    iGreenValue = sbGreenColor.Value;

                    colorFilter.CenterColor = new RGB((byte)iRedValue, (byte)iGreenValue, (byte)iBlueValue);
                    colorFilter.Radius = (short)iRadius;
                    colorFilterImage = colorFilter.Apply(bitmapSourceImage);
                    break;
                case 2:
                    iRedValue = sbRedColor.Value;
                    iBlueValue = sbBlueColor.Value;
                    iGreenValue = sbGreenColor.Value;

                    colorFilter.CenterColor = new RGB((byte)iRedValue, (byte)iGreenValue, (byte)iBlueValue);
                    colorFilter.Radius = (short)iRadius;
                    colorFilterImage = colorFilter.Apply(bitmapSourceImage);
                    break;
                case 3:
                    iRedValue = sbRedColor.Value;
                    iBlueValue = sbBlueColor.Value;
                    iGreenValue = sbGreenColor.Value;

                    colorFilter.CenterColor = new RGB((byte)iRedValue, (byte)iGreenValue, (byte)iBlueValue);
                    colorFilter.Radius = (short)iRadius;
                    colorFilterImage = colorFilter.Apply(bitmapSourceImage);
                    break;
            }

            Grayscale grayscale = new Grayscale(0.2125, 0.7154, 0.0721);                          
            bitmapGreyImage = grayscale.Apply(colorFilterImage);                                 

            if (blurFlag == true)                                                                 
            {
                GaussianBlur blurfilter = new GaussianBlur(0.7);                                  
                bitmapBlurImage = blurfilter.Apply(bitmapGreyImage);                              
                bitmapEdgeImage = edgeFilter.Apply(bitmapBlurImage);
            }
            else if (blurFlag == false)                                                           
            {
                bitmapEdgeImage = edgeFilter.Apply(bitmapGreyImage);                              
            }

            Threshold threshold = new Threshold(iThreshold);                                      
            bitmapBinaryImage = threshold.Apply(bitmapEdgeImage);                                

            BlobCounter blobCounter = new BlobCounter                                             
            {                                                                                     
                MinWidth = 20,
                MinHeight = 20,
                FilterBlobs = true
                
            };

            blobCounter.ProcessImage(bitmapBinaryImage);                                          

            blobPoints = blobCounter.GetObjectsInformation();                                    
            graph = Graphics.FromImage(bitmapSourceImage);                                        
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();                          

            for (int i = 0; i < blobPoints.Length; i++)
            {
                List<IntPoint> edgePoint = blobCounter.GetBlobsEdgePoints(blobPoints[i]);         
                                                                                                  

                if (shapeChecker.IsCircle(edgePoint, out center, out radius))                     
                {

                    graph.DrawEllipse(pictureboxPen, pictureBox1.Size.Width, pictureBox1.Size.Height, 5, 5);
                    rects = blobCounter.GetObjectsRectangles();
                    Pen pen = new Pen(Color.Red, ipenWidth);
                    
                    int x = (int)center.X;
                    int y = (int)center.Y;

                    graph.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);

                    centroid_X = (int)blobPoints[i].CenterOfGravity.X;
                    centroid_Y = (int)blobPoints[i].CenterOfGravity.Y;

                    graph.DrawEllipse(pen, centroid_X, centroid_Y, 1, 1);

                    graph.DrawString(("P")+ Convert.ToString(i + 1), font, brush, x, y + 15);
                    graph.DrawString(("X:") + rects[i].X.ToString(), font, brush, x, y + 35);
                    graph.DrawString(("Y:") + rects[i].Y.ToString(), font, brush, x, y + 55);

                }

                try
                {
                    MarkerPoints();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    //CloseCapture();

                }
                

            }

            return bitmapSourceImage;
        }
        #endregion
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(rects is null)
            {
                MessageBox.Show("Ни одной точки не было найдено", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                for (number = 0; number < rects.Length; number++)
                {

                    clickInImage = rects[number].Contains(e.Location);

                    if (clickInImage == true)
                    {
                        pointsX.Add((int)(blobPoints[number].CenterOfGravity.X));
                        pointsY.Add((int)(blobPoints[number].CenterOfGravity.Y));
                    }
                }

                if (pointsX.Count == 2 )
                {
                    label7.Text = Convert.ToString((Math.Sqrt(Math.Pow(pointsX[0] - pointsX[1], 2) + Math.Pow(pointsY[0] - pointsY[1], 2))) * longat);
                } else if(pointsX.Count == 3)
                {
                    label14.Text = Convert.ToString((Math.Sqrt(Math.Pow(pointsX[1] - pointsX[2], 2) + Math.Pow(pointsY[1] - pointsY[2], 2))) * longat);
                } else if(pointsX.Count == 4 && numericUpDown1.Value == 4)
                {
                    label14.Text = Convert.ToString((Math.Sqrt(Math.Pow(pointsX[1] - pointsX[2], 2) + Math.Pow(pointsY[1] - pointsY[2], 2))) * longat);
                    label17.Text = Convert.ToString((Math.Sqrt(Math.Pow(pointsX[0] - pointsX[3], 2) + Math.Pow(pointsY[0] - pointsY[3], 2))) * longat);
                }
            }
        }
        private void OpenResultsFormButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label7.Text))
            {
                MessageBox.Show("Точки не были выбраны", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (pointsX.Count == 2)
                {
                    label8.Text = Convert.ToString((Math.Sqrt(Math.Pow(cr1_X - cr2_X, 2) + Math.Pow(cr1_Y - cr2_Y, 2))) * longat);
                } else if(pointsX.Count == 3)
                {
                    label8.Text = Convert.ToString((Math.Sqrt(Math.Pow(cr1_X - cr2_X, 2) + Math.Pow(cr1_Y - cr2_Y, 2))) * longat);
                    label13.Text = Convert.ToString((Math.Sqrt(Math.Pow(cr2_X - cr3_X, 2) + Math.Pow(cr2_Y - cr3_Y, 2))) * longat);

                }
                else if (pointsX.Count == 4 && numericUpDown1.Value == 4)
                {
                    label13.Text = Convert.ToString((Math.Sqrt(Math.Pow(cr2_X - cr3_X, 2) + Math.Pow(cr2_Y - cr3_Y, 2))) * longat);
                    label18.Text = Convert.ToString((Math.Sqrt(Math.Pow(cr1_X - cr4_X, 2) + Math.Pow(cr1_Y - cr4_Y, 2))) * longat);

                }


                //Extensions extensions = new Extensions();
                //extensions.Longation = Math.Round(Convert.ToDouble(label8.Text) - Convert.ToDouble(label7.Text),3);
                //db.Extensions.Add(extensions);
                //db.SaveChanges();
            }
        }
               
        private void MarkerPoints()
        {
            if (blobPoints.Length >= 2)
            {
                cr1_X = blobPoints[0].CenterOfGravity.X;
                cr1_Y = blobPoints[0].CenterOfGravity.Y;
                cr2_X = blobPoints[1].CenterOfGravity.X;
                cr2_Y = blobPoints[1].CenterOfGravity.Y;
            }
            

            if (numericUpDown1.Value == 2 && blobPoints.Length >= 2 && pointsX.Count == 2)
            {
                
                graph.DrawEllipse(greenPen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                graph.DrawLine(greenLine, cr1_X, cr1_Y, cr2_X, cr2_Y);

            }
            else if (numericUpDown1.Value == 3 && blobPoints.Length >= 3 && pointsX.Count == 3)
            {
                
                cr3_X = blobPoints[2].CenterOfGravity.X;
                cr3_Y = blobPoints[2].CenterOfGravity.Y;
                graph.DrawEllipse(greenPen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                graph.DrawLine(greenLine, cr1_X, cr1_Y, cr2_X, cr2_Y);
                graph.DrawLine(greenLine, cr2_X, cr2_Y, cr3_X, cr3_Y);

            }
            else if (numericUpDown1.Value == 4 && blobPoints.Length >= 4 && pointsX.Count == 4)
            {

                cr3_X = blobPoints[2].CenterOfGravity.X;
                cr3_Y = blobPoints[2].CenterOfGravity.Y;
                cr4_X = blobPoints[3].CenterOfGravity.X;
                cr4_Y = blobPoints[3].CenterOfGravity.Y;
                graph.DrawEllipse(greenPen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                graph.DrawLine(greenLine, cr1_X, cr1_Y, cr4_X, cr4_Y);
                graph.DrawLine(greenLine, cr2_X, cr2_Y, cr3_X, cr3_Y);
            }
        }
    }
}
