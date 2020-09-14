/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 10:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsmEditor.Projects {
	
	public class Header {
		
		public readonly String pName,pEntryFile,pBinDir,pSrcDir;
		
		protected internal Header (IEnumerable<String> lines, out List<String> newLines) {
			
			this.pName=lines.First();
			this.pEntryFile=lines.ElementAt(1);
			this.pBinDir=lines.ElementAt(2);
			this.pSrcDir=lines.ElementAt(3);
			
			newLines = lines.Skip(3).ToList();
			
		}
		
		protected internal Header (IEnumerable<String> lines) {
			
			this.pName=lines.First();
			this.pEntryFile=lines.ElementAt(1);
			this.pBinDir=lines.ElementAt(2);
			this.pSrcDir=lines.ElementAt(3);
			
		}
		
	}
	
}