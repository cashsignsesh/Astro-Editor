/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/13/2020
 * Time: 1:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using AsmEditor.Projects;
using System.IO;
using System.Diagnostics;

namespace AsmEditor {
	
	public partial class ProjectSettingsForm : Form	{
		
		private Settings settings;
		private Project project;
		private Editor editor;
		
		public ProjectSettingsForm (Settings settings,Project p,Editor sender) {
			
			InitializeComponent();
			
			this.settings = settings;
			this.project = p;
			this.editor = sender;
			
		}
		
		
		private void ProjectSettingsFormLoad (Object sender,EventArgs e) {
			
			this.ShowIcon=false;
			this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
			this.MinimizeBox=true;
			
			Header h = this.project.getHeader();
			this.entryFileTextBox.Text=h.pEntryFile;
			this.binDirTextBox.Text=h.pBinDir;
			this.srcDirTextBox.Text=h.pSrcDir;
			
			this.fontNameTextBox.Text=this.settings.getSetting("defaultStyleFont");
			this.fontSizeTextBox.Text=this.settings.getSetting("defaultStyleSizeF");
			
		}
		
		
		private void DiscardPictureBoxClick (Object sender, EventArgs e) {
			
			this.Close();
			
		}
		
		private void SavePictureBoxClick (Object sender, EventArgs e) {
			
			this.settings.setSetting("defaultStyleFont",this.fontNameTextBox.Text);
			this.settings.setSetting("defaultStyleSizeF",this.fontSizeTextBox.Text);
			
			File.WriteAllLines(this.project.getProjectLocation(),new []{this.project.getHeader().pName,this.entryFileTextBox.Text,this.binDirTextBox.Text,this.srcDirTextBox.Text});
			
			if (MessageBox.Show("Settings require a restart to take effect. Should you allow the automatic save all and restart?","Save project settings",MessageBoxButtons.YesNo,MessageBoxIcon.None,MessageBoxDefaultButton.Button1)==DialogResult.Yes) {
				
				this.editor.saveAll();
				Process.Start(new ProcessStartInfo(){FileName=Application.ExecutablePath,Arguments=this.project.getProjectLocation()});
				Environment.Exit(0);
				
			}
			
			
		}
	}
	
}