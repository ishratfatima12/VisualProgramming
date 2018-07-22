using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Coffee_Magn_Sys
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            frmMain f2 = new frmMain();
            public Form2()
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.label1.Text = "CustomerId";
            this.label1.BackColor = Color.Transparent;
            this.label1.Parent = pictureBox1;
            this.label2.Text = "Customer Name";
            this.label2.BackColor = Color.Transparent;
            this.label2.Parent = pictureBox1;
            this.label3.Text = "Customr Pno";
            this.label3.BackColor = Color.Transparent;
            this.label3.Parent = pictureBox1;
            this.label4.Text = "Customer Address";
            this.label4.BackColor = Color.Transparent;
            this.label4.Parent = pictureBox1;
            this.label5.Text = "Customer Email";
            this.label5.BackColor = Color.Transparent;
            this.label5.Parent = pictureBox1;
            this.button1.Text = "Insert";
            this.button2.Text = "Update";
            this.button3.Text = "Delete";
            this.button4.Text = "Display customers";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into vendor(C_ID,C_Name,C_PNO,C_ADD,C_Email)values(@C_ID,@C_Name,@C_PNO,@C_ADD,@C_Email)", f2.oleDbConnection1);

            cmd.Parameters.AddWithValue("@C_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@C_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@C_PNO", textBox3.Text);
            cmd.Parameters.AddWithValue("@C_ADD", textBox4.Text);
            cmd.Parameters.AddWithValue("@C_Email", textBox5.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("record inserted");
            f2.oleDbConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customer", f2.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f2.oleDbConnection1.Close();
        }
    }
}
