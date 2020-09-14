/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/11/2020
 * Time: 1:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsmEditor {
	
	
	public partial class NewProject : Form {
	
		public delegate void NPExitEventH (Object s,NPExitEventArgs e);
		
		public event NPExitEventH onExit;
		private Boolean ignoreOnce = false;
		private Control selected;
		private Panel[] panels;
		
		public NewProject () {
			
			InitializeComponent();
			
		}
		
		
		private void NewProjectLoad (Object sender, EventArgs e) {
			
			this.ShowIcon=false;
			this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
			this.MinimizeBox=true;
			
			this.assemblyProjectPanel.Paint+=paintBorder;
			this.fortranProjectPanel.Paint+=paintBorder;
			
			this.assemblyProjectPanel.MouseEnter+=highlight;
			this.assemblyProjectLbl.MouseEnter+=highlight;
			this.fortranProjectPanel.MouseEnter+=highlight;
			this.fortranProjectLbl.MouseEnter+=highlight;
			
			this.assemblyProjectPanel.MouseLeave+=deHighlight;
			this.fortranProjectPanel.MouseLeave+=deHighlight;
			
			this.assemblyProjectPanel.Click+=select;
			this.assemblyProjectLbl.Click+=select;
			this.fortranProjectPanel.Click+=select;
			this.fortranProjectLbl.Click+=select;
			
			this.panels = new [] { this.assemblyProjectPanel, this.fortranProjectPanel };
			
		}
		
		private void paintBorder (Object sender,PaintEventArgs e) {
			
			ControlPaint.DrawBorder(e.Graphics,(sender as Control).ClientRectangle,Color.LightGray,ButtonBorderStyle.Solid);
			
		}
		
		private void highlight (Object sender,EventArgs e) {
			
			if (sender.GetType()!=typeof(Panel)) {
				
				(sender as Control).Parent.BackColor=Color.LightGray;
				return;
				
			}
			
			(sender as Control).BackColor=Color.LightGray;
			
		}
		
		private void select (Object sender,EventArgs e) {
			
			foreach (Panel p in this.panels)
				this.deSelect(p);
			
			if (sender.GetType()!=typeof(Panel)) {
				
				this.select((sender as Control).Parent,e);
				return;
				
			}
			
			(sender as Control).BackColor = Color.LightGray;
			(sender as Control).ForeColor = Color.Blue;
			
			this.ignoreOnce=true;
			this.selected=sender as Control;
			
		}
		
		private void deHighlight (Object sender,EventArgs e) {
			
			if (ignoreOnce) {
				ignoreOnce=false;
				return;
			}
			
			if (this.selected!=null)
				if (sender==this.selected)
					return;
				
			(sender as Control).BackColor=Color.White;
			
		}
		
		private void deSelect (Control sender) {
			
			sender.BackColor=Color.White;
			sender.ForeColor=Color.Black;
			
		}
		
		
		private void CreateButtonClick (Object sender,EventArgs e) {
			
			if (this.selected==null) {
				
				MessageBox.Show("You need to select a project type!");
				return;
				
			}
			
			String str = this.projectNameTextBox.Text;
			
			if (String.IsNullOrEmpty(str)) {
				
				MessageBox.Show("You need to select a project name!");
				return;
				
			}
			
			if (this.selected==this.assemblyProjectPanel)
				this.onExit.Invoke(this,new NPExitEventArgs(true,str,ProjectType.ASSEMBLYx86));
			else if (this.selected==this.fortranProjectPanel)
				this.onExit.Invoke(this,new NPExitEventArgs(true,str,ProjectType.FORTRAN));
			else
				this.onExit.Invoke(this,new NPExitEventArgs(true,str,ProjectType.NONE));
			
			this.Close();
			
		}
		
		
		private void NewProjectFormClosing (Object sender, FormClosingEventArgs e) {
			
			this.onExit.Invoke(this,new NPExitEventArgs(false,"",ProjectType.NONE));
			
		}
		
	}
	
	public class NPExitEventArgs : EventArgs {
		
		public readonly Boolean success;
		public readonly String projectName;
		public readonly ProjectType type;
		
		internal NPExitEventArgs (Boolean result,String pn,ProjectType type) {
			
			this.success=result;
			this.projectName=pn;
			this.type=type;
			
		}
		
	}
	
}
