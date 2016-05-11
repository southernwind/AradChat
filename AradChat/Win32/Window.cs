using System;
using System.Runtime.InteropServices;

namespace AradChat.Win32 {
	static class Window {

		[DllImport( "user32.dll" )]
		internal static extern int GetWindowRect( IntPtr hWnd, out RECT rect );

		[StructLayout( LayoutKind.Sequential, Pack = 4 )]
		internal struct RECT {
			internal readonly int left;
			internal readonly int top;
			internal readonly int right;
			internal readonly int bottom;
		}
	}
}