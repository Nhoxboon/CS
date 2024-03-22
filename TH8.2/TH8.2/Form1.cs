using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;


namespace TH8._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "";
            label5.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        void LoadFilm()
        {
                if (comboBox1.Text == "Oppenheimer")
                {
                    label4.Text = "Oppenheimer";
                }
                else if (comboBox1.Text == "Gintama: The Very Final")
                {
                    label4.Text = "Gintama: The Very Final";
                }
                else if (comboBox1.Text == "Spider Man No Way Home")
                {
                    label4.Text = "Spider Man No Way Home";
                }
                else if (comboBox1.Text == "Spider Man Into the Spider Verse")
                {
                    label4.Text = "Spider Man Into the Spider Verse";
                }
                else if (comboBox1.Text == "Cuộc phiêu lưu của ScooBy-Doo")
                {
                    label4.Text = "Cuộc phiêu lưu của ScooBy-Doo";
                }
                else
                {
                    label4.Text = "";
                }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = comboBox1.Text;
        }

        private void SeatA_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phim");
            }
            else
            {
                Button button = (Button)sender;
                if (button.BackColor == Color.PaleTurquoise)
                {
                    button.BackColor = Color.Green;
                    label5.Text = (double.Parse(label5.Text) + 25000).ToString();
                }
                else
                {
                    button.BackColor = Color.PaleTurquoise;
                    label5.Text = (double.Parse(label5.Text) - 25000).ToString();
                }
            }
        }

        private void SeatB_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phim");
            }
            else
            {
                Button button = (Button)sender;
                if (button.BackColor == Color.PaleGreen)
                {
                    button.BackColor = Color.Green;
                    label5.Text = (double.Parse(label5.Text) + 30000).ToString();
                }
                else
                {
                    button.BackColor = Color.PaleGreen;
                    label5.Text = (double.Parse(label5.Text) - 30000).ToString();
                }
            }
        }


        private void SeatC_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phim");
            }
            else
            {
                Button button = (Button)sender;
                if (button.BackColor == Color.LightGoldenrodYellow)
                {
                    button.BackColor = Color.Green;
                    label5.Text = (double.Parse(label5.Text) + 35000).ToString();
                }
                else
                {
                    button.BackColor = Color.LightGoldenrodYellow;
                    label5.Text = (double.Parse(label5.Text) - 35000).ToString();
                }
            }
        }


        private void SeatD_Click(object sender, EventArgs e)
        {
           if(comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phim");
            }
            else
            {
                Button button = (Button)sender;
                if (button.BackColor == Color.Plum)
                {
                    button.BackColor = Color.Green;
                    label5.Text = (double.Parse(label5.Text) + 40000).ToString();
                }
                else
                {
                    button.BackColor = Color.Plum;
                    label5.Text = (double.Parse(label5.Text) - 40000).ToString();
                }
            }
        }

        private void SeatE_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phim");
            }
            else
            {
                Button button = (Button)sender;
                if (button.BackColor == Color.Pink)
                {
                    button.BackColor = Color.Green;
                    label5.Text = (double.Parse(label5.Text) + 50000).ToString();
                }
                else
                {
                    button.BackColor = Color.Pink;
                    label5.Text = (double.Parse(label5.Text) - 50000).ToString();
                }
            }
           
        }


        private void SeatF_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phim");
            }
            else
            {
                Button button = (Button)sender;
                if (button.BackColor == Color.LavenderBlush)
                {
                    button.BackColor = Color.Green;
                    label5.Text = (double.Parse(label5.Text) + 45000).ToString();
                }
                else
                {
                    button.BackColor = Color.LavenderBlush;
                    label5.Text = (double.Parse(label5.Text) - 45000).ToString();
                }
            }
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

                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Thực hiện chọn phim nào thì thể hiện phòng chiếu của phim đó ở thời điểm hiện tại (ghế đã bán thì hiển thị màu xanh lá, ghế còn trống màu ban đầu)



    }
}
