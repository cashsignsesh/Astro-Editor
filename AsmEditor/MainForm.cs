/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using AsmEditor.Utils;
using System.Text;
using System.Diagnostics;
using AsmEditor.Projects;
using System.ComponentModel;

namespace AsmEditor {
	
	//TODO:: Maybe rename this thing to AstroEditor ("As"tro for assembly)
	//TODO:: make new icon for app, if name is AstroEditor, make "As" red and "troEditor" some other colour like light gray
	
	public partial class MainForm : Form {
		
		public const String recentsFile = "./.recents";
		public const String settingsFile = "./.settings";
		
		private static Random r = new Random();
		
		private Settings settings;
		private Int32 listM = 0;
		
		public MainForm () {
			
			this.InitializeComponent();
			
		}
		
		private void MainFormLoad (Object sender,EventArgs e) {
			
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.recentProjectsList.BorderStyle = BorderStyle.None;
			
			this.install();
			foreach (String s in this.getRecents().Take(8))
				this.addToList(new Project(s).getHeader().pName,s);
			
		}
		
		private void paintBorder (Object sender,PaintEventArgs e) {
			
			ControlPaint.DrawBorder(e.Graphics,(sender as Control).ClientRectangle,Color.LightGray,ButtonBorderStyle.Solid);
			
		}
		
		private void paintBorderEastPB (Object sender,PaintEventArgs e) {
			
			using (Pen p=new Pen(Color.LightGray,1F))
				e.Graphics.DrawLine(p,(sender as Control).ClientRectangle.Right-1,(sender as Control).Top-1,(sender as Control).ClientRectangle.Right-1,((sender as Control).ClientRectangle.Top+(sender as Control).Height));
			
		}
		
		private void install () {
			
			this.settings = new Settings(MainForm.settingsFile);
			this.components = new Container();
			
			if (!(File.Exists(MainForm.recentsFile))) {
				
				Byte[] data = Encoding.UTF8.GetBytes(@"'The DateTime's here are listed in UTC (for speed&timezone change compatibility).
'If you are looking for accurate numbers for whatever reason, convert from UTC to your timezone.");
				using (FileStream fs = File.Create(MainForm.recentsFile))
					fs.Write(data,0,data.Length);
				
			}
			
			//TODO:: make it so that any .ae file will autorun to this application
			
		}
		
		internal IEnumerable<String> getRecents () {
			
			Dictionary<DateTime,String> _recents = File.ReadAllLines(MainForm.recentsFile).Where(x=>!(x.StartsWith("'"))&&!String.IsNullOrEmpty(x)).Select(x=>x.Split('?')).ToDictionary(x=>DateTime.Parse(x[1]),x=>x[0]);
			
			//Won't work with multiple Strings of the same DateTime
			foreach (DateTime dt in _recents.Keys.Cast<DateTime>().sort())
				yield return _recents[dt];
			
		}
		
		
		private void openProjectPanelClick (Object sender,EventArgs e) {
			
			OpenFileDialog ofd = new OpenFileDialog() { Filter="Project files (*.ae)|*.ae|All files (*.*)|*.*",InitialDirectory=this.settings.getSetting("openProjInitDir",Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))};
			
			if (ofd.ShowDialog()==DialogResult.OK) {
				
				String fn = ofd.FileName;
				this.settings.setSetting("openProjInitDir",fn);
				this.addRecent(fn,DateTime.UtcNow);
				this.open(fn);
				
			}
			
		}
		
		private void addRecent (String recent,DateTime dt) {
			
			List<String> lines = new List<String>(File.ReadAllLines(MainForm.recentsFile));
			String str = recent+'?'+dt.ToString()+'\n';
			if (lines.Where(x=>x.StartsWith(recent)).Count()==0) {
				
				File.AppendAllText(MainForm.recentsFile,str);
				return;
				
			}
			
			lines.RemoveAll(x=>x.StartsWith(recent));
			lines.Add(str);
			File.WriteAllLines(MainForm.recentsFile,lines);
			
		}
		
		private void addToList (String itemText,String toOpen) {
			
			Panel p = new Panel(){
					                                     	Location=new Point(0,listM),
					                                     	Size=new Size(229,18),
					                                     	BorderStyle=BorderStyle.FixedSingle
				                                     	};
			
			p.Controls.Add(new PictureBox(){
					                                     	Location=new Point(0,0),
					                                     	Name="PB-"+MainForm.r.Next(0,100000000).ToString(),
					                                     	Size=new Size(16,16),
					                                     	Image=(listM<41)?Bitmap.FromFile("./newer.png"):Bitmap.FromFile("./older.png")
				                                     	});
			
			p.Controls.Add(new Label(){
					                                     	Text=itemText,
					                                     	Location=new Point(16,0),
					                                     	Name="LBL-"+MainForm.r.Next(0,100000000).ToString(),
					                                     	Font=new Font("Corbel",10F),
					                                     	Size=new Size(229,15)
				                                     	});
			
			p.Paint+=this.paintBorder;
			
			this.recentProjectsList.Controls.Add(p);
			ToolStripMenuItem tsmi = new ToolStripMenuItem(){Size=new Size(180,22),Text="Open",Name="TMSI-"+MainForm.r.Next(0,100000000).ToString() };
			tsmi.Click+=delegate { this.open(toOpen); };
		
			ContextMenuStrip cms = new ContextMenuStrip(this.components) {
			               									Name="CMS-"+MainForm.r.Next(0,100000000).ToString()
			               								};
			
			foreach (Control c in p.Controls.Cast<Control>().Concat(new []{p})) {
				
				c.Click+=delegate { this.open(toOpen); };
				c.MouseEnter+=delegate { p.ForeColor=Color.Red; p.BackColor=Color.LightGray; };
				c.MouseLeave+=delegate { p.ForeColor=Color.Black;p.BackColor=Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252))))); };
				
			}
			
			cms.Items.AddRange(new []{tsmi});
			
			p.ContextMenuStrip = cms;
			listM+=20;
			
		}
		
		private void open (String fn) {
			
			Process.Start(new ProcessStartInfo () { Arguments=fn,FileName=Application.ExecutablePath }); 
			Environment.Exit(0);
			
		}
		
		private void create (String name, ProjectType type) {
			
			if (type==ProjectType.FORTRAN) {
				
				MessageBox.Show("FORTRAN is currently not supported!");
				return;
				
			}
			
			if (type==ProjectType.NONE) {
				
				MessageBox.Show("Error: No project type?");
				return;
				
			}
			
			String defPEntryFile = this.settings.getSetting("defPEntryFile",@"src\main.asm");
			String defPBinDir = this.settings.getSetting("defPBinDir",@"src\bin");
			String defPSrcDir = this.settings.getSetting("defPSrcDir",@"src\");
			
			foreach (String s in new [] { name, defPEntryFile,defPBinDir,defPSrcDir })
				if (s.IndexOfAny(Path.GetInvalidPathChars())!=-1) {
					MessageBox.Show("Error creating projects: Illegal character in \""+s+"\". Illegal chars: " + new String(Path.GetInvalidPathChars()));
					return;
				}
			
			Byte[] data = Encoding.UTF8.GetBytes(
			
				new Project (
					
					new Header (
								
									 new [] {
						               
						          	    name,
						          	    defPEntryFile,
						          	    defPBinDir,
						          	    defPSrcDir
						          	   	
								     }
					          	   
								)
					          
				)
			
			.ToString());
			
			String pDir = this.settings.getSetting("defPDir",Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\AstroEditor Projects\") + name + @"\";
			
			String fn = pDir+(name.ToLower()+".ae");
			
			Directory.CreateDirectory(Path.GetDirectoryName(fn));
			using (FileStream fs=File.Create(fn))
				fs.Write(data,0,data.Length);
			
			Directory.CreateDirectory(pDir+defPBinDir);
			Directory.CreateDirectory(pDir+defPSrcDir);
			
			data = Encoding.UTF8.GetBytes(@"Yatta yatta yoo
one day the default hello world asm file will be loaded here
WHEN I LEARN ASSEMBLY IN THE FIRST PLACE!!!!");
			using (FileStream fs=File.Create(pDir+defPEntryFile))
				fs.Write(data,0,data.Length);
			
			this.open(fn);
			
		}
		
		public void newProjectPanelClick (Object s,EventArgs e) {
			
			NewProject np = new NewProject ();
			np.onExit+=this.onNewPanel;
			np.Show();
			
		}
		
		private void onNewPanel (Object s,NPExitEventArgs e) {
			
			if (!(e.success))
				return;
			
			this.create(e.projectName,e.type);
			
		}
		
	}
	
}