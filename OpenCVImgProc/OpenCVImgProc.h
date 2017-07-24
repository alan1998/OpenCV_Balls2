// OpenCVImgProc.h : main header file for the OpenCVImgProc DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// COpenCVImgProcApp
// See OpenCVImgProc.cpp for the implementation of this class
//

class COpenCVImgProcApp : public CWinApp
{
public:
	COpenCVImgProcApp();

// Overrides
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
