using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH8._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label5.Text = "0";
            int cot = 6;
            char Hang = 'F';
            foreach (Button item in tableLayoutPanel1.Controls)
            {

                item.Text = (Hang + " " + cot).ToString();
                cot--;
                if (cot == 0)
                {
                    cot = 6;
                    Hang--;
                }

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (label5.Text == "0")
            {
                MessageBox.Show("Bạn chưa chọn ghế nào");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thanh toán không?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    label5.Text = "0";
                    TongTien = 0;
                    foreach (Button item in tableLayoutPanel1.Controls)
                    {
                        if(item.BackColor == Color.Green)
                        {
                            item.BackColor = Color.Red;
                            item.Enabled = false;
                        }
                    }
                }
            }
        }

        int TongTien = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackColor == Color.Green)
            {
                if (button.Text.Contains("A"))
                {
                    button.BackColor = Color.PaleTurquoise;
                    TongTien -= 25000;
                }
                else if (button.Text.Contains("B"))
                {
                    button.BackColor = Color.PaleGreen;
                    TongTien -= 30000;
                }
                else if (button.Text.Contains("C"))
                {
                    button.BackColor = Color.LemonChiffon;
                    TongTien -= 35000;
                }
                else if (button.Text.Contains("D"))
                {
                    button.BackColor = Color.Thistle;
                    TongTien -= 40000;
                }
                else if (button.Text.Contains("E"))
                {
                    button.BackColor = Color.Pink;
                    TongTien -= 50000;
                }
                else if (button.Text.Contains("F"))
                {
                    button.BackColor = Color.LavenderBlush;
                    TongTien -= 45000;

                }
            }
            else
            {
                button.BackColor = Color.Green;
                if (button.Text.Contains("A"))
                {
                    TongTien += 25000;
                }
                else if (button.Text.Contains("B"))
                {
                    TongTien += 30000;
                }
                else if (button.Text.Contains("C"))
                {
                    TongTien += 35000;
                }
                else if (button.Text.Contains("D"))
                {
                    TongTien += 40000;
                }
                else if (button.Text.Contains("E"))
                {
                    TongTien += 50000;
                }
                else if (button.Text.Contains("F"))
                {
                    TongTien += 45000;

                }
                //worrychems
            }
            label5.Text = TongTien.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = comboBox1.Text;
        }
    }
}
