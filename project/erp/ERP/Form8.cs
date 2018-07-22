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
    public partial class Form8 : Form
    {
        Form4 f4 = new Form4();
        public Form8()
        {
            InitializeComponent();
        }

       

        private void Form8_Load(object sender, EventArgs e)
        {
            this.Text = "Approval";
            this.button1.Text = "Approve";
            this.button2.Text = "Reject";
            this.button1.BackColor = Color.LightGray;
            this.button2.BackColor = Color.LightGray;
            this.label1.BackColor = Color.LightGray;
            this.label2.BackColor = Color.LightGray;
            this.label3.BackColor = Color.LightGray;
            this.label4.BackColor = Color.LightGray;
            this.label5.BackColor = Color.LightGray;
            this.label6.BackColor = Color.LightGray;
            this.label7 .BackColor = Color.LightGray;
            this.label8.BackColor = Color.LightGray;
            this.Text = "Approval Form";
            this.Text = "ADD VENDOR";
            this.label1.Text = "VID";
            this.label2.Text = "VName";
            this.label3.Text = "VCity";
            this.label4.Text = "PH1";
            this.label5.Text = "CPName";
            this.label6.Text = "CPPH";
            this.label7.Text = "VStatus";
            this.label8.Text = "Approval";


            this.button1.Text = "Approval";
            this.button2.Text = "Dis_Approval";



            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select VID from Vendor where VStatus = 'Inactive'", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]).ToString();
            }
            f4.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Vendor where VID ='" + comboBox1.Text + "'", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["VName"].ToString();
                textBox2.Text = dr["VCity"].ToString();
                textBox3.Text = dr["PH1"].ToString();
                textBox4.Text = dr["CPName"].ToString();
                textBox5.Text = dr["CPPH"].ToString();
                textBox6.Text = dr["VStatus"].ToString();
            }
            f4.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,VCity=@VCity,PH1=@PH1,CPName=@CPName,CPPH=@CPPH,VStatus=@VStatus where VID=@VID", f4.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VName", textBox1.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox2.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox3.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox4.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox5.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox6.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Vendor has been Approved");
            this.Hide();
            f4.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,VCity=@VCity,PH1=@PH1,CPName=@CPName,CPPH=@CPPH,VStatus=@VStatus where VID=@VID", f4.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VName", textBox1.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox2.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox3.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox4.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox5.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox6.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Issue accured in Approvig Vendor");
            f4.oleDbConnection1.Close();
        }
    }
    }

