/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/26/2020
 * Time: 10:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using AsmEditor.Utils;

namespace AsmEditor.Projects {
	
	public class OptData {
		
		public readonly CompileType compileType;
		public readonly String nasmArgs,fileExt;
		public readonly IEnumerable<String> bonusInstructions;
		
		private OptData (String[] settings,IEnumerable<String> lines) {
			
			this.compileType=((CompileType)(Int32.Parse(settings.First())));
			this.nasmArgs=settings[1];
			this.fileExt=settings[2];
			this.bonusInstructions=lines;
			
		}
		
		public static OptData getOptData (IEnumerable<String> lines) { return new OptData(lines.First().Split(',').Take(3).ToArray(),lines.Skip(1)); }
		
	}
	
}