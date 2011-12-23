using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

using Google.GData.Documents;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.AccessControl;


namespace Binamedia.Pixination
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private Thread t; // Mouse position working thread
		private Bitmap bmpScreenshot; // Bitmap to retrieve the color
		private static bool bSelectColor = false; // Color selection enabled flag
		private static LowLevelMouseProc _proc = HookCallback; //
	    private static IntPtr _hookID = IntPtr.Zero;	    

		// Structure created to interact with user32.dll
		public struct POINTAPI{
			public int x; 
			public int y;
		}
		
		private POINTAPI p = new POINTAPI(); // Point to store mouse position
		
		public delegate void UpdatePixelsCallback();			
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
			
		}	
		
		private void UpdatePixels(){
			textBox1.Text = "X: "+p.x.ToString() + " Y:"+p.y.ToString();

			Graphics gfxScreenshot;
            // Set the bitmap object to the size of the screen
            bmpScreenshot = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);            
            // Create a graphics object from the bitmap
            gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            // Take the screenshot from the upper left corner to the right bottom corner
            gfxScreenshot.CopyFromScreen(p.x, 
                                         p.y, 0, 0, new Size(1,1), CopyPixelOperation.SourceCopy);
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

		private void btnStart_Click(object sender, EventArgs e){			
			if (!bSelectColor)
			{				
				t = new Thread(new ThreadStart(GetMyCusorPos));								
				//btnStart.Text = "Stop";
				bSelectColor = true;
				t.Start();
				_hookID = SetHook(_proc);
			}
			else
			{								
				//btnStart.Text = "Start";
				bSelectColor = false;
				//t.Abort();
				UnhookWindowsHookEx(_hookID);
			}				
		}		
		
		private void GetMyCusorPos(){
			while (bSelectColor == true)
			{
				GetCursorPos(ref p);
				this.Invoke(new UpdatePixelsCallback(UpdatePixels),	null);
				Thread.Sleep(1);
			}
		}		
		
		public void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (bSelectColor){
				bSelectColor = false;				
				t.Abort();
				UnhookWindowsHookEx(_hookID);
			}
		}		
		
		#region GoogleIntegration
		void MnuGoogleLoginClick(object sender, EventArgs e)
		{
			DocumentsService myService = new DocumentsService("exampleCo-exampleApp-1");
			myService.setUserCredentials("", "");

			DocumentsListQuery query = new DocumentsListQuery();
			DocumentsFeed feed = myService.Query(query);
			
			foreach (DocumentEntry entry in feed.Entries)
			{
			    MessageBox.Show(entry.Title.Text);
			}		
		}
		#endregion	
		
		#region MouseHook
 		IntPtr SetHook(LowLevelMouseProc proc)
	    {
	        using (Process curProcess = Process.GetCurrentProcess())
	        using (ProcessModule curModule = curProcess.MainModule)
	        {
	            return SetWindowsHookEx(WH_MOUSE_LL, proc,
	                GetModuleHandle(curModule.ModuleName), 0);
	        }
	    }
	
	    private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
	
	    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
	    {
	    	// Disable other hooks for a clean click
	    	if (nCode >= 0 &&(MouseMessages)wParam == MouseMessages.WM_LBUTTONDOWN){   
	    		return (System.IntPtr)1;
	    	}
	    	
	    	// Pick the color with the click
	    	if (nCode >= 0 && (MouseMessages)wParam == MouseMessages.WM_LBUTTONUP){   
	    		MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));    							    			
				// Disable working thread
	    		bSelectColor = false;
    			// Disable the pixination hook
				UnhookWindowsHookEx(_hookID);
				// Ignore other hooks
    			return (System.IntPtr)1;
	    	}

	    	// Send the event to the next hook
	        return CallNextHookEx(_hookID, nCode, wParam, lParam);	        
	    }
	
	    private const int WH_MOUSE_LL = 14;
	
	    private enum MouseMessages
	    {
	        WM_LBUTTONDOWN = 0x0201,
	        WM_LBUTTONUP = 0x0202,
	        WM_MOUSEMOVE = 0x0200,
	        WM_MOUSEWHEEL = 0x020A,
	        WM_RBUTTONDOWN = 0x0204,
	        WM_RBUTTONUP = 0x0205
	    }
	
	    [StructLayout(LayoutKind.Sequential)]
	    private struct POINT
	    {
	        public int x;
	        public int y;
	    }
	
	    [StructLayout(LayoutKind.Sequential)]
	    private struct MSLLHOOKSTRUCT
	    {
	        public POINT pt;
	        public uint mouseData;
	        public uint flags;
	        public uint time;
	        public IntPtr dwExtraInfo;
	    }
	    
		#endregion
		
	    #region DLL declarations
	    [DllImport("user32.dll")]
		public static extern int GetCursorPos(ref POINTAPI lpPoint);
	
	    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	    private static extern IntPtr SetWindowsHookEx(int idHook,
	        LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
	
	    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    private static extern bool UnhookWindowsHookEx(IntPtr hhk);
	
	    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
	        IntPtr wParam, IntPtr lParam);
	
	    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	    private static extern IntPtr GetModuleHandle(string lpModuleName);		
	    #endregion		
	}
}
