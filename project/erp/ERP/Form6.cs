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
    public partial class Form6 : Form
    {
        Form4 f4 = new Form4();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = Color.LightGray;
            this.label2.BackColor = Color.LightGray;
            this.label3.BackColor = Color.LightGray;
            this.label4.BackColor = Color.LightGray;
            this.label5.BackColor = Color.LightGray;
            this.label6.BackColor = Color.LightGray;
            this.label7.BackColor = Color.LightGray;
            this.label8.BackColor = Color.LightGray;
            this.label9.BackColor = Color.LightGray;
            this.label10.BackColor = Color.LightGray;
            this.label11.BackColor = Color.LightGray;
            this.label12.BackColor = Color.LightGray;
            this.label13.BackColor = Color.LightGray;
            this.label14.BackColor = Color.LightGray;



            this.Text = "Vendor";
            this.label1.Text = "VID";
            this.label2.Text = "VName";
            this.label3.Text = "VCode";
            this.label4.Text = "VCity";
            this.label5.Text = "PH1";
            this.label6.Text = "PH2";
            this.label7.Text = "VAddress";
            this.label8.Text = "CPName";
            this.label9.Text = "CPPH";
            this.label10.Text = "VEmail";
            this.label11.Text = "Vfax";
            this.label12.Text = "VGroup";
            this.label13.Text = "VStatus";
            this.label14.Text = "Vendor";



          



            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox8.ReadOnly = true;
            this.textBox9.ReadOnly = true;
            this.textBox10.ReadOnly = true;
            this.textBox11.ReadOnly = true;
            this.textBox12.ReadOnly = true;




            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select VID from Vendor where VStatus = 'Active'", f4.oleDbConnection1);
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
            OleDbCommand cm = new OleDbCommand("Select * from Vendor where VID='" + comboBox1.Text + "'", f4.oleDbConnection1);
            OleDbDataReader d = cm.ExecuteReader();
            if (d.Read())
            {
                textBox1.Text = d["VName"].ToString();
                textBox2.Text = d["VCode"].ToString();
                textBox3.Text = d["VCity"].ToString();
                textBox4.Text = d["PH1"].ToString();
                textBox5.Text = d["PH2"].ToString();
                textBox6.Text = d["VAddress"].ToString();
                textBox7.Text = d["CPName"].ToString();
                textBox8.Text = d["CPPH"].ToString();
                textBox9.Text = d["VEmail"].ToString();
                textBox10.Text = d["Vfax"].ToString();
                textBox11.Text = d["VGroup"].ToString();
                textBox12.Text = d["VStatus"].ToString();
            }
            f4.oleDbConnection1.Close();



            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Vendor where VID='" + comboBox1.Text + "'", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f4.oleDbConnection1.Close();
        }

    }
}

