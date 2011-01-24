using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Binamedia.Pixination
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void PctSelectClick(object sender, EventArgs e)
		{
			
		}
		
		private Bitmap bmpScreenshot;
		
		private int WorkStatus;
		private bool bSelectColor = false;
		
		public struct POINTAPI{
			public int x; 
			public int y;
		}
		
		private int posX;
		private int posY;
		
		[DllImport("user32.dll")]
		public static extern int GetCursorPos(ref POINTAPI lpPoint);
		
		POINTAPI p = new POINTAPI();
		
		private void UpdateText(object[] text){
			textBox1.Text = text[0].ToString();
			posX = (int)text[1];
			posY = (int)text[2];		
		}
		
		private void UpdatePixels(int pX, int pY){
			posX = pX;
			posY = pY;
			textBox1.Text = "X: "+pX.ToString() + " Y:"+pY.ToString();

		Graphics gfxScreenshot;
	            // Set the bitmap object to the size of the screen
	            bmpScreenshot = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);            
	            // Create a graphics object from the bitmap
	            gfxScreenshot = Graphics.FromImage(bmpScreenshot);
	            // Take the screenshot from the upper left corner to the right bottom corner
	            gfxScreenshot.CopyFromScreen(posX, 
	                                         posY, 0, 0, new Size(1,1), CopyPixelOperation.SourceCopy);
	            // Save the screenshot to the specified path that the user has chosen				
			
            Color myColor = bmpScreenshot.GetPixel(0,0);
            pctSelect.BackColor = myColor;
            textBox2.Text = myColor.R.ToString();
            textBox3.Text = myColor.G.ToString();
            textBox4.Text = myColor.B.ToString();
            txtHex.Text = "#" + int.Parse(myColor.R.ToString()).ToString("X2") +
            					int.Parse(myColor.G.ToString()).ToString("X2") +
            					int.Parse(myColor.B.ToString()).ToString("X2") ;
		}
		
		public delegate void UpdateTextCallback(object[] text);
		public delegate void UpdatePixelsCallback(int pX, int pY);
		
		private void GetMyCusorPos(){
			while (WorkStatus == 0)
			{
				GetCursorPos(ref p);
				this.Invoke(new UpdatePixelsCallback(UpdatePixels),
				new object[2] { p.x,p.y});
				Thread.Sleep(1);
			}
		}
		
		private void btnStart_Click(object sender, EventArgs e){
			Thread t = new Thread(new ThreadStart(GetMyCusorPos));
			if (!bSelectColor)
			{
				WorkStatus = 0;
				//btnStart.Text = "Stop";
				bSelectColor = true;
				t.Start();
					
			}
			else
			{
				WorkStatus = 1;
				t.Abort();
				//btnStart.Text = "Start";
				bSelectColor = false;
			}
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			WorkStatus = 1;
		}		
	}
}
