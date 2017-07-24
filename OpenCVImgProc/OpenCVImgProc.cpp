// OpenCVImgProc.cpp : Defines the initialization routines for the DLL.
//

#include "stdafx.h"
#include "OpenCVImgProc.h"
#include "opencv2\core.hpp"
#include "opencv2\highgui.hpp"
#include "opencv2\imgproc.hpp"

#include <map>
#include <atlimage.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

//
//TODO: If this DLL is dynamically linked against the MFC DLLs,
//		any functions exported from this DLL which call into
//		MFC must have the AFX_MANAGE_STATE macro added at the
//		very beginning of the function.
//
//		For example:
//
//		extern "C" BOOL PASCAL EXPORT ExportedFunction()
//		{
//			AFX_MANAGE_STATE(AfxGetStaticModuleState());
//			// normal function body here
//		}
//
//		It is very important that this macro appear in each
//		function, prior to any calls into MFC.  This means that
//		it must appear as the first statement within the 
//		function, even before any object variable declarations
//		as their constructors may generate calls into the MFC
//		DLL.
//
//		Please see MFC Technical Notes 33 and 58 for additional
//		details.
//

// COpenCVImgProcApp

BEGIN_MESSAGE_MAP(COpenCVImgProcApp, CWinApp)
END_MESSAGE_MAP()


typedef struct _CIRCLE {
	double dX;
	double dY;
	double dRad;
} CIRCLE;

// COpenCVImgProcApp construction

COpenCVImgProcApp::COpenCVImgProcApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only COpenCVImgProcApp object

COpenCVImgProcApp theApp;


// COpenCVImgProcApp initialization
void CopyToCImage(int nImage, CImage& image);

std::map<int, cv::Mat> gMapImages;
int gImage{ 1 };

BOOL COpenCVImgProcApp::InitInstance()
{
	CWinApp::InitInstance();

	return TRUE;
}

extern "C" int PASCAL EXPORT OpenImage(LPCSTR pFileName)
{
	int nRet = -1;
	cv::String cvFileName = pFileName;
	// Assume getting an 8but grey scale
	cv::Mat cvImg = cv::imread(cvFileName, CV_LOAD_IMAGE_UNCHANGED);
	if (!cvImg.empty())
	{
		nRet = gImage;
		gMapImages[gImage++] = cvImg;
	}
	return nRet;
}

extern "C" void PASCAL EXPORT FreeImage(int n)
{
	if (gMapImages.find(n) != gMapImages.end())
	{
		gMapImages[n].deallocate();
	}
}

extern "C" HANDLE PASCAL EXPORT GetHBmp(int nImage)
{
	CImage image;
	CopyToCImage(nImage, image);
	return image.Detach();
}

void CopyToCImage(int nImage, CImage& image)
{
	if (gMapImages.find(nImage) != gMapImages.end())
	{
		if (gMapImages[nImage].empty())
			return;
		int nBPP = gMapImages[nImage].channels() * 8;

		image.Create(gMapImages[nImage].cols, gMapImages[nImage].rows, nBPP);
		if (nBPP == 8)
		{
			static RGBQUAD pRGB[256];
			for (int i = 0; i < 256; i++)
				pRGB[i].rgbBlue = pRGB[i].rgbGreen = pRGB[i].rgbRed = i;
			image.SetColorTable(0, 256, pRGB);
		}
		uchar* psrc = gMapImages[nImage].data;
		uchar* pdst = (uchar*)image.GetBits();
		int imgPitch = image.GetPitch();
		for (int y = 0; y < gMapImages[nImage].rows; y++)
		{
			memcpy(pdst, psrc, gMapImages[nImage].cols*gMapImages[nImage].channels());//mat->step is incorrect for those images created by roi (sub-images!)
			psrc += gMapImages[nImage].step;
			pdst += imgPitch;
		}
	}
}

extern "C" void PASCAL EXPORT DrawOnDC(HDC dc,int width, int height, int nImage)
{
	CRect rc;
	rc.left = 0;
	rc.right = width;
	rc.top = 0;
	rc.bottom = height;
	//Convert the Mat to a GDI CImage and Draw
	// destroy the CImage at end
	CImage image;
	CopyToCImage(nImage, image);
	image.Draw(dc, rc, Gdiplus::InterpolationModeHighQuality);
	image.Destroy();
}

//--------------------------------------------------------------------
// Process fuctions

// Down sample by pyramid
extern "C" int PASCAL EXPORT DownPy(int nImage)
{
	int nRetNewImage = -1;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			if (gMapImages[nImage].empty())
				return nRetNewImage;
			cv::Mat cvDest = gMapImages[nImage].clone();
			cv::pyrDown(gMapImages[nImage], cvDest);
			nRetNewImage = gImage;
			gMapImages[gImage++] = cvDest;
		}
	}
	catch (...)
	{

	}
	return nRetNewImage;
}

extern "C" int PASCAL EXPORT SubImage(int nImage, int x, int y, int w, int h)
{
	int nRetNewImage = -1;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			if (gMapImages[nImage].empty())
				return nRetNewImage;
			cv::Rect roi;
			roi.x = x;
			roi.y = y;
			roi.width = w;
			roi.height = h;
			auto sub = cv::Mat(gMapImages[nImage], roi);
			nRetNewImage = gImage;
			gMapImages[gImage++] = sub;
		}
	}
	catch (...)
	{

	}
	return nRetNewImage;

}

extern "C" int PASCAL EXPORT Blur(int nImage, int kSize)
{
	int nRetNewImage = -1;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			if (gMapImages[nImage].empty())
				return nRetNewImage;
			cv::Mat cvDest(gMapImages[nImage]);
			cv::blur(gMapImages[nImage], cvDest,cv::Size( kSize,kSize));
			nRetNewImage = gImage;
			gMapImages[gImage++] = cvDest;
		}
	}
	catch (...)
	{

	}
	return nRetNewImage;
}

extern "C" int PASCAL EXPORT MedianBlur(int nImage, int kSize)
{
	int nRetNewImage = -1;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			if (gMapImages[nImage].empty())
				return nRetNewImage;
			cv::Mat cvDest(gMapImages[nImage]);
			cv::medianBlur(gMapImages[nImage], cvDest, kSize);
			nRetNewImage = gImage;
			gMapImages[gImage++] = cvDest;
		}
	}
	catch (...)
	{

	}
	return nRetNewImage;
}

extern "C" int PASCAL EXPORT Canny(int nImage, double dTh1, double dTh2,int nAppSize, int nL2)
{
	int nRetNewImage = -1;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			if (gMapImages[nImage].empty())
				return nRetNewImage;
			cv::Mat cvDest(gMapImages[nImage]);
			cv::Canny(gMapImages[nImage], cvDest, dTh1, dTh2, nAppSize, nL2 == 1);
			nRetNewImage = gImage;
			gMapImages[gImage++] = cvDest;
		}
	}
	catch (...)
	{

	}
	return nRetNewImage;
}

extern "C" int PASCAL EXPORT GetLine(int nImage, int x1, int y1, int x2, int y2, uchar* Pixels, int nSizeIn)
{
	//Get the pixels along a line into an array
	// If size in is zero return just the number of pixels
	//Do some tests to check coords are within bounds of image
	int nRetCount = 0;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			if (gMapImages[nImage].empty())
				return nRetCount;
			if ((x1 < 0) || (x1 > gMapImages[nImage].size().width))
				return nRetCount;
			if ((x2 < 0) || (x2 > gMapImages[nImage].size().width))
				return nRetCount;
			if ((y1 < 0) || (y1 > gMapImages[nImage].size().height))
				return nRetCount;
			if ((y2 < 0) || (y2 > gMapImages[nImage].size().height))
				return nRetCount;
			cv::Point s; s.x = x1; s.y = y1;
			cv::Point f; f.x = x2; f.y = y2;
			auto it = cv::LineIterator(gMapImages[nImage], s, f);
			if (nSizeIn == 0)
				return it.count;
			int p = 0;
			for ( p=0; (p <it.count) || (p == nSizeIn-1); p++, it++)
			{
				Pixels[p] =  gMapImages[nImage].at<uchar>(it.pos());
			}
			if (it.count > nSizeIn)
				nRetCount = -1;
			else
				nRetCount = p;
		}
	}
	catch (...)
	{

	}
	return nRetCount;
}

extern "C" int PASCAL EXPORT  AdaptiveThreshold(int nImage, double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double C)
{
	int nRetNewImage = -1;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			if (gMapImages[nImage].empty())
				return nRetNewImage;
			cv::Mat cvDest = gMapImages[nImage].clone();
			cv::adaptiveThreshold(gMapImages[nImage], cvDest, maxValue, adaptiveMethod, thresholdType, blockSize, C);
			nRetNewImage = gImage;
			gMapImages[gImage++] = cvDest;
		}
	}
	catch (...)
	{

	}
	return nRetNewImage;
}

// Return number of contours found
extern "C" int  PASCAL EXPORT FindContours(int nImage, int nMinArea, double dMinRadius, double dAspectDev,
	CIRCLE* pCircles, int nSize)
{
	int nFound = 0;
	try {
		if (gMapImages.find(nImage) != gMapImages.end())
		{
			std::vector<std::vector<cv::Point>> outContours;
			std::vector<cv::Vec4i>	outHierarchy;
			cv::findContours(gMapImages[nImage], outContours, outHierarchy, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_SIMPLE);
			float fRad;
			cv::Point2f cent;
			for (int nCtr = 0; nCtr < outContours.size(); nCtr++)
			{
				auto Moments = cv::moments(outContours[nCtr], false);
				auto area =Moments.m00;
				auto cx = Moments.m10 / Moments.m00;
				auto cy = Moments.m01 / Moments.m00;
				if (area > nMinArea)
				{
					//What bounding box ?
					// What circle?
					auto rc = cv::minAreaRect(outContours[nCtr]);				
					auto ar = static_cast<double>(rc.size.height) / static_cast<double>(rc.size.width);
					cv::minEnclosingCircle(outContours[nCtr], cent, fRad);
					if (ar > (1.0 - dAspectDev) && ar < (1.0 + dAspectDev) && fRad > dMinRadius && nFound < nSize)
					{
						pCircles[nFound].dX = cent.x;
						pCircles[nFound].dY = cent.y;
						pCircles[nFound++].dRad = fRad;
					}
				}
			}
		}
	}
	catch (...)
	{

	}
	return nFound;
}