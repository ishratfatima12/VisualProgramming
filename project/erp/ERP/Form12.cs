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
    public partial class Form12 : Form
    {
        Form4 f4 = new Form4();
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
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
            this.button1.BackColor = Color.LightGray;
            this.button2.BackColor = Color.LightGray;


            this.label1.Text = "Customer Registration Form";
            this.label2.Text = "Cutomer ID";
            this.label3.Text = "Name";
            this.label4.Text = "Address";
            this.label6.Text = "Ph No.";
            this.label7.Text = "ph No.2";
            this.label8.Text = "CP Name";
            this.label9.Text = "CPPH";
            this.label10.Text = "Email";
            this.label11.Text = "Credit limit";
            this.label12.Text = "Group";
            this.label13.Text = "Status";
            this.label5.Text = "City";
            this.button1.Text = "Submit";
            this.button2.Text = "";



            textBox11.Text = "Dis_Approve";
        }

        private void button1_Click(object sender, EventArgs e)
        {


            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into customer(CID,Cname,CAddress,City,PH1,PH2,ContectPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup) Values(@CID,@Cname,@CAddress,@City,@PH1,@PH2,@ContectPerson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup)", f4.oleDbConnection1);
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@CAddress", textBox3.Text);
            cmd.Parameters.AddWithValue("@City", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH1", Convert.ToInt32(textBox5.Text));
            cmd.Parameters.AddWithValue("@PH2", Convert.ToInt32(textBox6.Text));
            cmd.Parameters.AddWithValue("@ContectPerson", textBox7.Text);
            cmd.Parameters.AddWithValue("@CPPH", Convert.ToInt32(textBox8.Text));
            cmd.Parameters.AddWithValue("@CreditLimit", Convert.ToInt32(textBox10.Text));
            cmd.Parameters.AddWithValue("@CStatus", textBox11.Text);
            cmd.Parameters.AddWithValue("@CGroup", textBox12.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Customer Record has been Inserted ");
            f4.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customer", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Approve";
            btn.Name = "APPROVE";
            btn.Text = "APPROVE";
            btn.UseColumnTextForButtonValue = true;
            f4.oleDbConnection1.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String status = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("update customer set CStatus ='Approve' where CID='" + status + "'", f4.oleDbConnection1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("update");
            dataGridView1.Refresh();
            f4.oleDbConnection1.Close();
        }
    }
    }

