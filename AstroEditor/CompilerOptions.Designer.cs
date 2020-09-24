/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/16/2020
 * Time: 3:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AsmEditor
{
	partial class CompilerOptions
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
			this.compileTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.fasmRadioBtn = new System.Windows.Forms.RadioButton();
			this.masmRadioBtn = new System.Windows.Forms.RadioButton();
			this.nasmRadioBtn = new System.Windows.Forms.RadioButton();
			this.optionsGroupBox = new System.Windows.Forms.GroupBox();
			this.linkExeChkBox = new System.Windows.Forms.CheckBox();
			this.ldExeChkBox = new System.Windows.Forms.CheckBox();
			this.gccExeChkBox = new System.Windows.Forms.CheckBox();
			this.saveBtn = new System.Windows.Forms.Button();
			this.linkArgs = new System.Windows.Forms.TextBox();
			this.ldArgs = new System.Windows.Forms.TextBox();
			this.gccArgs = new System.Windows.Forms.TextBox();
			this.compileTypeGroupBox.SuspendLayout();
			this.optionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// compileTypeGroupBox
			// 
			this.compileTypeGroupBox.Controls.Add(this.fasmRadioBtn);
			this.compileTypeGroupBox.Controls.Add(this.masmRadioBtn);
			this.compileTypeGroupBox.Controls.Add(this.nasmRadioBtn);
			this.compileTypeGroupBox.Location = new System.Drawing.Point(12, 12);
			this.compileTypeGroupBox.Name = "compileTypeGroupBox";
			this.compileTypeGroupBox.Size = new System.Drawing.Size(500, 119);
			this.compileTypeGroupBox.TabIndex = 0;
			this.compileTypeGroupBox.TabStop = false;
			this.compileTypeGroupBox.Text = "Compile type";
			// 
			// fasmRadioBtn
			// 
			this.fasmRadioBtn.Location = new System.Drawing.Point(7, 80);
			this.fasmRadioBtn.Name = "fasmRadioBtn";
			this.fasmRadioBtn.Size = new System.Drawing.Size(65, 24);
			this.fasmRadioBtn.TabIndex = 2;
			this.fasmRadioBtn.TabStop = true;
			this.fasmRadioBtn.Text = "FASM";
			this.fasmRadioBtn.UseVisualStyleBackColor = true;
			// 
			// masmRadioBtn
			// 
			this.masmRadioBtn.Location = new System.Drawing.Point(7, 50);
			this.masmRadioBtn.Name = "masmRadioBtn";
			this.masmRadioBtn.Size = new System.Drawing.Size(65, 24);
			this.masmRadioBtn.TabIndex = 1;
			this.masmRadioBtn.TabStop = true;
			this.masmRadioBtn.Text = "MASM";
			this.masmRadioBtn.UseVisualStyleBackColor = true;
			// 
			// nasmRadioBtn
			// 
			this.nasmRadioBtn.Location = new System.Drawing.Point(7, 20);
			this.nasmRadioBtn.Name = "nasmRadioBtn";
			this.nasmRadioBtn.Size = new System.Drawing.Size(65, 24);
			this.nasmRadioBtn.TabIndex = 0;
			this.nasmRadioBtn.TabStop = true;
			this.nasmRadioBtn.Text = "NASM";
			this.nasmRadioBtn.UseVisualStyleBackColor = true;
			// 
			// optionsGroupBox
			// 
			this.optionsGroupBox.Controls.Add(this.gccArgs);
			this.optionsGroupBox.Controls.Add(this.ldArgs);
			this.optionsGroupBox.Controls.Add(this.linkArgs);
			this.optionsGroupBox.Controls.Add(this.gccExeChkBox);
			this.optionsGroupBox.Controls.Add(this.ldExeChkBox);
			this.optionsGroupBox.Controls.Add(this.linkExeChkBox);
			this.optionsGroupBox.Location = new System.Drawing.Point(12, 137);
			this.optionsGroupBox.Name = "optionsGroupBox";
			this.optionsGroupBox.Size = new System.Drawing.Size(500, 119);
			this.optionsGroupBox.TabIndex = 3;
			this.optionsGroupBox.TabStop = false;
			this.optionsGroupBox.Text = "Options";
			// 
			// linkExeChkBox
			// 
			this.linkExeChkBox.Location = new System.Drawing.Point(7, 20);
			this.linkExeChkBox.Name = "linkExeChkBox";
			this.linkExeChkBox.Size = new System.Drawing.Size(104, 24);
			this.linkExeChkBox.TabIndex = 0;
			this.linkExeChkBox.Text = "link.exe";
			this.linkExeChkBox.UseVisualStyleBackColor = true;
			// 
			// ldExeChkBox
			// 
			this.ldExeChkBox.Location = new System.Drawing.Point(7, 51);
			this.ldExeChkBox.Name = "ldExeChkBox";
			this.ldExeChkBox.Size = new System.Drawing.Size(104, 24);
			this.ldExeChkBox.TabIndex = 1;
			this.ldExeChkBox.Text = "ld.exe";
			this.ldExeChkBox.UseVisualStyleBackColor = true;
			// 
			// gccExeChkBox
			// 
			this.gccExeChkBox.Location = new System.Drawing.Point(7, 82);
			this.gccExeChkBox.Name = "gccExeChkBox";
			this.gccExeChkBox.Size = new System.Drawing.Size(104, 24);
			this.gccExeChkBox.TabIndex = 2;
			this.gccExeChkBox.Text = "gcc.exe";
			this.gccExeChkBox.UseVisualStyleBackColor = true;
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(437, 262);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 23);
			this.saveBtn.TabIndex = 4;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			// 
			// linkArgs
			// 
			this.linkArgs.Location = new System.Drawing.Point(71, 23);
			this.linkArgs.Name = "linkArgs";
			this.linkArgs.Size = new System.Drawing.Size(410, 20);
			this.linkArgs.TabIndex = 3;
			// 
			// ldArgs
			// 
			this.ldArgs.Location = new System.Drawing.Point(71, 53);
			this.ldArgs.Name = "ldArgs";
			this.ldArgs.Size = new System.Drawing.Size(410, 20);
			this.ldArgs.TabIndex = 4;
			// 
			// gccArgs
			// 
			this.gccArgs.Location = new System.Drawing.Point(71, 84);
			this.gccArgs.Name = "gccArgs";
			this.gccArgs.Size = new System.Drawing.Size(410, 20);
			this.gccArgs.TabIndex = 5;
			// 
			// CompilerOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 297);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.optionsGroupBox);
			this.Controls.Add(this.compileTypeGroupBox);
			this.Name = "CompilerOptions";
			this.Text = "CompilerOptions";
			this.Load += new System.EventHandler(this.CompilerOptionsLoad);
			this.compileTypeGroupBox.ResumeLayout(false);
			this.optionsGroupBox.ResumeLayout(false);
			this.optionsGroupBox.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.CheckBox linkExeChkBox;
		private System.Windows.Forms.CheckBox ldExeChkBox;
		private System.Windows.Forms.CheckBox gccExeChkBox;
		private System.Windows.Forms.TextBox linkArgs;
		private System.Windows.Forms.TextBox ldArgs;
		private System.Windows.Forms.TextBox gccArgs;
		private System.Windows.Forms.GroupBox optionsGroupBox;
		private System.Windows.Forms.RadioButton nasmRadioBtn;
		private System.Windows.Forms.RadioButton masmRadioBtn;
		private System.Windows.Forms.RadioButton fasmRadioBtn;
		private System.Windows.Forms.GroupBox compileTypeGroupBox;
	}
}
