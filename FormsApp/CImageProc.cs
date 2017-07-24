using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace FormsApp
{
    public class CImageProc
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Circle
        {
            public double x;
            public double y;
            public double r;
            public double X
            {
                get { return x; }
                set { x = value; }
            }
        }
        /// <summary>
        ///     Specifies a raster-operation code. These codes define how the color data for the
        ///     source rectangle is to be combined with the color data for the destination
        ///     rectangle to achieve the final color.
        /// </summary>
        enum TernaryRasterOperations : uint
        {
            /// <summary>dest = source</summary>
            SRCCOPY = 0x00CC0020,
            /// <summary>dest = source OR dest</summary>
            SRCPAINT = 0x00EE0086,
            /// <summary>dest = source AND dest</summary>
            SRCAND = 0x008800C6,
            /// <summary>dest = source XOR dest</summary>
            SRCINVERT = 0x00660046,
            /// <summary>dest = source AND (NOT dest)</summary>
            SRCERASE = 0x00440328,
            /// <summary>dest = (NOT source)</summary>
            NOTSRCCOPY = 0x00330008,
            /// <summary>dest = (NOT src) AND (NOT dest)</summary>
            NOTSRCERASE = 0x001100A6,
            /// <summary>dest = (source AND pattern)</summary>
            MERGECOPY = 0x00C000CA,
            /// <summary>dest = (NOT source) OR dest</summary>
            MERGEPAINT = 0x00BB0226,
            /// <summary>dest = pattern</summary>
            PATCOPY = 0x00F00021,
            /// <summary>dest = DPSnoo</summary>
            PATPAINT = 0x00FB0A09,
            /// <summary>dest = pattern XOR dest</summary>
            PATINVERT = 0x005A0049,
            /// <summary>dest = (NOT dest)</summary>
            DSTINVERT = 0x00550009,
            /// <summary>dest = BLACK</summary>
            BLACKNESS = 0x00000042,
            /// <summary>dest = WHITE</summary>
            WHITENESS = 0x00FF0062,
            /// <summary>
            /// Capture window as seen on screen.  This includes layered windows 
            /// such as WPF windows with AllowsTransparency="true"
            /// </summary>
            CAPTUREBLT = 0x40000000
        }

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "OpenImage")]
        public static extern int OpenImage(string fileName);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "DrawOnDC")]
        public static extern void DrawOnDC(IntPtr hDC, int width, int height, int nImageIndex);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "FreeImage")]
        public static extern void FreeImage(int nImage);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "GetHBmp")]
        public static extern IntPtr GetHBmp(int nImage);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "DownPy")]
        public static extern int ExtDownPy(int nImage);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "AdaptiveThreshold")]
        public static extern int AdaptiveThreshold(int nImage, double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double C);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "FindContours")]
        public static extern int FindContours(int nImage, int nMinArea, double dMinRadiusContour, double dMaxDeviationRatio, [In, Out] Circle[] circs, int nSize);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "SubImage")]
        public static extern int SubImage(int nImage, int x, int y, int w, int h);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "Blur")]
        public static extern int Blur(int nImage, int kSize);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "MedianBlur")]
        public static extern int MedianBlur(int nImage, int kSize);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "Canny")]
        public static extern int Canny(int nImage, double dTh1, double dTh2, int nAppSize, int nL2);
        [DllImport(@"..\..\..\x64\Debug\OpenCVImgProc.dll", EntryPoint = "GetLine")]
        public static extern int GetLine(int nImage, int x1, int y1, int x2, int y2, byte[] Pixels, int nSizeIn);

        public static int DownPy(int nImage, int nNum)
        {
            int nTmp = nImage;
            for (int n = 0; n < nNum; n++)
            {
                nTmp = nImage;
                nImage = ExtDownPy(nTmp);
                if (nImage >= 0)
                    FreeImage(nTmp);
                else
                    nImage = nTmp;
            }
            return nTmp;
        }

        public static Bitmap CreateResultsBitmap(int nWidth, int nHeight, List<Circle> circles)
        {
            Bitmap bmp;
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Pen penYellow = new Pen(Color.Yellow, 2);
            bmp = new Bitmap(nWidth, nHeight);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(blackBrush, 0, 0, nWidth, nHeight);
            foreach (Circle c in circles)
            {
                double x = 0, y = 0, r = 0;
                x = c.x;
                y = c.y;
                r = c.r;
                g.DrawEllipse(penYellow, (float)(x - r), (float)(y - r), (float)(2 * r), (float)(2 * r));
            }
            g.Dispose();

            return bmp;
        }

        public static Bitmap OverlayResults(Bitmap bImage, List<Circle> circles, bool bShowLines=false, bool bShowCoords=false)
        {
            Graphics gDest = Graphics.FromImage(bImage);
            Pen penYellow = new Pen(Color.Yellow, 2);
            Pen penGreen = new Pen(Color.LawnGreen, 2);
            Brush brushBlue = new SolidBrush(Color.AliceBlue);
            Font font = new Font(FontFamily.GenericSansSerif, 18);
            SolidBrush brush = new SolidBrush(Color.Black);
            foreach (Circle c in circles)
            {
                double x = 0, y = 0, r = 0, x1 = 0, y1 = 0, x2 = 2, y2 = 0;
                x = c.x;
                y = c.y;
                r = c.r;
                gDest.DrawEllipse(penYellow, (float)(x - r), (float)(y - r), (float)(2 * r), (float)(2 * r));
                //Show coords
                if(bShowCoords)
                {
                    String s = String.Format("({0},{1}) {2}",x.ToString("##0"),y.ToString("##0"),r.ToString("##0"));
                    
                    gDest.DrawString(s, font, brushBlue, (float)(x - r), (float)(y - r-20));
                }
                // Draw some radial lines for sampling
                double dMinRad = r * 0.85;
                double dMaxRad = r * 1.45;
                if (bShowLines)
                {
                    for (double dAng = 0; dAng < 360; dAng += 45)
                    {
                        double dAR = dAng * Math.PI / 180;
                        x1 = x + Math.Cos(dAR) * dMinRad;
                        x2 = x + Math.Cos(dAR) * dMaxRad;
                        y1 = y + Math.Sin(dAR) * dMinRad;
                        y2 = y + Math.Sin(dAR) * dMaxRad;
                        gDest.DrawLine(penGreen, (float)x1, (float)y1, (float)x2, (float)y2);
                    }
                }
            }
            gDest.Dispose();
            return bImage;
        }
        public static List<Circle> AdjustCirclesToSubImage(double dOff, List<Circle> resCircles)
        {
            List<Circle> o = new List<Circle>();

            foreach (Circle c in resCircles)
            {
                Circle n;
                n.x = dOff;
                n.y = dOff;
                n.r = c.r;
                o.Add(n);
            }
            return o;
        }

        public static Bitmap OverlayResultsPoints(Bitmap bImage, List<Point> pts)
        {
            Graphics gDest = Graphics.FromImage(bImage);
            Pen penRed = new Pen(Color.Red, 1);
            foreach (Point p in pts)
            {
                Point p2 = p;
                p2.X += 1;
                gDest.DrawLine(penRed, p, p2);
            }
            gDest.Dispose();
            return bImage;
        }
        public static void GaussBlurLine(byte[] nVals, out double[] dBlur, int nWidth)
        {
            int nSz = nVals.Length;
            double[] dKer = new double[nWidth];
            //Todo calculate Gauss kernel
            //For test use mean
            for (int n = 0; n < nWidth; n++)
                dKer[n] = 1 / (double)nWidth;
            dBlur = Convolute(nVals, dKer);
        }

        public static double[] Convolute(byte[] nVals, double[] dKer)
        {
            double[] dRes = new double[nVals.Length];
            int nStart = dKer.Length / 2;
            for (int n = nStart; n < nVals.Length - nStart; n++)
            {
                double dSum = 0;
                for (int i = -nStart; i <= nStart; i++)
                {
                    dSum += (double)nVals[n + i] * dKer[i + nStart];
                }
                dRes[n] = dSum;
            }
            //Fill the ends
            for (int i = 0; i < nStart; i++)
                dRes[i] = dRes[nStart];
            for (int i = dRes.Length - nStart; i < dRes.Length; i++)
                dRes[i] = dRes[dRes.Length - nStart - 1];
            return dRes;
        }
        public static void NormalizeLine(double[] dLine)
        {
            //Find mean and range
            double dSum = 0, dMin = 1e10, dMax = -1e10;
            foreach (double v in dLine)
            {
                dSum += v;
                if (v < dMin)
                    dMin = v;
                if (v > dMax)
                    dMax = v;
            }
            dSum /= dLine.Length;
            for (int n = 0; n < dLine.Length; n++)
                dLine[n] = (dLine[n] - dSum) / (dMax - dMin);
        }

        public static double[] dMatchFilter = new double[] { -0.269411765,
                                                        -0.269411765,
                                                        -0.275294118,
                                                        -0.269411765,
                                                        -0.298823529,
                                                        -0.304705882,
                                                        -0.304705882,
                                                        -0.281176471,
                                                        -0.24,
                                                        -0.169411765,
                                                        -0.087058824,
                                                        -0.004705882,
                                                        0.042352941,
                                                        0.095294118,
                                                        0.212941176,
                                                        0.312941176,
                                                        0.383529412,
                                                        0.465882353,
                                                        0.565882353,
                                                        0.695294118 };
        public static int MatchFilterPt = 8;

        public static double Correl(double[] dLine, double[] dFilter, int nIndex)
        {
            // Calculate correlation of section of Line (starting at index) and filter
            double SumX = 0, SumY = 0, SumXX = 0, SumYY = 0, SumXY=0;
            double dRet = -2; //Failure
            if (dLine.Length < nIndex + dFilter.Length)
                return dRet;
            int n = dFilter.Length;
            for (int j=0;j < n; j++)
            {
                SumX += dLine[j + nIndex];
                SumXX += dLine[j + nIndex] * dLine[j + nIndex];
                SumY += dFilter[j];
                SumYY += dFilter[j] * dFilter[j];
                SumXY += dFilter[j] * dLine[j + nIndex];
            }
            dRet = (n * SumXY - SumX * SumY) / (Math.Sqrt(n * SumXX - SumX * SumX) * Math.Sqrt(n * SumYY - SumY * SumY));
            return dRet;
        }

        public static Circle FitCircleCloser(List<Point> pts, double dStdDevMult)
        {
            //Fit and then eliminate outliers
            Circle fit1 = FitCircle(pts);
            double dSum = 0;
            double[] dDists = new double[pts.Count];
            for (int n = 0; n < pts.Count; n++)
            {
                dDists[n] = Math.Abs(Math.Sqrt(Math.Pow((pts[n].X - fit1.x), 2) + Math.Pow((pts[n].Y - fit1.y), 2)) - fit1.r);
                dSum += Math.Pow(dDists[n], 2);
            }
            double dSigma = Math.Sqrt(dSum / (pts.Count - 1));
            List<Point> newPts = new List<Point>();
            for (int n = 0; n < pts.Count; n++)
            {
                if (dDists[n] <= dSigma * dStdDevMult)
                {
                    newPts.Add(pts[n]);
                }
            }
            fit1 = FitCircle(newPts);
            return fit1;
        }
        public static Circle FitCircle(List<Point>pts)
        {
            Circle c = new Circle();
            double SumX = 0, SumX2 = 0, SumX3 = 0, SumY = 0, SumY2 = 0;
            double SumXY = 0, SumXY2 = 0, SumYX2 = 0, SumY3=0;
            foreach(Point p in pts)
            {
                SumX += p.X;
                SumX2 += (p.X * p.X);
                SumY += p.Y;
                SumXY += p.X * p.Y;
                SumY2 += p.Y * p.Y;
                SumXY2 += p.X * p.Y * p.Y;
                SumYX2 += p.Y * p.X * p.X;
                SumX3 += p.X * p.X * p.X;
                SumY3 += p.Y * p.Y * p.Y;
            }
            double n = pts.Count;
            double A = n * SumX2 - SumX * SumX;
            double B = n*SumXY -SumX * SumY;
            double C = n * SumY2 - SumY * SumY;
            double D = 0.5 * (n * SumXY2 - SumX * SumY2 + n * SumX3 - SumX * SumX2);
            double E = 0.5 * (n * SumYX2 - SumY * SumX2 + n * SumY3 - SumY * SumY2);
            double xM = (D * C - B * E) / (A * C - B * B);
            double yM = (A * E - B * D) / (A * C - B * B);
            c.x = xM;
            c.y = yM;
            double R = 0;
            foreach(Point p in pts)
            {
                R += Math.Sqrt((p.X - xM) * (p.X - xM) + (p.Y - yM) * (p.Y - yM))/n;
            }
            c.r = R;
            return c;
        }
    };
}

