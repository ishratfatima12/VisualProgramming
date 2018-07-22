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
    public partial class Form10 : Form
    {
        Form4 f4 = new Form4();

        public Form10()
        {

            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = Color.LightGray;
            this.button1.BackColor = Color.LightGray;
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
           


            this.label10.Text = "GRN FORM";
            this.label1.Text = "POID:";
            this.label2.Text = "Vendor ID:";
            this.label3.Text = "Vendor Name:";
            this.label11.Text = "Data Show";
            this.label6.Text = "GRN ID:";
            this.label4.Text = "Department";
            this.label5.Text = "Total Amount";
            this.label7.Text = "Product Quantity REC ";


            this.button1.Text = "Creat GRN";


            //To Populate Combobox1 of POID
            {
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select POID from PO", f4.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["POID"].ToString());
                }
                f4.oleDbConnection1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                //Data Insertion in GRN Prducts table....................................
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into GRNProducts(grnid,vname,pqty)values(@grnid,@vname,@pqty)", f4.oleDbConnection1);
                cmd.Parameters.AddWithValue("@grnid", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@vname", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@pqty", this.textBox6.Text);
                cmd.ExecuteNonQuery();
                f4.oleDbConnection1.Close();

                MessageBox.Show("Data of GRN Products Inserted in Table");

            }
            //Data Insertion int GRN Table.............................
            {
                {
                    f4.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into GRN(GRNID,POID,VName,VID,TotalAmount)values(@GRNID,@POID,@VName,@VID,@TotalAmount)", f4.oleDbConnection1);
                    cmd.Parameters.AddWithValue("@GRNID", this.textBox5.Text);
                    cmd.Parameters.AddWithValue("@POID", this.comboBox1.Text);
                    cmd.Parameters.AddWithValue("@VName", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@VID", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", this.textBox4.Text);
                    //cmd.Parameters.AddWithValue("@DDate",dateTimePicker1);
                    // cmd.Parameters.AddWithValue("@GRDate",dateTimePicker2);
                    cmd.ExecuteNonQuery();
                    f4.oleDbConnection1.Close();

                    MessageBox.Show("GRN Created");
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //For Auto ID Generation Of GRN............................
            {
                int c = 0;
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(grnid) from grn where poid='" + comboBox1.Text + "'", f4.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]); c++;
                }

                {
                    textBox3.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                f4.oleDbConnection1.Close();
            }

            //To Populate Combobox1 from POID.....................
            {
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from PO where POID='" + comboBox1.Text + "'", f4.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["vid"].ToString();
                    textBox2.Text = dr["vname"].ToString();
                    textBox3.Text = dr["vdept"].ToString();
                    textBox4.Text = dr["totalamount"].ToString();

                }
                f4.oleDbConnection1.Close();
            }

            //To Show Products Data....................................
            {
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from poproducts where POID=@POID", f4.oleDbConnection1);
                cmd.Parameters.AddWithValue("@POID", comboBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                f4.oleDbConnection1.Close();
            }
        }
    }
    }

