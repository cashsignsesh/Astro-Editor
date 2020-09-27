/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/16/2020
 * Time: 3:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using AsmEditor.Utils;
using System.Linq;
using AsmEditor.Projects;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace AsmEditor {
	
	public partial class CompilerOptions : Form {
		
		private String fn;
		private String selRbtnTR;
		
		public CompilerOptions (String fn) {
			
			InitializeComponent();
			this.fn=fn;
			
		}
		
		private void CompilerOptionsLoad (Object sender, EventArgs e) {
			
			this.ShowIcon=false;
			this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
			this.MinimizeBox=true;
			
			if (!(this.nasmRadioBtn.Checked))
				this.nasmCompileInstruction.Hide();
			
			
			if (!(File.Exists(this.fn))) {
				
				Byte[] defaultInst=Encoding.UTF8.GetBytes("3,-fobj,bin"+Environment.NewLine);
				using (FileStream fs = File.Create(this.fn))
					fs.Write(defaultInst,0,defaultInst.Length);
				
			}
			
			OptData data = OptData.getOptData(File.ReadAllLines(this.fn));
			
			switch (data.compileType) {
					
				case CompileType.NASM:
					this.selRbtnTR="1";
					this.nasmRadioBtn.Checked=true;
					break;
					
				case CompileType.MASM:
					this.selRbtnTR="2";
					this.masmRadioBtn.Checked=true;
					break;
					
				default:
					this.selRbtnTR="3";
					this.fasmRadioBtn.Checked=true;
					break;
					
			}
			
			this.nasmCompileInstruction.Text=data.nasmArgs;
			this.compileAsTextBox.Text=data.fileExt;
			
		}
		
		private void handleRbtn (Object sender,EventArgs e) {
			
			RadioButton rb = (sender as RadioButton);
			Boolean isNasm = (rb.Text=="NASM");
			this.selRbtnTR=((isNasm)?"1":(rb.Text=="MASM")?"2":"3");
			
			if (isNasm)
				nasmCompileInstruction.Show();
			else
				nasmCompileInstruction.Hide();//This might have room for optimization with a boolean tracking whether or not it is hidden	
			
		}
		
		
		private void OpenInstructionsFileBtnClick (Object sender,EventArgs e) { Process.Start(new ProcessStartInfo(){FileName=@"C:\Windows\System32\Notepad.exe",Arguments=this.fn}); }
		
		
		private void SaveBtnClick (Object sender,EventArgs e) {
			
			List<String> lns = new List<String>(File.ReadAllLines(this.fn));
			lns[0]=((new []{this.selRbtnTR,this.nasmCompileInstruction.Text,this.compileAsTextBox.Text}).merge(","))+Environment.NewLine;
			lns.RemoveAll(x=>String.IsNullOrEmpty(x));
			File.WriteAllLines(this.fn,lns);
			this.Close();
			
		}
		
		private void AddInstructionBtnClick (Object sender, EventArgs e) { File.AppendAllText(this.fn,this.instructionTextBox.Text+Environment.NewLine); }
		
	}
	
}