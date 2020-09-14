/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/14/2020
 * Time: 8:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsmEditor {
	
	public partial class CreateFileEditorDialog : Form {
		
		public String fn,type,dir;
		
		public CreateFileEditorDialog () {
			
			InitializeComponent();
		}
		
		public static void ShowDialog (CreateFileEditorDialog form,Action whatever) {
			
			form.Show();
			
			form.Closing+=delegate{whatever.Invoke();};
			
		}
		
		private void CreateFileEditorDialogLoad (Object sender, EventArgs e) {
			
			this.ShowIcon=false;
			this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
			this.MinimizeBox=true;
			
		}
		
		
		private void CreateBtnClick (Object sender, EventArgs e) { 
			
			this.fn=fileNameTextBox.Text;
			this.Close();
			
		}
		
	}
	
}