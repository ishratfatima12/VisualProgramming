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
    public partial class Form9 : Form
    {
        Form4 f4 = new Form4();

        string[] prds = new string[50];
        int[] pqty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.LightGray;
            this.button2.BackColor = Color.LightGray;
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
            this.label15.BackColor = Color.LightGray;
            this.label14.BackColor = Color.LightGray;
            this.textBox8.BackColor = Color.LightBlue;
            this.groupBox3.BackColor = Color.LightBlue;
            this.groupBox2.BackColor = Color.LightBlue;
            this.groupBox1.BackColor = Color.LightBlue;






            this.button1.Text = "Add Product";
            this.button2.Text = "Create Purchase Order";

            this.groupBox1.Text = "DEPART";
            this.groupBox2.Text = "VENDER DETAILS";
            this.groupBox3.Text = "PRODUCT DETAILS";

            this.label1.Text = "Purchase Order Form";
            this.label3.Text = "Choose Department:";
            this.label4.Text = "POID:";
            this.label13.Text ="PO Creation Date:";
            this.label14.Text = "Delivery Date:";
            this.label5.Text = "Vendor ID:";
            this.label6.Text = "Vendor Name:";
            this.label7.Text = "Comapny Name:";
            this.label8.Text = "Phone No#";
            this.label9.Text = "Product ID:";
            this.label10.Text = "Product Name:";
            this.label12.Text = "Product Price:";
            this.label11.Text = "Product Quantity:";
            this.label2.Text = "Show Total Products:";
            this.label15.Text = "Total Amount";

            {
                f4.oleDbConnection1.Open();
                OleDbCommand c = new OleDbCommand("select VID from vendor ", f4.oleDbConnection1);
                OleDbDataReader dr = c.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["VID"].ToString());
                }
                f4.oleDbConnection1.Close();

                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select Pid from Products ", f4.oleDbConnection1);
                OleDbDataReader d = cmd.ExecuteReader();

                while (d.Read())
                {
                    comboBox2.Items.Add(d["Pid"].ToString());
                }
                f4.oleDbConnection1.Close();

                f4.oleDbConnection1.Open();
                OleDbCommand c1 = new OleDbCommand("select Deptid from Dept ", f4.oleDbConnection1);
                OleDbDataReader dr1 = c1.ExecuteReader();
                while (dr1.Read())
                {
                    comboBox3.Items.Add(dr1["Deptid"].ToString());
                }
                f4.oleDbConnection1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            {
                int c = 0;
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(poid) from po where vdept='" + comboBox1.Text + "'", f4.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]); c++;
                }
                if (comboBox1.Text == "Consumer")
                {
                    textBox1.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                else if (comboBox1.Text == "Marketing")
                {
                    textBox1.Text = "MR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                else if (comboBox1.Text == "HR")
                {
                    textBox1.Text = "HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                else if (comboBox1.Text == "Sales")
                {
                    textBox1.Text = "SALES-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                f4.oleDbConnection1.Close();
            }

            {
                f4.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select vid from vendor where vgroup=@vgroup", f4.oleDbConnection1);
                cmd.Parameters.AddWithValue("@vgroup", comboBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Clear();
                    comboBox2.Items.Add(dr["vid"].ToString());
                }
                f4.oleDbConnection1.Close();
            }



        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from products where pid='" + comboBox3.Text + "'", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox7.Text = dr["pname"].ToString();
                textBox6.Text = dr["baseprice"].ToString();

            }
            f4.oleDbConnection1.Close();
        }

        //FOR ADD PRODUCT
        private void button1_Click(object sender, EventArgs e)
        {
            int baseprice = 0;
            int productqty = 0;

            baseprice = Convert.ToInt32(textBox6.Text);
            productqty = Convert.ToInt32(textBox5.Text);

            //   baseprice* productqty = Convert.ToInt32(this.textBox9.Text); 
            this.textBox9.Text = Convert.ToString(baseprice * productqty);

            //multiple Products storing in Array
            prds[counter] = comboBox3.Text;
            pqty[counter] = Convert.ToInt32(textBox7.Text);
            pprice[counter] = Convert.ToInt32(textBox6.Text);
            counter++;

            //Data Showing In textbox8

            this.textBox8.Text += "****Purchase Order Details****" + Environment.NewLine + Environment.NewLine;
            this.textBox8.Text += "Department:  " + comboBox1.Text + Environment.NewLine;
            this.textBox8.Text += "POID:        " + textBox1.Text + Environment.NewLine;
            this.textBox8.Text += "PO Creation Date:" + dateTimePicker2.Text + Environment.NewLine;
            this.textBox8.Text += "Delivery Date:" + dateTimePicker1.Text + Environment.NewLine + Environment.NewLine;

            this.textBox8.Text += "****Vendor Details****" + Environment.NewLine + Environment.NewLine;
            this.textBox8.Text += "Vendor ID:   " + comboBox2.Text + Environment.NewLine;
            this.textBox8.Text += "Vendor Name: " + textBox2.Text + Environment.NewLine;
            this.textBox8.Text += "Company Name:" + textBox3.Text + Environment.NewLine;
            this.textBox8.Text += "Phone No.#   " + textBox4.Text + Environment.NewLine + Environment.NewLine;

            this.textBox8.Text += "****Product Details****" + Environment.NewLine + Environment.NewLine;
            this.textBox8.Text += "Product ID:  " + comboBox3.Text + Environment.NewLine;
            this.textBox8.Text += "Product Name:" + textBox7.Text + Environment.NewLine;
            this.textBox8.Text += "Product Price:" + textBox6.Text + Environment.NewLine;
            this.textBox8.Text += "Product Quantity:" + textBox5.Text + Environment.NewLine;
            this.textBox8.Text += "Total Amount :" + textBox9.Text + Environment.NewLine;


            MessageBox.Show("Value edited....");




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from vendor where vid='" + comboBox2.Text + "'", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["vname"].ToString();
                textBox3.Text = dr["cpname"].ToString();
                textBox4.Text = dr["ph1"].ToString();

            }
            f4.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            { 
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into PO(poid,vdept,vname,vid,vcpph,podate,ddate,TotalAmount)values(@poid,@vdept,@vname,@vid,@vcpph,@podate,@ddate,@TotalAmount)", f4.oleDbConnection1);
            cmd.Parameters.AddWithValue("@poid", this.textBox1.Text);
            cmd.Parameters.AddWithValue("@vdept", this.comboBox1.Text);
            cmd.Parameters.AddWithValue("@vname", this.textBox2.Text);
            cmd.Parameters.AddWithValue("@vid", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("@vcpph", this.textBox4.Text);
            cmd.Parameters.AddWithValue("@podate", this.dateTimePicker1);
            cmd.Parameters.AddWithValue("@ddate", this.dateTimePicker1);
            cmd.Parameters.AddWithValue("@TotalAmount", this.textBox9.Text);
            cmd.ExecuteNonQuery();
            f4.oleDbConnection1.Close();
            MessageBox.Show("Transaction done!!");
        }
            {
                {
                    //Insertion of Products in PoProducts table

                    for(int i=0; i<prds.Length; i++)
                    {
                   f4.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into POProducts(poid,pid,pname,pqty)values(@poid,@pid,@pname,@pqty)", f4.oleDbConnection1);
        cmd.Parameters.AddWithValue("@poid",this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@pid",prds[i]);
                   cmd.Parameters.AddWithValue("@pname",this.textBox7.Text);
                    cmd.Parameters.AddWithValue("@pqty",pqty[i]);
                    cmd.ExecuteNonQuery();
                    f4.oleDbConnection1.Close();
                    MessageBox.Show("Multiple Products Added ");

                    }
}
}
}
}
}

 


              
         
                


      

        
    

