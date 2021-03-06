﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AradChat.Arad.ChatWindow {
	class Megaphone {

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
		/// メガホンチャットログ画像
		/// </summary>
		internal readonly Bitmap image;

		internal class MegaphoneChatLog :ChatLog {

			internal int channel;

		}

		internal Megaphone(Bitmap img) {
			var imageHeight = H;
			/* 切り取り位置検索 */
			var targetY = 0;
			for( var y = 0; y < img.Height - 6; y++ ) {
				if( img.GetPixel( 30, y ) == FontColor.Text.tab &&
					img.GetPixel( 30, y + 1 ) == FontColor.Text.tab &&
					img.GetPixel( 30, y + 2 ) == FontColor.Text.tab &&
					img.GetPixel( 30, y + 3 ) == FontColor.Text.tab &&
					img.GetPixel( 30, y + 4 ) != FontColor.Text.tab &&
					img.GetPixel( 30, y + 5 ) == FontColor.Text.tab &&
					img.GetPixel( 30, y + 6 ) != FontColor.Text.tab
												) {
					targetY = y + 15;
					break;
				}
			}

			//画像の高さを決定
			for( var endy = 0; endy < img.Height - 6; endy++ ) {
				if( img.GetPixel( 34, endy ) != FontColor.Text.general &&
					img.GetPixel( 34, endy + 1 ) == FontColor.Text.general &&
					img.GetPixel( 34, endy + 2 ) == FontColor.Text.general &&
					img.GetPixel( 34, endy + 3 ) != FontColor.Text.general &&
					img.GetPixel( 34, endy + 4 ) == FontColor.Text.general &&
					img.GetPixel( 34, endy + 5 ) != FontColor.Text.general &&
					img.GetPixel( 34, endy + 6 ) == FontColor.Text.general &&
					img.GetPixel( 34, endy + 7 ) != FontColor.Text.general &&
					img.GetPixel( 34, endy + 8 ) == FontColor.Text.general &&
					img.GetPixel( 34, endy + 9 ) != FontColor.Text.general &&
					img.GetPixel( 34, endy + 10 ) != FontColor.Text.general &&
					img.GetPixel( 34, endy + 11 ) == FontColor.Text.general
												) {
					imageHeight = endy - targetY - 15;
					break;
				}
			}

			this.image = new Bitmap( W, imageHeight );
			using( var g = Graphics.FromImage( this.image ) ) {
				g.DrawImage( img, new Rectangle( 0, 0, this.image.Width, this.image.Height ), new Rectangle( X, targetY, this.image.Width, this.image.Height ), GraphicsUnit.Pixel );
			}
		}

		internal IEnumerable<MegaphoneChatLog> GetLog() {

			var result = new List<MegaphoneChatLog>();
			var temp = new MegaphoneChatLog();
			for( var y = 4; y < this.image.Height - FONT_H; y += 16 ) {

				//チャンネル表示を見つけるたびにチャット格納変数を切り替える

				var color = this.image.GetPixel( 8, y + 1 );

				if( CheckColor( color, FontColor.Channel.min, FontColor.Channel.max ) ) {
					if( temp.name != "" ) {
						result.Add( temp );
					}
					temp = new MegaphoneChatLog();

					var chImg = new Bitmap( CH_W, CH_H );
					using( var g = Graphics.FromImage( chImg ) ) {
						g.DrawImage( this.image, new Rectangle( 0, 0, chImg.Width, chImg.Height ), new Rectangle( 7, y+1, chImg.Width, chImg.Height ), GraphicsUnit.Pixel );
					}
					temp.channel = GetCh(chImg);

					var img = new Bitmap( W - 42, FONT_H );
					using( var g = Graphics.FromImage( img ) ) {
						g.DrawImage( this.image, new Rectangle( 0, 0, img.Width, img.Height ), new Rectangle( 42, y, img.Width, img.Height ), GraphicsUnit.Pixel );
					}
					var tempstr = GetText( img );
					temp.raw.Add( tempstr );
					temp.name += Regex.Replace( tempstr, " : .*$", "" ).Trim();
					temp.detail += Regex.Replace( tempstr, "^.*? : ", "" ).Trim();
				} else {

					var img = new Bitmap( W, FONT_H );
					using( var g = Graphics.FromImage( img ) ) {
						g.DrawImage( this.image, new Rectangle( 0, 0, img.Width, img.Height ), new Rectangle( 0 , y, img.Width, img.Height ), GraphicsUnit.Pixel );
					}
					var tempstr = GetText( img );
					temp.raw.Add( tempstr );
					temp.detail += tempstr.Trim();
				}
			}

			if( temp.name != "" ) {
				result.Add( temp );
			}
			return result.ToArray();
		}

		private static int GetCh( Bitmap bmp ) {
			const int searchStartIndexX = 12;
			const int searchStartIndexY = 2;
			var colordata = new bool[bmp.Width - searchStartIndexX, CH_FONT_H];

			//扱いやすいbool型に
			for( var x = searchStartIndexX; x < bmp.Width; x++ ) {
				for( var y = searchStartIndexY; y < searchStartIndexY + CH_FONT_H; y++ ) {
					var tmpcolor = bmp.GetPixel( x, y );
					if( tmpcolor == FontColor.Channel.text ) {
						colordata[x - searchStartIndexX, y - searchStartIndexY] = true;
					} else {
						colordata[x - searchStartIndexX, y - searchStartIndexY] = false;
					}
				}
			}

			//文字と文字の間の位置を求める
			var spaceList = new List<int>();
			spaceList.Add( -1 );
			for( var x = 0; x < colordata.GetLength( 0 ); x++ ) {
				var flag = false;
				for( var y = 0; y < colordata.GetLength( 1 ); y++ ) {
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
			var chText = "";
			for( var i = 0; i < spaceList.Count; i++ ) {
				var nextCol = i + 1 == spaceList.Count ? colordata.GetLength( 0 ) : spaceList[i + 1];

				if( spaceList[i] + 1 < nextCol ) {

					var fontdata = "";
					for( var x = spaceList[i] + 1; x < nextCol; x++ ) {
						for( var y = 0; y < CH_FONT_H; y++ ) {
							fontdata += colordata[x, y] ? "1" : "0";
						}
					}

					switch( fontdata ) {
						case "111111000111111":
							chText += "0";
							break;
						case "010011111100001":
							chText += "1";
							break;
						case "101111010111101":
							chText += "2";
							break;
						case "101011010111111":
							chText += "3";
							break;
						case "111000010011111":
							chText += "4";
							break;
						case "111011010110111":
							chText += "5";
							break;
						case "111111010110111":
							chText += "6";
							break;
						case "100001011111000":
							chText += "7";
							break;
						case "111111010111111":
							chText += "8";
							break;
						case "111011010111111":
							chText += "9";
							break;
					}
				}
			}
			int result;

			if( int.TryParse( chText,out result ) ) {

				return result;
			}
			return 0;
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
						if( tmpcolor == FontColor.Text.megaphone ) {
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

				tempStr = Regex.Replace( Regex.Replace( tempStr, " +$", " " ), "^ +", "" );
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
