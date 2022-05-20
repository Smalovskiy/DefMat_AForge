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
        Pen pictureboxPen = new Pen(Color.Black, 5);
        Pen greenPen = new Pen(Color.Green, 6);
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
        int iThreshold = 40, iRadius = 40;
        int iColorMode = 1, iRedValue = 220, iGreenValue = 30, iBlueValue = 30;
        bool blurFlag = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
            db = new DefMatContext();
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
                sbRadius.Value = 180;
                iRadius = sbRadius.Value;

                sbRedColor.Value = 30;
                sbGreenColor.Value = 30;
                sbBlueColor.Value = 240;

            }
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
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
                }
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
                sbRadius.Value = 180;
                iRadius = sbRadius.Value;

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
                sbRadius.Value = 100;
                iRadius = sbRadius.Value;

                sbRedColor.Value = 220;
                sbGreenColor.Value = 30;
                sbBlueColor.Value = 30;

            }
        }

        private void sbThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            iThreshold = sbThreshold.Value;
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
       

        private void SrartCameras(int deviceindex)                                        //Метод выбора камеры из списка доступных
        {
            try
            {
                captureDevice = new VideoCaptureDevice(device[deviceindex].MonikerString);//Создание эксземпляра класса VideoCapture
                //captureDevice.VideoResolution = captureDevice.VideoCapabilities[19];
                captureDevice.VideoResolution = selectResolution(captureDevice);
                captureDevice.NewFrame += new NewFrameEventHandler(get_Frame);            // обработка события 
                captureDevice.Start();                                                    //старт потока видео
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

        private void get_Frame(object sender, NewFrameEventArgs eventArgs)                // Метод захвата изображения 
        {
            BsourceFrame = (Bitmap)eventArgs.Frame.Clone();                               // Обьект Bitmap изображения
            pictureBox1.Image = BlobDetection(BsourceFrame);                              // Главное изображение 
            pictureBox2.Image = bitmapEdgeImage;                                          // pB2 - pB4 вспомогательное изображение 
            pictureBox3.Image = bitmapBinaryImage;
            pictureBox4.Image = colorFilterImage;

        }

        //private double FindCamDistance(int pixel)
        //{
        //    double distance;
        //    double objectWidth = 10, focalLength = 604.8;

        //    distance = (objectWidth * focalLength) / pixel;
        //    return distance;

        //}

        #region BlobDetection
        private Bitmap BlobDetection(Bitmap bitmapSourceImage)                            //Метод обнаружения обьектов 
        {     
            switch (iColorMode)                                                           //Конструкция для переключения цветовой палитры
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

            Grayscale grayscale = new Grayscale(0.2125, 0.7154, 0.0721);                          //Градации серого изображения
            bitmapGreyImage = grayscale.Apply(colorFilterImage);                                  // Создание бинарного изображения в сером фильтре

            if (blurFlag == true)                                                                 //если блюр вкл
            {
                GaussianBlur blurfilter = new GaussianBlur(1.5);                                  //Размытие по Гаусу
                bitmapBlurImage = blurfilter.Apply(bitmapGreyImage);                              
                bitmapEdgeImage = edgeFilter.Apply(bitmapBlurImage);
            }
            else if (blurFlag == false)                                                           //если блюр выкл
            {
                bitmapEdgeImage = edgeFilter.Apply(bitmapGreyImage);                              //дефолт
            }

            Threshold threshold = new Threshold(iThreshold);                                      //обьект для бинаризации изображения с порогом
            bitmapBinaryImage = threshold.Apply(bitmapEdgeImage);                                

            BlobCounter blobCounter = new BlobCounter                                             //обьект для подсчёта Blobs 
            {                                                                                     //c определенными параметрами
                MinWidth = 10,
                MinHeight = 10,
                FilterBlobs = true
            };

            blobCounter.ProcessImage(bitmapBinaryImage);                                          //Подсчёт неообработанных изображений

            blobPoints = blobCounter.GetObjectsInformation();                                     //Создание массива из необработанных обьектов
            graph = Graphics.FromImage(bitmapSourceImage);                                        //Создание обьекта для рисования
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();                           //Обьект для обнаружения фигуры

            for (int i = 0; i < blobPoints.Length; i++)
            {
                List<IntPoint> edgePoint = blobCounter.GetBlobsEdgePoints(blobPoints[i]);         //Запись в List краевых точек блоба 
                                                                                                  //для последующей проверки

                if (shapeChecker.IsCircle(edgePoint, out center, out radius))                     //Елси круг то..
                {
                    graph.DrawEllipse(pictureboxPen, pictureBox1.Size.Width, pictureBox1.Size.Height, 10, 10); //рисуем эллипс в пределах pB

                    rects = blobCounter.GetObjectsRectangles();
                    Pen pen = new Pen(Color.Red, ipenWidth);
                    //string shapeString = "" + shapeChecker.CheckShapeType(edgePoint);
                    int x = (int)center.X;
                    int y = (int)center.Y;

                  if (pointsX.Count >= 2)
                  {     
                      graph.DrawEllipse(greenPen, center.X - radius, center.Y - radius, radius * 2, radius * 2);       //Рисуем найденные окружности
                  }
                  else
                  {
                      graph.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);       //Рисуем найденные окружности
                  }      
                    

                    centroid_X = (int)blobPoints[i].CenterOfGravity.X;
                    centroid_Y = (int)blobPoints[i].CenterOfGravity.Y;

                    graph.DrawEllipse(pen, centroid_X, centroid_Y, 1, 1);

                    int deg_x = centroid_X - pictureBox1.Size.Width;
                    int deg_y = pictureBox1.Size.Height - centroid_Y;

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
               
                for (int i = 0; i < rects.Length; i++)
                {

                    clickInImage = rects[i].Contains(e.Location);

                    if (clickInImage == true)
                    {
                        pointsX.Add((rects[i].X));
                        pointsY.Add((rects[i].Y));
                    }
                    if (pointsX.Count == 2)
                    {
                        label7.Text = Convert.ToString((Math.Sqrt(Math.Pow(pointsX[0] - pointsX[1], 2) + Math.Pow(pointsY[0] - pointsY[1], 2))) * 0.2645833333333);
                        label9.Hide();
                    }
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
                label8.Text = Convert.ToString((Math.Sqrt(Math.Pow(rects[0].X - rects[1].X, 2) + Math.Pow(rects[0].Y - rects[1].Y, 2))) * 0.2645833333333);
                Extensions extensions = new Extensions();
                extensions.Longation = Math.Round(Convert.ToDouble(label8.Text) - Convert.ToDouble(label7.Text),3);
                db.Extensions.Add(extensions);
                db.SaveChanges();
            }
        }
    }
}
