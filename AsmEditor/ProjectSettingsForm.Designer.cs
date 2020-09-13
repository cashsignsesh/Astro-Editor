/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/13/2020
 * Time: 1:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AsmEditor
{
	partial class ProjectSettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSettingsForm));
			this.entryFileLabel = new System.Windows.Forms.Label();
			this.entryFileTextBox = new System.Windows.Forms.TextBox();
			this.generalSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.srcDirLabel = new System.Windows.Forms.Label();
			this.srcDirTextBox = new System.Windows.Forms.TextBox();
			this.binDirLabel = new System.Windows.Forms.Label();
			this.binDirTextBox = new System.Windows.Forms.TextBox();
			this.fontSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.sizeLabel = new System.Windows.Forms.Label();
			this.fontSizeTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.fontNameTextBox = new System.Windows.Forms.TextBox();
			this.savePictureBox = new System.Windows.Forms.PictureBox();
			this.discardPictureBox = new System.Windows.Forms.PictureBox();
			this.generalSettingsGroupBox.SuspendLayout();
			this.fontSettingsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.savePictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.discardPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// entryFileLabel
			// 
			this.entryFileLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.entryFileLabel.Location = new System.Drawing.Point(6, 20);
			this.entryFileLabel.Name = "entryFileLabel";
			this.entryFileLabel.Size = new System.Drawing.Size(75, 21);
			this.entryFileLabel.TabIndex = 0;
			this.entryFileLabel.Text = "Entry file";
			// 
			// entryFileTextBox
			// 
			this.entryFileTextBox.Location = new System.Drawing.Point(87, 21);
			this.entryFileTextBox.Name = "entryFileTextBox";
			this.entryFileTextBox.Size = new System.Drawing.Size(227, 20);
			this.entryFileTextBox.TabIndex = 1;
			// 
			// generalSettingsGroupBox
			// 
			this.generalSettingsGroupBox.Controls.Add(this.srcDirLabel);
			this.generalSettingsGroupBox.Controls.Add(this.srcDirTextBox);
			this.generalSettingsGroupBox.Controls.Add(this.binDirLabel);
			this.generalSettingsGroupBox.Controls.Add(this.binDirTextBox);
			this.generalSettingsGroupBox.Controls.Add(this.entryFileLabel);
			this.generalSettingsGroupBox.Controls.Add(this.entryFileTextBox);
			this.generalSettingsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.generalSettingsGroupBox.Name = "generalSettingsGroupBox";
			this.generalSettingsGroupBox.Size = new System.Drawing.Size(320, 98);
			this.generalSettingsGroupBox.TabIndex = 2;
			this.generalSettingsGroupBox.TabStop = false;
			this.generalSettingsGroupBox.Text = "General settings";
			// 
			// srcDirLabel
			// 
			this.srcDirLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.srcDirLabel.Location = new System.Drawing.Point(6, 68);
			this.srcDirLabel.Name = "srcDirLabel";
			this.srcDirLabel.Size = new System.Drawing.Size(75, 21);
			this.srcDirLabel.TabIndex = 4;
			this.srcDirLabel.Text = "Src dir";
			// 
			// srcDirTextBox
			// 
			this.srcDirTextBox.Location = new System.Drawing.Point(87, 68);
			this.srcDirTextBox.Name = "srcDirTextBox";
			this.srcDirTextBox.Size = new System.Drawing.Size(227, 20);
			this.srcDirTextBox.TabIndex = 5;
			// 
			// binDirLabel
			// 
			this.binDirLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.binDirLabel.Location = new System.Drawing.Point(6, 43);
			this.binDirLabel.Name = "binDirLabel";
			this.binDirLabel.Size = new System.Drawing.Size(75, 21);
			this.binDirLabel.TabIndex = 2;
			this.binDirLabel.Text = "Bin dir";
			// 
			// binDirTextBox
			// 
			this.binDirTextBox.Location = new System.Drawing.Point(87, 44);
			this.binDirTextBox.Name = "binDirTextBox";
			this.binDirTextBox.Size = new System.Drawing.Size(227, 20);
			this.binDirTextBox.TabIndex = 3;
			// 
			// fontSettingsGroupBox
			// 
			this.fontSettingsGroupBox.Controls.Add(this.sizeLabel);
			this.fontSettingsGroupBox.Controls.Add(this.fontSizeTextBox);
			this.fontSettingsGroupBox.Controls.Add(this.nameLabel);
			this.fontSettingsGroupBox.Controls.Add(this.fontNameTextBox);
			this.fontSettingsGroupBox.Location = new System.Drawing.Point(12, 128);
			this.fontSettingsGroupBox.Name = "fontSettingsGroupBox";
			this.fontSettingsGroupBox.Size = new System.Drawing.Size(320, 98);
			this.fontSettingsGroupBox.TabIndex = 6;
			this.fontSettingsGroupBox.TabStop = false;
			this.fontSettingsGroupBox.Text = "Font settings";
			// 
			// sizeLabel
			// 
			this.sizeLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sizeLabel.Location = new System.Drawing.Point(6, 44);
			this.sizeLabel.Name = "sizeLabel";
			this.sizeLabel.Size = new System.Drawing.Size(75, 21);
			this.sizeLabel.TabIndex = 2;
			this.sizeLabel.Text = "Size";
			// 
			// fontSizeTextBox
			// 
			this.fontSizeTextBox.Location = new System.Drawing.Point(87, 45);
			this.fontSizeTextBox.Name = "fontSizeTextBox";
			this.fontSizeTextBox.Size = new System.Drawing.Size(227, 20);
			this.fontSizeTextBox.TabIndex = 3;
			// 
			// nameLabel
			// 
			this.nameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nameLabel.Location = new System.Drawing.Point(6, 20);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(75, 21);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name";
			// 
			// fontNameTextBox
			// 
			this.fontNameTextBox.Location = new System.Drawing.Point(87, 21);
			this.fontNameTextBox.Name = "fontNameTextBox";
			this.fontNameTextBox.Size = new System.Drawing.Size(227, 20);
			this.fontNameTextBox.TabIndex = 1;
			// 
			// savePictureBox
			// 
			this.savePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("savePictureBox.Image")));
			this.savePictureBox.Location = new System.Drawing.Point(12, 237);
			this.savePictureBox.Name = "savePictureBox";
			this.savePictureBox.Size = new System.Drawing.Size(32, 32);
			this.savePictureBox.TabIndex = 7;
			this.savePictureBox.TabStop = false;
			this.savePictureBox.Click += new System.EventHandler(this.SavePictureBoxClick);
			// 
			// discardPictureBox
			// 
			this.discardPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("discardPictureBox.Image")));
			this.discardPictureBox.Location = new System.Drawing.Point(300, 239);
			this.discardPictureBox.Name = "discardPictureBox";
			this.discardPictureBox.Size = new System.Drawing.Size(32, 32);
			this.discardPictureBox.TabIndex = 8;
			this.discardPictureBox.TabStop = false;
			this.discardPictureBox.Click += new System.EventHandler(this.DiscardPictureBoxClick);
			// 
			// ProjectSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 281);
			this.Controls.Add(this.discardPictureBox);
			this.Controls.Add(this.savePictureBox);
			this.Controls.Add(this.fontSettingsGroupBox);
			this.Controls.Add(this.generalSettingsGroupBox);
			this.Name = "ProjectSettingsForm";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.ProjectSettingsFormLoad);
			this.generalSettingsGroupBox.ResumeLayout(false);
			this.generalSettingsGroupBox.PerformLayout();
			this.fontSettingsGroupBox.ResumeLayout(false);
			this.fontSettingsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.savePictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.discardPictureBox)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox discardPictureBox;
		private System.Windows.Forms.PictureBox savePictureBox;
		private System.Windows.Forms.TextBox fontNameTextBox;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox fontSizeTextBox;
		private System.Windows.Forms.Label sizeLabel;
		private System.Windows.Forms.GroupBox fontSettingsGroupBox;
		private System.Windows.Forms.TextBox binDirTextBox;
		private System.Windows.Forms.Label binDirLabel;
		private System.Windows.Forms.TextBox srcDirTextBox;
		private System.Windows.Forms.Label srcDirLabel;
		private System.Windows.Forms.GroupBox generalSettingsGroupBox;
		private System.Windows.Forms.TextBox entryFileTextBox;
		private System.Windows.Forms.Label entryFileLabel;
	}
}
