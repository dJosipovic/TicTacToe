using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiktok
{
    public partial class Form2 : Form
    {
        public static bool CloseTheApp = false;
        public bool NotCloseByX = false;
        public static bool OnePlayerMode;

        public Form2()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (e.CloseReason == CloseReason.UserClosing && NotCloseByX == false)
            {

                switch (MessageBox.Show(this, "Are you sure?", "Do you wish to exit the application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        CloseTheApp = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.SetPlayerNames(textBox1.Text);
            OnePlayerMode = true;
            if (textBox1.Text == "")
                MessageBox.Show("Player one name cannot be left empty. Please enter your name.");
            else
            {
                NotCloseByX = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.SetPlayerNames(textBox1.Text, textBox2.Text);
            OnePlayerMode = false;
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Name textboxes cannot be left empty. Please enter your names.");
            else
            {
                NotCloseByX = true;
                this.Close();
            }
        }
    }
}
