/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/24/2020
 * Time: 3:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Diagnostics;
using System.Net;
using ICSharpCode.SharpZipLib.Zip;

namespace Installer {
	
	public class Program {
		
		private static WebClient wc;
		private static FastZip fz;
		
		/// <summary>
		/// Not a traditional installer.
		/// This application was not meant to be practical,
		/// this is just here because I can't upload
		/// any of these files since they are not owned by me.
		/// 
		/// For latest versions, download these files your self.
		/// 
		/// </summary>
		public static void Main (String[] args) {
			
			Console.WriteLine("Initializing...");
			
			String part0=Environment.CurrentDirectory+@"\.part0",part1=Environment.CurrentDirectory+@"\.part1";
			Console.WriteLine(part0);
			
			Program.wc=new WebClient();
			Program.fz=new FastZip();
			
			Console.WriteLine("Downloading includes and fasm...");
			wc.DownloadFile("https://flatassembler.net/fasmw17325.zip",part0);
			
			Console.WriteLine("Downloading nasm...");
			wc.DownloadFile("https://www.nasm.us/pub/nasm/releasebuilds/2.15.05/win32/nasm-2.15.05-win32.zip",part1);
			
			Console.WriteLine("Installing includes and fasm...");
			Program.fz.ExtractZip(part0,Environment.CurrentDirectory,null);
			File.Move("FASM.EXE",Environment.CurrentDirectory+@"\INCLUDE\FASM.EXE");
			
			Console.WriteLine("Installing nasm...");
			Program.fz.ExtractZip(part1,Environment.CurrentDirectory,null);
			File.Move(Environment.CurrentDirectory+@"\nasm-2.15.05\nasm.exe",Environment.CurrentDirectory+@"\INCLUDE\nasm.exe");
			File.Move(Environment.CurrentDirectory+@"\nasm-2.15.05\ndisasm.exe",Environment.CurrentDirectory+@"\ndisasm.exe");
			
			Console.WriteLine("Cleaning up...");
			File.Delete(part0);
			File.Delete(part1);
			File.Delete(Environment.CurrentDirectory+@"\FASMW.EXE");
			File.Delete(Environment.CurrentDirectory+@"\FASM.PDF");
			File.Delete(Environment.CurrentDirectory+@"\WHATSNEW.TXT");
			Directory.Delete(Environment.CurrentDirectory+@"\EXAMPLES\",true);
			Directory.Delete(Environment.CurrentDirectory+@"\SOURCE\",true);
			Directory.Delete(Environment.CurrentDirectory+@"\TOOLS\",true);
			Directory.Delete(Environment.CurrentDirectory+@"\nasm-2.15.05\",true);
			
			Console.WriteLine("Running astro editor...");
			Process.Start("AstroEditor.exe");
			Environment.Exit(0);
			
		}
		
	}
	
}