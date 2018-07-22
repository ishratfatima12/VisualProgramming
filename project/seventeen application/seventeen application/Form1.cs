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

namespace seventeen_application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Ishrat-Notepad";
            this.WindowState = FormWindowState.Maximized;
            this.menuStrip1.BackColor = Color.MediumVioletRed;
            this.textBox1.BackColor = Color.PeachPuff;
            this.cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            this.copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            this.pastToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            this.timeDateToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            this.deletToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            this.selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.unDoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
            this.findToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            this.replaceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            this.newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            this.openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            this.saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F10;
            this.exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;








        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void deletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();

        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = System.DateTime.Today.ToString();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void unDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Undo();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                unDoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                unDoToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr =this. openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "ft (*.txt)|*.txt";
            if(dr== DialogResult.OK)
            {
                string fname = openFileDialog1.FileName;
                this.textBox1.Text = File.ReadAllText(fname);
            }

            }
        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            saveFileDialog1.Filter = "All Text(*.txt)|*.txt";
            if(dr==DialogResult.OK)
            {
                /*string fname = saveFileDialog1.FileName;
                File.WriteAllText(fname, this.textBox1.Text);
                fname += fname + ".txt";*/
                string sd = saveFileDialog1.FileName;
                sd += ".txt";
                File.WriteAllText(sd, this.textBox1.Text);
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
                
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.Show();

        }

        private void forntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr =this.fontDialog1.ShowDialog();
            this.textBox1.Font = this.fontDialog1.Font;
            if( dr==DialogResult.OK)
            {
                this.textBox1.Font = this.fontDialog1.Font;

            }
        }

        private void fontWithColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.colorDialog1.ShowDialog();
            this.textBox1.ForeColor = this.colorDialog1.Color;
            if(dr==DialogResult.OK)
            {
                this.textBox1.ForeColor = this.colorDialog1.Color;
            }
                
        }

        private void worldWapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.worldWapeToolStripMenuItem.Checked = true;
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Notepad is created by Ishrat Fatima");
        }


    }
}
