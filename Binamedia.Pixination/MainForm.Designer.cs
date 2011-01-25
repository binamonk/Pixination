namespace Binamedia.Pixination
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsGetPixelColor = new System.Windows.Forms.ToolStripMenuItem();
			this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuGoogleLogin = new System.Windows.Forms.ToolStripMenuItem();
			this.dlgColor = new System.Windows.Forms.ColorDialog();
			this.pctSelect = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.txtHex = new System.Windows.Forms.TextBox();
			this.mnuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctSelect)).BeginInit();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolsToolStripMenuItem,
									this.googleToolStripMenuItem});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(232, 24);
			this.mnuMain.TabIndex = 0;
			this.mnuMain.Text = "menuStrip1";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnuToolsGetPixelColor});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// mnuToolsGetPixelColor
			// 
			this.mnuToolsGetPixelColor.Name = "mnuToolsGetPixelColor";
			this.mnuToolsGetPixelColor.Size = new System.Drawing.Size(155, 22);
			this.mnuToolsGetPixelColor.Text = "Get Pixel Color";
			// 
			// googleToolStripMenuItem
			// 
			this.googleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnuGoogleLogin});
			this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
			this.googleToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.googleToolStripMenuItem.Text = "Google";
			// 
			// mnuGoogleLogin
			// 
			this.mnuGoogleLogin.Name = "mnuGoogleLogin";
			this.mnuGoogleLogin.Size = new System.Drawing.Size(110, 22);
			this.mnuGoogleLogin.Text = "Login";
			this.mnuGoogleLogin.Click += new System.EventHandler(this.MnuGoogleLoginClick);
			// 
			// pctSelect
			// 
			this.pctSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pctSelect.Location = new System.Drawing.Point(12, 27);
			this.pctSelect.Name = "pctSelect";
			this.pctSelect.Size = new System.Drawing.Size(32, 32);
			this.pctSelect.TabIndex = 1;
			this.pctSelect.TabStop = false;
			this.pctSelect.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(50, 27);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(181, 27);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(39, 20);
			this.textBox2.TabIndex = 4;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(181, 53);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(39, 20);
			this.textBox3.TabIndex = 5;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(181, 79);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(39, 20);
			this.textBox4.TabIndex = 6;
			// 
			// txtHex
			// 
			this.txtHex.Location = new System.Drawing.Point(50, 53);
			this.txtHex.Name = "txtHex";
			this.txtHex.Size = new System.Drawing.Size(100, 20);
			this.txtHex.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(232, 169);
			this.Controls.Add(this.txtHex);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pctSelect);
			this.Controls.Add(this.mnuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnuMain;
			this.Name = "MainForm";
			this.Text = "Pixination";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctSelect)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem mnuGoogleLogin;
		private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
		private System.Windows.Forms.TextBox txtHex;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.PictureBox pctSelect;
		private System.Windows.Forms.ColorDialog dlgColor;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsGetPixelColor;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mnuMain;
	}
}
