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
    public partial class Form3 : Form
    {
        Form1 f1;
        public Form3(Form1 ff1 )
        {
            f1 = ff1;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumVioletRed;
            this.button1.BackColor = Color.Salmon;
            this.button2.BackColor = Color.Salmon;
         
            this.Text = "Replace";
            this.label1.Text = "Find";
            this.label2.Text = "Replace With";
            this.button1.Text = "Find Next";
            this.button2.Text = "Replace";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.textBox1.Text = f1.textBox1.Text.Replace(this.textBox1.Text, this.textBox2.Text);
            MessageBox.Show("replaced"  +  this.textBox1.Text  + "to" +  this.textBox2.Text);
            this.Close();

            
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
        
        }
    }
    }
