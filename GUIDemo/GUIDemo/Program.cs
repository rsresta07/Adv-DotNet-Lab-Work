using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUIDemo
{
    class Gui : Form
    {
        Button saveBtn, resetBtn, updateBtn, viewDataBtn, deleteBtn;
        Label nameLbl, ageLbl, addressLbl;
        TextBox nameTxt, ageTxt, addressTxt;
        Panel buttonPanel;
        ModelDb data = new ModelDb();

        public Gui()
        {
            // Form Properties
            this.Size = new Size(500, 320);
            this.Location = new Point(500, 300);
            this.Text = "MyForm";

            // Labels
            nameLbl = CreateLabel("Name", 20, 50);
            ageLbl = CreateLabel("Age", 20, 100);
            addressLbl = CreateLabel("Address", 20, 150);

            // Textboxes
            nameTxt = CreateTextBox(230, 50, 200, 25);
            nameTxt.GotFocus += (s, e) => nameTxt.BackColor = Color.Cyan;
            nameTxt.LostFocus += (s, e) => nameTxt.BackColor = Color.White;
            ageTxt = CreateTextBox(230, 100, 200, 25);
            addressTxt = CreateTextBox(230, 150, 200, 25);

            // Button Panel
            buttonPanel = new Panel()
            {
                Size = new Size(450, 100),
                Location = new Point(20, 200),
                BackColor = Color.LightGray
            };
            Controls.Add(buttonPanel);

            // Buttons
            saveBtn = CreateButton("Save", 10, SaveMethod);
            viewDataBtn = CreateButton("View Data", 100, ViewDataMethod);
            updateBtn = CreateButton("Update", 190, UpdateMethod);
            deleteBtn = CreateButton("Delete", 280, DeleteMethod);
            resetBtn = CreateButton("Reset", 370, ResetMethod);
        }

        Label CreateLabel(string text, int x, int y)
        {
            var lbl = new Label()
            {
                Text = text,
                Size = new Size(200, 25),
                Font = new Font("Arial", 16),
                Location = new Point(x, y)
            };
            Controls.Add(lbl);
            return lbl;
        }

        TextBox CreateTextBox(int x, int y, int w, int h)
        {
            var txt = new TextBox() { Size = new Size(w, h), Location = new Point(x, y) };
            Controls.Add(txt);
            return txt;
        }

        Button CreateButton(string text, int x, EventHandler clickEvent)
        {
            var btn = new Button()
            {
                Text = text,
                Location = new Point(x, 30),
                BackColor = Color.Pink,
                ForeColor = Color.Green
            };
            btn.Click += clickEvent;
            buttonPanel.Controls.Add(btn);
            return btn;
        }

        void SaveMethod(object sender, EventArgs e)
        {
            bool status = data.Insert(nameTxt.Text, Convert.ToInt32(ageTxt.Text), addressTxt.Text);
            MessageBox.Show(status ? "Data saved!" : "Failed to save.");
            ResetFields();
        }

        void ViewDataMethod(object sender, EventArgs e) => MessageBox.Show(data.View());

        void UpdateMethod(object sender, EventArgs e)
        {
            if (data.Update(nameTxt.Text.Trim(), Convert.ToInt32(ageTxt.Text)))
                MessageBox.Show($"Updated age for {nameTxt.Text} successfully!");
        }

        void DeleteMethod(object sender, EventArgs e)
        {
            if (data.Delete(nameTxt.Text.Trim()))
                MessageBox.Show($"Deleted record");
        }

        void ResetMethod(object sender, EventArgs e) => ResetFields();

        void ResetFields() => (nameTxt.Text, ageTxt.Text, addressTxt.Text) = ("", "", "");

        static void Main() => Application.Run(new Gui());
    }
}
