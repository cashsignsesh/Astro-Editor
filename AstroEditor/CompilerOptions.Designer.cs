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
			this.nasmCompileInstruction = new System.Windows.Forms.TextBox();
			this.fasmRadioBtn = new System.Windows.Forms.RadioButton();
			this.masmRadioBtn = new System.Windows.Forms.RadioButton();
			this.nasmRadioBtn = new System.Windows.Forms.RadioButton();
			this.optionsGroupBox = new System.Windows.Forms.GroupBox();
			this.optionsInfoLbl1 = new System.Windows.Forms.Label();
			this.optionsInfoLbl0 = new System.Windows.Forms.Label();
			this.optionsInfoLbl = new System.Windows.Forms.Label();
			this.openInstructionsFileBtn = new System.Windows.Forms.Button();
			this.instructionTextBox = new System.Windows.Forms.TextBox();
			this.addInstructionBtn = new System.Windows.Forms.Button();
			this.saveBtn = new System.Windows.Forms.Button();
			this.compileAsLabel = new System.Windows.Forms.Label();
			this.compileAsTextBox = new System.Windows.Forms.TextBox();
			this.compileTypeGroupBox.SuspendLayout();
			this.optionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// compileTypeGroupBox
			// 
			this.compileTypeGroupBox.Controls.Add(this.nasmCompileInstruction);
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
			// nasmCompileInstruction
			// 
			this.nasmCompileInstruction.Location = new System.Drawing.Point(66, 22);
			this.nasmCompileInstruction.Name = "nasmCompileInstruction";
			this.nasmCompileInstruction.Size = new System.Drawing.Size(77, 20);
			this.nasmCompileInstruction.TabIndex = 3;
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
			this.fasmRadioBtn.CheckedChanged += new System.EventHandler(this.handleRbtn);
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
			this.masmRadioBtn.CheckedChanged += new System.EventHandler(this.handleRbtn);
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
			this.nasmRadioBtn.CheckedChanged += new System.EventHandler(this.handleRbtn);
			// 
			// optionsGroupBox
			// 
			this.optionsGroupBox.Controls.Add(this.optionsInfoLbl1);
			this.optionsGroupBox.Controls.Add(this.optionsInfoLbl0);
			this.optionsGroupBox.Controls.Add(this.optionsInfoLbl);
			this.optionsGroupBox.Controls.Add(this.openInstructionsFileBtn);
			this.optionsGroupBox.Controls.Add(this.instructionTextBox);
			this.optionsGroupBox.Controls.Add(this.addInstructionBtn);
			this.optionsGroupBox.Location = new System.Drawing.Point(12, 137);
			this.optionsGroupBox.Name = "optionsGroupBox";
			this.optionsGroupBox.Size = new System.Drawing.Size(500, 104);
			this.optionsGroupBox.TabIndex = 3;
			this.optionsGroupBox.TabStop = false;
			this.optionsGroupBox.Text = "Options";
			// 
			// optionsInfoLbl1
			// 
			this.optionsInfoLbl1.Location = new System.Drawing.Point(7, 52);
			this.optionsInfoLbl1.Name = "optionsInfoLbl1";
			this.optionsInfoLbl1.Size = new System.Drawing.Size(487, 16);
			this.optionsInfoLbl1.TabIndex = 5;
			this.optionsInfoLbl1.Text = "Example: copy /b %CMPFILE%+C:\\Documents\\toAppend.bin \"%BINDIR%\\result.flp\"";
			// 
			// optionsInfoLbl0
			// 
			this.optionsInfoLbl0.Location = new System.Drawing.Point(7, 36);
			this.optionsInfoLbl0.Name = "optionsInfoLbl0";
			this.optionsInfoLbl0.Size = new System.Drawing.Size(487, 16);
			this.optionsInfoLbl0.TabIndex = 4;
			this.optionsInfoLbl0.Text = "%EXEPATH%=Path to Astro Editor.exe,%BINDIR%=bin dir,%CMPFILE%=Path to compiled fi" +
			"le";
			// 
			// optionsInfoLbl
			// 
			this.optionsInfoLbl.Location = new System.Drawing.Point(7, 20);
			this.optionsInfoLbl.Name = "optionsInfoLbl";
			this.optionsInfoLbl.Size = new System.Drawing.Size(487, 16);
			this.optionsInfoLbl.TabIndex = 3;
			this.optionsInfoLbl.Text = "You can add additional batch instructions to your compiler. They will execute aft" +
			"er compilation.";
			// 
			// openInstructionsFileBtn
			// 
			this.openInstructionsFileBtn.Location = new System.Drawing.Point(347, 67);
			this.openInstructionsFileBtn.Name = "openInstructionsFileBtn";
			this.openInstructionsFileBtn.Size = new System.Drawing.Size(147, 23);
			this.openInstructionsFileBtn.TabIndex = 2;
			this.openInstructionsFileBtn.Text = "Open instructions file";
			this.openInstructionsFileBtn.UseVisualStyleBackColor = true;
			this.openInstructionsFileBtn.Click += new System.EventHandler(this.OpenInstructionsFileBtnClick);
			// 
			// instructionTextBox
			// 
			this.instructionTextBox.Location = new System.Drawing.Point(6, 69);
			this.instructionTextBox.Name = "instructionTextBox";
			this.instructionTextBox.Size = new System.Drawing.Size(235, 20);
			this.instructionTextBox.TabIndex = 1;
			// 
			// addInstructionBtn
			// 
			this.addInstructionBtn.Location = new System.Drawing.Point(247, 67);
			this.addInstructionBtn.Name = "addInstructionBtn";
			this.addInstructionBtn.Size = new System.Drawing.Size(94, 23);
			this.addInstructionBtn.TabIndex = 0;
			this.addInstructionBtn.Text = "Add instruction";
			this.addInstructionBtn.UseVisualStyleBackColor = true;
			this.addInstructionBtn.Click += new System.EventHandler(this.AddInstructionBtnClick);
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(437, 248);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 23);
			this.saveBtn.TabIndex = 4;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.SaveBtnClick);
			// 
			// compileAsLabel
			// 
			this.compileAsLabel.Location = new System.Drawing.Point(12, 249);
			this.compileAsLabel.Name = "compileAsLabel";
			this.compileAsLabel.Size = new System.Drawing.Size(66, 17);
			this.compileAsLabel.TabIndex = 6;
			this.compileAsLabel.Text = "Compile as";
			// 
			// compileAsTextBox
			// 
			this.compileAsTextBox.Location = new System.Drawing.Point(70, 246);
			this.compileAsTextBox.Name = "compileAsTextBox";
			this.compileAsTextBox.Size = new System.Drawing.Size(25, 20);
			this.compileAsTextBox.TabIndex = 7;
			// 
			// CompilerOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 276);
			this.Controls.Add(this.compileAsTextBox);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.compileAsLabel);
			this.Controls.Add(this.optionsGroupBox);
			this.Controls.Add(this.compileTypeGroupBox);
			this.Name = "CompilerOptions";
			this.Text = "Compiler Options";
			this.Load += new System.EventHandler(this.CompilerOptionsLoad);
			this.compileTypeGroupBox.ResumeLayout(false);
			this.compileTypeGroupBox.PerformLayout();
			this.optionsGroupBox.ResumeLayout(false);
			this.optionsGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox compileAsTextBox;
		private System.Windows.Forms.Label compileAsLabel;
		private System.Windows.Forms.Label optionsInfoLbl0;
		private System.Windows.Forms.Label optionsInfoLbl1;
		private System.Windows.Forms.TextBox nasmCompileInstruction;
		private System.Windows.Forms.Button addInstructionBtn;
		private System.Windows.Forms.TextBox instructionTextBox;
		private System.Windows.Forms.Button openInstructionsFileBtn;
		private System.Windows.Forms.Label optionsInfoLbl;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.GroupBox optionsGroupBox;
		private System.Windows.Forms.RadioButton nasmRadioBtn;
		private System.Windows.Forms.RadioButton masmRadioBtn;
		private System.Windows.Forms.RadioButton fasmRadioBtn;
		private System.Windows.Forms.GroupBox compileTypeGroupBox;
	}
}
