using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH9._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            double a;
            if(double.TryParse(textBox2.Text, out a))
            {

            }
            else
            {
                MessageBox.Show("Vui lòng nhập số");
                textBox2.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Doraemon")
            {
                textBox3.Text = "10000";
            }
            else if(comboBox1.Text == "Danmachi")
            {
                textBox3.Text = "20000";
            }
            else if(comboBox1.Text == "Frieren")
            {
                textBox3.Text = "30000";
            }
            else if(comboBox1.Text == "Oregairu")
            {
                textBox3.Text = "40000";
            }
            else if(comboBox1.Text == "Hắc quản gia")
            {
                textBox3.Text = "50000";
            }
            else
            {
                textBox3.Text = "0";
            }
        }

        int STT = 0;
        //Mượn truyện
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(STT++, textBox1.Text, textBox2.Text, comboBox1.Text, dateTimePicker1.Text, "", "", "Chưa trả");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        //Mượn truyện
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Cells[5].Value = dateTimePicker2.Text;
            DateTime ngaymuon = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime ngaytra = Convert.ToDateTime(dateTimePicker2.Text);
            TimeSpan time = ngaytra - ngaymuon;
            int songay = time.Days;
            dataGridView1.CurrentRow.Cells[6].Value = songay * double.Parse(textBox3.Text);
            dataGridView1.CurrentRow.Cells[7].Value = "";
        }
    }
}
