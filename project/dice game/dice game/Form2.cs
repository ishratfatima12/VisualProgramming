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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pbdiceshow1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.endstart.Text = "START";
            this.endexit.Text = "EXIT";
            this.pbdice1.Visible = false;
            this.pbdice2.Visible = false;
            this.pbdice3.Visible = false;
            this.pbdice4.Visible = false;
            this.pbdice5.Visible = false;
            this.pbdice6.Visible = false;
            this.BackColor = Color.Goldenrod;
            this.endexit.BackColor = Color.Goldenrod;
            this.endstart.BackColor = Color.Goldenrod;
        }

        private void endstart_Click(object sender, EventArgs e)
        {
            this.pbdice1.Visible = true;
            this.pbdice2.Visible = true;
            this.pbdice3.Visible = true;
            this.pbdice4.Visible = true;
            this.pbdice5.Visible = true;
            this.pbdice6.Visible = true;



            Random r = new Random();
            //declare new data to get random values from object r.

            int iRnd = new int();

            iRnd = r.Next(0, 6); //counting randomly from 0 to 5.

            //compare data wit each random number
            if (iRnd == 0)
                pbdiceshow1.Image = pbdice1.Image;
            else if(iRnd==1)
                pbdiceshow1.Image = pbdice2.Image;
            else if (iRnd == 2)
                pbdiceshow1.Image = pbdice3.Image;
            else if (iRnd == 3)
                pbdiceshow1.Image = pbdice4.Image;
            else if (iRnd == 4)
                pbdiceshow1.Image = pbdice5.Image;
            else
                pbdiceshow1.Image = pbdice6.Image;

            iRnd = r.Next(0, 6); //counting randomly from 0 to 5.
            if (iRnd == 0)
                pbdiceshow2.Image = pbdice1.Image;
            else if (iRnd == 1)
                pbdiceshow2.Image = pbdice2.Image;
            else if (iRnd == 2)
                pbdiceshow2.Image = pbdice3.Image;
            else if (iRnd == 3)
                pbdiceshow2.Image = pbdice4.Image;
            else if (iRnd == 4)
                pbdiceshow2.Image = pbdice5.Image;
            else
                pbdiceshow2.Image = pbdice6.Image;



            iRnd = r.Next(0, 6); //counting randomly from 0 to 5.
            if (iRnd == 0)
                pbdiceshow3.Image = pbdice1.Image;
            else if (iRnd == 1)
                pbdiceshow3.Image = pbdice2.Image;
            else if (iRnd == 2)
                pbdiceshow3.Image = pbdice3.Image;
            else if (iRnd == 3)
                pbdiceshow3.Image = pbdice4.Image;
            else if (iRnd == 4)
                pbdiceshow3.Image = pbdice5.Image;
            else
                pbdiceshow3.Image = pbdice6.Image;


















        }

        private void endexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbdice6_Click(object sender, EventArgs e)
        {

        }
    }
}
