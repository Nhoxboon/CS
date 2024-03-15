using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            double a;
            if(double.TryParse(textBox1.Text, out a))
            {
                if( a >= 0 && a <= 10)
                {
                    MessageBox.Show("Số hợp lệ");
                }
                else
                {
                    MessageBox.Show("Số không hợp lệ");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số");
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, 8);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //...
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //...
            dataGridView1.CurrentRow.Cells[0].Value = comboBox1.Text;
        }
    }
    //:O
}
