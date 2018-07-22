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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.label1.Text = "VID";
            this.label1.BackColor = Color.Transparent;
            this.label1.Parent = pictureBox1;
            this.label2.Text = "VName";
            this.label2.BackColor = Color.Transparent;
            this.label2.Parent = pictureBox1;
            this.label3.Text = "V_NO";
            this.label3.BackColor = Color.Transparent;
            this.label3.Parent = pictureBox1;
            this.label4.Text = "VCompany";
            this.label4.BackColor = Color.Transparent;
            this.label4.Parent = pictureBox1;
            this.label5.Text = "VAddress";
            this.label5.BackColor = Color.Transparent;
            this.label5.Parent = pictureBox1;
            this.label6.Text = "Email";
            this.label6.BackColor = Color.Transparent;
            this.label6.Parent = pictureBox1;
            this.button1.Text = "Insert";
            
            this.button2.Text = "Update";
           
            this.button3.Text = "Delete";

            this.button4.Text = "Home";
            
        }
    }
}
