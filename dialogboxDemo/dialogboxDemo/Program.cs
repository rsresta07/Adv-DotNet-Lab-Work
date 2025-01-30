using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dialogboxDemo
{
    class Program :Form
    {
        Button btn1 = new Button();

        Button btn2 = new Button();

        TextBox txt = new TextBox();

        ColorDialog cd = new ColorDialog();
        FontDialog fd = new FontDialog();


        public Program()
        {
            this.Size = new Size(400,300);
            this.Location = new Point(300,200);
            this.Text = "Dialog Example Form";

            txt.Size = new Size(200, 75);
            txt.Location = new Point(20,20);

            btn1.Location = new Point(20,100);
            btn1.Text = "Font";
            btn1.Click += new EventHandler(btn1_click);

            btn2.Location = new Point(120, 100);
            btn2.Click += new EventHandler(btn2_click);
            btn2.Text = "Color";

            this.Controls.Add(txt);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
        }

        private void btn1_click(Object sender , EventArgs e)
        {
            fd.ShowDialog();
            txt.Font = fd.Font;

        }

        private void btn2_click(Object sender, EventArgs e)
        {
            cd.ShowDialog();
            this.BackColor = cd.Color;

        }


        static void Main(string[] args)
        {
            Application.Run(new Program());
        }
    }
}
