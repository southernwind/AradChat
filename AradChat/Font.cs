using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using AradChat.Properties;

namespace AradChat {
	internal class Font :IDisposable {

		private readonly SQLiteConnection _conn;

		internal Font() {
			if( !File.Exists( "./font.db" ) ) {
				File.WriteAllBytes( "./font.db", Resources.font );
				Thread.Sleep( 300 );
			}
			this._conn = new SQLiteConnection( "Data Source=./font.db" );
			this._conn.Open();
		}

		public void Dispose() {
			this._conn.Close();
		}

		internal string[] Search( string fontdata ) {
			using( var command = this._conn.CreateCommand() ) {
				command.CommandText = "SELECT char FROM fonts WHERE fontdata=@fontdata";
				command.Parameters.Add( "@fontdata", DbType.String );
				command.Parameters["@fontdata"].Value = fontdata;
				using( var reader = command.ExecuteReader() ) {
					var result = new List<string>();
					for( var i = 0; reader.Read(); i++ ) {
						result.Add( reader[0].ToString() );
					}
					return result.ToArray();
				}
			}
		}

		internal string[][] LikeSearch( string fontdata ) {
			using( var command = this._conn.CreateCommand() ) {
				command.CommandText = "SELECT char,fontdata FROM fonts WHERE fontdata LIKE @fontdata";
				command.Parameters.Add( "@fontdata", DbType.String );
				command.Parameters["@fontdata"].Value = fontdata + "%";
				using( var reader = command.ExecuteReader() ) {
					var result = new List<string[]>();
					for( var i = 0; reader.Read(); i++ ) {
						result.Add(
									new[] {
									reader[0].ToString(),
									reader[1].ToString()
									} );
					}

					return result.ToArray();
				}
			}
		}
	}
}
