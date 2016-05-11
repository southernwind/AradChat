using System;
using System.Runtime.InteropServices;

namespace AradChat.Win32 {
	static class DC {

		[DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		internal static extern IntPtr GetDC( IntPtr hwnd );

		[DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		internal static extern IntPtr ReleaseDC( IntPtr hwnd, IntPtr hdc );

	}
}