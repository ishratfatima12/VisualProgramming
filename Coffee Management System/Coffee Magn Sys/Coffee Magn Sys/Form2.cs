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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void pURCHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.menuStrip1.BackColor = Color.Transparent;
            this.menuStrip1.Parent = pictureBox1;
            this.pURCHASEToolStripMenuItem.ForeColor = Color.White;
            this.label1.Text = "Welcome to coffee shop";
            this.label1.BackColor = Color.Transparent;
            this.label1.Parent = pictureBox1;
            this.label1.ForeColor = Color.White;
        }

        private void vENDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void sTOKEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void sALESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cUTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
