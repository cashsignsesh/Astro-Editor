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
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace AsmEditor {
	
	public partial class Editor : Form {
		
		private const Int32 numCtPadding = 3;
		
		private readonly String projectPath;
		private readonly Project project;
		private readonly Header header;
		private readonly String entryFile;
		private readonly String projectPathDir;
		private readonly String resourcesDir;
		
		private TreeNode projectNode;
		private TreeNode latestInteracted;
		private Settings settings;
		private Compiler compiler;
		
		public Editor (String projectPath) {
			
			try {
				
				InitializeComponent();
				
				AppDomain.CurrentDomain.UnhandledException+=delegate (Object s,UnhandledExceptionEventArgs e) {
					try { this.editorErrors.Text+=(e.ExceptionObject as Exception).Message+'\n'; }
					catch (Exception) { /*this.editorErrors probably not loaded*/ }
				};
				
				Application.ThreadException+=delegate (Object s,ThreadExceptionEventArgs e) {
					try { this.editorErrors.Text+=e.Exception.Message+'\n'; }
					catch (Exception) { /*this.editorErrors probably not loaded*/ }
				};
				
				if (!(File.Exists(projectPath))) {
					
					MessageBox.Show("Error: could not find project at " + projectPath);
					Environment.Exit(0);
					return;
					
				}
				
				this.settings = new Settings(MainForm.settingsFile);
				this.projectPath = projectPath;
				this.projectPathDir = Path.GetDirectoryName(this.projectPath);
				this.project = new Project(this.projectPath);
				this.header = project.getHeader();
				this.compiler = new Compiler(this.project,this.projectPathDir);
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
				this.resourcesDir = this.projectPathDir+@"\"+this.header.pSrcDir+"Resources";
				if (Directory.Exists(this.resourcesDir))
					this.projectNode.Nodes.Insert(0,new TreeNode(){Name=this.resourcesDir,ImageIndex=3,SelectedImageIndex=3,Text="Resources"});
				
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
				
				
			}
			catch (IOException ex) { MessageBox.Show(ex.Message); }
			catch (Exception ex) { MessageBox.Show("Unhandled exception: " + ex.ToString()); }
			
		}
		
		
		private void EditorLoad (Object sender,EventArgs e) {
			
			this.projectTabPage.AutoScroll = true;
			this.loadProjectTreeView();
			//TODO:: (in paint probably) resizing controls accordingly when form resized
			//TODO:: saving (save in memory at least in tabclose, ask to save on project exit, save on CTRL+S&CTRL+SHIFT+S, save on click in contextmenustrip, think of others)
			this.BringToFront();
			
		}
		
		private void loadTabPage (String fn) {
			
			String str = Path.GetFileName(fn);
			
			if (!(this.fileTabs.TabPages.Cast<TabPage>().Select(x=>x.Text).Contains(str))) {
				
				TabPage tc = new TabPage (str);
				this.fileTabs.TabPages.Add(tc);
				Scintilla s = null;
				tc.Controls.Add(new Scintilla () {
				                	
				                	Size=new Size(tc.Size.Width-2,tc.Size.Height-2),
				                	Location=new Point(1,1)
				                	
				                });
				
				s = tc.Controls.Cast<Control>().Where(x=>x.GetType()==typeof(Scintilla)).First() as Scintilla;
				s.StyleResetDefault();
				s.Styles[Style.Default].Font=this.settings.getSetting("defaultStyleFont","Consolas");
				s.Styles[Style.Default].SizeF=Single.Parse(this.settings.getSetting("defaultStyleSizeF","13.5"));
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
		
		private void loadTabPage (TreeNode tn) {
			
			String nodeText=tn.Text;
			IEnumerable<TabPage> cast = this.fileTabs.TabPages.Cast<TabPage>();
			IEnumerable<TabPage> query = (cast.Where(x=>x.Text==nodeText));
			IEnumerable<TabPage> query0 = (cast.Where(x=>x.Text==Path.GetFileName(this.project.getProjectLocation()).ToLower()));
			if (query.Count()!=0)
				this.fileTabs.SelectTab(query.First());
			else if ((nodeText==this.header.pName)&&(query0.Count()!=0))
				this.fileTabs.SelectTab(query0.First());
			else
				this.loadTabPage(tn.Name);
			
		}
		
		private void ClearEditorErrorsBtnClick (Object sender,EventArgs e) {
			
			this.editorErrors.Clear();
			
		}
		
		
		private void ClearProjectErrorsBtnClick (Object sender,EventArgs e) {
			
			this.projectErrors.Clear();
			
		}
		
		private void loadProjectTreeView () {
			
			this.projectNode.Nodes.AddRange(this.getNodesFromPath(this.projectPathDir+'\\'+this.header.pSrcDir).Select(x=>{x.SelectedImageIndex=x.ImageIndex; return x;}).ToArray());
			foreach (TreeNode tn in this.projectNode.Nodes.Cast<TreeNode>().Where(x=>Directory.Exists(this.projectPathDir+x.Name)))
				this.writeAllDescendants(this.projectPathDir+tn.Name,this.projectTreeView,tn,this.projectPathDir);
			this.projectNode.Expand();
			
		}
		
		private IEnumerable<TreeNode> getNodesFromPath (String path) {
			
			foreach (String s in Directory.GetDirectories(path).Select(x=>x.Remove(0,this.projectPathDir.Length)).Where(x=>x.Substring(1)!=this.header.pBinDir))
				yield return new TreeNode(){Name=s,ImageIndex=0,Text=(s.Contains(@"\"))?s.Split('\\').Last():s};
			
			foreach (String s in Directory.GetFiles(path))
				yield return new TreeNode(){Name=s,ImageIndex=(s.EndsWith(".asm"))?1:(s.EndsWith(".bat"))?2:4,Text=(s.Contains(@"\"))?s.Split('\\').Last():s};
			
		}
		
		private void rmEvents (ToolStripItemCollection tsmic) {
			
			foreach (ToolStripItem t in tsmic.Cast<ToolStripItem>()) {
				
		        Object o = typeof(ToolStripItem).GetField("EventClick",BindingFlags.Static|BindingFlags.NonPublic).GetValue(t);
		        
		        using (EventHandlerList list = (EventHandlerList)(t.GetType().GetProperty("Events",BindingFlags.NonPublic|BindingFlags.Instance)).GetValue(t))
		        	list.RemoveHandler(o,list[o]);
		        
			}
			
		}
		
		
		private void ProjectTreeViewMouseClick (Object sender,MouseEventArgs e) {
			
			MouseButtons btn = e.Button;
			
			if ((btn!=MouseButtons.Left)&&(btn!=MouseButtons.Right))
				return;
			
			TreeNode tn = projectTreeView.GetNodeAt(e.Location);
			String nodeName=tn.Name,nodeText=tn.Text;
			this.latestInteracted=tn;
			
			if (btn==MouseButtons.Left) {
				
				projectTreeView.SelectedNode=tn;
				
				if (!(File.Exists(nodeName)))
					nodeName=this.projectPathDir+nodeName;
				
				if (!(File.Exists(nodeName)))
					return;
				
				this.loadTabPage(tn);
				
				return;
			
			}
			
			if (tn.ImageIndex==5) 
				projectTreeViewItemContextMenuStrip.Show(this.projectTreeView,e.Location);
			else if (tn.ImageIndex==0)
				folderTreeViewItemContextMenuStrip.Show(this.projectTreeView,e.Location);
			else if (tn.ImageIndex==1||tn.ImageIndex==4)
				assemblyOrGenericTreeViewItemContextMenuStrip.Show(this.projectTreeView,e.Location);
			else if (tn.ImageIndex==2)
				batchTreeViewItemContextMenuStrip.Show(this.projectTreeView,e.Location);
			else if (tn.ImageIndex==3)
				resourcesTreeViewItemContextMenuStrip.Show(this.projectTreeView,e.Location);
			else
				assemblyOrGenericTreeViewItemContextMenuStrip.Show(this.projectTreeView,e.Location);
			
		}
		
		private void debug () {
			
			//TODO:: call this when F5 is pressed
			this.compile();
			
		}
		
		
		private void DebugF5ToolStripMenuItemClick (Object sender, EventArgs e) {
			
			this.debug();
			
		}
		
		private void openExplorer () {
			
			if (this.latestInteracted==null)
				return;
			
			Process.Start(new ProcessStartInfo(){FileName=@"C:\Windows\Explorer.exe",Arguments=(File.Exists(this.latestInteracted.Name))?Path.GetDirectoryName(this.latestInteracted.Name):this.projectPathDir+this.latestInteracted.Name});
			
		}
		
		private void openExplorer(Object s,EventArgs e){this.openExplorer();}//Editor.Designer.Cs is not happy with delegate{} in code :)
		
		private void tabPageFromCmsItem(Object s,EventArgs e){this.loadTabPage(this.latestInteracted);}
		
		private void ExpandToolStripMenuItemClick (Object sender, EventArgs e) {this.latestInteracted.Expand();}
		
		private void ExpandAllToolStripMenuItemClick (Object sender, EventArgs e) {this.projectNode.ExpandAll();}
		
		private void ProjectSettingsToolStripMenuItemClick (Object sender, EventArgs e) { new ProjectSettingsForm(this.settings,this.project,this).Show(); }
		
		public void saveAll () {
			
			
			
		}
		
		private void saveFile (String file) {
			
			
			
		}
		
		private void addResource (String path) {
			
			
			
		}
		
		private void createResources () {
			
			if (Directory.Exists(this.resourcesDir)) {
				
				MessageBox.Show("You already have a resources folder!");
				return;
				
			}
			Directory.CreateDirectory(this.resourcesDir);
			this.projectNode.Nodes.Insert(0,new TreeNode(){Name=this.resourcesDir,ImageIndex=3,SelectedImageIndex=3,Text="Resources"});
			
		}
		
		private void AddResourceToolStripMenuItem1Click (Object sender,EventArgs e) { this.createResources(); }
		
		private void compile () {
			
			foreach (String s in Directory.GetFiles(this.resourcesDir))
				File.Copy(s,this.compiler.compileDir+@"\"+Path.GetFileName(s));
			
			this.compiler.compile();
			
		}
		
		
		private void ImportResourceToolStripMenuItemClick (Object sender,EventArgs e) {
			
			OpenFileDialog ofd = new OpenFileDialog(){
				Filter="Any file (*.*)|*.*",
				InitialDirectory=this.settings.getSetting("initialDirImportRes",Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
			};
			
			if (ofd.ShowDialog()!=DialogResult.OK)
				return;
		
			String fn = ofd.FileName;
			this.settings.setSetting("initialDirImportRes",Path.GetDirectoryName(fn));
			File.Copy(fn,this.resourcesDir+@"\"+Path.GetFileName(fn));
			
		}
		
		
		private void RemoveResourceToolStripMenuItemClick (Object sender,EventArgs e) {
			
			OpenFileDialog ofd = new OpenFileDialog(){
				Filter="Any file (*.*)|*.*",
				InitialDirectory=this.resourcesDir
			};
			
			if (ofd.ShowDialog()!=DialogResult.OK)
				return;
			
			String fn = ofd.FileName;
			if (Path.GetDirectoryName(fn)!=this.resourcesDir) {
				
				MessageBox.Show("Please select a file from the resources directory!");
				return;
				
			}
			
			FileSystem.DeleteFile(fn,UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin);
			
		}
		
		private void ViewResourcesToolStripMenuItemClick (Object sender,EventArgs e) { Process.Start(new ProcessStartInfo(){FileName=@"C:\Windows\Explorer.exe",Arguments=this.resourcesDir}); }
		
		
		private void DeleteToolStripMenuItem3Click (Object sender,EventArgs e) {
			
			this.projectNode.Nodes.RemoveAt(0);
			FileSystem.DeleteDirectory(this.resourcesDir,UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin);
			
		}
		
		private void ContractToolStripMenuItemClick (Object sender,EventArgs e) { this.latestInteracted.Collapse(); }
		
		private void DeleteToolStripMenuItemClick (Object sender,EventArgs e) { 
			
			this.projectNode.Nodes.Find(this.latestInteracted.Name,true).First().Remove();
			FileSystem.DeleteDirectory(this.projectPathDir+@"\"+this.latestInteracted.Name,UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin);
			
		}
		
		private void deleteFileLatestTV (Object sender,EventArgs e) {
			
			this.projectNode.Nodes.Find(this.latestInteracted.Name,true).First().Remove();
			FileSystem.DeleteFile(this.projectPathDir+@"\"+this.latestInteracted.Name,UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin);
			
		}
		
		private void RunToolStripMenuItemClick (Object sender,EventArgs e) { Process.Start(this.latestInteracted.Name); }
		
		private void writeAllDescendants (String path,TreeView tv,TreeNode parent,String ext="") {
			
			foreach (TreeNode tn in this.getNodesFromPath(path)) {
				
				tn.SelectedImageIndex=tn.ImageIndex;
				parent.Nodes.Add(tn);
				String str = ext+tn.Name;
				if (Directory.Exists(str))
					this.writeAllDescendants(str,tv,tn,ext);
				
			}
			
		}
		
	}
	
}