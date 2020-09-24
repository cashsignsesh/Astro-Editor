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

namespace AsmEditor {
	
	public partial class CompilerOptions : Form {
		
		public CompilerOptions () {
			
			InitializeComponent();
			
		}
		
		private void CompilerOptionsLoad (Object sender, EventArgs e) {
			
			this.ShowIcon=false;
			this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
			this.MinimizeBox=true;
			
			//TODO:: Compiler options
			
		}
		
	}
	
}