using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUIDemo
{
    class Gui : Form
    {
        Button savebtn,resetbtn,updatebtn,viewdatabtn,deletebtn;
        Label namelbl, agelbl , addresslbl;
        TextBox nametxt, agetxt,addresstxt;
        Panel p1;
        ModelDb data = new ModelDb();

        public Gui()
        {
            this.Size = new Size(500,320);
            this.Location = new Point(500, 300);
            this.Text = "Myform";


            namelbl = new Label();
            namelbl.Text = "Name";
            namelbl.Size = new Size(200,25);
            namelbl.Font = new Font(" ",16);
            namelbl.Location = new Point(20,50);
            Controls.Add(namelbl);


            agelbl = new Label();
            agelbl.Text = "Age";
            agelbl.Size = new Size(200, 25);
            agelbl.Font = new Font(" ", 16);
            agelbl.Location = new Point(20, 100);
            Controls.Add(agelbl);

            addresslbl = new Label();
            addresslbl.Text = "Address";
            addresslbl.Size = new Size(200, 25);
            addresslbl.Font = new Font(" ", 16);
            addresslbl.Location = new Point(20, 150);
            Controls.Add(addresslbl);




            nametxt = new TextBox();
            nametxt.Size = new Size(200,100);
            nametxt.Name = "name";
            nametxt.Location = new Point(230,50);
            nametxt.GotFocus += new EventHandler(getfocus_txt);
            nametxt.LostFocus += new EventHandler(lossfocus_txt);
            Controls.Add(nametxt);

            agetxt = new TextBox();
            agetxt.Size = new Size(200, 25);
            agetxt.Location = new Point(230, 100);
            Controls.Add(agetxt);


            addresstxt = new TextBox();
            addresstxt.Size = new Size(200, 25);
            addresstxt.Location = new Point(230, 150);
            Controls.Add(addresstxt);


            p1 = new Panel();
            p1.BackColor = Color.LightGray;
            p1.Size = new Size(450,100);
            p1.Location = new Point(20,200);
            Controls.Add(p1);


            savebtn = new Button();
            savebtn.Text = "Save";
            savebtn.Location = new Point(10,30);
            savebtn.BackColor = Color.Pink;
            savebtn.ForeColor = Color.Green;
            p1.Controls.Add(savebtn);

            viewdatabtn = new Button();
            viewdatabtn.Text = "View Data";
            viewdatabtn.Location = new Point(100, 30);
            viewdatabtn.BackColor = Color.Pink;
            viewdatabtn.ForeColor = Color.Green;
            p1.Controls.Add(viewdatabtn);

            updatebtn = new Button();
            updatebtn.Text = "Update";
            updatebtn.Location = new Point(190, 30);
            updatebtn.BackColor = Color.Pink;
            updatebtn.ForeColor = Color.Green;
            p1.Controls.Add(updatebtn);

            deletebtn = new Button();
            deletebtn.Text = "Delete";
            deletebtn.Location = new Point(280, 30);
            deletebtn.BackColor = Color.Pink;
            deletebtn.ForeColor = Color.Green;
            p1.Controls.Add(deletebtn);

            resetbtn = new Button();
            resetbtn.Text = "Reset";
            resetbtn.Location = new Point(370, 30);
            resetbtn.BackColor = Color.Pink;
            resetbtn.ForeColor = Color.Green;
            p1.Controls.Add(resetbtn);


            savebtn.Click += new EventHandler(SaveMethod);
            viewdatabtn.Click += new EventHandler(ViewDataMethod);
            updatebtn.Click += new EventHandler(UpdateMethod);
            deletebtn.Click += new EventHandler(DeleteMethod);
            resetbtn.Click += new EventHandler(ResetMethod);


        }
       
        private void SaveMethod(Object sender , EventArgs e)
        {
            ModelDb data = new ModelDb();
            string name = nametxt.Text;
            int  age = Convert.ToInt32(agetxt.Text);
            string address = addresstxt.Text;
           bool status= data.Insert(name,age,address);
            if(status)
            {
                MessageBox.Show("Congratulation !!! Data saved successfully");
            }
            nametxt.Text = "";
            agetxt.Text = "";
            addresstxt.Text = "";

        }

        private void ViewDataMethod(Object sender, EventArgs e)
        {
           
            MessageBox.Show(data.View());

        }


        private void UpdateMethod(Object sender, EventArgs e)
        {
            string name = nametxt.Text.ToString().Trim();
            int age = Convert.ToInt32(agetxt.Text);
            if (data.Update(name,age))
            {
                MessageBox.Show("THE AGE UNDER THE NAMED AS : " + name + " IS CHANGED TO  "+age+ " SUCCESSFULLY !!!!");
            }

        }

        private void DeleteMethod(Object sender, EventArgs e)
        {
            string name = nametxt.Text.ToString().Trim();
            if (data.Delete(name))
            {
                MessageBox.Show("THE RECORD UNDER NAMED AS : "+ name + " IS DELETED SUCCESSFULLY !!!!");
            }

            
        }

        private void ResetMethod(Object sender, EventArgs e)
        {
            nametxt.Text = "";
            agetxt.Text = "";
            addresstxt.Text = "";

        }

        private void getfocus_txt(Object sender, EventArgs e) 
        {
            nametxt.BackColor = Color.Cyan;
        }
        private void lossfocus_txt(Object sender, EventArgs e)
        {
            nametxt.BackColor = Color.White;
        }

        static void Main()
        {
            Application.Run(new Gui());                        
        }
    }
}
