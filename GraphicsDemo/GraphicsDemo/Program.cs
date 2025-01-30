using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsDemo
{
    class Program:Form
    {
        public Program()
        {
            this.Paint += new PaintEventHandler(paint_method);
        }


        private void paint_method(Object sender , PaintEventArgs e)
        {
            Graphics g = e.Graphics;
          //  g.DrawRectangle(new Pen(Color.Pink,3),15,15,200,150);
           // g.FillRectangle(new SolidBrush(Color.Cyan), 30, 30, 200, 100);
            g.FillPolygon(new SolidBrush(Color.Tomato),new Point[] {new Point(20,20), new Point(75, 60), new Point(40,60), new Point(120,150), new Point(20, 150) });
            //g.DrawPie(new Pen(Color.Red,3),12,15,17,89,120,12);

        }
        static void Main(string[] args)
        {
            Application.Run(new Program());

        }
    }
}
