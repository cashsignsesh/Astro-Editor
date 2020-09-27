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
using AsmEditor.Utils;
using System.Linq;

namespace AsmEditor {
	
	public class Compiler {
		
		public readonly String projectDir,compileDir,entryFile,instructionsFile;
		
		private Project project;
		private Header header;
		private Settings s;
		
		public Process compilerProcess;
		public CompileType compileType;
		
		public static String exeDir = Path.GetDirectoryName(Application.ExecutablePath),
							 fasmFn = Compiler.exeDir+@"\include\fasm.exe",
							 linkFn = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Tools\MSVC\14.27.29110\bin\Hostx64\x86\link.exe";
		
		public Compiler (Project project,String projectDir,Settings s,String instructionsFile) {
			
			this.projectDir=projectDir;
			this.project=project;
			this.header=this.project.getHeader();
			this.compileDir = this.projectDir+@"\"+header.pBinDir;
			this.s=s;
			this.entryFile=this.projectDir+@"\"+header.pEntryFile;
			this.instructionsFile=instructionsFile;
			
		}
		
		public String compile (Boolean explorerBit = false) {
							 	
			if (!(File.Exists(this.instructionsFile))) {
				
				Byte[] defaultInst=Encoding.UTF8.GetBytes("3,-fobj,bin"+Environment.NewLine);
				using (FileStream fs = File.Create(this.instructionsFile))
					fs.Write(defaultInst,0,defaultInst.Length);
				
			}
			
			OptData data = OptData.getOptData(File.ReadAllLines(this.instructionsFile));
			String compiledFn="\""+compileDir+@"\"+header.pName+"."+data.fileExt+"\"",compileBatchFile=this.compileDir+@"\compile.bat",retVal=compiledFn.Substring(1).Remove(compiledFn.Length-2);
			String append = (explorerBit)?"\nexplorer \""+this.compileDir+'"':"";
			append+=(data.bonusInstructions.Count()>0)?'\n'+data.bonusInstructions.Where(x=>(!(String.IsNullOrEmpty(x)))).Select(x=>x.Replace("%EXEPATH%",'"'+Application.ExecutablePath+'"').Replace("%BINDIR%",this.compileDir).Replace("%CMPFILE%",compiledFn)).merge("\n"):"";
			
			this.compileType=data.compileType;
			
			switch (this.compileType) {
				
				case CompileType.FASM:
					File.WriteAllText(compileBatchFile,"(\ncd \""+Compiler.exeDir+"\\include\"\n"+"fasm "+'"'+this.entryFile+"\" "+compiledFn+append+"\n)1> \""+this.compileDir+"\\output.txt\" 2>&1");
					this.compilerProcess=Process.Start(new ProcessStartInfo(){FileName=compileBatchFile,CreateNoWindow=true,UseShellExecute=false,WindowStyle=ProcessWindowStyle.Hidden});
					return retVal;
				
				case CompileType.NASM:
					//TODO:: Load in NASM includes @ compile time
					File.WriteAllText(compileBatchFile,"(\ncd \""+Compiler.exeDir+"\\include\"\n"+"nasm "+data.nasmArgs+" \""+this.entryFile+"\" -o "+compiledFn+append+"\n)1> \""+this.compileDir+"\\output.txt\" 2>&1");
					this.compilerProcess=Process.Start(new ProcessStartInfo(){FileName=compileBatchFile,CreateNoWindow=true,UseShellExecute=false,WindowStyle=ProcessWindowStyle.Hidden});
					return retVal;
					
				case CompileType.MASM:
					MessageBox.Show("Sorry!! MASM Is not yet supported!"); //TODO:: Support compiling with MASM
					return retVal;
					
				default:
					this.compilerProcess=Process.Start(new ProcessStartInfo(){FileName=@"C:\Windows\Cmd.exe",Arguments=" /c echo whatever"});
					return Compiler.exeDir+@"\invalidCompileType.vbs";
				
			}
			
		}
		
	}
	
}