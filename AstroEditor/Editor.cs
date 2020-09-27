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
using System.Windows.Input;
using AsmEditor.Utils;
using ScintillaNET_FindReplaceDialog;
using System.Threading.Tasks;

namespace AsmEditor {
	
	public partial class Editor : Form {
		
		private const Int32 numCtPadding = 3;
		
		private readonly String projectPath;
		private readonly Project project;
		private readonly Header header;
		private readonly String entryFile;
		private readonly String projectPathDir;
		private readonly String resourcesDir;
		private readonly String instructionsFn;
		
		private TreeNode projectNode;
		private TreeNode latestInteracted;
		private Settings settings;
		private Compiler compiler;
		private Scintilla lastTxtChanged;
		
		public Editor (String projectPath) {
			
			try {
				
				InitializeComponent();
				
				#if DEBUG
				
				AppDomain.CurrentDomain.UnhandledException+=delegate (Object s,UnhandledExceptionEventArgs e) {
					try { this.editorErrors.Text+=(e.ExceptionObject as Exception).ToString()+'\n'; }
					catch (Exception) { /*this.editorErrors probably not loaded*/ }
				};
				
				Application.ThreadException+=delegate (Object s,ThreadExceptionEventArgs e) {
					try { this.editorErrors.Text+=e.Exception.ToString()+'\n'; }
					catch (Exception) { /*this.editorErrors probably not loaded*/ }
				};
				
				#else
				
				AppDomain.CurrentDomain.UnhandledException+=delegate (Object s,UnhandledExceptionEventArgs e) {
					try { this.editorErrors.Text+=(e.ExceptionObject as Exception).Message+'\n'; }
					catch (Exception) { /*this.editorErrors probably not loaded*/ }
				};
				
				Application.ThreadException+=delegate (Object s,ThreadExceptionEventArgs e) {
					try { this.editorErrors.Text+=e.Exception.Message+'\n'; }
					catch (Exception) { /*this.editorErrors probably not loaded*/ }
				};
				
				#endif
				
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
				this.instructionsFn=Path.GetDirectoryName(this.project.getProjectLocation())+@"\.c_opt";
				this.compiler = new Compiler(this.project,this.projectPathDir,this.settings,this.instructionsFn);
				this.fileTabs.TabPages.Clear();
				this.entryFile = Path.GetDirectoryName(this.projectPath)+'\\'+header.pEntryFile;
				this.loadTabPage(this.entryFile);
				ImageList imageList = new ImageList();
				String str = Path.GetDirectoryName(Application.ExecutablePath);
				imageList.Images.AddRange(new []{
				                          	
				                          	Image.FromFile(str+@"\Folder.png"),
				                          	Image.FromFile(str+@"\Assembly.png"),
				                          	Image.FromFile(str+@"\Batch.png"),
				                          	Image.FromFile(str+@"\Resources.png"),
				                          	Image.FromFile(str+@"\Generic.png"),
				                          	Image.FromFile(str+@"\Project.png")
				                          		
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
				
				this.fileTabs.MouseUp+=delegate (Object s,System.Windows.Forms.MouseEventArgs e) {
					
					if (e.Button!=MouseButtons.Right)
						return;
					
					Int32 i = 0;
					IEnumerable<TabPage> tabPageEnumerator = this.fileTabs.TabPages.Cast<TabPage>();
					foreach (TabPage tp in tabPageEnumerator) {
						
						if (this.fileTabs.GetTabRect(i).Contains(e.Location)) {
							
							this.tabPageContextMenuStrip.Show(this.fileTabs,e.Location);
							
							this.tabPageContextMenuStrip.Items[0].Click+=delegate { 
								
								this.saveFile(tp);
								this.fileTabs.TabPages.Remove(tp); 
								this.rmEvents(this.tabPageContextMenuStrip.Items);
								
							};
							this.tabPageContextMenuStrip.Items[1].Click+=delegate { 
								
								this.saveAll();
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
				this.KeyPreview=true;
				
			}
			#if DEBUG
			catch (IOException ex) { MessageBox.Show(ex.ToString()); }
			#else
			catch (IOException ex) { MessageBox.Show(ex.Message); }
			#endif
			catch (Exception ex) { MessageBox.Show("Unhandled exception: " + ex.ToString()); }
			
		}
		
		
		private void EditorLoad (Object sender,EventArgs e) {
			
			this.projectTabPage.AutoScroll = true;
			this.loadProjectTreeView();
			
			this.mainTabs.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Bottom;
			this.fileTabs.Anchor=AnchorStyles.Top|AnchorStyles.Right|AnchorStyles.Left|AnchorStyles.Bottom;
			this.errorsPanel.Anchor=AnchorStyles.Bottom|AnchorStyles.Left;
			
			foreach (Control c in this.mainTabs.allChildren())
				c.Anchor = AnchorStyles.Top|AnchorStyles.Right|AnchorStyles.Left|AnchorStyles.Bottom;
			
			this.Text="Editor  ("+this.header.pName+')';
			
			this.BringToFront();
			
		}
		
		private void loadTabPage (String fn) {
			
			String str = Path.GetFileName(fn);
			
			if (!(this.fileTabs.TabPages.Cast<TabPage>().Select(x=>x.Text).Contains(str))) {
				
				TabPage tc = new TabPage (str);
				tc.Name=fn;
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
					s.Styles[Style.Asm.CommentBlock].ForeColor=Color.Gray;
					s.Styles[Style.Asm.CommentDirective].ForeColor=Color.Gray;
					s.Styles[Style.Asm.CpuInstruction].ForeColor=Color.Blue;
					s.Styles[Style.Asm.Operator].ForeColor=Color.Black;
					s.Styles[Style.Asm.Number].ForeColor=Color.DarkBlue;
					s.Styles[Style.Asm.Character].ForeColor=Color.HotPink;
					s.Styles[Style.Asm.Default].ForeColor=Color.Black;
					s.Styles[Style.Asm.Directive].ForeColor=Color.Blue;
					s.Styles[Style.Asm.DirectiveOperand].ForeColor=Color.Blue;
					
					s.Styles[Style.Asm.String].ForeColor=Color.LightSalmon;
					
					s.Lexer=Lexer.Asm;
					
					//TODO:: Autofill suggestions
					//etc, like sharpdevelop
					
				}
				
				Int32 lldc = 0;
				s.TextChanged+=delegate{
					
					this.lastTxtChanged=s;
					
					s.IndicatorCurrent=8;
					s.IndicatorClearRange(0,s.TextLength);
					
					Int32 largestLineDigitCount = s.Lines.Count().ToString().Length;
					if (largestLineDigitCount==lldc) return;
					
					s.Margins.First().Width=s.TextWidth(Style.LineNumber,new String('9',largestLineDigitCount+1))+Editor.numCtPadding;
					lldc=largestLineDigitCount;
					
				};
				
				s.ClearCmdKey(Keys.Control|Keys.S);
				s.ClearCmdKey(Keys.Control|Keys.Shift|Keys.S);
				s.ClearCmdKey(Keys.Control|Keys.F);
				s.ClearCmdKey(Keys.Control|Keys.Shift|Keys.F);
				s.ClearCmdKey(Keys.Control|Keys.G);
				
				s.IndicatorCurrent=8;
				s.IndicatorClearRange(0,s.TextLength);
				
				s.Indicators[8].Style=IndicatorStyle.StraightBox;
				s.Indicators[8].ForeColor = Color.Red;
				
				tc.Anchor=AnchorStyles.Top|AnchorStyles.Right|AnchorStyles.Left|AnchorStyles.Bottom;
				foreach (Control con in tc.allChildren())
					con.Anchor=AnchorStyles.Top|AnchorStyles.Right|AnchorStyles.Left|AnchorStyles.Bottom;
				
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
		
		
		private void ProjectTreeViewMouseClick (Object sender,System.Windows.Forms.MouseEventArgs e) {
			
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
		
		
		private void DebugF5ToolStripMenuItemClick (Object sender, EventArgs e) {
			
			this.compile(false,true);
			
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
			
			foreach (TabPage t in this.fileTabs.TabPages.Cast<TabPage>())
				this.saveFile(t);
			
		}
		
		private void saveFile (TabPage p) {
			
			File.WriteAllText(p.Name,p.Controls.Cast<Control>().Where(x=>x.GetType()==typeof(Scintilla)).First().Text);
			
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
		
		private void compile (Boolean explorerbit=false,Boolean dbg=false) {
			
			this.saveAll();
			
			if (Directory.Exists(this.resourcesDir))
				foreach (String s in Directory.GetFiles(this.resourcesDir))
					File.Copy(s,this.compiler.compileDir+@"\"+Path.GetFileName(s));
			
			String str = this.compiler.compile(explorerbit);
			
			Task.Factory.StartNew(()=>{
			    
				while (!(this.compiler.compilerProcess.HasExited)) Thread.Sleep(100);
			    Int32 exitCode = this.compiler.compilerProcess.ExitCode;
			    String output = File.ReadAllText(this.projectPathDir+'\\'+this.header.pBinDir+"\\output.txt");
			    
			    if (output.Contains("error: ")) {
			    	
			    	if (this.compiler.compileType==CompileType.FASM)
			    		this.projectErrors.Text+=output.Split('\n').Reverse().Skip(0).Reverse().merge("\n");
			    	else if (this.compiler.compileType==CompileType.NASM)
			    		this.projectErrors.Text+=output;
			    	MessageBox.Show("There was an error with your code. See the project errors textbox. (Exit code: "+exitCode+")");
			    	return;
			    	
			    } 
			    
			    if (dbg)  Process.Start(str);
			    
			 });
			
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
			foreach (TabPage p in this.fileTabs.TabPages.Cast<TabPage>().Where(x=>x.Name==this.latestInteracted.Name))
				this.fileTabs.TabPages.Remove(p);
			try { FileSystem.DeleteFile(this.projectPathDir+@"\"+this.latestInteracted.Name,UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin); }
			catch (NotSupportedException) { FileSystem.DeleteFile(this.latestInteracted.Name,UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin); }
			
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
		
		
		private void EditorKeyDown (Object sender,System.Windows.Forms.KeyEventArgs e) {
			
			if (e.KeyCode==Keys.F5)
				this.compile(false,true);
			
			if (!(Keyboard.IsKeyDown(Key.LeftCtrl)))
					return;
			
			if (e.KeyCode==Keys.S) {
				
				if (Keyboard.IsKeyDown(Key.LeftShift))
					this.saveAll();
				else
					this.saveFile(this.fileTabs.SelectedTab);
				
			}
			else if (e.KeyCode==Keys.F) {
				
				FindReplace fr = new FindReplace(this.fileTabs.SelectedTab.allChildren().Where(x=>x.GetType()==typeof(Scintilla)).First()as Scintilla);
				
				fr.FindAllResults+=delegate (Object sender0,FindResultsEventArgs e0) {
					
					Scintilla scin = fr.Scintilla;
					scin.IndicatorCurrent=8;
					
					foreach (ScintillaNET_FindReplaceDialog.CharacterRange cr in e0.FindAllResults) {
						
						Int32 cpMin = cr.cpMin;
						scin.IndicatorFillRange(cpMin,cr.cpMax-cpMin);
						
					}
					
				};
				
				if (Keyboard.IsKeyDown(Key.LeftShift))
					fr.ShowReplace();
				else
					fr.ShowFind();
				
			}
			else if (e.KeyCode==Keys.G)
				new GoTo(this.fileTabs.SelectedTab.allChildren().Where(x=>x.GetType()==typeof(Scintilla)).First()as Scintilla).ShowGoToDialog();
			
		}
		
		private void CompileToolStripMenuItem1Click (Object sender,EventArgs e) { this.compile(true); }
		
		private void SaveFileCtrlSToolStripMenuItemClick (Object sender,EventArgs e) { this.saveFile(this.fileTabs.SelectedTab); }
		
		private void SaveProjectCtrlShiftSToolStripMenuItemClick (Object sender,EventArgs e) { this.saveAll(); }
		
		private void EditorFormClosing (Object sender,FormClosingEventArgs e) {
			
			if (MessageBox.Show("Should you save any unsaved changes?","Exiting Astro Editor",MessageBoxButtons.YesNo,MessageBoxIcon.None,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
				this.saveAll();
			
		}
		
		private void createFile (Boolean toProject,String type) {
			
			String bleh = this.projectPathDir+@"\"+this.header.pSrcDir;
			String dir = (this.latestInteracted==null)?bleh:((this.latestInteracted==this.projectNode)?bleh:Path.GetDirectoryName(this.latestInteracted.Name));
			if (!(dir.EndsWith(@"\",StringComparison.CurrentCulture)))
				dir+='\\';
			CreateFileEditorDialog cfed = new CreateFileEditorDialog (){
				type=type,
				dir=dir
			};
			
			CreateFileEditorDialog.ShowDialog(cfed,()=>{
			                                  	
			if (String.IsNullOrEmpty(cfed.fn))
				return;
			
			String cfedFn=dir+cfed.fn+type;
			
			File.Create(cfedFn).Close();
			this.loadTabPage(cfedFn);
			
			String s = Path.GetFileName(cfedFn);
			Int32 imageIndex = (s.EndsWith(".asm"))?1:(s.EndsWith(".bat"))?2:4;
			
			if (toProject) {
				
				this.projectNode.Nodes.Add(new TreeNode(){
				                           	
				                           	Name=cfedFn,
				                           	Text=s,
				                           	ImageIndex=imageIndex,
				                           	SelectedImageIndex=imageIndex
				                           	
				                           });
				return;
				
			}
			
			this.latestInteracted.Nodes.Add(new TreeNode(){
				                           	
					                           	Name=cfedFn,
					                           	Text=s,
					                           	ImageIndex=imageIndex,
					                           	SelectedImageIndex=imageIndex
					                           	
					                        });
			
			this.latestInteracted.Expand();
			
			                                  });
			
		}
		
		private void addAsm (Boolean toProject=false) { this.createFile(toProject,".asm"); }
		
		private void addBat (Boolean toProject=false) { this.createFile(toProject,".bat"); }
		
		private void AssemblyFileToolStripMenuItemClick (Object sender, EventArgs e) { this.addAsm(); }
		
		private void BatchFileToolStripMenuItemClick (Object sender, EventArgs e) { this.addBat(); }
		
		private void AssemblyFileToolStripMenuItem1Click (Object sender, EventArgs e) { this.addAsm(true); }
		
		private void BatchFileToolStripMenuItem1Click (Object sender, EventArgs e) { this.addBat(true); }
		
		private void AssemblyFileToolStripMenuItem2Click (Object sender, EventArgs e) { this.addAsm(); }
		
		private void BatchFileToolStripMenuItem2Click (Object sender, EventArgs e) { this.addBat(); }
		
		private void NewProjectToolStripMenuItem1Click (Object sender, EventArgs e) {
			
			NewProject np = new NewProject ();
			np.onExit+=this.onNewPanel;
			np.Show();
			
		}
		
		private void onNewPanel (Object s,NPExitEventArgs e) {
			
			if (!(e.success))
				return;
			
			String fn = MainForm.create(e.projectName,e.type,this.settings);
			
			if (!(String.IsNullOrEmpty(fn)))
				MainForm.open(fn,false);
			
		}
		
		
		private void OpenProjectToolStripMenuItem1Click (Object sender, EventArgs e) {
			
			OpenFileDialog ofd = new OpenFileDialog() { Filter="Project files (*.ae)|*.ae|All files (*.*)|*.*",InitialDirectory=this.settings.getSetting("openProjInitDir",Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))};
			
			if (ofd.ShowDialog()==DialogResult.OK) {
				
				String fn = ofd.FileName;
				this.settings.setSetting("openProjInitDir",fn);
				MainForm.open(fn,false);
				
			}
			
		}
		
		private void CloseProjectToolStripMenuItem1Click (Object sender, EventArgs e) { Environment.Exit(0); }
		
		private void UndoCtrlZToolStripMenuItem1Click (Object sender, EventArgs e) { this.lastTxtChanged.Undo(); }
		
		private void RedoCtrlYToolStripMenuItem1Click (Object sender, EventArgs e) { this.lastTxtChanged.Redo(); }
		
		private void FindToolStripMenuItem1Click (Object sender, EventArgs e) { 
			
			FindReplace fr = new FindReplace(this.fileTabs.SelectedTab.allChildren().Where(x=>x.GetType()==typeof(Scintilla)).First()as Scintilla);
				
			fr.FindAllResults+=delegate (Object sender0,FindResultsEventArgs e0) {
				
				Scintilla scin = fr.Scintilla;
				scin.IndicatorCurrent=8;
				
				foreach (ScintillaNET_FindReplaceDialog.CharacterRange cr in e0.FindAllResults) {
					
					Int32 cpMin = cr.cpMin;
					scin.IndicatorFillRange(cpMin,cr.cpMax-cpMin);
					
				}
				
			};
			
			fr.ShowFind();
			
		}
		
		private void ReplaceToolStripMenuItem1Click (Object sender, EventArgs e) {
			
			FindReplace fr = new FindReplace(this.fileTabs.SelectedTab.allChildren().Where(x=>x.GetType()==typeof(Scintilla)).First()as Scintilla);
				
			fr.FindAllResults+=delegate (Object sender0,FindResultsEventArgs e0) {
				
				Scintilla scin = fr.Scintilla;
				scin.IndicatorCurrent=8;
				
				foreach (ScintillaNET_FindReplaceDialog.CharacterRange cr in e0.FindAllResults) {
					
					Int32 cpMin = cr.cpMin;
					scin.IndicatorFillRange(cpMin,cr.cpMax-cpMin);
					
				}
				
			};
		
			fr.ShowReplace();
			
		}
		
		
		private void GoToToolStripMenuItemClick (Object sender, EventArgs e) { new GoTo(this.fileTabs.SelectedTab.allChildren().Where(x=>x.GetType()==typeof(Scintilla)).First()as Scintilla).ShowGoToDialog(); }
		
		
		private void CompilerOptionsToolStripMenuItemClick (Object sender, EventArgs e) { new CompilerOptions(this.instructionsFn).Show(); }
		
	}
	
}