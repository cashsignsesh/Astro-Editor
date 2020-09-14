/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/14/2020
 * Time: 8:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AsmEditor
{
	partial class CreateFileEditorDialog
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
			this.createBtn = new System.Windows.Forms.Button();
			this.fileNameTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// createBtn
			// 
			this.createBtn.Location = new System.Drawing.Point(172, 12);
			this.createBtn.Name = "createBtn";
			this.createBtn.Size = new System.Drawing.Size(98, 20);
			this.createBtn.TabIndex = 0;
			this.createBtn.Text = "Create";
			this.createBtn.UseVisualStyleBackColor = true;
			this.createBtn.Click += new System.EventHandler(this.CreateBtnClick);
			// 
			// fileNameTextBox
			// 
			this.fileNameTextBox.Location = new System.Drawing.Point(12, 12);
			this.fileNameTextBox.Name = "fileNameTextBox";
			this.fileNameTextBox.Size = new System.Drawing.Size(154, 20);
			this.fileNameTextBox.TabIndex = 1;
			this.fileNameTextBox.Text = "MyFile";
			// 
			// CreateFileEditorDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 42);
			this.Controls.Add(this.fileNameTextBox);
			this.Controls.Add(this.createBtn);
			this.Name = "CreateFileEditorDialog";
			this.Text = "Create file";
			this.Load += new System.EventHandler(this.CreateFileEditorDialogLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox fileNameTextBox;
		private System.Windows.Forms.Button createBtn;
	}
}
