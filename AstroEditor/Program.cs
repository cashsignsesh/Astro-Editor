/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Linq;
using AsmEditor.Utils;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;

namespace AsmEditor {
	
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program {
		
		[DllImport("shell32.dll")]
		private static extern IntPtr SHChangeNotify (IntPtr wEventId,IntPtr uFlags,IntPtr dwItem1,IntPtr dwItem2);
		
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main (String[] args) {
			
			Program.init(args);
			
			switch (args.Length) {
					
				case 0:
					Program.run(new MainForm());
					return;
					
				default:
					Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
					Program.run(new Editor(args.Skip(0).merge(" ")));
					return;
					
			}
			
		}
		
		private static void init (String[] args) {
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			RegistryKey r = Registry.ClassesRoot.OpenSubKey(".ae");
			if ((r!=null)&&((r.GetValue("")as String)=="astroeditor.ae"))
				return;
			
			String str = Path.GetDirectoryName(Application.ExecutablePath)+@"\CHK";
			
			if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))) {
				
				if (File.Exists(str)) {
					
					MessageBox.Show("Please run this in administrator!");
					File.Delete(str);
					Environment.Exit(0);
					return;
					
				}
				
				File.Create(str);
				Process.Start(new ProcessStartInfo(){FileName=Application.ExecutablePath,Arguments=args.Skip(0).merge(" "),Verb="runas"});
				Environment.Exit(0);
				
			}
			
			Registry.ClassesRoot.CreateSubKey(".ae").SetValue("","astroeditor.ae");
			Registry.ClassesRoot.CreateSubKey("astroeditor.ae").SetValue("","AstroEditor Project");
			Registry.ClassesRoot.CreateSubKey(@"astroeditor.ae\DefaultIcon").SetValue("",Path.GetDirectoryName(Application.ExecutablePath)+@"\assembly.ico");
			Registry.ClassesRoot.CreateSubKey(@"astroeditor.ae\shell").SetValue("","");
			Registry.ClassesRoot.CreateSubKey(@"astroeditor.ae\shell\open").SetValue("","");
			Registry.ClassesRoot.CreateSubKey(@"astroeditor.ae\shell\open\command").SetValue("",Application.ExecutablePath+" \"%1\"");
			Registry.ClassesRoot.CreateSubKey(@"astroeditor.ae\shell\print").SetValue("","");
			Registry.ClassesRoot.CreateSubKey(@"astroeditor.ae\shell\print\command").SetValue("",Application.ExecutablePath+" \"%1\"");
			Program.SHChangeNotify((IntPtr)0x8000000,IntPtr.Zero,IntPtr.Zero,IntPtr.Zero);
			
			if (File.Exists(str))
				File.Delete(str);
			
		}
		
		public static void run (Form startForm) {
			
			Application.Run(startForm);
			
		}
		
		
		
	}
	
}