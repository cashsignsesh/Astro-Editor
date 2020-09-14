/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/10/2020
 * Time: 6:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AsmEditor.Utils {
	
	public static class Util {
		
		/// <summary>
		/// Most recent to least recent DateTimes
		/// </summary>
		public static List<DateTime> sort (this IEnumerable<DateTime> times) {
			
			List<DateTime> sorted = new List<DateTime>();
			List<DateTime> _times = times.ToList();
			
			restart:
			
			if (_times.Count==0) return sorted;
			
			DateTime latest = DateTime.MinValue;
			
			foreach (DateTime t in _times)
				if (DateTime.Compare(t,latest)==1)
					latest=t;
			
			//It's super cool that you don't have to write manyOf<DateTime>(latest,i) and can write manyOf(latest,i)
			
			sorted.AddRange(Util.manyOf(latest,_times.instancesOf(latest)));
			_times.RemoveAll(x=>x==latest);
			
			goto restart; 
			
		}
		
		public static Int32 instancesOf<T> (this IEnumerable<T> t,T item) {
			
			Int32 i = 0;
			
			foreach (T o in t)
				if (o.Equals(item)) 
					++i;
			
			return i;
			
		}
		
		public static T[] manyOf<T> (T item,Int32 amount) {
			
			Int32 i = 0;
			T[] arr = new T[amount];
			while (i!=amount) {
				arr[i]=item;
				++i;
			}
			
			return arr;
			
		}
		
		public static String merge (this IEnumerable<String> strings,String append="") {
			
			StringBuilder sb = new StringBuilder();
			
			foreach (String s in strings)
				sb.Append(s+append);
			
			return sb.ToString();
			
		}
		
		public static IEnumerable<Control> allChildren (this Control c) {
			
			foreach (Control c0 in c.Controls) {
				
				yield return c0;
				IEnumerable<Control> cArr = c0.allChildren();
				if (cArr.Count()>0)
					foreach (Control c1 in cArr)
						yield return c1;
				
			}
			
		}
		
	}
	
}