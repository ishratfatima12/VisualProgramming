using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dice_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "DICE ROLLING GAME";
            this.button1.Text = "START";
            this.button2.Text = "END";
            this.BackColor = Color.Goldenrod;
            this.label1.BackColor = Color.Goldenrod;
            this.button2.BackColor = Color.Goldenrod;
            this.button1.BackColor = Color.Goldenrod;


        }
    }
}
