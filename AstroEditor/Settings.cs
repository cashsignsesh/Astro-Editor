/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 8:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsmEditor {
	
	public class Settings {
		
		private readonly String _settings;
		private readonly Dictionary<String,String> vars;
		private const Char spChar='\u1013';
		
		public Settings (String fn) {
			
			this._settings = fn;
			this.vars = new Dictionary<String,String>();
			try { this.reloadVars(); }
			catch (IOException) { this.create(); }
			
		}
		
		private void create () {
			
			Byte[] data = Encoding.UTF8.GetBytes("settingsInitialized"+spChar+"true");
			using (FileStream fs = File.Create(this._settings))
				fs.Write(data,0,data.Length);
			this.reloadVars();
			
		}
		
		public String getSetting (String setting, String defaultSetting = "") {
			
			if (vars.ContainsKey(setting))
				return vars[setting];
			
			this.setSetting(setting,defaultSetting);
			return defaultSetting;
			
		}
		
		public void setSetting (String setting, String newSetting) {
			
			List<String> lines = new List<String>();
			String str = setting+Settings.spChar+newSetting;
			foreach (String s in File.ReadAllLines(this._settings)) {
				
				if (s.StartsWith(setting)) {
					
					lines.Add(str);
					continue;
					
				}
				
				lines.Add(s);
				
			}
			if(!(lines.Contains(str)))lines.Add(str);
			File.WriteAllLines(this._settings,lines);
			this.reloadVars();
			
		}
		
		private void reloadVars () {
			
			foreach (String[] s in File.ReadAllLines(this._settings).Select(x=>x.Split(Settings.spChar)))
				if (this.vars.ContainsKey(s[0]))this.vars[s[0]]=(String.IsNullOrEmpty(s[1]))?"":s[1];
				else this.vars.Add(s[0],((String.IsNullOrEmpty(s[1]))?"":s[1]));
			
		}
		
	}
	
}