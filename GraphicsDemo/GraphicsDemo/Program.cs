using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsDemo
{
    class Program : Form
    {
        public Program()
        {
            this.Text = "Graphics Demo";
            this.Size = new Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Paint += new PaintEventHandler(PaintMethod);
        }

        private void PaintMethod(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] points =
            {
                new Point(20, 20),
                new Point(75, 60),
                new Point(40, 60),
                new Point(120, 150),
                new Point(20, 150)
            };

            using (SolidBrush brush = new SolidBrush(Color.Tomato))
            {
                g.FillPolygon(brush, points);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Program());
        }
    }
}
