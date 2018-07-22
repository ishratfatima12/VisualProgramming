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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

       

        private void Form5_Load(object sender, EventArgs e)
        {
            this.button1.Text = "Add vendor";
            this.button2.Text = "Search vendor";
            this.button1.BackColor = Color.LightGray;
            this.button2.BackColor = Color.LightGray;


        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();

                
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Form6 f6 = new Form6();
            f6.Show();
        }
    }
}
