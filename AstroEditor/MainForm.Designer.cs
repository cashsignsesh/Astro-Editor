/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AsmEditor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.loadProgressBar = new System.Windows.Forms.ProgressBar();
			this.recentProjectsLabel = new System.Windows.Forms.Label();
			this.recentProjectsGroupBox = new System.Windows.Forms.GroupBox();
			this.recentProjectsList = new System.Windows.Forms.Panel();
			this.newProjectLabel = new System.Windows.Forms.Label();
			this.newProjectPictureBox = new System.Windows.Forms.PictureBox();
			this.newProjectPanel = new System.Windows.Forms.Panel();
			this.openProjectPanel = new System.Windows.Forms.Panel();
			this.openProjectPictureBox = new System.Windows.Forms.PictureBox();
			this.openProjectLabel = new System.Windows.Forms.Label();
			this.recentProjectsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.newProjectPictureBox)).BeginInit();
			this.newProjectPanel.SuspendLayout();
			this.openProjectPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.openProjectPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// loadProgressBar
			// 
			this.loadProgressBar.Location = new System.Drawing.Point(259, 197);
			this.loadProgressBar.Name = "loadProgressBar";
			this.loadProgressBar.Size = new System.Drawing.Size(216, 22);
			this.loadProgressBar.TabIndex = 0;
			// 
			// recentProjectsLabel
			// 
			this.recentProjectsLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.recentProjectsLabel.Location = new System.Drawing.Point(47, 12);
			this.recentProjectsLabel.Name = "recentProjectsLabel";
			this.recentProjectsLabel.Size = new System.Drawing.Size(144, 26);
			this.recentProjectsLabel.TabIndex = 1;
			this.recentProjectsLabel.Text = "Recent Projects";
			// 
			// recentProjectsGroupBox
			// 
			this.recentProjectsGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
			this.recentProjectsGroupBox.Controls.Add(this.recentProjectsList);
			this.recentProjectsGroupBox.Controls.Add(this.recentProjectsLabel);
			this.recentProjectsGroupBox.Location = new System.Drawing.Point(12, 5);
			this.recentProjectsGroupBox.Name = "recentProjectsGroupBox";
			this.recentProjectsGroupBox.Size = new System.Drawing.Size(241, 216);
			this.recentProjectsGroupBox.TabIndex = 2;
			this.recentProjectsGroupBox.TabStop = false;
			// 
			// recentProjectsList
			// 
			this.recentProjectsList.Location = new System.Drawing.Point(6, 41);
			this.recentProjectsList.Name = "recentProjectsList";
			this.recentProjectsList.Size = new System.Drawing.Size(229, 169);
			this.recentProjectsList.TabIndex = 2;
			// 
			// newProjectLabel
			// 
			this.newProjectLabel.Font = new System.Drawing.Font("Corbel", 18F);
			this.newProjectLabel.Location = new System.Drawing.Point(66, 12);
			this.newProjectLabel.Name = "newProjectLabel";
			this.newProjectLabel.Size = new System.Drawing.Size(137, 32);
			this.newProjectLabel.TabIndex = 3;
			this.newProjectLabel.Text = "New Project";
			this.newProjectLabel.Click += new System.EventHandler(this.newProjectPanelClick);
			// 
			// newProjectPictureBox
			// 
			this.newProjectPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newProjectPictureBox.BackgroundImage")));
			this.newProjectPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.newProjectPictureBox.ErrorImage = null;
			this.newProjectPictureBox.InitialImage = null;
			this.newProjectPictureBox.Location = new System.Drawing.Point(1, 1);
			this.newProjectPictureBox.Name = "newProjectPictureBox";
			this.newProjectPictureBox.Size = new System.Drawing.Size(52, 52);
			this.newProjectPictureBox.TabIndex = 4;
			this.newProjectPictureBox.TabStop = false;
			this.newProjectPictureBox.Click += new System.EventHandler(this.newProjectPanelClick);
			this.newProjectPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.paintBorderEastPB);
			// 
			// newProjectPanel
			// 
			this.newProjectPanel.Controls.Add(this.newProjectPictureBox);
			this.newProjectPanel.Controls.Add(this.newProjectLabel);
			this.newProjectPanel.Location = new System.Drawing.Point(259, 136);
			this.newProjectPanel.Name = "newProjectPanel";
			this.newProjectPanel.Size = new System.Drawing.Size(216, 54);
			this.newProjectPanel.TabIndex = 5;
			this.newProjectPanel.Click += new System.EventHandler(this.newProjectPanelClick);
			this.newProjectPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.paintBorder);
			// 
			// openProjectPanel
			// 
			this.openProjectPanel.Controls.Add(this.openProjectPictureBox);
			this.openProjectPanel.Controls.Add(this.openProjectLabel);
			this.openProjectPanel.Location = new System.Drawing.Point(259, 76);
			this.openProjectPanel.Name = "openProjectPanel";
			this.openProjectPanel.Size = new System.Drawing.Size(216, 54);
			this.openProjectPanel.TabIndex = 6;
			this.openProjectPanel.Click += new System.EventHandler(this.openProjectPanelClick);
			this.openProjectPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.paintBorder);
			// 
			// openProjectPictureBox
			// 
			this.openProjectPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("openProjectPictureBox.BackgroundImage")));
			this.openProjectPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.openProjectPictureBox.ErrorImage = null;
			this.openProjectPictureBox.InitialImage = null;
			this.openProjectPictureBox.Location = new System.Drawing.Point(1, 1);
			this.openProjectPictureBox.Name = "openProjectPictureBox";
			this.openProjectPictureBox.Size = new System.Drawing.Size(52, 52);
			this.openProjectPictureBox.TabIndex = 4;
			this.openProjectPictureBox.TabStop = false;
			this.openProjectPictureBox.Click += new System.EventHandler(this.openProjectPanelClick);
			this.openProjectPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.paintBorderEastPB);
			// 
			// openProjectLabel
			// 
			this.openProjectLabel.Font = new System.Drawing.Font("Corbel", 18F);
			this.openProjectLabel.Location = new System.Drawing.Point(60, 12);
			this.openProjectLabel.Name = "openProjectLabel";
			this.openProjectLabel.Size = new System.Drawing.Size(147, 32);
			this.openProjectLabel.TabIndex = 3;
			this.openProjectLabel.Text = "Open Project";
			this.openProjectLabel.Click += new System.EventHandler(this.openProjectPanelClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
			this.ClientSize = new System.Drawing.Size(487, 227);
			this.Controls.Add(this.openProjectPanel);
			this.Controls.Add(this.newProjectPanel);
			this.Controls.Add(this.recentProjectsGroupBox);
			this.Controls.Add(this.loadProgressBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Astro Editor";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.recentProjectsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.newProjectPictureBox)).EndInit();
			this.newProjectPanel.ResumeLayout(false);
			this.openProjectPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.openProjectPictureBox)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Panel recentProjectsList;
		private System.Windows.Forms.Label openProjectLabel;
		private System.Windows.Forms.PictureBox openProjectPictureBox;
		private System.Windows.Forms.Panel openProjectPanel;
		private System.Windows.Forms.Panel newProjectPanel;
		private System.Windows.Forms.PictureBox newProjectPictureBox;
		private System.Windows.Forms.Label newProjectLabel;
		private System.Windows.Forms.GroupBox recentProjectsGroupBox;
		private System.Windows.Forms.Label recentProjectsLabel;
		private System.Windows.Forms.ProgressBar loadProgressBar;
		
	
	}
}
