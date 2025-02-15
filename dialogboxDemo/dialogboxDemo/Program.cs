using System;
using System.Drawing;
using System.Windows.Forms;

namespace DialogBoxDemo
{
    class Program : Form
    {
        private Button btnFont = new Button();
        private Button btnColor = new Button();
        private TextBox txt = new TextBox();
        private ColorDialog colorDialog = new ColorDialog();
        private FontDialog fontDialog = new FontDialog();

        public Program()
        {
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dialog Form";

            txt.Size = new Size(200, 75);
            txt.Location = new Point(20, 20);

            btnFont.Location = new Point(20, 100);
            btnFont.Size = new Size(80, 30);
            btnFont.Text = "Font";
            btnFont.Click += BtnFont_Click;

            btnColor.Location = new Point(120, 100);
            btnColor.Size = new Size(80, 30);
            btnColor.Text = "Color";
            btnColor.Click += BtnColor_Click;

            this.Controls.Add(txt);
            this.Controls.Add(btnFont);
            this.Controls.Add(btnColor);
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txt.Font = fontDialog.Font;
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog.Color;
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
