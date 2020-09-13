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
			this.newProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.closeProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectCtrlShiftSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.undoCtrlZToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.redoCtrlYToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.projectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.createFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.assemblyFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.batchFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.addResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.debugF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectTreeViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFromExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addResourceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderTreeViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openFromExplorerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.batchTreeViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.openFromExplorerToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.assemblyOrGenericTreeViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.openFromExplorerToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.resourcesTreeViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.importResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.mainTabs.SuspendLayout();
			this.projectTabPage.SuspendLayout();
			this.errorsPanel.SuspendLayout();
			this.fileTabs.SuspendLayout();
			this.fileContextMenuStrip.SuspendLayout();
			this.editContextMenuStrip.SuspendLayout();
			this.projectContextMenuStrip.SuspendLayout();
			this.searchContextMenuStrip.SuspendLayout();
			this.tabPageContextMenuStrip.SuspendLayout();
			this.projectTreeViewItemContextMenuStrip.SuspendLayout();
			this.folderTreeViewItemContextMenuStrip.SuspendLayout();
			this.batchTreeViewItemContextMenuStrip.SuspendLayout();
			this.assemblyOrGenericTreeViewItemContextMenuStrip.SuspendLayout();
			this.resourcesTreeViewItemContextMenuStrip.SuspendLayout();
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
			this.projectTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProjectTreeViewMouseClick);
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
			// editContextMenuStrip
			// 
			this.editContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.undoCtrlZToolStripMenuItem1,
									this.redoCtrlYToolStripMenuItem1});
			this.editContextMenuStrip.Name = "editContextMenuStrip";
			this.editContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
			this.assemblyFileToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
			this.assemblyFileToolStripMenuItem1.Text = "Assembly file";
			// 
			// batchFileToolStripMenuItem1
			// 
			this.batchFileToolStripMenuItem1.Name = "batchFileToolStripMenuItem1";
			this.batchFileToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
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
			this.debugF5ToolStripMenuItem.Click += new System.EventHandler(this.DebugF5ToolStripMenuItemClick);
			// 
			// searchContextMenuStrip
			// 
			this.searchContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.findToolStripMenuItem1,
									this.replaceToolStripMenuItem1});
			this.searchContextMenuStrip.Name = "contextMenuStrip4";
			this.searchContextMenuStrip.Size = new System.Drawing.Size(116, 48);
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
			// tabPageContextMenuStrip
			// 
			this.tabPageContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.closeToolStripMenuItem,
									this.closeAllToolStripMenuItem,
									this.closeAllButThisToolStripMenuItem});
			this.tabPageContextMenuStrip.Name = "tabPageContextMenuStrip";
			this.tabPageContextMenuStrip.Size = new System.Drawing.Size(162, 70);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.closeToolStripMenuItem.Text = "Close";
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.closeAllToolStripMenuItem.Text = "Close all";
			// 
			// closeAllButThisToolStripMenuItem
			// 
			this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
			this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.closeAllButThisToolStripMenuItem.Text = "Close all but this";
			// 
			// projectTreeViewItemContextMenuStrip
			// 
			this.projectTreeViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem,
									this.openFromExplorerToolStripMenuItem,
									this.projectSettingsToolStripMenuItem,
									this.addToolStripMenuItem,
									this.addResourceToolStripMenuItem1,
									this.expandAllToolStripMenuItem});
			this.projectTreeViewItemContextMenuStrip.Name = "contextMenuStrip1";
			this.projectTreeViewItemContextMenuStrip.Size = new System.Drawing.Size(178, 136);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.tabPageFromCmsItem);
			// 
			// openFromExplorerToolStripMenuItem
			// 
			this.openFromExplorerToolStripMenuItem.Name = "openFromExplorerToolStripMenuItem";
			this.openFromExplorerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.openFromExplorerToolStripMenuItem.Text = "Open from explorer";
			this.openFromExplorerToolStripMenuItem.Click += new System.EventHandler(this.openExplorer);
			// 
			// projectSettingsToolStripMenuItem
			// 
			this.projectSettingsToolStripMenuItem.Name = "projectSettingsToolStripMenuItem";
			this.projectSettingsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.projectSettingsToolStripMenuItem.Text = "Project settings";
			this.projectSettingsToolStripMenuItem.Click += new System.EventHandler(this.ProjectSettingsToolStripMenuItemClick);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.addToolStripMenuItem.Text = "Debug (F5)";
			// 
			// addResourceToolStripMenuItem1
			// 
			this.addResourceToolStripMenuItem1.Name = "addResourceToolStripMenuItem1";
			this.addResourceToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
			this.addResourceToolStripMenuItem1.Text = "Add resources";
			this.addResourceToolStripMenuItem1.Click += new System.EventHandler(this.AddResourceToolStripMenuItem1Click);
			// 
			// expandAllToolStripMenuItem
			// 
			this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
			this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.expandAllToolStripMenuItem.Text = "Expand all";
			this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItemClick);
			// 
			// folderTreeViewItemContextMenuStrip
			// 
			this.folderTreeViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem1,
									this.openFromExplorerToolStripMenuItem1,
									this.expandToolStripMenuItem,
									this.contractToolStripMenuItem,
									this.deleteToolStripMenuItem});
			this.folderTreeViewItemContextMenuStrip.Name = "folderTreeViewItemContextMenuStrip";
			this.folderTreeViewItemContextMenuStrip.Size = new System.Drawing.Size(178, 114);
			// 
			// openToolStripMenuItem1
			// 
			this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
			this.openToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
			this.openToolStripMenuItem1.Text = "Open";
			this.openToolStripMenuItem1.Click += new System.EventHandler(this.tabPageFromCmsItem);
			// 
			// openFromExplorerToolStripMenuItem1
			// 
			this.openFromExplorerToolStripMenuItem1.Name = "openFromExplorerToolStripMenuItem1";
			this.openFromExplorerToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
			this.openFromExplorerToolStripMenuItem1.Text = "Open from explorer";
			this.openFromExplorerToolStripMenuItem1.Click += new System.EventHandler(this.openExplorer);
			// 
			// expandToolStripMenuItem
			// 
			this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
			this.expandToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.expandToolStripMenuItem.Text = "Expand";
			this.expandToolStripMenuItem.Click += new System.EventHandler(this.ExpandToolStripMenuItemClick);
			// 
			// contractToolStripMenuItem
			// 
			this.contractToolStripMenuItem.Name = "contractToolStripMenuItem";
			this.contractToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.contractToolStripMenuItem.Text = "Contract";
			this.contractToolStripMenuItem.Click += new System.EventHandler(this.ContractToolStripMenuItemClick);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
			// 
			// batchTreeViewItemContextMenuStrip
			// 
			this.batchTreeViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem2,
									this.openFromExplorerToolStripMenuItem2,
									this.runToolStripMenuItem,
									this.deleteToolStripMenuItem1});
			this.batchTreeViewItemContextMenuStrip.Name = "contextMenuStrip1";
			this.batchTreeViewItemContextMenuStrip.Size = new System.Drawing.Size(178, 114);
			// 
			// openToolStripMenuItem2
			// 
			this.openToolStripMenuItem2.Name = "openToolStripMenuItem2";
			this.openToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
			this.openToolStripMenuItem2.Text = "Open";
			this.openToolStripMenuItem2.Click += new System.EventHandler(this.tabPageFromCmsItem);
			// 
			// openFromExplorerToolStripMenuItem2
			// 
			this.openFromExplorerToolStripMenuItem2.Name = "openFromExplorerToolStripMenuItem2";
			this.openFromExplorerToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
			this.openFromExplorerToolStripMenuItem2.Text = "Open from explorer";
			this.openFromExplorerToolStripMenuItem2.Click += new System.EventHandler(this.openExplorer);
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.runToolStripMenuItem.Text = "Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItemClick);
			// 
			// deleteToolStripMenuItem1
			// 
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteFileLatestTV);
			// 
			// assemblyOrGenericTreeViewItemContextMenuStrip
			// 
			this.assemblyOrGenericTreeViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem3,
									this.openFromExplorerToolStripMenuItem3,
									this.deleteToolStripMenuItem2});
			this.assemblyOrGenericTreeViewItemContextMenuStrip.Name = "assemblyOrGenericTreeViewItemContextMenuStrip";
			this.assemblyOrGenericTreeViewItemContextMenuStrip.Size = new System.Drawing.Size(178, 70);
			// 
			// openToolStripMenuItem3
			// 
			this.openToolStripMenuItem3.Name = "openToolStripMenuItem3";
			this.openToolStripMenuItem3.Size = new System.Drawing.Size(177, 22);
			this.openToolStripMenuItem3.Text = "Open";
			this.openToolStripMenuItem3.Click += new System.EventHandler(this.tabPageFromCmsItem);
			// 
			// openFromExplorerToolStripMenuItem3
			// 
			this.openFromExplorerToolStripMenuItem3.Name = "openFromExplorerToolStripMenuItem3";
			this.openFromExplorerToolStripMenuItem3.Size = new System.Drawing.Size(177, 22);
			this.openFromExplorerToolStripMenuItem3.Text = "Open from explorer";
			this.openFromExplorerToolStripMenuItem3.Click += new System.EventHandler(this.openExplorer);
			// 
			// deleteToolStripMenuItem2
			// 
			this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
			this.deleteToolStripMenuItem2.Text = "Delete";
			this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.deleteFileLatestTV);
			// 
			// resourcesTreeViewItemContextMenuStrip
			// 
			this.resourcesTreeViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.importResourceToolStripMenuItem,
									this.removeResourceToolStripMenuItem,
									this.viewResourcesToolStripMenuItem,
									this.deleteToolStripMenuItem3});
			this.resourcesTreeViewItemContextMenuStrip.Name = "resourcesTreeViewItemContextMenuStrip";
			this.resourcesTreeViewItemContextMenuStrip.Size = new System.Drawing.Size(166, 92);
			// 
			// importResourceToolStripMenuItem
			// 
			this.importResourceToolStripMenuItem.Name = "importResourceToolStripMenuItem";
			this.importResourceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.importResourceToolStripMenuItem.Text = "Import resource";
			this.importResourceToolStripMenuItem.Click += new System.EventHandler(this.ImportResourceToolStripMenuItemClick);
			// 
			// removeResourceToolStripMenuItem
			// 
			this.removeResourceToolStripMenuItem.Name = "removeResourceToolStripMenuItem";
			this.removeResourceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.removeResourceToolStripMenuItem.Text = "Remove resource";
			// 
			// viewResourcesToolStripMenuItem
			// 
			this.viewResourcesToolStripMenuItem.Name = "viewResourcesToolStripMenuItem";
			this.viewResourcesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.viewResourcesToolStripMenuItem.Text = "View resources";
			this.viewResourcesToolStripMenuItem.Click += new System.EventHandler(this.ViewResourcesToolStripMenuItemClick);
			// 
			// deleteToolStripMenuItem3
			// 
			this.deleteToolStripMenuItem3.Name = "deleteToolStripMenuItem3";
			this.deleteToolStripMenuItem3.Size = new System.Drawing.Size(165, 22);
			this.deleteToolStripMenuItem3.Text = "Delete";
			this.deleteToolStripMenuItem3.Click += new System.EventHandler(this.DeleteToolStripMenuItem3Click);
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
			this.tabPageContextMenuStrip.ResumeLayout(false);
			this.projectTreeViewItemContextMenuStrip.ResumeLayout(false);
			this.folderTreeViewItemContextMenuStrip.ResumeLayout(false);
			this.batchTreeViewItemContextMenuStrip.ResumeLayout(false);
			this.assemblyOrGenericTreeViewItemContextMenuStrip.ResumeLayout(false);
			this.resourcesTreeViewItemContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem viewResourcesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeResourceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importResourceToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip resourcesTreeViewItemContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addResourceToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem openFromExplorerToolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem3;
		private System.Windows.Forms.ContextMenuStrip assemblyOrGenericTreeViewItemContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFromExplorerToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem2;
		private System.Windows.Forms.ContextMenuStrip batchTreeViewItemContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contractToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFromExplorerToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip folderTreeViewItemContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem projectSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFromExplorerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip projectTreeViewItemContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem closeAllButThisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip tabPageContextMenuStrip;
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
