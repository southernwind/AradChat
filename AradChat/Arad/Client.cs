using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AradChat.Arad {
	/// <summary>
	/// アラド戦記クライアントに対する動作はここで定義する
	/// なお、アラド戦記が多数起動されていない前提で作成されている
	/// </summary>
	static class Client {

		/// <summary>
		/// アラド戦記チャットウィンドウ横幅
		/// </summary>
		private const int CHAT_W = 330;

		/// <summary>
		/// アラド戦記チャットウィンドウ高さ
		/// </summary>
		private const int CHAT_H = 600;

		/// <summary>
		/// アラド戦記クライアントの横幅デフォルト値
		/// </summary>
		private const int DEFAULT_W = 800;

		/// <summary>
		/// アラド戦記クライアントの高さデフォルト値
		/// </summary>
		private const int DEFAULT_H = 600;

		/// <summary>
		/// アラド戦記のプロセス
		/// </summary>
		private static Process _process;

		/// <summary>
		/// アラド戦記のクライアントの左上X座標
		/// </summary>
		private static int x;

		/// <summary>
		/// アラド戦記のクライアントの左上Y座標
		/// </summary>
		private static int y;

		/// <summary>
		/// アラド戦記のクライアントの横幅
		/// </summary>
		private static int w = DEFAULT_W;

		/// <summary>
		/// アラド戦記のクライアントの高さ
		/// </summary>
		private static int h = DEFAULT_H;

		/// <summary>
		/// Windowのマージン 左
		/// </summary>
		private const int MARGIN_LEFT = 0;

		/// <summary>
		/// Windowのマージン 上
		/// </summary>
		private const int MARGIN_TOP = 0;

		/// <summary>
		/// Windowのマージン 右
		/// </summary>
		private const int MARGIN_RIGHT = 0;


		/// <summary>
		/// Windowのマージン 下
		/// </summary>
		private const int MARGIN_BOTTOM = 0;

		/// <summary>
		/// プロセスを取得し、
		/// アラド戦記のクライアント生存状況,X,Y,W,Hの値を取得し
		/// さらにW,Hを元にデフォルト値からの比率を計算する。
		/// </summary>
		private static void Get() {
			_process = Process.GetProcessesByName( Properties.Settings.Default.processName ).FirstOrDefault( hProcess => !hProcess.HasExited && hProcess.MainWindowHandle != IntPtr.Zero );

			if( _process == null ) {
				return;
			}

			Win32.Window.RECT rect;
			try {
				Win32.Window.GetWindowRect( _process.MainWindowHandle, out rect );
			} catch( Exception ) {
				return;
			}
			x = rect.left + MARGIN_LEFT;
			y = rect.top + MARGIN_TOP;
			w = rect.right - rect.left - MARGIN_LEFT - MARGIN_RIGHT;
			h = rect.bottom - rect.top - MARGIN_BOTTOM - MARGIN_TOP;
		}

		/// <summary>
		/// アラド戦記の右側のチャットウィンドウのスクリーンショットを取得する。
		/// 引数情報により、スクリーンショットの範囲を変更できる。
		/// 何も渡さなければアラド戦記の右側のチャットウィンドウ全体が取得できる。
		/// </summary>
		/// <param name="methodType">キャプチャ方式 0:BitBlt 1:Printscreen</param>
		/// <param name="targetX">左上X座標</param>
		/// <param name="targetY">左上Y座標</param>
		/// <param name="targetW">横幅</param>
		/// <param name="targetH">高さ</param>
		/// <returns></returns>
		internal static Bitmap GetChatScreenShot(int methodType, int targetX = 0, int targetY = 0, int targetW = 0, int targetH = 0 ) {
			Get();
			if( targetW == 0 ) {
				targetW = CHAT_W;
			}
			if( targetH == 0 ) {
				targetH = CHAT_H;
			}
			if( targetX + targetW > CHAT_W || targetY + targetH > CHAT_H ) {
				throw new ArgumentOutOfRangeException();
			}

			//チャット画面の相対座標から画面の絶対座標に変換
			targetX += x + w;
			targetY += y;
			if( methodType == 0 ) {
				return BitBlt( targetX, targetY, targetW, targetH );
			}
			return Prscr( targetX, targetY, targetW, targetH );
		}

		/// <summary>
		/// PrintScreenキーをストロークしてクリップボードから取得
		/// </summary>
		/// <returns>Bitmap</returns>
		private static Bitmap Prscr( int targetX, int targetY, int targetW, int targetH ) {
			var point = GetPrimaryDisplayPosition();

			targetX += point.X;
			targetY += point.Y;

			var bmp = new Bitmap( targetW, targetH );
			SendKeys.SendWait( "^{PRTSC}" );
			Application.DoEvents();
			var d = Clipboard.GetDataObject();

			//ビットマップデータ形式に関連付けられているデータを取得
			var img = (Bitmap)d?.GetData( DataFormats.Bitmap );
			if( img != null ) {
				using( var g = Graphics.FromImage( bmp ) ) {
					g.DrawImage( img, new Rectangle( 0, 0, bmp.Width, bmp.Height ), new Rectangle( targetX, targetY, bmp.Width, bmp.Height ), GraphicsUnit.Pixel );
				}
			}

			return bmp;
		}
		/// <summary>
		/// 座標を指定してスクリーンショットを取得
		/// </summary>
		/// <returns>Bitmap</returns>
		private static Bitmap BitBlt(int targetX, int targetY, int targetW, int targetH) {
			var bmp = new Bitmap( targetW, targetH );
			var disDC = Win32.DC.GetDC( IntPtr.Zero );
			using( var g = Graphics.FromImage( bmp ) ) {
				var hDC = g.GetHdc();
				Win32.Object.BitBlt( hDC, 0, 0, bmp.Width, bmp.Height, disDC, targetX, targetY, 13369376 );
				g.ReleaseHdc( hDC );
			}
			Win32.DC.ReleaseDC( IntPtr.Zero, disDC );
			return bmp;
		}


		private static Point GetPrimaryDisplayPosition() {
			var result = new Point(0,0);
			foreach( var screen in Screen.AllScreens ) {
				if( screen.Bounds.X < 0 ) {
					result.X -= screen.Bounds.X;
				}
				if( screen.Bounds.Y < 0 ) {
					result.Y -= screen.Bounds.Y;
				}
			}
			return result;
		}
	}
}