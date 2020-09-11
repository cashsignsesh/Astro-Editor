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
			this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoCtrlZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoCtrlYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assemblyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.batchFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compileDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainTabs.SuspendLayout();
			this.projectTabPage.SuspendLayout();
			this.errorsPanel.SuspendLayout();
			this.fileTabs.SuspendLayout();
			this.mainContextMenuStrip.SuspendLayout();
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
			this.settingsTabPage.Size = new System.Drawing.Size(376, 489);
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
			// mainContextMenuStrip
			// 
			this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.editToolStripMenuItem,
									this.projectToolStripMenuItem,
									this.searchToolStripMenuItem});
			this.mainContextMenuStrip.Name = "contextMenuStrip1";
			this.mainContextMenuStrip.Size = new System.Drawing.Size(112, 92);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newProjectToolStripMenuItem,
									this.openProjectToolStripMenuItem,
									this.closeProjectToolStripMenuItem,
									this.saveFileToolStripMenuItem,
									this.saveAllToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.newProjectToolStripMenuItem.Text = "New Project";
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.openProjectToolStripMenuItem.Text = "Open Project";
			// 
			// closeProjectToolStripMenuItem
			// 
			this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
			this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.closeProjectToolStripMenuItem.Text = "Close Project";
			// 
			// saveFileToolStripMenuItem
			// 
			this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
			this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.saveFileToolStripMenuItem.Text = "Save File (Ctrl+S)";
			// 
			// saveAllToolStripMenuItem
			// 
			this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
			this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.saveAllToolStripMenuItem.Text = "Save All (Ctrl+Shift+S)";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.undoCtrlZToolStripMenuItem,
									this.redoCtrlYToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// undoCtrlZToolStripMenuItem
			// 
			this.undoCtrlZToolStripMenuItem.Name = "undoCtrlZToolStripMenuItem";
			this.undoCtrlZToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.undoCtrlZToolStripMenuItem.Text = "Undo (Ctrl+Z)";
			// 
			// redoCtrlYToolStripMenuItem
			// 
			this.redoCtrlYToolStripMenuItem.Name = "redoCtrlYToolStripMenuItem";
			this.redoCtrlYToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.redoCtrlYToolStripMenuItem.Text = "Redo (Ctrl+Y)";
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createFileToolStripMenuItem,
									this.addReferenceToolStripMenuItem,
									this.compileToolStripMenuItem,
									this.compileDebugToolStripMenuItem});
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.projectToolStripMenuItem.Text = "Project";
			// 
			// createFileToolStripMenuItem
			// 
			this.createFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.assemblyFileToolStripMenuItem,
									this.batchFileToolStripMenuItem});
			this.createFileToolStripMenuItem.Name = "createFileToolStripMenuItem";
			this.createFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.createFileToolStripMenuItem.Text = "Create file";
			// 
			// assemblyFileToolStripMenuItem
			// 
			this.assemblyFileToolStripMenuItem.Name = "assemblyFileToolStripMenuItem";
			this.assemblyFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.assemblyFileToolStripMenuItem.Text = "Assembly file";
			// 
			// batchFileToolStripMenuItem
			// 
			this.batchFileToolStripMenuItem.Name = "batchFileToolStripMenuItem";
			this.batchFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.batchFileToolStripMenuItem.Text = "Batch file";
			// 
			// addReferenceToolStripMenuItem
			// 
			this.addReferenceToolStripMenuItem.Name = "addReferenceToolStripMenuItem";
			this.addReferenceToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.addReferenceToolStripMenuItem.Text = "Add resource";
			// 
			// compileToolStripMenuItem
			// 
			this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
			this.compileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.compileToolStripMenuItem.Text = "Compile";
			// 
			// compileDebugToolStripMenuItem
			// 
			this.compileDebugToolStripMenuItem.Name = "compileDebugToolStripMenuItem";
			this.compileDebugToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.compileDebugToolStripMenuItem.Text = "Debug";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.findToolStripMenuItem,
									this.replaceToolStripMenuItem});
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.searchToolStripMenuItem.Text = "Search";
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.findToolStripMenuItem.Text = "Find";
			// 
			// replaceToolStripMenuItem
			// 
			this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
			this.replaceToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.replaceToolStripMenuItem.Text = "Replace";
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
			this.mainContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.RichTextBox projectErrors;
		private System.Windows.Forms.RichTextBox editorErrors;
		private System.Windows.Forms.Button clearEditorErrorsBtn;
		private System.Windows.Forms.Button clearProjectErrorsBtn;
		private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compileDebugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addReferenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem batchFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem assemblyFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoCtrlYToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoCtrlZToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
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
