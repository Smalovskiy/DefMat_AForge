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

namespace DefMat_V2._0
{
    public partial class Form1 : Form
    {
        FilterInfoCollection device;
        VideoCaptureDevice captureDevice;
        Bitmap bitmapEdgeImage, bitmapBinaryImage, bitmapGreyImage, bitmapBlurImage, colorFilterImage;
        EuclideanColorFiltering colorFilter = new EuclideanColorFiltering();
        Font font = new Font("Times New Roman", 48, FontStyle.Bold);
        SolidBrush brush = new SolidBrush(Color.Black);
        SobelEdgeDetector edgeFilter = new SobelEdgeDetector();
        Pen pictureboxPen = new Pen(Color.Black, 5);

        
        int ipenWidth = 2, iFeatureWidth;
        int iThreshold = 40, iRadius = 40;
        int iColorMode = 1, iRedValue = 220, iGreenValue = 30, iBlueValue = 30;
        bool blurFlag = false;
        public Form1()
        {
            InitializeComponent();
        }

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (captureDevice != null)
            //    {
            //        captureDevice.
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

        private void SrartCameras(int deviceindex)
        {
            try
            {
                captureDevice = new VideoCaptureDevice(device[deviceindex].MonikerString);
                captureDevice.NewFrame += new NewFrameEventHandler(get_Frame);
                captureDevice.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SrartCameras(toolStripComboBox1.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void get_Frame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap _BsourceFrame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = BlobDetection(_BsourceFrame);
            pictureBox2.Image = bitmapEdgeImage;
            pictureBox3.Image = bitmapBinaryImage;
            pictureBox4.Image = colorFilterImage;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                device = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                for (var i = 0; i < device.Count; i++)
                    toolStripComboBox1.Items.Add(device[i].Name);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private double FindDistance(int pixel)
        {
            double distance;
            double objectWidth = 10, focalLength = 604.8;

            distance = (objectWidth * focalLength) / pixel;
            return distance;

        }
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
                GaussianBlur blurfilter = new GaussianBlur(1.5);
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
                MinWidth = 10,
                MinHeight = 10,
                FilterBlobs = true
            };

            blobCounter.ProcessImage(bitmapBinaryImage);

            Blob[] blobPoints = blobCounter.GetObjectsInformation();
            Graphics graph = Graphics.FromImage(bitmapSourceImage);
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

            for (int i = 0; i < blobPoints.Length; i++)
            {
                List<IntPoint> edgePoint = blobCounter.GetBlobsEdgePoints(blobPoints[i]);


                if (shapeChecker.IsCircle(edgePoint, out AForge.Point center, out float radius))
                {
                    graph.DrawEllipse(pictureboxPen, pictureBox1.Size.Width, pictureBox1.Size.Height, 10, 10);

                    Rectangle[] rects = blobCounter.GetObjectsRectangles();
                    Pen pen = new Pen(Color.Red, ipenWidth);
                    string shapeString = "" + shapeChecker.CheckShapeType(edgePoint);
                    int x = (int)center.X;
                    int y = (int)center.Y;

                    graph.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
         
                    int centroid_X = (int)blobPoints[0].CenterOfGravity.X;
                    int centroid_Y = (int)blobPoints[0].CenterOfGravity.Y;

                    graph.DrawEllipse(pen, centroid_X, centroid_Y, 10, 10);

                    int deg_x = centroid_X - pictureBox1.Size.Width;
                    int deg_y = pictureBox1.Size.Height - centroid_Y;

                    foreach (Rectangle rc in rects)
                    {
                        iFeatureWidth = rc.Width;
                        double dis = FindDistance(iFeatureWidth);
                        //_g.DrawString(dis.ToString("N2") + "cm", _font, _brush, _x, _y + 60);
                    }
                }
            }
            return bitmapSourceImage;
        }
    }
}
