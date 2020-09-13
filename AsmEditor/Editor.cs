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
using System.Text;
using ScintillaNET;
using System.ComponentModel;
using System.Reflection;

namespace AsmEditor {
	
	public partial class Editor : Form {
		
		private const Int32 numCtPadding = 3;
		
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
			this.projectNode.SelectedImageIndex=5;
			this.projectNode.Name = this.projectPath;
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
			
			this.fileTabs.MouseUp+=delegate (Object s,MouseEventArgs e) {
				
				if (e.Button!=MouseButtons.Right)
					return;
				
				Int32 i = 0;
				IEnumerable<TabPage> tabPageEnumerator = this.fileTabs.TabPages.Cast<TabPage>();
				foreach (TabPage tp in tabPageEnumerator) {
					
					if (this.fileTabs.GetTabRect(i).Contains(e.Location)) {
						
						this.tabPageContextMenuStrip.Show(this.fileTabs,e.Location);
						
						this.tabPageContextMenuStrip.Items[0].Click+=delegate { 
							
							this.fileTabs.TabPages.Remove(tp); 
							this.rmEvents(this.tabPageContextMenuStrip.Items);
							
						};
						this.tabPageContextMenuStrip.Items[1].Click+=delegate { 
							
							this.fileTabs.TabPages.Clear(); 
							this.rmEvents(this.tabPageContextMenuStrip.Items);
							
						};
						this.tabPageContextMenuStrip.Items[2].Click+=delegate {
							
							foreach (TabPage tp0 in tabPageEnumerator) {
								
								if (tp0!=tp)
									this.fileTabs.TabPages.Remove(tp0);
								
							}
							
							this.rmEvents(this.tabPageContextMenuStrip.Items);
							
						};
						
						return;
						
					}
					
					++i;
					
				}
				
			};
			
			this.projectPathDir = Path.GetDirectoryName(this.projectPath);
			
		}
		
		
		private void EditorLoad (Object sender,EventArgs e) {
			
			this.projectTabPage.AutoScroll = true;
			this.loadProjectTreeView();
			//TODO::Add resources functionality into ae project, drop it into bin @ runtime or smth
			//TODO::Modify defP- settings by right clicking on project from viewer
			//TODO::Open from explorer on right click
			//TODO::TabPages, right click and close this file, close all files but this, close all files
			//TODO:: Finish contextmenustrip/toolstrip work
			//TODO:: (in paint probably) resizing controls accordingly when form resized
			//TODO:: AsmEditor exception handler (Rtb on this form)
			this.BringToFront();
			
		}
		
		private void loadTabPage (String fn) {
			
			String str = Path.GetFileName(fn);
			
			if (!(this.fileTabs.TabPages.Cast<TabPage>().Select(x=>x.Text).Contains(str))) {
				
				TabPage tc = new TabPage (str);
				this.fileTabs.TabPages.Add(tc);
				Scintilla s = null;
				try{
				tc.Controls.Add(new Scintilla () {
				                	
				                	Size=new Size(tc.Size.Width-2,tc.Size.Height-2),
				                	Location=new Point(1,1)
				                	
				                });
				
				s = tc.Controls.Cast<Control>().Where(x=>x.GetType()==typeof(Scintilla)).First() as Scintilla;
				}catch(Exception ex){MessageBox.Show(ex.ToString());}
				s.StyleResetDefault();
				s.Styles[Style.Default].Font="Consolas";
				s.Styles[Style.Default].SizeF=13.5F;
				s.StyleClearAll();
				
				s.WrapMode = WrapMode.None;
								
				if (str.EndsWith(".bat")) {
					
					s.Styles[Style.Batch.Command].ForeColor=Color.Blue;
					s.Styles[Style.Batch.Comment].ForeColor=Color.Green; 
					s.Styles[Style.Batch.Identifier].ForeColor=Color.HotPink;
					s.Styles[Style.Batch.Word].ForeColor=Color.Blue;
					s.Styles[Style.Batch.Default].ForeColor=Color.Black;
					s.Styles[Style.Batch.Label].ForeColor=Color.White;
					s.Styles[Style.Batch.Label].BackColor=Color.Black;
					s.Styles[Style.Batch.Operator].ForeColor=Color.Black;
					
					s.Lexer=Lexer.Batch;
					
				}
				
				else if (str.EndsWith(".asm")) {
					
					s.Styles[Style.Asm.Comment].ForeColor=Color.Gray;
					
					s.Lexer=Lexer.Asm;
					
				}
				
				Int32 lldc = 0;
				s.TextChanged+=delegate{
					
					Int32 largestLineDigitCount = s.Lines.Count().ToString().Length;
					if (largestLineDigitCount==lldc) return;
					
					s.Margins.First().Width=s.TextWidth(Style.LineNumber,new String('9',largestLineDigitCount+1))+Editor.numCtPadding;
					lldc=largestLineDigitCount;
					
				};
				
				s.Text=File.ReadAllText(fn);
				this.fileTabs.SelectTab(tc);
				
			}
			
		}
		
		private void ClearEditorErrorsBtnClick (Object sender,EventArgs e) {
			
			this.editorErrors.Clear();
			
		}
		
		
		private void ClearProjectErrorsBtnClick (Object sender,EventArgs e) {
			
			this.projectErrors.Clear();
			
		}
		
		private void loadProjectTreeView () {
			
			this.projectNode.Nodes.AddRange(this.getNodesFromPath(this.projectPathDir+'\\'+this.header.pSrcDir,this.projectNode).Select(x=>{x.SelectedImageIndex=x.ImageIndex; return x;}).ToArray());
			this.projectNode.Expand();
			
		}
		
		private IEnumerable<TreeNode> getNodesFromPath (String path,TreeNode parent) {
			
			foreach (String s in Directory.GetDirectories(path).Select(x=>x.Remove(0,this.projectPathDir.Length)).Where(x=>x.Substring(1)!=this.header.pBinDir))
				yield return new TreeNode(){Name=s,ImageIndex=0,Text=(s.Contains(@"\"))?s.Split('\\').Last():s};
			
			foreach (String s in Directory.GetFiles(path))
				yield return new TreeNode(){Name=s,ImageIndex=(s.EndsWith(".asm"))?1:(s.EndsWith(".bat"))?2:4,Text=(s.Contains(@"\"))?s.Split('\\').Last():s};
			
		}
		
		
		private void ProjectTreeViewAfterSelect (Object sender,TreeViewEventArgs e) {
			
			String nodeName=e.Node.Name;
			
			if (!(File.Exists(nodeName)))
				nodeName=this.projectPathDir+nodeName;
			
			if (!(File.Exists(nodeName)))
				return;
			
			this.loadTabPage(nodeName);
			
		}
		
		private void rmEvents (ToolStripItemCollection tsmic) {
			
			foreach (ToolStripItem t in tsmic.Cast<ToolStripItem>()) {
				
		        Object o = typeof(ToolStripItem).GetField("EventClick",BindingFlags.Static|BindingFlags.NonPublic).GetValue(t);
		        
		        using (EventHandlerList list = (EventHandlerList)(t.GetType().GetProperty("Events",BindingFlags.NonPublic|BindingFlags.Instance)).GetValue(t))
		        	list.RemoveHandler(o,list[o]);
		        
			}
			
		}
		
	}
	
}