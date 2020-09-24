/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/13/2020
 * Time: 3:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using AsmEditor.Projects;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace AsmEditor {
	
	public class Compiler {
		
		public readonly String projectDir,compileDir,compileType,entryFile;
		
		private Project project;
		private Header header;
		private Settings s;
		
		public Process compilerProcess;
		
		public static String exeDir = Path.GetDirectoryName(Application.ExecutablePath),
							 fasmFn = Compiler.exeDir+@"\include\fasm.exe",
							 linkFn = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Tools\MSVC\14.27.29110\bin\Hostx64\x86\link.exe";
		
		public Compiler (Project project,String projectDir,Settings s) {
			
			this.projectDir=projectDir;
			this.project=project;
			this.header=this.project.getHeader();
			this.compileDir = this.projectDir+@"\"+header.pBinDir;
			this.s=s;
			this.compileType=this.s.getSetting("compileType","FASM");
			this.entryFile=this.projectDir+@"\"+header.pEntryFile;
			
		}
		
		public String compile (Boolean explorerBit = false) {
			
			String append = (explorerBit)?"\nexplorer \""+this.compileDir+'"':"";
			
			switch (this.compileType) {
				
				case "FASM":
					String compileBatchFile = this.compileDir+@"\compile.bat";
					String compiledExe = "\""+compileDir+@"\"+header.pName+".exe\"";
					File.WriteAllText(compileBatchFile,"(\ncd \""+Compiler.exeDir+"\\include\"\n"+"fasm "+'"'+this.entryFile+"\" "+compiledExe+append+"\n)1> \""+this.compileDir+"\\output.txt\" 2>&1");
					this.compilerProcess=Process.Start(new ProcessStartInfo(){FileName=compileBatchFile,CreateNoWindow=true,UseShellExecute=false,WindowStyle=ProcessWindowStyle.Hidden});
					return compiledExe.Substring(1).Remove(compiledExe.Length-2);
				
				default:
					this.compilerProcess=Process.Start(new ProcessStartInfo(){FileName=@"C:\Windows\Cmd.exe",Arguments=" /c echo whatever"});
					return Compiler.exeDir+@"\invalidCompileType.vbs";
				
			}
			
		}
		
	}
	
}