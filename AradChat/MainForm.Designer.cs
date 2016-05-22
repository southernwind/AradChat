namespace AradChat {
	internal partial class MainForm {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.btnStart = new System.Windows.Forms.Button();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.rtb2 = new System.Windows.Forms.RichTextBox();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.pb = new System.Windows.Forms.PictureBox();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbCaptcheMethod = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nudInterval = new System.Windows.Forms.NumericUpDown();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.splitContainer5 = new System.Windows.Forms.SplitContainer();
			this.pb2 = new System.Windows.Forms.PictureBox();
			this.splitContainer6 = new System.Windows.Forms.SplitContainer();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
			this.splitContainer5.Panel1.SuspendLayout();
			this.splitContainer5.Panel2.SuspendLayout();
			this.splitContainer5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
			this.splitContainer6.Panel1.SuspendLayout();
			this.splitContainer6.Panel2.SuspendLayout();
			this.splitContainer6.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
			this.splitContainer1.Size = new System.Drawing.Size(669, 839);
			this.splitContainer1.SplitterDistance = 286;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.btnStart);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new System.Drawing.Size(286, 839);
			this.splitContainer2.SplitterDistance = 95;
			this.splitContainer2.TabIndex = 0;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(56, 30);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(170, 45);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "START";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer3.IsSplitterFixed = true;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.splitContainer6);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.rtb2);
			this.splitContainer3.Size = new System.Drawing.Size(286, 740);
			this.splitContainer3.SplitterDistance = 612;
			this.splitContainer3.TabIndex = 1;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(0, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(286, 469);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// rtb2
			// 
			this.rtb2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtb2.Location = new System.Drawing.Point(0, 0);
			this.rtb2.Name = "rtb2";
			this.rtb2.Size = new System.Drawing.Size(286, 124);
			this.rtb2.TabIndex = 0;
			this.rtb2.Text = "";
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer4.IsSplitterFixed = true;
			this.splitContainer4.Location = new System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.pb);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
			this.splitContainer4.Size = new System.Drawing.Size(379, 839);
			this.splitContainer4.SplitterDistance = 419;
			this.splitContainer4.TabIndex = 1;
			// 
			// pb
			// 
			this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb.Location = new System.Drawing.Point(0, 0);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(379, 419);
			this.pb.TabIndex = 0;
			this.pb.TabStop = false;
			// 
			// txtUrl
			// 
			this.txtUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AradChat.Properties.Settings.Default, "uploadUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.txtUrl.Location = new System.Drawing.Point(91, 82);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(228, 19);
			this.txtUrl.TabIndex = 5;
			this.txtUrl.Text = global::AradChat.Properties.Settings.Default.uploadUrl;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(27, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "URL";
			// 
			// cmbCaptcheMethod
			// 
			this.cmbCaptcheMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCaptcheMethod.FormattingEnabled = true;
			this.cmbCaptcheMethod.Items.AddRange(new object[] {
            "BitBlt",
            "クリップボード"});
			this.cmbCaptcheMethod.Location = new System.Drawing.Point(90, 49);
			this.cmbCaptcheMethod.Name = "cmbCaptcheMethod";
			this.cmbCaptcheMethod.Size = new System.Drawing.Size(121, 20);
			this.cmbCaptcheMethod.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "取得方式";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "更新間隔";
			// 
			// nudInterval
			// 
			this.nudInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::AradChat.Properties.Settings.Default, "nudInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nudInterval.DecimalPlaces = 1;
			this.nudInterval.Location = new System.Drawing.Point(91, 15);
			this.nudInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudInterval.Name = "nudInterval";
			this.nudInterval.Size = new System.Drawing.Size(50, 19);
			this.nudInterval.TabIndex = 0;
			this.nudInterval.Value = global::AradChat.Properties.Settings.Default.nudInterval;
			// 
			// timer1
			// 
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// splitContainer5
			// 
			this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer5.Location = new System.Drawing.Point(0, 0);
			this.splitContainer5.Name = "splitContainer5";
			this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer5.Panel1
			// 
			this.splitContainer5.Panel1.Controls.Add(this.pb2);
			// 
			// splitContainer5.Panel2
			// 
			this.splitContainer5.Panel2.Controls.Add(this.label1);
			this.splitContainer5.Panel2.Controls.Add(this.txtUrl);
			this.splitContainer5.Panel2.Controls.Add(this.nudInterval);
			this.splitContainer5.Panel2.Controls.Add(this.label3);
			this.splitContainer5.Panel2.Controls.Add(this.label2);
			this.splitContainer5.Panel2.Controls.Add(this.cmbCaptcheMethod);
			this.splitContainer5.Size = new System.Drawing.Size(379, 416);
			this.splitContainer5.SplitterDistance = 284;
			this.splitContainer5.TabIndex = 6;
			// 
			// pb2
			// 
			this.pb2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb2.Location = new System.Drawing.Point(0, 0);
			this.pb2.Name = "pb2";
			this.pb2.Size = new System.Drawing.Size(379, 284);
			this.pb2.TabIndex = 0;
			this.pb2.TabStop = false;
			// 
			// splitContainer6
			// 
			this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer6.IsSplitterFixed = true;
			this.splitContainer6.Location = new System.Drawing.Point(0, 0);
			this.splitContainer6.Name = "splitContainer6";
			this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer6.Panel1
			// 
			this.splitContainer6.Panel1.Controls.Add(this.richTextBox1);
			// 
			// splitContainer6.Panel2
			// 
			this.splitContainer6.Panel2.Controls.Add(this.richTextBox2);
			this.splitContainer6.Size = new System.Drawing.Size(286, 612);
			this.splitContainer6.SplitterDistance = 469;
			this.splitContainer6.TabIndex = 0;
			// 
			// richTextBox2
			// 
			this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox2.Location = new System.Drawing.Point(0, 0);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(286, 139);
			this.richTextBox2.TabIndex = 0;
			this.richTextBox2.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 839);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
			this.splitContainer5.Panel1.ResumeLayout(false);
			this.splitContainer5.Panel2.ResumeLayout(false);
			this.splitContainer5.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
			this.splitContainer5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
			this.splitContainer6.Panel1.ResumeLayout(false);
			this.splitContainer6.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
			this.splitContainer6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.RichTextBox rtb2;
		private System.Windows.Forms.SplitContainer splitContainer4;
		private System.Windows.Forms.ComboBox cmbCaptcheMethod;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudInterval;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.SplitContainer splitContainer5;
		private System.Windows.Forms.PictureBox pb2;
		private System.Windows.Forms.SplitContainer splitContainer6;
		private System.Windows.Forms.RichTextBox richTextBox2;
	}
}

