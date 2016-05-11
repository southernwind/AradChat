using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AradChat {
	internal partial class MainForm :Form {

		internal MainForm() {
			InitializeComponent();
			this.cmbCaptcheMethod.SelectedIndex = 0;
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
	}
}
