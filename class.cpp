#include"resource.h"
#include<Windows.h>
#include<stdio.h>
#include<stdlib.h>
#include<time.h>


int R,G,B;
LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK FrameWndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK ChildWndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam);
BOOL CALLBACK DlgProc(HWND,UINT,WPARAM, LPARAM);

HINSTANCE hInst;
int num;
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lpszCmdLine, int nCmdShow)
{
	HWND hwnd;
	MSG msg;
	WNDCLASS WndClass;
	hInst = hInstance; 
	WndClass.style = CS_HREDRAW | CS_VREDRAW;
	WndClass.lpfnWndProc = FrameWndProc;
	WndClass.cbClsExtra = 0;
	WndClass.cbWndExtra =0;
	WndClass.hInstance = hInstance;
	WndClass.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	WndClass.hCursor = LoadCursor(NULL,IDC_ARROW);
	WndClass.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	WndClass.lpszMenuName = MAKEINTRESOURCE(IDR_MENU1);
	WndClass.lpszClassName = "Windows Class Name";
	RegisterClass(&WndClass);
	WndClass.lpfnWndProc = ChildWndProc;
	WndClass.lpszMenuName = NULL;
	WndClass.lpszClassName = "Child Window Class Nmae";
	RegisterClass(&WndClass);
	hwnd = CreateWindow("Windows Class Name", "Main Window Title",WS_OVERLAPPEDWINDOW,CW_USEDEFAULT,CW_USEDEFAULT,1280,1080, NULL,NULL,hInstance, NULL);
	ShowWindow(hwnd,nCmdShow);
	UpdateWindow(hwnd);

	while(GetMessage(&msg,NULL,0,0))
	{
		
			TranslateMessage(&msg);
			DispatchMessage(&msg);
	}
	return msg.wParam;
}
/*
LRESULT CALLBACK WndProc(HWND hwnd,UINT iMsg, WPARAM wParam, LPARAM lParam)
{
	srand(time(NULL));
	static BITMAP bmp;
	static RECT rect;
	HDC memdc,hButton;
	static HDC hdc,mem1dc, mem2dc,mem3dc,mem4dc,mem5dc;
	static HBITMAP hBit1,oldBit1;
	HBRUSH hBrush, oldBrush;
	PAINTSTRUCT ps;
	int mWidth,mHeight,mx,my;
	int wWidth,wHeight;
	static HINSTANCE hInstance;
	

	switch(iMsg)
	{
	case WM_CREATE:
		SetTimer(hwnd,2,70,NULL);
		hInstance = hInst;
		R=0;
		G=0;
		B=0;
		break;
	case WM_TIMER:
		switch(LOWORD(wParam))
		{
		
		case 2:
			
			hdc = GetDC(hwnd);
			GetClientRect(hwnd,&rect);
			wWidth = rect.right;
			wHeight = rect.bottom;
			if(hBit1==NULL)
				hBit1 = CreateCompatibleBitmap(hdc,wWidth,wHeight);
			mem1dc = CreateCompatibleDC(hdc);
			mem2dc = CreateCompatibleDC(mem1dc);
			mem3dc = CreateCompatibleDC(mem1dc);
			mem4dc = CreateCompatibleDC(mem1dc);
			oldBit1 = (HBITMAP)SelectObject(mem1dc,hBit1);
			FillRect(mem1dc, &rect, (HBRUSH)GetStockObject(WHITE_BRUSH));
			
			hBrush = CreateSolidBrush(RGB(R, G, B));
			oldBrush= (HBRUSH) SelectObject(mem1dc, hBrush);
			Rectangle(mem1dc,0,0,wWidth,wHeight);
			SelectObject(mem1dc, oldBrush);
			DeleteObject(hBrush);
			DeleteDC(mem1dc);

			SelectObject(mem1dc,oldBit1);
			DeleteDC(mem1dc);
			ReleaseDC(hwnd,hdc);

			InvalidateRect(hwnd,NULL,FALSE);
			break;
		}
		break;
	case WM_COMMAND:
		switch(LOWORD(wParam))
		{
		
		}
		break;
	case WM_LBUTTONDOWN:
		mx=LOWORD(lParam);
		my=HIWORD(lParam);
		
		break;
	case WM_LBUTTONUP:
		break;
	case WM_MOUSEMOVE:
		break;
		case WM_KEYDOWN:

		break;
	case WM_CHAR:
		
		break;
	case WM_PAINT:
		GetClientRect(hwnd,&rect);
		wWidth = rect.right;
		wHeight = rect.bottom;
		hdc = BeginPaint(hwnd, &ps);
		
		mem1dc = CreateCompatibleDC(hdc);
		//oldBit1 = (HBITMAP)SelectObject(mem1dc,hBit1);
		//BitBlt(hdc,0,0,wWidth,wHeight,mem1dc,0,0,SRCCOPY);
		
		oldBit1 = (HBITMAP)SelectObject(mem1dc,hBit1);
		BitBlt(hdc,0,0,wWidth,wHeight,mem1dc,0,0,SRCCOPY);
		SelectObject(mem1dc,oldBit1);
		DeleteDC(mem1dc);
		GetObject(hBit1,sizeof(BITMAP),&bmp);
		memdc = CreateCompatibleDC(hdc);
		SelectObject(memdc,hBit1);
		if(Drag)
			TransparentBlt(hdc,xPos1,yPos1,mWidth,mHeight,memdc,0,0,mWidth,mHeight,RGB(255,255,255));
		DeleteDC(memdc);
		EndPaint(hwnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hwnd,iMsg,wParam,lParam);
}
*/
LRESULT CALLBACK FrameWndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam)
{
	static HWND hwndClient;
	CLIENTCREATESTRUCT clientcreate;
	MDICREATESTRUCT mdicreate;
	HWND hwndChild;
	switch(iMsg)
	{
	case WM_CREATE:
		clientcreate.hWindowMenu = GetSubMenu(GetMenu(hwnd),0);
		clientcreate.idFirstChild = 100;
		hwndClient = CreateWindow("MDICLIENT",NULL,WS_CHILD|WS_CLIPCHILDREN | WS_VISIBLE, 0,0,1200,1000,hwnd,NULL,hInst,(LPSTR) &clientcreate);
		ShowWindow(hwndClient,SW_SHOW);
		return 0;
	case WM_COMMAND:
		switch(LOWORD(wParam))
		{
		case ID_FILE_NEW40001:
			mdicreate.szClass="Child Window Class Nmae";
			mdicreate.szTitle = "Child Window Title Name";
			mdicreate.hOwner = hInst;
			mdicreate.x = CW_USEDEFAULT;
			mdicreate.y = CW_USEDEFAULT;
			mdicreate.cx = CW_USEDEFAULT;
			mdicreate.cy = CW_USEDEFAULT;
			mdicreate.style = 0;
			mdicreate.lParam = 0;
			hwndChild = (HWND)SendMessage(hwndClient,WM_MDICREATE,0,(LPARAM)(LPMDICREATESTRUCT) &mdicreate);
			return 0;
		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return DefFrameProc(hwnd,hwndClient,iMsg,wParam,lParam);
}

LRESULT CALLBACK ChildWndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hdc;
	PAINTSTRUCT ps;
	static char lstr[10][20];
	static char str[10][10][100];
	static char astr[10][10][100];
	static int scount =0; 
	static int count =0;
	static int yPos=0;
	static int tcount=0;
	static int t2count =0;
	static int xPos=0;
	static SIZE size;
	
		
	switch(iMsg)
	{
	case WM_CREATE:
		count =0;
		CreateCaret(hwnd,NULL,5,15);
		ShowCaret(hwnd);
		break;
	case WM_CHAR:
		hdc = GetDC(hwnd);
		if(wParam == VK_BACK)
		{
			if(scount ==0&&count==0)
			{}
			else if(count==0)
				scount--;
			else
				count--;
		}
		else if(wParam == VK_ESCAPE)
		{
			for(int i =0 ; i<10;i++)
			{
				strcpy(astr[num-100][i],str[num-100][i]);
			}
			t2count = count;
			tcount = scount;
			yPos = 0;
			count =0;
			scount =0;

		}
		else if(wParam == VK_TAB)
		{
			for(int i =0 ; i<10;i++)
			{
				strcpy(str[num-100][i],astr[num-100][i]);
			}
			count = t2count;
			scount=tcount;
			yPos+=20;
		}

		else if(wParam == VK_RETURN)
		{
			count=0;
			scount++;
			yPos+=20;
		}
		else
		{
			str[num-100][scount][count++]=wParam;
		}
		//xPos=0;
		//yPos=0;
		str[num-100][scount][count]='\0';
		InvalidateRect(hwnd, NULL, TRUE);
		ReleaseDC(hwnd, hdc);
		break;
	case WM_KEYDOWN:
		if(wParam == VK_LEFT)
		{
			if(xPos==0){}
			else
				xPos= xPos-20;
		}
		else if(wParam == VK_UP)
		{
			if(yPos==0){}
			else
				yPos = yPos-20;
		}
		else if(wParam == VK_RIGHT)
		{
			if(xPos >= 1100){}
			else
			xPos = xPos+20;
		}
		else if(wParam == VK_DOWN)
		{
			if(yPos>=840){}
			else
			yPos+=20;
		}
		InvalidateRect(hwnd, NULL, TRUE);
		
	case WM_PAINT:
		hdc = BeginPaint(hwnd, &ps);
		//if(count==0&&scount==0)
			//TextOut(hdc,xPos,yPos,"키보드 입력 연습문제",strlen("키보드 입력 연습문제"));
		for(int i=0; i<scount+1; i++)
		{
			GetTextExtentPoint(hdc, str[num-100][i], strlen(str[num-100][i]), &size);
			TextOut(hdc, 0, i*20, str[num-100][i], strlen(str[num-100][i]));
			SetCaretPos(size.cx, i*20);
		}
	
		EndPaint(hwnd, &ps);
		break;
	case WM_DESTROY:
		HideCaret(hwnd);
		DestroyCaret();
		PostQuitMessage(0);
		return 0;
	}
	return DefMDIChildProc(hwnd,iMsg,wParam,lParam);
}