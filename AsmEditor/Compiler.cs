/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/13/2020
 * Time: 3:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using AsmEditor.Projects;

namespace AsmEditor {
	
	public class Compiler {
		
		public readonly String projectDir,compileDir;
		
		private Project project;
		private Header header;
		
		public Compiler (Project project,String projectDir) {
			
			this.projectDir=projectDir;
			this.project=project;
			this.header=this.project.getHeader();
			this.compileDir = this.projectDir+@"\"+header.pBinDir;
			
		}
		
		public void compile () {
			
			
			
		}
		
	}
	
}