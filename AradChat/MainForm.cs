using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AradChat {
	internal partial class MainForm :Form {

		internal MainForm() {
			InitializeComponent();
			this.cmbCaptcheMethod.SelectedIndex = 0;
			LoadSettings();
			Application.ApplicationExit += Application_ApplicationExit;
		}

		private bool _timerFlag;
		private void btnStart_Click( object sender, EventArgs e ) {
			this.timer1.Interval = (int)(this.nudInterval.Value * 1000);
			if( !this._timerFlag ) {
				this.timer1.Start();
				this._timerFlag = true;
				this.btnStart.Text = "STOP";
				SendLog();
			} else {
				this.timer1.Stop();
				this._timerFlag = false;
				this.btnStart.Text = "START";
			}
		}

		private void timer1_Tick( object sender, EventArgs e ) {
			SendLog();
		}

		private async void SendLog() {
			var bmp = Arad.Client.GetChatScreenShot(this.cmbCaptcheMethod.SelectedIndex);
			var megaphone = new Arad.ChatWindow.Megaphone( bmp );
			this.pb.Image = megaphone.image;
			var log = megaphone.GetLog();
			this.richTextBox1.Text = "";
			var hc = new Hc();
			var uploadUrl = this.txtUrl.Text;
			var dPost = new Dictionary<string, string>();
			var index = 0;
			foreach( var row in log.Where( row => row.name != "" ) ) {
				this.richTextBox1.Text += "[ Ch." + row.channel + " ] [" + row.name + "] : " + row.detail + Environment.NewLine + Environment.NewLine;
				dPost.Add( "chat[" + index + "][ch]", row.channel.ToString() );
				dPost.Add( "chat[" + index + "][name]", row.name );
				dPost.Add( "chat[" + index + "][detail]", row.detail );
				index++;
			}
			var html = await hc.Navigate( uploadUrl, dPost );
			this.rtb2.Text = html;
		}


		/// <summary>
		/// アプリケーション終了時、設定を保存する。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Application_ApplicationExit( object sender, EventArgs e ) {
			SaveSettings();
			Properties.Settings.Default.Save();
		}

		private void SaveSettings() {
			Properties.Settings.Default.cmbCaptcheMethod = this.cmbCaptcheMethod.SelectedIndex;

		}

		private void LoadSettings() {
			this.cmbCaptcheMethod.SelectedIndex = Properties.Settings.Default.cmbCaptcheMethod;
		}
	}
}
