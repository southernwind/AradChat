using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AradChat.Arad.ChatWindow {
	class General {

		/// <summary>
		/// 切り取り位置X座標
		/// </summary>
		private const int X = 10;

		/// <summary>
		/// 切り取り幅
		/// </summary>
		private const int W = 305;

		/// <summary>
		/// 切り取り高さ
		/// </summary>
		private const int H = 326;

		/// <summary>
		/// フォントの高さ
		/// </summary>
		private const int FONT_H = 12;

		/// <summary>
		/// チャンネル画像幅
		/// </summary>
		private const int CH_W = 25;

		/// <summary>
		/// チャンネル画像高さ
		/// </summary>
		private const int CH_H = 9;

		/// <summary>
		/// チャンネルフォントの高さ
		/// </summary>
		private const int CH_FONT_H = 5;

		/// <summary>
		/// 一般チャットログ画像
		/// </summary>
		internal readonly Bitmap image;

		internal class GeneralChatLog :ChatLog {

		}

		internal General(Bitmap img) {
			/* 切り取り位置検索 */
			var targetY = 0;
			for( var y = 0; y < img.Height - 6; y++ ) {
				if( img.GetPixel( 34, y ) != FontColor.Text.general &&
					img.GetPixel( 34, y + 1 ) == FontColor.Text.general &&
					img.GetPixel( 34, y + 2 ) == FontColor.Text.general &&
					img.GetPixel( 34, y + 3 ) != FontColor.Text.general &&
					img.GetPixel( 34, y + 4 ) == FontColor.Text.general &&
					img.GetPixel( 34, y + 5 ) != FontColor.Text.general &&
					img.GetPixel( 34, y + 6 ) == FontColor.Text.general &&
					img.GetPixel( 34, y + 7 ) != FontColor.Text.general &&
					img.GetPixel( 34, y + 8 ) == FontColor.Text.general &&
					img.GetPixel( 34, y + 9 ) != FontColor.Text.general &&
					img.GetPixel( 34, y + 10 ) != FontColor.Text.general &&
					img.GetPixel( 34, y + 11 ) == FontColor.Text.general
												) {
					targetY = y + 17;
					break;
				}
			}

			this.image = new Bitmap(W,H);
			using( var g = Graphics.FromImage( this.image ) ) {
				g.DrawImage( img, new Rectangle( 0, 0, this.image.Width, this.image.Height ), new Rectangle( X, targetY, this.image.Width, this.image.Height ), GraphicsUnit.Pixel );
			}
		}

		internal IEnumerable<GeneralChatLog> GetLog() {

			var result = new List<GeneralChatLog>();
			var temp = new GeneralChatLog();
			for( var y = 4; y < this.image.Height; y += 16 ) {
				var img = new Bitmap( W, FONT_H );
				using( var g = Graphics.FromImage( img ) ) {
					g.DrawImage( this.image, new Rectangle( 0, 0, img.Width, img.Height ), new Rectangle( 0, y, img.Width, img.Height ), GraphicsUnit.Pixel );
				}
				var tempstr = GetText( img );
				if( !Regex.IsMatch( tempstr, "^ {8}" ) ) { //1行目
					if( temp.name != "" ) {
						result.Add( temp );
					}
					temp = new GeneralChatLog();
					temp.raw.Add( tempstr );
					temp.name += Regex.Replace( tempstr, " : .*$", "" ).Trim();
					temp.detail += Regex.Replace( tempstr, "^.*? : ", "" ).Trim();
				} else { //2行目以降
					temp.raw.Add( tempstr );
					temp.detail += tempstr.Trim();
				}
			}

			if( temp.name != "" ) {
				result.Add( temp );
			}
			return result.ToArray();
		}

		private static string GetText( Bitmap bmp ) {
			var colordata = new bool[bmp.Width,bmp.Height];
			var itemType = new int[bmp.Width];
			var spacedata = "";
			for( var y = 0; y < FONT_H; y++ ) {
				spacedata += "0";
			}

			using( var font = new Font() ) {
				//扱いやすいbool型に
				for( var x = 0; x < bmp.Width; x++ ) {
					for( var y = 0; y < bmp.Height; y++ ) {
						var tmpcolor = bmp.GetPixel( x, y );
						if( tmpcolor == FontColor.Text.guild ) {
							colordata[x, y] = true;
						} else if( tmpcolor == FontColor.Text.general ) {
							colordata[x, y] = true;
						} else {
							if( tmpcolor == FontColor.Grade.chronicle ) {
								colordata[x, y] = true;
								itemType[x] = 1;
							} else if( tmpcolor == FontColor.Grade.common ) {
								colordata[x, y] = true;
								itemType[x] = 2;
							} else if( tmpcolor == FontColor.Grade.epic ) {
								colordata[x, y] = true;
								itemType[x] = 3;
							} else if( tmpcolor == FontColor.Grade.legendary ) {
								colordata[x, y] = true;
								itemType[x] = 4;
							} else if( tmpcolor == FontColor.Grade.rare ) {
								colordata[x, y] = true;
								itemType[x] = 5;
							} else if( tmpcolor == FontColor.Grade.uncommon ) {
								colordata[x, y] = true;
								itemType[x] = 6;
							} else if( tmpcolor == FontColor.Grade.unique ) {
								colordata[x, y] = true;
								itemType[x] = 7;
							} else {
								colordata[x, y] = false;
							}
						}
					}
				}

				//文字と文字の間の位置を求める
				var spaceList = new List<int>();
				spaceList.Add( -1 );
				for( var x = 0; x < bmp.Width; x++ ) {
					var flag = false;
					for( var y = 0; y < bmp.Height ; y++ ) {
						if( colordata[x, y] ) {
							flag = true;
							break;
						}
					}
					if( !flag ) {
						spaceList.Add( x );
					}
				}

				//0と1で構成されたfontdataを生成する
				var fontdataList = new List<string>();
				for( var i = 0; i < spaceList.Count; i++ ) {
					var nextCol = i + 1 == spaceList.Count ? bmp.Width : spaceList[i + 1];

					fontdataList.Add( spacedata );

					if( spaceList[i] + 1 < nextCol ) {

						var fontdata = "";
						for( var x = spaceList[i] + 1; x < nextCol; x++ ) {
							for( var y = 0; y < bmp.Height; y++ ) {
								fontdata += colordata[x, y] ? "1" : "0";
							}
						}
						fontdataList.Add( fontdata );
					}
				}

				var tempStr = "";
				for( var i = 0; i < fontdataList.Count; i++ ) {

					//空列が4つ続けば半角スペースであると判断する。
					if( fontdataList.Count - 4 > i ) {
						if( fontdataList[i] == spacedata &&
							fontdataList[i + 1] == spacedata &&
							fontdataList[i + 2] == spacedata &&
							fontdataList[i + 3] == spacedata
														) {
							tempStr += " ";
							i += 3;
							continue;
						}
					}
					var res = font.LikeSearch( fontdataList[i] );
					switch( res.Length ) {
						case 0:

							//該当0
							break;
						case 1:
							tempStr += res[0][0];
							break;
						default:

							//複数結果があった場合の処理
							tempStr += LongestMatch( res, fontdataList.ToArray(), ref i );
							break;
					}
				}
				tempStr = Regex.Replace( tempStr, "([A-Z])０", "$1O" );
				tempStr = Regex.Replace( tempStr, "０([A-Z])", "O$1" );
				return tempStr;
			}
		}

		/// <summary>
		///     データベースから複数の応答があった場合の判断をする
		/// </summary>
		/// <param name="fontdataResult">データベースからの結果(char,fontdata)</param>
		/// <param name="fontdataList">各文字のfontdataリスト</param>
		/// <param name="index">fontdataListの文字開始位置</param>
		/// <returns>判断された文字</returns>
		private static string LongestMatch( string[][] fontdataResult, IReadOnlyList<string> fontdataList, ref int index ) {
			var maxlength = fontdataResult.Select( t => t[1].Length ).Concat( new[] {
				0
			} ).Max();

			var result = "";
			var fontdata = "";
			for( var fi = index; fi < fontdataList.Count; fi++ ) {
				fontdata += fontdataList[fi];
				if( fontdata.Length > maxlength ) {
					break;
				}
				var tmpfd = fontdata;
				foreach( var col in fontdataResult.Where( col => col[1] == tmpfd ) ) {
					result = col[0];
					index = fi;
				}
			}
			return result;
		}

		/// <summary>
		/// 色閾値の検証値が最小値と最大値の間に収まっているかを判定する
		/// </summary>
		/// <param name="check">検証値</param>
		/// <param name="min">最小値</param>
		/// <param name="max">最大値</param>
		/// <returns>結果</returns>
		private static bool CheckColor( Color check, Color min, Color max ) {
			if( check.R >= min.R && check.R <= max.R && check.G >= min.G && check.G <= max.G && check.B >= min.B && check.B <= max.B ) {
				return true;
			}
			return false;

		}
	}
}
