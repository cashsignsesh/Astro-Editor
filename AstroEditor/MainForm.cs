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
	
	//TODO:: Make a new icon for the app
	// make "As" red and "troEditor" some other colour like light gray, or something along those lines
	public partial class MainForm : Form {
		
		private static String exePath = Path.GetDirectoryName(Application.ExecutablePath)+@"\";
		public const String _recentsFile = ".recents";
		public const String _settingsFile = ".settings";
		
		public static String recentsFile = MainForm.exePath+MainForm._recentsFile;
		public static String settingsFile = MainForm.exePath+MainForm._settingsFile;
		
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
			
			Boolean doExit=false;
			
			foreach (String s in this.getRecents().Take(8)) {
				
				try { this.addToList(new Project(s).getHeader().pName,s); }
				catch (IOException) {
					
					File.WriteAllLines(MainForm.recentsFile,File.ReadAllLines(MainForm.recentsFile).Where(x=>(!(x.Split('?').First()==s))));
					Process.Start(Application.ExecutablePath);
					if (!(doExit)) doExit=true;
					
				}
				
			}
			
			if (doExit)
				Environment.Exit(0);
			
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
'If you are looking for accurate numbers for whatever reason, convert from UTC to your timezone."+Environment.NewLine);
				using (FileStream fs = File.Create(MainForm.recentsFile))
					fs.Write(data,0,data.Length);
				
			}
			
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
				MainForm.open(fn);
				
			}
			
		}
		
		public static void addRecent (String recent,DateTime dt) {
			
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
					                                     	Image=(listM<41)?Bitmap.FromFile(MainForm.exePath+"newer.png"):Bitmap.FromFile(MainForm.exePath+"older.png")
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
			tsmi.Click+=delegate { MainForm.open(toOpen); };
		
			ContextMenuStrip cms = new ContextMenuStrip(this.components) {
			               									Name="CMS-"+MainForm.r.Next(0,100000000).ToString()
			               								};
			
			foreach (Control c in p.Controls.Cast<Control>().Concat(new []{p})) {
				
				c.Click+=delegate { MainForm.open(toOpen); };
				c.MouseEnter+=delegate { p.ForeColor=Color.Red; p.BackColor=Color.LightGray; };
				c.MouseLeave+=delegate { p.ForeColor=Color.Black;p.BackColor=Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252))))); };
				
			}
			
			cms.Items.AddRange(new []{tsmi});
			
			p.ContextMenuStrip = cms;
			listM+=20;
			
		}
		
		public static void open (String fn,Boolean exit=true) {
			
			MainForm.addRecent(fn,DateTime.UtcNow);
			Process.Start(new ProcessStartInfo () { Arguments=fn,FileName=Application.ExecutablePath }); 
			if (exit) Environment.Exit(0);
			
		}
		
		private void create (String name, ProjectType type) {
			
			String fn = MainForm.create(name,type,this.settings);
			
			if (!(String.IsNullOrEmpty(fn)))
				MainForm.open(fn);
			
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
		
		public static String create (String name,ProjectType type,Settings settings) {
			
			if (type==ProjectType.FORTRAN) {
				
				MessageBox.Show("FORTRAN is currently not supported!");
				return "";
				
			}
			
			if (type==ProjectType.NONE) {
				
				MessageBox.Show("Error: No project type?");
				return "";
				
			}
			
			String defPEntryFile = settings.getSetting("defPEntryFile",@"src\main.asm");
			String defPBinDir = settings.getSetting("defPBinDir",@"src\bin");
			String defPSrcDir = settings.getSetting("defPSrcDir",@"src\");
			
			foreach (String s in new [] { name, defPEntryFile,defPBinDir,defPSrcDir })
				if (s.IndexOfAny(Path.GetInvalidPathChars())!=-1) {
					MessageBox.Show("Error creating projects: Illegal character in \""+s+"\". Illegal chars: " + new String(Path.GetInvalidPathChars()));
					return "";
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
			
			String pDir = settings.getSetting("defPDir",Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\AstroEditor Projects\") + name + @"\";
			
			String fn = pDir+(name.ToLower()+".ae");
			
			Directory.CreateDirectory(Path.GetDirectoryName(fn));
			using (FileStream fs=File.Create(fn))
				fs.Write(data,0,data.Length);
			
			Directory.CreateDirectory(pDir+defPBinDir);
			Directory.CreateDirectory(pDir+defPSrcDir);
			
			data = Encoding.UTF8.GetBytes(";AstroEditor Project by "+Environment.UserName+"\n;"+name+" created "+DateTime.Now+@"

include 'win64ax.inc'

.code
    
    ;Sample FASM hello world source

    ;Useful AstroEditor keybinds:
    ;Ctrl+Scroll to zoom
    ;Ctrl+F to find/replace
    ;F5 to debug
    
    start:
        invoke  MessageBox,HWND_DESKTOP,""Hello world"",invoke GetCommandLine,MB_OK
        invoke  ExitProcess,0
    

.end start");//TODO:: Set Hello world app to default asm file
			using (FileStream fs=File.Create(pDir+defPEntryFile))
				fs.Write(data,0,data.Length);
			
			return fn;
			
		}
		
	}
	
}