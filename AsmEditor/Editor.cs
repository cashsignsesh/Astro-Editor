/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AsmEditor.Projects;
using System.Collections.Generic;
using System.Linq;

namespace AsmEditor {
	
	public partial class Editor : Form {
		
		private readonly String projectPath;
		private readonly Project project;
		private readonly Header header;
		private readonly String entryFile;
		private readonly String projectPathDir;
		
		private TreeNode projectNode;
		
		public Editor (String projectPath) {
			
			InitializeComponent();
			
			if (!(File.Exists(projectPath))) {
				
				MessageBox.Show("Error: could not find project at " + projectPath);
				Environment.Exit(0);
				return;
				
			}
			
			this.projectPath = projectPath;
			this.project = new Project(this.projectPath);
			this.header = project.getHeader();
			this.fileTabs.TabPages.Clear();
			this.entryFile = Path.GetDirectoryName(this.projectPath)+'\\'+header.pEntryFile;
			this.loadTabPage(this.entryFile);
			ImageList imageList = new ImageList();
			imageList.Images.AddRange(new []{
			                          	
			                          	Image.FromFile("./Folder.png"),
			                          	Image.FromFile("./Assembly.png"),
			                          	Image.FromFile("./Batch.png"),
			                          	Image.FromFile("./Resources.png"),
			                          	Image.FromFile("./Generic.png"),
			                          	Image.FromFile("./Project.png")
			                          		
			                          });
			this.projectTreeView.ImageList = imageList;
			this.projectNode = this.projectTreeView.Nodes.Add(this.header.pName);
			this.projectNode.ImageIndex=5;
			ToolStrip ts = new ToolStrip();
			
			ToolStripDropDownButton tdsb = new ToolStripDropDownButton () { Name="File",Text="File"} ;
			ToolStripDropDownButton tdsb0 = new ToolStripDropDownButton () { Name="Edit",Text="Edit"} ;
			ToolStripDropDownButton tdsb1 = new ToolStripDropDownButton () { Name="Project",Text="Project"} ;
			ToolStripDropDownButton tdsb2 = new ToolStripDropDownButton () { Name="Search",Text="Search"} ;
			
			tdsb.DropDown=fileContextMenuStrip;
			tdsb0.DropDown=editContextMenuStrip;
			tdsb1.DropDown=projectContextMenuStrip;
			tdsb2.DropDown=searchContextMenuStrip;
			
			ts.Items.AddRange(new [] { tdsb,tdsb0,tdsb1,tdsb2 });
			
			ts.Dock = DockStyle.Top;
			
			this.Controls.Add(ts);
			
			this.projectPathDir = Path.GetDirectoryName(this.projectPath);
			
		}
		
		
		private void EditorLoad (Object sender,EventArgs e) {
			
			this.projectTabPage.AutoScroll = true;
			this.loadProjectTreeView();
			//TODO:: dock a contextmenustrip to top of form
			//Add resources functionality into ae project, drop it into bin @ runtime or smth
			//Modify defP- settings by right clicking on project from viewer
			//Open from explorer on right click
			//TabPages, right click and close this file, close all files but this, close all files
			//TODO:: Finish contextmenustrip/toolstrip work
			//TODO:: Syntax highlighting
			//TODO:: (in paint probably) resizing controls accordingly when form resized
			this.BringToFront();
			
		}
		
		private void loadTabPage (String fn) {
			
			this.fileTabs.TabPages.Add(Path.GetFileName(fn));
			
		}
		
		private TreeNode addTreeNode (String fn) {
			
			return null;
			
		}
		
		private void ClearEditorErrorsBtnClick (Object sender,EventArgs e) {
			
			this.editorErrors.Clear();
			
		}
		
		
		private void ClearProjectErrorsBtnClick (Object sender,EventArgs e) {
			
			this.projectErrors.Clear();
			
		}
		
		private void loadProjectTreeView () {
			
			this.projectNode.Nodes.AddRange(this.getNodesFromPath(this.projectPathDir+'\\'+this.header.pSrcDir,this.projectNode).ToArray());
			this.projectNode.Expand();
			
			//this.projectNode.Nodes.Add
			
		}
		
		private IEnumerable<TreeNode> getNodesFromPath (String path,TreeNode parent) {
			
			Int32 projectPathDirSrcLength = this.projectPathDir.Length;
			
			foreach (String s in Directory.GetDirectories(path).Select(x=>x.Remove(0,projectPathDirSrcLength)).Where(x=>x.Substring(1)!=this.header.pBinDir))
				yield return new TreeNode(){Name=s,ImageIndex=0,Text=(s.Contains(@"\"))?s.Split('\\').Last():s};
			
			foreach (String s in Directory.GetFiles(path))
				yield return new TreeNode(){Name=s.Remove(0,projectPathDirSrcLength),ImageIndex=(s.EndsWith(".asm"))?1:(s.EndsWith(".bat"))?2:4,Text=(s.Contains(@"\"))?s.Split('\\').Last():s};
			
		}
		
	}
	
}