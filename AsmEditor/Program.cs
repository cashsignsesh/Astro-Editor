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

namespace AsmEditor {
	
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program {
		
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main (String[] args) {
			
			Program.init();
			
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
		
		private static void init () {
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
		}
		
		public static void run (Form startForm) {
			
			Application.Run(startForm);
			
		}
		
	}
	
}