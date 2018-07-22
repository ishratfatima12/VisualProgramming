using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace ERP
{
    public partial class Form7 : Form
    {
        Form4 f4 = new Form4();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = Color.LightGray;
            this.label2.BackColor = Color.LightGray;
            this.label3.BackColor = Color.LightGray;
            this.label4.BackColor = Color.LightGray;
            this.label5.BackColor = Color.LightGray;
            this.label6.BackColor = Color.LightGray;
            this.label7.BackColor = Color.LightGray;
            this.label8.BackColor = Color.LightGray;
            this.button1.BackColor = Color.LightGray;

            this.Text = "Add Vendor";
            this.label1.Text = "V_ID";
            this.label2.Text = "V_Name";
            this.label3.Text = "V_City";
            this.label4.Text = "V_PH#";
            this.label5.Text = "CPName";
            this.label6.Text = "CPPH";
            this.label9.Text = "VStatus";
            this.label8.Text = "Add vendor";


            this.button1.Text = "Add";
           

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into Vendor (VID,VName,VCity,PH1,CPName,CPPH,VStatus) Values(@VID,@VName,@VCity,@PH1,@CPName,@CPPH,@VStatus);", f4.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox5.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox6.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox7.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Vendor has been send for Approval");
            f4.oleDbConnection1.Close();
            Form8 f8 = new Form8();
            f8.Show();

        }
    }
}
       
       
