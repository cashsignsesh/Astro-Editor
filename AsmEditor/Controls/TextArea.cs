/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 9/12/2020
 * Time: 5:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using AsmEditor.Controls.Utils;

namespace AsmEditor.Controls {
	
	public class TextArea : Control, IDisposable {
		
		public String text;
		
		public readonly Int32 X,Y,Width,Height;
		
		private Syntax syntax;
		private Graphics g;
		
		/// <param name="s">Width&Height</param>
		/// <param name="loc">X&Y</param>
		public TextArea (Syntax syntax,Size s,Point loc,String text="") : base () {
			
			this.syntax=syntax;
			this.text=text;
			this.X=loc.X;
			this.Y=loc.Y;
			this.Width=s.Width;
			this.Height=s.Height;
			this.OnPaint+=this.paint;
			
		}
		
		private void drawBox () {
			
			//Border
			
			using (Pen p=new Pen(Color.LightGray,2.3F)) {
				
				this.g.DrawLine(p,this.X,this.Y,this.X+this.Width,this.Y);
				this.g.DrawLine(p,this.X,this.Y,this.X,this.Y+this.Height);
				this.g.DrawLine(p,this.X,this.Y-this.Height,this.X+this.Width,this.Y-Height);
				this.g.DrawLine(p,this.X-this.Width,this.Y,this.X-this.Width,this.Y+Height);
				
			}
			
			
		}
		
		private void drawLineCounter () {
			
			
			
		}
		
		private void drawText () {
			
			Boolean inQuotes = false;
			Int32 pos = 0;
			
			foreach (Char c in this.text) {
				
				//if c=='\n',call line counter to add num?
				
				if (this.syntax==Syntax.GENERIC) {
					
					this.drawChar(c,Color.Black);
					continue;
					
				}
				
				if (this.syntax==Syntax.BATCH) {
					
					
					
				}
					
				//...
				
				++pos;
				
			}
			
			
			
		}
		
		private void drawChar (Char c,Color cl) {
			
			
			
		}
		
		protected virtual void Dispose () {
			
			this.g.Dispose();
			this.Dispose(true);
			GC.SuppressFinalize(this);
			
		}
		
		private void paint (EventArgs e) {
			
			if (this.g==null)
				this.g=this.Parent.CreateGraphics();
			
			this.drawLineCounter();
			this.drawBox();
			this.drawText();
			
		}
		
	}
}