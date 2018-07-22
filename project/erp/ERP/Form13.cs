using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP
{
    public partial class Form13 : Form
    {
        Form4 f4 = new Form4();

        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
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
            this.button1.BackColor = Color.LightGray;


            this.label1.Text = "Standard operation Procedure";
            this.label2.Text = "Department ID";
            this.label3.Text = "So ID";
            this.label4.Text = "Customer ID";
            this.label5.Text = "Name";
            this.label6.Text = "Credit Limit";
            this.label7.Text = "Group";
            this.label8.Text = "Phone number";
            this.label9.Text = "Product ID";
            this.label10.Text = "Name";
            this.label11.Text = "Quantity";
            this.label12.Text = "Type";
            this.label13.Text = "warenty";
            this.label14.Text = "Base Price";
            this.button1.Text = "Submit";


            this.groupBox1.Text = "Departement";
            this.groupBox2.Text = "Customer";
            this.groupBox3.Text = "Product";





            f4.oleDbConnection1.Open();
            OleDbCommand c1 = new OleDbCommand("select Deptid from Dept ", f4.oleDbConnection1);
            OleDbDataReader dr1 = c1.ExecuteReader();

            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["Deptid"].ToString());
            }
            f4.oleDbConnection1.Close();

            f4.oleDbConnection1.Open();
            OleDbCommand c = new OleDbCommand("select CID from customer ", f4.oleDbConnection1);
            OleDbDataReader dr = c.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["CID"].ToString());
            }
            f4.oleDbConnection1.Close();



            f4.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("select Pid from Products ", f4.oleDbConnection1);
            OleDbDataReader d1 = cmd1.ExecuteReader();

            while (d1.Read())
            {
                comboBox3.Items.Add(d1["Pid"].ToString());
            }
            f4.oleDbConnection1.Close();





        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Products where Pid='" + comboBox3.Text + "'", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox8.Text = dr["PName"].ToString();
                textBox7.Text = dr["PQuantity"].ToString();
                textBox6.Text = dr["ProductType"].ToString();
                textBox5.Text = dr["WarrentyPeriod"].ToString();
                textBox9.Text = dr["BasePrice"].ToString();
            }
            f4.oleDbConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customer where CID='" + comboBox2.Text + "'", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Cname"].ToString();
                textBox2.Text = dr["CreditLimit"].ToString();
                textBox3.Text = dr["CGroup"].ToString();
                textBox4.Text = dr["PH1"].ToString();

            }
            f4.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into SOP (SOID,DeptID,CID,PID,PQuantity,Creditlimit) Values(@SOID,@DeptID,@CID,@PID,@PQuantity,@Creditlimit)", f4.oleDbConnection1);
            cmd.Parameters.AddWithValue("@SOID", Convert.ToInt32(textBox10.Text));
            cmd.Parameters.AddWithValue("@DeptID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@CID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@PID", comboBox3.Text);
            cmd.Parameters.AddWithValue("@PQuantity", Convert.ToInt32(textBox7.Text));
            // cmd.Parameters.AddWithValue("@Group", textBox3.Text);
            cmd.Parameters.AddWithValue("@Creditlimit", Convert.ToInt32(textBox2.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Insert");
            f4.oleDbConnection1.Close();
        }
    }
}
