using System;
using System.Runtime.InteropServices;

namespace AradChat.Win32 {
	static class Object {
		[DllImport( "gdi32.dll" )]
		public static extern int BitBlt( IntPtr hDestDc, int x, int y, int nWidth, int nHeight, IntPtr hSrcDc, int xSrc, int ySrc, int dwRop );
	}
}