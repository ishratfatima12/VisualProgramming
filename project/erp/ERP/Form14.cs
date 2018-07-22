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
    public partial class Form14 : Form
    {

        Form4 f4 = new Form4();
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Delivery Chalan";
            this.label2.Text = "SOP ID";
            this.label1.BackColor = Color.LightGray;
            this.label2.BackColor = Color.LightGray;



            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select SOID from SOP", f4.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["SOID"].ToString());

            }
            f4.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f4.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from SOP where SOID=@SOID", f4.oleDbConnection1);
            cmd.Parameters.AddWithValue("@SOID", comboBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f4.oleDbConnection1.Close();

        }
    }
}
    

