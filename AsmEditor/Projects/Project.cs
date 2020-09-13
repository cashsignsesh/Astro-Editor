/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 10:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace AsmEditor.Projects {
	
	public class Project {
		
		private List<String> lines;
		
		private String projectFile;
		private Header _header;
		
		public Project (String projectFile) {
			
			this.lines = new List<String>(File.ReadAllLines(projectFile));
			this._header = new Header(lines,out lines);
			this.projectFile = projectFile;
			
		}
		
		public Project (Header h) {
			
			this._header = h;
			
		}
		
		public String getProjectLocation () { return this.projectFile; }
		public Header getHeader () { return this._header; }
		
		public override String ToString () {
			
			return this._header.pName+'\n'+this._header.pEntryFile+'\n'+this._header.pBinDir+'\n'+this._header.pSrcDir;
			
		}

		
	}
	
}