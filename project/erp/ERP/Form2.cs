using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Login controller";
            this.label1.Text = "Login controller";
            this.label2.Text = "User name";
            this.label3.Text = "Password";
            this.label1.BackColor = Color.LightGray;
            this.label2.BackColor = Color.LightGray;
            this.label3.BackColor = Color.LightGray;
            this.textBox1.BackColor = Color.LightGray;
            this.textBox2.BackColor = Color.LightGray;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }


       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "1234")

            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }

           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
