/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AsmEditor
{
	partial class Editor
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
			this.mainTabs = new System.Windows.Forms.TabControl();
			this.projectTabPage = new System.Windows.Forms.TabPage();
			this.projectTreeView = new System.Windows.Forms.TreeView();
			this.settingsTabPage = new System.Windows.Forms.TabPage();
			this.errorsPanel = new System.Windows.Forms.Panel();
			this.clearProjectErrorsBtn = new System.Windows.Forms.Button();
			this.clearEditorErrorsBtn = new System.Windows.Forms.Button();
			this.editorErrors = new System.Windows.Forms.RichTextBox();
			this.projectErrors = new System.Windows.Forms.RichTextBox();
			this.errorsLabel = new System.Windows.Forms.Label();
			this.fileTabs = new System.Windows.Forms.TabControl();
			this.defaultTabPage = new System.Windows.Forms.TabPage();
			this.fileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.projectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.searchContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.closeProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectCtrlShiftSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoCtrlZToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.redoCtrlYToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.createFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.assemblyFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.batchFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.addResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.debugF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.mainTabs.SuspendLayout();
			this.projectTabPage.SuspendLayout();
			this.errorsPanel.SuspendLayout();
			this.fileTabs.SuspendLayout();
			this.fileContextMenuStrip.SuspendLayout();
			this.editContextMenuStrip.SuspendLayout();
			this.projectContextMenuStrip.SuspendLayout();
			this.searchContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTabs
			// 
			this.mainTabs.Controls.Add(this.projectTabPage);
			this.mainTabs.Controls.Add(this.settingsTabPage);
			this.mainTabs.Location = new System.Drawing.Point(0, 31);
			this.mainTabs.Name = "mainTabs";
			this.mainTabs.SelectedIndex = 0;
			this.mainTabs.Size = new System.Drawing.Size(384, 506);
			this.mainTabs.TabIndex = 0;
			// 
			// projectTabPage
			// 
			this.projectTabPage.Controls.Add(this.projectTreeView);
			this.projectTabPage.Location = new System.Drawing.Point(4, 22);
			this.projectTabPage.Name = "projectTabPage";
			this.projectTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.projectTabPage.Size = new System.Drawing.Size(376, 480);
			this.projectTabPage.TabIndex = 0;
			this.projectTabPage.Text = "Project";
			this.projectTabPage.UseVisualStyleBackColor = true;
			// 
			// projectTreeView
			// 
			this.projectTreeView.Location = new System.Drawing.Point(8, 28);
			this.projectTreeView.Name = "projectTreeView";
			this.projectTreeView.Size = new System.Drawing.Size(362, 449);
			this.projectTreeView.TabIndex = 0;
			// 
			// settingsTabPage
			// 
			this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
			this.settingsTabPage.Name = "settingsTabPage";
			this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.settingsTabPage.Size = new System.Drawing.Size(376, 480);
			this.settingsTabPage.TabIndex = 1;
			this.settingsTabPage.Text = "Settings";
			this.settingsTabPage.UseVisualStyleBackColor = true;
			// 
			// errorsPanel
			// 
			this.errorsPanel.BackColor = System.Drawing.SystemColors.Control;
			this.errorsPanel.Controls.Add(this.clearProjectErrorsBtn);
			this.errorsPanel.Controls.Add(this.clearEditorErrorsBtn);
			this.errorsPanel.Controls.Add(this.editorErrors);
			this.errorsPanel.Controls.Add(this.projectErrors);
			this.errorsPanel.Controls.Add(this.errorsLabel);
			this.errorsPanel.Location = new System.Drawing.Point(0, 547);
			this.errorsPanel.Name = "errorsPanel";
			this.errorsPanel.Size = new System.Drawing.Size(1108, 133);
			this.errorsPanel.TabIndex = 1;
			// 
			// clearProjectErrorsBtn
			// 
			this.clearProjectErrorsBtn.Location = new System.Drawing.Point(4, 54);
			this.clearProjectErrorsBtn.Name = "clearProjectErrorsBtn";
			this.clearProjectErrorsBtn.Size = new System.Drawing.Size(166, 23);
			this.clearProjectErrorsBtn.TabIndex = 4;
			this.clearProjectErrorsBtn.Text = "Clear project errors";
			this.clearProjectErrorsBtn.UseVisualStyleBackColor = true;
			this.clearProjectErrorsBtn.Click += new System.EventHandler(this.ClearProjectErrorsBtnClick);
			// 
			// clearEditorErrorsBtn
			// 
			this.clearEditorErrorsBtn.Location = new System.Drawing.Point(4, 25);
			this.clearEditorErrorsBtn.Name = "clearEditorErrorsBtn";
			this.clearEditorErrorsBtn.Size = new System.Drawing.Size(166, 23);
			this.clearEditorErrorsBtn.TabIndex = 3;
			this.clearEditorErrorsBtn.Text = "Clear editor errors";
			this.clearEditorErrorsBtn.UseVisualStyleBackColor = true;
			this.clearEditorErrorsBtn.Click += new System.EventHandler(this.ClearEditorErrorsBtnClick);
			// 
			// editorErrors
			// 
			this.editorErrors.Location = new System.Drawing.Point(307, 7);
			this.editorErrors.Name = "editorErrors";
			this.editorErrors.ReadOnly = true;
			this.editorErrors.Size = new System.Drawing.Size(390, 113);
			this.editorErrors.TabIndex = 2;
			this.editorErrors.Text = "";
			// 
			// projectErrors
			// 
			this.projectErrors.Location = new System.Drawing.Point(703, 7);
			this.projectErrors.Name = "projectErrors";
			this.projectErrors.ReadOnly = true;
			this.projectErrors.Size = new System.Drawing.Size(390, 113);
			this.projectErrors.TabIndex = 1;
			this.projectErrors.Text = "";
			// 
			// errorsLabel
			// 
			this.errorsLabel.Location = new System.Drawing.Point(4, 7);
			this.errorsLabel.Name = "errorsLabel";
			this.errorsLabel.Size = new System.Drawing.Size(36, 15);
			this.errorsLabel.TabIndex = 0;
			this.errorsLabel.Text = "Errors";
			// 
			// fileTabs
			// 
			this.fileTabs.Controls.Add(this.defaultTabPage);
			this.fileTabs.Location = new System.Drawing.Point(391, 31);
			this.fileTabs.Name = "fileTabs";
			this.fileTabs.SelectedIndex = 0;
			this.fileTabs.Size = new System.Drawing.Size(714, 506);
			this.fileTabs.TabIndex = 2;
			// 
			// defaultTabPage
			// 
			this.defaultTabPage.Location = new System.Drawing.Point(4, 22);
			this.defaultTabPage.Name = "defaultTabPage";
			this.defaultTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.defaultTabPage.Size = new System.Drawing.Size(706, 480);
			this.defaultTabPage.TabIndex = 1;
			this.defaultTabPage.UseVisualStyleBackColor = true;
			// 
			// fileContextMenuStrip
			// 
			this.fileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newProjectToolStripMenuItem1,
									this.openProjectToolStripMenuItem1,
									this.closeProjectToolStripMenuItem1,
									this.saveFileCtrlSToolStripMenuItem,
									this.saveProjectCtrlShiftSToolStripMenuItem});
			this.fileContextMenuStrip.Name = "fileContextMenuStrip";
			this.fileContextMenuStrip.Size = new System.Drawing.Size(192, 114);
			// 
			// editContextMenuStrip
			// 
			this.editContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.undoCtrlZToolStripMenuItem1,
									this.redoCtrlYToolStripMenuItem1});
			this.editContextMenuStrip.Name = "editContextMenuStrip";
			this.editContextMenuStrip.Size = new System.Drawing.Size(149, 48);
			// 
			// projectContextMenuStrip
			// 
			this.projectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createFileToolStripMenuItem1,
									this.addResourceToolStripMenuItem,
									this.compileToolStripMenuItem1,
									this.debugF5ToolStripMenuItem});
			this.projectContextMenuStrip.Name = "projectContextMenuStrip";
			this.projectContextMenuStrip.Size = new System.Drawing.Size(145, 92);
			// 
			// searchContextMenuStrip
			// 
			this.searchContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.findToolStripMenuItem1,
									this.replaceToolStripMenuItem1});
			this.searchContextMenuStrip.Name = "contextMenuStrip4";
			this.searchContextMenuStrip.Size = new System.Drawing.Size(116, 48);
			// 
			// newProjectToolStripMenuItem1
			// 
			this.newProjectToolStripMenuItem1.Name = "newProjectToolStripMenuItem1";
			this.newProjectToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
			this.newProjectToolStripMenuItem1.Text = "New Project";
			// 
			// openProjectToolStripMenuItem1
			// 
			this.openProjectToolStripMenuItem1.Name = "openProjectToolStripMenuItem1";
			this.openProjectToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
			this.openProjectToolStripMenuItem1.Text = "Open Project";
			// 
			// closeProjectToolStripMenuItem1
			// 
			this.closeProjectToolStripMenuItem1.Name = "closeProjectToolStripMenuItem1";
			this.closeProjectToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
			this.closeProjectToolStripMenuItem1.Text = "Close Project";
			// 
			// saveFileCtrlSToolStripMenuItem
			// 
			this.saveFileCtrlSToolStripMenuItem.Name = "saveFileCtrlSToolStripMenuItem";
			this.saveFileCtrlSToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.saveFileCtrlSToolStripMenuItem.Text = "Save File (Ctrl+S)";
			// 
			// saveProjectCtrlShiftSToolStripMenuItem
			// 
			this.saveProjectCtrlShiftSToolStripMenuItem.Name = "saveProjectCtrlShiftSToolStripMenuItem";
			this.saveProjectCtrlShiftSToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.saveProjectCtrlShiftSToolStripMenuItem.Text = "Save All (Ctrl+Shift+S)";
			// 
			// undoCtrlZToolStripMenuItem1
			// 
			this.undoCtrlZToolStripMenuItem1.Name = "undoCtrlZToolStripMenuItem1";
			this.undoCtrlZToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
			this.undoCtrlZToolStripMenuItem1.Text = "Undo (Ctrl+Z)";
			// 
			// redoCtrlYToolStripMenuItem1
			// 
			this.redoCtrlYToolStripMenuItem1.Name = "redoCtrlYToolStripMenuItem1";
			this.redoCtrlYToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
			this.redoCtrlYToolStripMenuItem1.Text = "Redo (Ctrl+Y)";
			// 
			// createFileToolStripMenuItem1
			// 
			this.createFileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.assemblyFileToolStripMenuItem1,
									this.batchFileToolStripMenuItem1});
			this.createFileToolStripMenuItem1.Name = "createFileToolStripMenuItem1";
			this.createFileToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
			this.createFileToolStripMenuItem1.Text = "Create file";
			// 
			// assemblyFileToolStripMenuItem1
			// 
			this.assemblyFileToolStripMenuItem1.Name = "assemblyFileToolStripMenuItem1";
			this.assemblyFileToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.assemblyFileToolStripMenuItem1.Text = "Assembly file";
			// 
			// batchFileToolStripMenuItem1
			// 
			this.batchFileToolStripMenuItem1.Name = "batchFileToolStripMenuItem1";
			this.batchFileToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.batchFileToolStripMenuItem1.Text = "Batch file";
			// 
			// addResourceToolStripMenuItem
			// 
			this.addResourceToolStripMenuItem.Name = "addResourceToolStripMenuItem";
			this.addResourceToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.addResourceToolStripMenuItem.Text = "Add resource";
			// 
			// compileToolStripMenuItem1
			// 
			this.compileToolStripMenuItem1.Name = "compileToolStripMenuItem1";
			this.compileToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
			this.compileToolStripMenuItem1.Text = "Compile";
			// 
			// debugF5ToolStripMenuItem
			// 
			this.debugF5ToolStripMenuItem.Name = "debugF5ToolStripMenuItem";
			this.debugF5ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.debugF5ToolStripMenuItem.Text = "Debug (F5)";
			// 
			// findToolStripMenuItem1
			// 
			this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
			this.findToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
			this.findToolStripMenuItem1.Text = "Find";
			// 
			// replaceToolStripMenuItem1
			// 
			this.replaceToolStripMenuItem1.Name = "replaceToolStripMenuItem1";
			this.replaceToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
			this.replaceToolStripMenuItem1.Text = "Replace";
			// 
			// Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1105, 679);
			this.Controls.Add(this.fileTabs);
			this.Controls.Add(this.errorsPanel);
			this.Controls.Add(this.mainTabs);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Editor";
			this.Text = "Editor";
			this.Load += new System.EventHandler(this.EditorLoad);
			this.mainTabs.ResumeLayout(false);
			this.projectTabPage.ResumeLayout(false);
			this.errorsPanel.ResumeLayout(false);
			this.fileTabs.ResumeLayout(false);
			this.fileContextMenuStrip.ResumeLayout(false);
			this.editContextMenuStrip.ResumeLayout(false);
			this.projectContextMenuStrip.ResumeLayout(false);
			this.searchContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem debugF5ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem addResourceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem batchFileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem assemblyFileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem createFileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem redoCtrlYToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem undoCtrlZToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem saveProjectCtrlShiftSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveFileCtrlSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip searchContextMenuStrip;
		private System.Windows.Forms.ContextMenuStrip projectContextMenuStrip;
		private System.Windows.Forms.ContextMenuStrip editContextMenuStrip;
		private System.Windows.Forms.ContextMenuStrip fileContextMenuStrip;
		private System.Windows.Forms.RichTextBox projectErrors;
		private System.Windows.Forms.RichTextBox editorErrors;
		private System.Windows.Forms.Button clearEditorErrorsBtn;
		private System.Windows.Forms.Button clearProjectErrorsBtn;
		private System.Windows.Forms.TabPage defaultTabPage;
		private System.Windows.Forms.TabControl fileTabs;
		private System.Windows.Forms.Label errorsLabel;
		private System.Windows.Forms.Panel errorsPanel;
		private System.Windows.Forms.TreeView projectTreeView;
		private System.Windows.Forms.TabPage settingsTabPage;
		private System.Windows.Forms.TabPage projectTabPage;
		private System.Windows.Forms.TabControl mainTabs;
		
		
		
	}
}
