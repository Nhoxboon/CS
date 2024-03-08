using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TH3._4
{
    public partial class Form1 : Form
    {

        bool IsNumber(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Your Name";
            label2.Text = "Year of birth";
            button1.Text = "Show";
            button2.Text = "Clear";
            button3.Text = "Exit";


        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please enter your name");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (textBox2.Text == "")
            {
                errorProvider2.SetError(textBox2, "Please enter your year of birth");
            }
            else
            {
                errorProvider2.Clear();
            }
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int year = int.Parse(textBox2.Text);
                int age = 2021 - year;
                MessageBox.Show("Your name: " + textBox1.Text + "\n" + "Your age: " + age);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ban có chắc chắn muốn thoát?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
