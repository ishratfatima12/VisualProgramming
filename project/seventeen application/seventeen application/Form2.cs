using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seventeen_application
{
    public partial class Form2 : Form
    {
        Form1 f1;

        public Form2(Form1 ff1)
        {
            f1 = ff1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumVioletRed;
            this.button1.BackColor = Color.Salmon;
         
            this.Text = "find";
            this.label1.Text = "Find";
            this.button1.Text = "Find";
        
            this.MinimizeBox = false;
            this.MaximizeBox = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (f1.textBox1.Text.Contains(this.textBox1.Text))

            {
                MessageBox.Show("String Found");
                this.Close();
            }
            else
            {
                MessageBox.Show("String NotFound");
                this.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

