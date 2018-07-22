using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coffee_Magn_Sys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "LOGIN";
            this.label1.Text = "LOGIN";
            this.label2.Text = "User ID";
            this.label3.Text = "Password";
            this.button1.Text = "LOGIN";
            this.button2.Text = "EXIT";
            this.textBox2.PasswordChar = '*';
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = this.button1;
            this.CancelButton = this.button2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "ishrat" && this.textBox2.Text == "123")
            {
                MessageBox.Show("Successfully Login");
                Form2 f2 = new Form2();
                f2.Show();

            }
            else
            {
                MessageBox.Show("Failed");
                this.Close();
            }
        }
    }
}
