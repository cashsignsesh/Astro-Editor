/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/11/2020
 * Time: 1:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AsmEditor
{
	partial class NewProject
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
			this.projectNameTextBox = new System.Windows.Forms.TextBox();
			this.projectNameLabel = new System.Windows.Forms.Label();
			this.createButton = new System.Windows.Forms.Button();
			this.projectTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.fortranProjectPanel = new System.Windows.Forms.Panel();
			this.fortranProjectLbl = new System.Windows.Forms.Label();
			this.assemblyProjectPanel = new System.Windows.Forms.Panel();
			this.assemblyProjectLbl = new System.Windows.Forms.Label();
			this.projectTypesListView = new System.Windows.Forms.ListView();
			this.projectTypeGroupBox.SuspendLayout();
			this.fortranProjectPanel.SuspendLayout();
			this.assemblyProjectPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// projectNameTextBox
			// 
			this.projectNameTextBox.Location = new System.Drawing.Point(89, 146);
			this.projectNameTextBox.Name = "projectNameTextBox";
			this.projectNameTextBox.Size = new System.Drawing.Size(140, 20);
			this.projectNameTextBox.TabIndex = 0;
			this.projectNameTextBox.Text = "My Project";
			// 
			// projectNameLabel
			// 
			this.projectNameLabel.Location = new System.Drawing.Point(9, 149);
			this.projectNameLabel.Name = "projectNameLabel";
			this.projectNameLabel.Size = new System.Drawing.Size(74, 15);
			this.projectNameLabel.TabIndex = 1;
			this.projectNameLabel.Text = "Project Name:";
			// 
			// createButton
			// 
			this.createButton.Location = new System.Drawing.Point(148, 172);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(81, 22);
			this.createButton.TabIndex = 2;
			this.createButton.Text = "Create";
			this.createButton.UseVisualStyleBackColor = true;
			this.createButton.Click += new System.EventHandler(this.CreateButtonClick);
			// 
			// projectTypeGroupBox
			// 
			this.projectTypeGroupBox.Controls.Add(this.fortranProjectPanel);
			this.projectTypeGroupBox.Controls.Add(this.assemblyProjectPanel);
			this.projectTypeGroupBox.Controls.Add(this.projectTypesListView);
			this.projectTypeGroupBox.Location = new System.Drawing.Point(13, 7);
			this.projectTypeGroupBox.Name = "projectTypeGroupBox";
			this.projectTypeGroupBox.Size = new System.Drawing.Size(216, 133);
			this.projectTypeGroupBox.TabIndex = 3;
			this.projectTypeGroupBox.TabStop = false;
			this.projectTypeGroupBox.Text = "Project Type";
			// 
			// fortranProjectPanel
			// 
			this.fortranProjectPanel.BackColor = System.Drawing.Color.White;
			this.fortranProjectPanel.Controls.Add(this.fortranProjectLbl);
			this.fortranProjectPanel.Location = new System.Drawing.Point(16, 60);
			this.fortranProjectPanel.Name = "fortranProjectPanel";
			this.fortranProjectPanel.Size = new System.Drawing.Size(123, 24);
			this.fortranProjectPanel.TabIndex = 2;
			// 
			// fortranProjectLbl
			// 
			this.fortranProjectLbl.BackColor = System.Drawing.Color.Transparent;
			this.fortranProjectLbl.Location = new System.Drawing.Point(2, 4);
			this.fortranProjectLbl.Name = "fortranProjectLbl";
			this.fortranProjectLbl.Size = new System.Drawing.Size(90, 15);
			this.fortranProjectLbl.TabIndex = 0;
			this.fortranProjectLbl.Text = "FORTRAN (WIP)";
			// 
			// assemblyProjectPanel
			// 
			this.assemblyProjectPanel.BackColor = System.Drawing.Color.White;
			this.assemblyProjectPanel.Controls.Add(this.assemblyProjectLbl);
			this.assemblyProjectPanel.Location = new System.Drawing.Point(16, 30);
			this.assemblyProjectPanel.Name = "assemblyProjectPanel";
			this.assemblyProjectPanel.Size = new System.Drawing.Size(123, 24);
			this.assemblyProjectPanel.TabIndex = 1;
			// 
			// assemblyProjectLbl
			// 
			this.assemblyProjectLbl.BackColor = System.Drawing.Color.Transparent;
			this.assemblyProjectLbl.Location = new System.Drawing.Point(3, 4);
			this.assemblyProjectLbl.Name = "assemblyProjectLbl";
			this.assemblyProjectLbl.Size = new System.Drawing.Size(117, 15);
			this.assemblyProjectLbl.TabIndex = 0;
			this.assemblyProjectLbl.Text = "Assembly project";
			// 
			// projectTypesListView
			// 
			this.projectTypesListView.Location = new System.Drawing.Point(7, 19);
			this.projectTypesListView.Name = "projectTypesListView";
			this.projectTypesListView.Size = new System.Drawing.Size(203, 108);
			this.projectTypesListView.TabIndex = 0;
			this.projectTypesListView.UseCompatibleStateImageBehavior = false;
			// 
			// NewProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(241, 200);
			this.Controls.Add(this.projectTypeGroupBox);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.projectNameLabel);
			this.Controls.Add(this.projectNameTextBox);
			this.Name = "NewProject";
			this.Text = "New Project";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewProjectFormClosing);
			this.Load += new System.EventHandler(this.NewProjectLoad);
			this.projectTypeGroupBox.ResumeLayout(false);
			this.fortranProjectPanel.ResumeLayout(false);
			this.assemblyProjectPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label fortranProjectLbl;
		private System.Windows.Forms.Panel fortranProjectPanel;
		private System.Windows.Forms.Label assemblyProjectLbl;
		private System.Windows.Forms.Panel assemblyProjectPanel;
		private System.Windows.Forms.ListView projectTypesListView;
		private System.Windows.Forms.GroupBox projectTypeGroupBox;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.Label projectNameLabel;
		private System.Windows.Forms.TextBox projectNameTextBox;
	}
}
