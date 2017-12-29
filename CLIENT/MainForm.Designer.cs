/*
 * Created by SharpDevelop.
 * User: chepchip
 * Date: 4/18/2017
 * Time: 1:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace CLIENT
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btconnect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lbtime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxOpMark = new System.Windows.Forms.TextBox();
            this.BoxMyMark = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.Room = new System.Windows.Forms.Label();
            this.btbatdau = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cancau = new System.Windows.Forms.Button();
            this.btdao = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "127.0.0.1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(53, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "13000";
            // 
            // btconnect
            // 
            this.btconnect.Location = new System.Drawing.Point(13, 58);
            this.btconnect.Name = "btconnect";
            this.btconnect.Size = new System.Drawing.Size(140, 44);
            this.btconnect.TabIndex = 10;
            this.btconnect.Text = "Connect";
            this.btconnect.UseVisualStyleBackColor = true;
            this.btconnect.Click += new System.EventHandler(this.ConnectClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btconnect);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(542, 365);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 110);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lbtime);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.BoxOpMark);
            this.panel3.Controls.Add(this.BoxMyMark);
            this.panel3.Location = new System.Drawing.Point(542, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(171, 180);
            this.panel3.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Menu;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(11, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "Đối thủ đã thoát";
            this.label7.Visible = false;
            // 
            // lbtime
            // 
            this.lbtime.AutoSize = true;
            this.lbtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtime.Location = new System.Drawing.Point(135, 119);
            this.lbtime.Name = "lbtime";
            this.lbtime.Size = new System.Drawing.Size(22, 16);
            this.lbtime.TabIndex = 7;
            this.lbtime.Text = "";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(8, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Thời gian chơi";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(11, 116);
            this.progressBar1.Maximum = 60;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(122, 22);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Điểm của đối thủ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điểm của bạn";
            // 
            // BoxOpMark
            // 
            this.BoxOpMark.Location = new System.Drawing.Point(68, 54);
            this.BoxOpMark.Name = "BoxOpMark";
            this.BoxOpMark.ReadOnly = true;
            this.BoxOpMark.Size = new System.Drawing.Size(85, 20);
            this.BoxOpMark.TabIndex = 1;
            this.BoxOpMark.Text = "0";
            // 
            // BoxMyMark
            // 
            this.BoxMyMark.Location = new System.Drawing.Point(68, 12);
            this.BoxMyMark.Name = "BoxMyMark";
            this.BoxMyMark.ReadOnly = true;
            this.BoxMyMark.Size = new System.Drawing.Size(82, 20);
            this.BoxMyMark.TabIndex = 0;
            this.BoxMyMark.Text = "0";
            this.BoxMyMark.TextChanged += new System.EventHandler(this.BoxMyMark_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.Room);
            this.panel4.Controls.Add(this.btbatdau);
            this.panel4.Location = new System.Drawing.Point(542, 244);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 107);
            this.panel4.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(17, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 13;
            // 
            // Room
            // 
            this.Room.AutoSize = true;
            this.Room.Location = new System.Drawing.Point(13, 79);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(38, 13);
            this.Room.TabIndex = 7;
            this.Room.Text = "Phòng";
            // 
            // btbatdau
            // 
            this.btbatdau.Enabled = false;
            this.btbatdau.Location = new System.Drawing.Point(13, 32);
            this.btbatdau.Name = "btbatdau";
            this.btbatdau.Size = new System.Drawing.Size(140, 44);
            this.btbatdau.TabIndex = 11;
            this.btbatdau.Text = "Sẵn sàng";
            this.btbatdau.UseVisualStyleBackColor = true;
            this.btbatdau.Click += new System.EventHandler(this.btbatdau_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cancau);
            this.panel5.Location = new System.Drawing.Point(12, 11);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(524, 46);
            this.panel5.TabIndex = 15;
            // 
            // cancau
            // 
            this.cancau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cancau.BackColor = System.Drawing.Color.White;
            this.cancau.BackgroundImage = global::CLIENT.Properties.Resources.Untitled1;
            this.cancau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancau.Location = new System.Drawing.Point(0, 0);
            this.cancau.Margin = new System.Windows.Forms.Padding(0);
            this.cancau.Name = "cancau";
            this.cancau.Size = new System.Drawing.Size(23, 46);
            this.cancau.TabIndex = 1;
            this.cancau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cancau.UseVisualStyleBackColor = false;
            // 
            // btdao
            // 
            this.btdao.Enabled = false;
            this.btdao.Location = new System.Drawing.Point(542, 12);
            this.btdao.Name = "btdao";
            this.btdao.Size = new System.Drawing.Size(171, 44);
            this.btdao.TabIndex = 12;
            this.btdao.Text = "Đào";
            this.btdao.UseVisualStyleBackColor = true;
            this.btdao.Click += new System.EventHandler(this.btdao_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::CLIENT.Properties.Resources.Asset_3_100;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 417);
            this.panel1.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(738, 526);
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(739, 504);
            this.Controls.Add(this.btdao);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(755, 543);
            this.MinimumSize = new System.Drawing.Size(755, 543);
            this.Name = "MainForm";
            this.Text = "Đào vàng online";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button btconnect;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			CheckForIllegalCrossThreadCalls = false;			
		}
		
	

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoxOpMark;
        private System.Windows.Forms.TextBox BoxMyMark;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btbatdau;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btdao;
        private volatile System.Windows.Forms.Button cancau;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Room;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
