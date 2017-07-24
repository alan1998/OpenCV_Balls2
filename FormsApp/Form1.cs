using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
/*
 * Todo:
 * Done - Move the pyramid to a function not load Process
 * Done - Add UI to run process
 * Done - Add adaptive threshold as part of process with dialog to set parameters
 * Done - Display image size on screen
 * Done - Add further filter parameters to UI: Mi area, min raduis, max deviation from 1.0 aspect ratio
 * Done - Get back array of radius and centers
 * Done - draw on original image in UI not/or create in cv
 * Done - Draw radial short lines - get data to file - experiment in Py to find edges
 * Done - Examine circle points and reject those > std dev away and reprocess?
 * Done - 2nd set of adaptive threshold parameters and process menu to work on visible image
 * Done -Settings for line finding and circle fitting -finish settings return on okay
 * Done -Use the cicle settings on the circumference menu process
 * Done - Finish the all in one find to use circle settings and display (inc radius,x,y results)
 * Optimise filter shape
 *  --------Interactive pick line and get intensity - to clip board filter / differentiate etc
 * Done Implement Gaussian blur and median blur -  operate on displayed image
 * ---------Interactive dialog to play with sub image to get Canny parameters (Use the settings dialog and pass image id and pict box)
 * ---------Ditto for Hough circle 
 * ---------Use a mask after Canny edge so that only edges near first rough outlines used for another Hough circle attempt
 */


namespace FormsApp
{
    using static CImageProc;

    public partial class Form1 : Form
    {

        private int mProcessedImageIndex = 0;
        private int mStartingImageIndex = 0;

        private string[] mFileNames;
        // Settings for operations
        AdaptiveParams adaptiveBallSettings = new AdaptiveParams();
        AdaptiveParams adaptiveProcessSettings = new AdaptiveParams();

        SettingsParams generalSettings = new SettingsParams();
        SettingsProcess processSettings = new SettingsProcess();
        SettingsCircle circleSettings = new SettingsCircle();

        Circle resCircle;
        List<Circle> foundBalls = new List<Circle>();
        bool bShow = true;
        private const int NumPyramidDown = 5;
        public Form1()
        {
            InitializeComponent();
            generalSettings.nPyramidDown = NumPyramidDown;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mStartingImageIndex != 0)
                FreeImage(mStartingImageIndex);
            if(mProcessedImageIndex != 0)
                FreeImage(mProcessedImageIndex);

        }

        private void openFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get file list
                mFileNames = openFileDialog1.FileNames;
                vScrollBar.Maximum = mFileNames.Length - 1;
                vScrollBar.Value = 0;
                LoadImage(0);
            }
        }

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            LoadImage(vScrollBar.Value);
        }

        void LoadImage(int nImage)
        {
            if (mStartingImageIndex != 0)
                FreeImage(mStartingImageIndex);
            if (mProcessedImageIndex != 0)
                FreeImage(mProcessedImageIndex);
            mStartingImageIndex = 0;
            mProcessedImageIndex = 0;
            if (nImage >= 0 && nImage < mFileNames.Length)
            {
                mStartingImageIndex = OpenImage(mFileNames[nImage]);
                toolStripStatusLabel2.Text = "File:- " + mFileNames[nImage];
                ShowImage(mStartingImageIndex);
            }

        }

        void ShowImage(int nImage)
        {
            if (nImage >= 0)
            {
                Image img = Image.FromHbitmap(GetHBmp(nImage));
                pictureBox.Image = img;
                toolStripStatusLabel1.Text = "Image size " + img.Width.ToString() + "x" + img.Height.ToString();
               
            }

        }

        private void toolStripButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mStartingImageIndex >= 0)
            {
                mProcessedImageIndex = DownPy(mStartingImageIndex, generalSettings.nPyramidDown);
                ShowImage(mProcessedImageIndex);
            }
        }

        private void toolStripButAdaptive_Click(object sender, EventArgs e)
        {
            if (mProcessedImageIndex >= 0)
            {
                int nType = 0;
                if (adaptiveBallSettings.bMean != true)
                    nType = 1;
                mProcessedImageIndex = AdaptiveThreshold(mProcessedImageIndex, 200,  nType,0, adaptiveBallSettings.nBlockSize, adaptiveBallSettings.nConst);
                ShowImage(mProcessedImageIndex);
                int nOld = mProcessedImageIndex;
                int  nMaxCircle = 10;
                Circle[] circles = new Circle[nMaxCircle];
                List<Circle> resCircles = new List<Circle>();
                int nFound = FindContours(mProcessedImageIndex, generalSettings.nMinArea, generalSettings.dMinContourRad, generalSettings.dMaxContourAspectRaioDev,circles, nMaxCircle);
                FreeImage(mProcessedImageIndex);
                mProcessedImageIndex = 0;
                for(int n=0; n < nFound; n++)
                {
                    if (circles[n].r != 0)
                    {
                        circles[n].x = circles[n].x * Math.Pow((generalSettings.nPyramidDown-1),2);
                        circles[n].y = circles[n].y * Math.Pow((generalSettings.nPyramidDown -1),2);
                        circles[n].r = circles[n].r * Math.Pow((generalSettings.nPyramidDown-1 ),2);
                        resCircles.Add(circles[n]);
                    }
                    else
                        break;
                }
                //Bitmap bmpResults = CreateResultsBitmap(1280, 960, resCircles);
                ShowImage(mStartingImageIndex);
                Bitmap bDest = new Bitmap(pictureBox.Image);
                pictureBox.Image = OverlayResults(bDest, resCircles);
                //Get a sub image
                int nCircle = 1;
                double dMargin = 1.7;
                int sz = (int)(dMargin*2 * circles[0].r);
                int x = (int)(circles[nCircle].x - dMargin * circles[nCircle].r);
                int y = (int)(circles[nCircle].y - dMargin * circles[nCircle].r);
                if (x < 0)
                    x = 0;
                if (y < 0)
                    y = 0;
                if (x + sz > bDest.Width)
                    sz = bDest.Width - x - 1;
                if (y + sz > bDest.Height)
                    sz = bDest.Height -y - 1;
                mProcessedImageIndex = SubImage(mStartingImageIndex, x, y, sz, sz);
                ShowImage(mProcessedImageIndex);
                List<Circle> subCircles = AdjustCirclesToSubImage((dMargin * circles[nCircle].r),  resCircles);
                bDest = new Bitmap(pictureBox.Image);
                //subCircles.RemoveAt(1);
                //pictureBox.Image = OverlayResults(bDest, subCircles);
                resCircle = subCircles[nCircle];
            }
        }

        private void adaptiveThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show dialog and get some parameters
            frmAdaptiveSettings frm = new frmAdaptiveSettings();
            frm.settings = adaptiveBallSettings;
            if (frm.ShowDialog(this)== DialogResult.OK)
            {
                //Get settings and store somewhere
                adaptiveBallSettings = frm.settings;
            }
        }
        private void adaptiveThresholdProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Settings to be used from process menu
            // Not getting ball contour from pyramided image
            frmAdaptiveSettings frm = new frmAdaptiveSettings();
            frm.settings = adaptiveProcessSettings;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                //Get settings and store somewhere
                adaptiveProcessSettings = frm.settings;
            }

        }

        private void adaptiveThresholdToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAdaptiveSettings frm = new frmAdaptiveSettings();
            frm.settings = adaptiveProcessSettings;
            frm.PreviewImage = mProcessedImageIndex;
            frm.PicDisplay = this.pictureBox;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                //Get settings and store somewhere
                adaptiveProcessSettings = frm.settings;
                if(frm.PreviewImage > 0)
                {
                    FreeImage(mProcessedImageIndex);
                    mProcessedImageIndex = frm.PreviewImage;
                    ShowImage(mProcessedImageIndex);
                }
            }
            else
            {
                ShowImage(mProcessedImageIndex);
            }

        }
        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOtherSettings frm = new frmOtherSettings();
            frm.settings = generalSettings;
            if (frm.ShowDialog(this) == DialogResult.OK)
                generalSettings = frm.settings;
        }

        private void blurMenuItem_Click(object sender, EventArgs e)
        {
            int nNew = -1;
            if(processSettings.nSmoothType ==0)            
                nNew= Blur(mProcessedImageIndex, processSettings.nBlurSize);
            else
                nNew = MedianBlur(mProcessedImageIndex, processSettings.nBlurSize);
            ShowImage(nNew);
            FreeImage(mProcessedImageIndex);
            mProcessedImageIndex = nNew;
        }

        private void processToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProcessSettings frm = new frmProcessSettings();
            frm.settings = processSettings;
            frm.setCircle = circleSettings;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                processSettings = frm.settings;
                circleSettings = frm.setCircle;
            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nNew = Canny(mProcessedImageIndex, 
                processSettings.dTh1, 
                processSettings.dTh2, 
                processSettings.nAppertureSize,
                processSettings.nMethod);
            ShowImage(nNew);
            FreeImage(mProcessedImageIndex);
            mProcessedImageIndex = nNew;

        }

        private void getLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get a trace line as an array 
            // Show on image
            double dAngle = 260;
            double dMinRad = resCircle.r * circleSettings.dInRad;
            double dMaxRad = resCircle.r * circleSettings.dOutRad;
            double dAR = dAngle * Math.PI / 180;
            double x1, x2, y1, y2;
            x1 = resCircle.x + Math.Cos(dAR) * dMinRad;
            x2 = resCircle.x + Math.Cos(dAR) * dMaxRad;
            y1 = resCircle.y + Math.Sin(dAR) * dMinRad;
            y2 = resCircle.y + Math.Sin(dAR) * dMaxRad;

            Bitmap bDest = new Bitmap(pictureBox.Image);


            byte[] nVals = new byte[1];
            int nLen = GetLine(mProcessedImageIndex, (int)x2, (int)y2, (int)x1, (int)y1, nVals, 0);
            nVals = new byte[nLen];
            nLen = GetLine(mProcessedImageIndex, (int)x2, (int)y2, (int)x1, (int)y1, nVals, nLen);
            double []dBlur = new double[nLen];
            int nWidth = 7;
            GaussBlurLine(nVals, out dBlur, nWidth);
            NormalizeLine(dBlur);

            double R = 0, Rl = 0;
            double dCorMin = 0.96;
            int n=0;
            while(R > -2)
            {
                R= Correl(dBlur, dMatchFilter, n);
                if ((Rl > dCorMin) && (R < Rl))
                    break;
                Rl = R;
                n++;
            }
            List<Point> points = new List<Point>();
            if (R > dCorMin)
            {
                //Valid get position along line and add to result set
                n = n += MatchFilterPt;
                double dLen = (double)n / (double)dBlur.Length;
                dLen *= (Math.Sqrt((x2-x1)*(x2-x1) + (y2-y1)*(y2-y1)));
                double x = dLen * Math.Cos( Math.PI + dAR) + x2;
                double y = dLen * Math.Sin(Math.PI + dAR) + y2;
                points.Add( new Point((int)x, (int)y));
                pictureBox.Image = OverlayResultsPoints(bDest, points);
            }

            
            if (nLen < 0)
                MessageBox.Show("Failed");
            else
            {
                Clipboard.Clear();
                StringBuilder sb = new StringBuilder();
                int nMax = nLen;

                for (int j = 0; j < nMax; j++)
                {
                    sb.AppendFormat("{0}\t{1}\n", nVals[j].ToString(),dBlur[j].ToString());
                }
                Clipboard.SetText(sb.ToString());
            }
        }

        private void getPerimeterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foundBalls.Clear();

            double dMinRad = resCircle.r * circleSettings.dInRad;
            double dMaxRad = resCircle.r * circleSettings.dOutRad;
            double x1, x2, y1, y2;
            List<Point> points = new List<Point>();

            for (double dAngle = 0; dAngle < 360; dAngle += circleSettings.dStepDeg)
            {
                double dAR = dAngle * Math.PI / 180;
                x1 = resCircle.x + Math.Cos(dAR) * dMinRad;
                x2 = resCircle.x + Math.Cos(dAR) * dMaxRad;
                y1 = resCircle.y + Math.Sin(dAR) * dMinRad;
                y2 = resCircle.y + Math.Sin(dAR) * dMaxRad;

                byte[] nVals = new byte[1];
                int nLen = GetLine(mProcessedImageIndex, (int)x2, (int)y2, (int)x1, (int)y1, nVals, 0);
                if (nLen == 0)
                    continue;
                nVals = new byte[nLen];
                nLen = GetLine(mProcessedImageIndex, (int)x2, (int)y2, (int)x1, (int)y1, nVals, nLen);
                double[] dBlur = new double[nLen];
                GaussBlurLine(nVals, out dBlur, circleSettings.nLineBlur);
                NormalizeLine(dBlur);

                double R = 0, Rl = 0;
                double dCorMin = circleSettings.dMinCor;
                int n = 0;
                while (R > -2)
                {
                    R = Correl(dBlur, dMatchFilter, n);
                    if ((Rl > dCorMin) && (R < Rl))
                        break;
                    Rl = R;
                    n++;
                }
                if (R > dCorMin)
                {
                    //Valid get position along line and add to result set
                    n = n += MatchFilterPt;
                    double dLen = (double)n / (double)dBlur.Length;
                    dLen *= (Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
                    double x = dLen * Math.Cos(Math.PI + dAR) + x2;
                    double y = dLen * Math.Sin(Math.PI + dAR) + y2;
                    points.Add(new Point((int)x, (int)y));
                }
            }
            Circle c = FitCircle(points);
            Bitmap bDest = new Bitmap(pictureBox.Image);
            pictureBox.Image = OverlayResultsPoints(bDest, points);

            foundBalls.Add(c);
            Circle c2 = FitCircleCloser(points, circleSettings.dStdDevReject);
            foundBalls.Clear();
            foundBalls.Add(c2);
            //pictureBox.Image = OverlayResults(bDest, foundBalls);

        }

        private void butToggleResults_Click(object sender, EventArgs e)
        {
            if (bShow)
            {
                Bitmap bDest = new Bitmap(pictureBox.Image);
                pictureBox.Image = OverlayResults(bDest, foundBalls);
                bShow = !bShow;
            }
            else
            {
                ShowImage(mProcessedImageIndex);
                bShow = !bShow;
            }
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            // Process whole image to get 2 balls
            if (mStartingImageIndex >= 0)
            {
                Bitmap bDest = new Bitmap(pictureBox.Image);
                int nType = 0;
                if (adaptiveBallSettings.bMean != true)
                    nType = 1;
                int nPyDown = DownPy(mStartingImageIndex, generalSettings.nPyramidDown);
                int nThreshImage = AdaptiveThreshold(nPyDown, 200, nType, 0, adaptiveBallSettings.nBlockSize, adaptiveBallSettings.nConst);
                FreeImage(nPyDown);
                int nMaxCircle = 10;
                Circle[] circles = new Circle[nMaxCircle];
                List<Circle> resCircles = new List<Circle>();
                int nFound = FindContours(nThreshImage, generalSettings.nMinArea, generalSettings.dMinContourRad, generalSettings.dMaxContourAspectRaioDev, circles, nMaxCircle);
                FreeImage(nThreshImage);
                for (int n = 0; n < nFound; n++)
                {
                    if (circles[n].r != 0)
                    {
                        circles[n].x = circles[n].x * Math.Pow((generalSettings.nPyramidDown - 1), 2);
                        circles[n].y = circles[n].y * Math.Pow((generalSettings.nPyramidDown - 1), 2);
                        circles[n].r = circles[n].r * Math.Pow((generalSettings.nPyramidDown - 1), 2);
                        resCircles.Add(circles[n]);
                    }
                    else
                        break;
                }
                // Rough contour circles
                //pictureBox.Image = OverlayResults(bDest, resCircles);
                //Now process each circle to get circumference 
                //Fit circles and display them
                foundBalls.Clear();

                double x1, x2, y1, y2;

                foreach (Circle c in resCircles)
                {
                    List<Point> points = new List<Point>();

                    double dMinRad = c.r * circleSettings.dInRad;
                    double dMaxRad = c.r * circleSettings.dOutRad;
                    for (double dAngle = 0; dAngle < 360; dAngle += circleSettings.dStepDeg)
                    {
                        double dAR = dAngle * Math.PI / 180;
                        x1 = c.x + Math.Cos(dAR) * dMinRad;
                        x2 = c.x + Math.Cos(dAR) * dMaxRad;
                        y1 = c.y + Math.Sin(dAR) * dMinRad;
                        y2 = c.y + Math.Sin(dAR) * dMaxRad;

                        byte[] nVals = new byte[1];
                        int nLen = GetLine(mStartingImageIndex, (int)x2, (int)y2, (int)x1, (int)y1, nVals, 0);
                        if (nLen == 0)
                            continue;
                        nVals = new byte[nLen];
                        nLen = GetLine(mStartingImageIndex, (int)x2, (int)y2, (int)x1, (int)y1, nVals, nLen);
                        double[] dBlur = new double[nLen];
                        GaussBlurLine(nVals, out dBlur, circleSettings.nLineBlur);
                        NormalizeLine(dBlur);

                        double R = 0, Rl = 0;
                        double dCorMin = circleSettings.dMinCor;
                        int n = 0;
                        while (R > -2)
                        {
                            R = Correl(dBlur, dMatchFilter, n);
                            if ((Rl > dCorMin) && (R < Rl))
                                break;
                            Rl = R;
                            n++;
                        }
                        if (R > dCorMin)
                        {
                            //Valid get position along line and add to result set
                            n = n += MatchFilterPt;
                            double dLen = (double)n / (double)dBlur.Length;
                            dLen *= (Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
                            double x = dLen * Math.Cos(Math.PI + dAR) + x2;
                            double y = dLen * Math.Sin(Math.PI + dAR) + y2;
                            points.Add(new Point((int)x, (int)y));
                        }
                    }
                    Circle fit = FitCircleCloser(points, circleSettings.dStdDevReject);
                    foundBalls.Add(fit);
       
                }
                pictureBox.Image = OverlayResults(bDest, foundBalls,false,true);
            }

        }



        //private void getLinesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Horizontal and vertical lines from image to clipboard
        //    //Hack a trace to the clipboard
        //    int sz = pictureBox.Image.Size.Width;
        //    byte[] nHorzVals = new byte[1];
        //    byte[] nVertVals = new byte[1];
        //    int x = sz / 2;
        //    int y = (sz) - 1;
        //    int nHLen = GetLine(mProcessedImageIndex, 0, sz/2, sz-1, sz/2, nHorzVals, 0);
        //    nHorzVals = new byte[nHLen];
        //    nHLen = GetLine(mProcessedImageIndex, 0, sz / 2, sz - 1, sz / 2, nHorzVals, nHLen);
        //    int nVLen = GetLine(mProcessedImageIndex, x, 0, x, y, nVertVals, 0);
        //    nVertVals = new byte[nVLen];
        //    nVLen = GetLine(mProcessedImageIndex, x, 0, x, y, nVertVals, nVLen);
        //    if (nHLen < 0)
        //        MessageBox.Show("Failed");
        //    else
        //    {
        //        Clipboard.Clear();
        //        StringBuilder sb = new StringBuilder();
        //        int nMax = nVLen;
        //        if (nHLen < nVLen)
        //            nMax = nHLen;
        //        for(int n =0; n < nMax; n++)
        //        {
        //            sb.AppendFormat("{0}\t{1}\n",nHorzVals[n].ToString(), nVertVals[n].ToString());
        //        }
        //        Clipboard.SetText(sb.ToString());
        //    }
        //    // End hack

        //}
    }
}
