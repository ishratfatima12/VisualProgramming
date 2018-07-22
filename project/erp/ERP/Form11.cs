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
    public partial class Form11 : Form
    {
        Form4 f4 = new Form4();
        public Form11()
        {
            InitializeComponent();
        }


        private void Form11_Load(object sender, EventArgs e)
        {

            this.label1.Text = "INVOICE PAYABLE";
            this.label2.Text = "GRN ID:";
            this.label3.Text = "GRN Date:";
            this.label4.Text = "Amount:";
            this.label8.Text = "POID:";
            this.label9.Text = "Vendor ID:";
            this.label10.Text = "Discount %:";
            this.label11.Text = "Total Amount Payable:";
            this.label13.Text = "Show Data:";
            this.label5.Text = "Delivery Date:";
            this.label6.Text = "Vendor Name:";
            this.label7.Text = "Invoice ID";
            this.label12.Text = "C_Invoice Date";


            this.button1.Text = "Create Invoice";

            this.button1.BackColor = Color.LightGray;
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

            //Auto INVOICE ID Geenration..............................
            {
                int c = 0;
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from invoice", f4.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]); c++;

                    {
                        this.textBox9.Text = "Inv-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                    }
                    f4.oleDbConnection1.Close();
                }
            }
            //Populate comboBox1 foR GRN ID.................
            {
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select GRNID from GRN", f4.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    comboBox1.Items.Add(dr["GRNID"].ToString());
                }
                f4.oleDbConnection1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // //Fetching Data from GRN Table in textboxes................
            {
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from GRN where GRNID=@GRNID", f4.oleDbConnection1);
                cmd.Parameters.AddWithValue("@GRIND", this.comboBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.textBox3.Text = dr["POID"].ToString();
                    //this.textBox1.Text = dr["GRNDate"].ToString();
                    //this.textBox7.Text = dr["DDate"].ToString();
                    this.textBox8.Text = dr["vname"].ToString();
                    this.textBox4.Text = dr["vid"].ToString();
                    this.textBox2.Text = dr["TotalAmount"].ToString();

                }
                f4.oleDbConnection1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                //Insertion of InVoice in  its table...................
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into invoice(vendorid,vendorname,amountpayable,grnid,invoiceID,cdate)values(@vendorid,@vendorname,@amountpayable,@grnid,@invoiceID,@cdate)", f4.oleDbConnection1);
                cmd.Parameters.AddWithValue("@vendorid", this.textBox4.Text);
                cmd.Parameters.AddWithValue("@vendorname", this.textBox8.Text);
                cmd.Parameters.AddWithValue("@amountpayable", this.textBox6.Text);
                cmd.Parameters.AddWithValue("@grnid", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@invoiceID", this.textBox9.Text);
                cmd.Parameters.AddWithValue("@cdate", this.dateTimePicker1);
                cmd.ExecuteNonQuery();
                f4.oleDbConnection1.Close();
                MessageBox.Show("Data Inserted in Invoice Table");
            }
            {
                //To Show GRN Data....................................
                {
                    f4.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("Select * from invoice ", f4.oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    f4.oleDbConnection1.Close();
                }
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int disc;
            int amount;
            int totalAmount;

            disc = Convert.ToInt32(this.textBox5.Text);
            amount = Convert.ToInt32(this.textBox2.Text);
            totalAmount = (amount * disc) / 100;
            this.textBox6.Text = Convert.ToString(totalAmount);
        }
    }
    }
