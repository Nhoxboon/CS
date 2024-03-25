using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH9._3
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanInternet;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
            dataGridView1.Columns.Clear();
            LoadData();
        }

        private void LoadData()
        {
            if(sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection.Open();
            string query = "Select * from ThongKe";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.BackColor == Color.Red)
            {
                MessageBox.Show("Máy đang được sử dụng, hãy chọn máy khác");
            }
            btn.BackColor = Color.Red;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int a;
            if(int.TryParse(textBox.Text, out a))
            {
                
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số nguyên");
                textBox.Focus();
            }    
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox11.Text = ((Convert.ToInt32(textBox6.Text) - Convert.ToInt32(textBox1.Text)) * 5000).ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox12.Text = ((Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox2.Text)) * 5000).ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox13.Text = ((Convert.ToInt32(textBox8.Text) - Convert.ToInt32(textBox3.Text)) * 5000).ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox14.Text = ((Convert.ToInt32(textBox9.Text) - Convert.ToInt32(textBox4.Text)) * 5000).ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = ((Convert.ToInt32(textBox10.Text) - Convert.ToInt32(textBox5.Text)) * 5000).ToString();
        }


        private void ThanhToanM1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Red)
            {
                button1.BackColor = SystemColors.ButtonShadow;
                sqlConnection.Open();
                string STTmax = "Select Isnull(Max(STT), 0) From ThongKe";
                SqlCommand getSTTmaxcmd = new SqlCommand(STTmax, sqlConnection);
                int maxSTT = (int)getSTTmaxcmd.ExecuteScalar();
                string query = "Insert Into ThongKe(STT, [Số máy], [Giờ vào], [Giờ ra], [Số giờ sử dụng], [Đơn giá/giờ], [Thành tiền]) Values (@STT, @Somay, @Giovao, @Giora, @Sogiosudung, @Dongiagio, @Thanhtien)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@STT", maxSTT + 1);
                cmd.Parameters.AddWithValue("@Somay", "Máy 1");
                cmd.Parameters.AddWithValue("@Giovao", textBox1.Text);
                cmd.Parameters.AddWithValue("@Giora", textBox6.Text);
                cmd.Parameters.AddWithValue("@Sogiosudung", Convert.ToInt32(textBox6.Text) - Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@Dongiagio", "5000đ/giờ");
                cmd.Parameters.AddWithValue("@Thanhtien", textBox11.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                LoadData();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn máy");
            }    
        }

        private void ThanhToanM2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Red)
            {
                button2.BackColor = SystemColors.ButtonShadow;
                sqlConnection.Open();
                string STTmax = "Select Isnull(Max(STT), 0) From ThongKe";
                SqlCommand getSTTmaxcmd = new SqlCommand(STTmax, sqlConnection);
                int maxSTT = (int)getSTTmaxcmd.ExecuteScalar();
                string query = "Insert Into ThongKe(STT, [Số máy], [Giờ vào], [Giờ ra], [Số giờ sử dụng], [Đơn giá/giờ], [Thành tiền]) Values (@STT, @Somay, @Giovao, @Giora, @Sogiosudung, @Dongiagio, @Thanhtien)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@STT", maxSTT + 1);
                cmd.Parameters.AddWithValue("@Somay", "Máy 2");
                cmd.Parameters.AddWithValue("@Giovao", textBox2.Text);
                cmd.Parameters.AddWithValue("@Giora", textBox7.Text);
                cmd.Parameters.AddWithValue("@Sogiosudung", Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox2.Text));
                cmd.Parameters.AddWithValue("@Dongiagio", "5000đ/giờ");
                cmd.Parameters.AddWithValue("@Thanhtien", textBox12.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                LoadData();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn máy");
            }
        }

        private void ThanhToanM3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Red)
            {
                button3.BackColor = SystemColors.ButtonShadow;
                sqlConnection.Open();
                string STTmax = "Select Isnull(Max(STT), 0) From ThongKe";
                SqlCommand getSTTmaxcmd = new SqlCommand(STTmax, sqlConnection);
                int maxSTT = (int)getSTTmaxcmd.ExecuteScalar();
                string query = "Insert Into ThongKe(STT, [Số máy], [Giờ vào], [Giờ ra], [Số giờ sử dụng], [Đơn giá/giờ], [Thành tiền]) Values (@STT, @Somay, @Giovao, @Giora, @Sogiosudung, @Dongiagio, @Thanhtien)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@STT", maxSTT + 1);
                cmd.Parameters.AddWithValue("@Somay", "Máy 3");
                cmd.Parameters.AddWithValue("@Giovao", textBox3.Text);
                cmd.Parameters.AddWithValue("@Giora", textBox8.Text);
                cmd.Parameters.AddWithValue("@Sogiosudung", Convert.ToInt32(textBox8.Text) - Convert.ToInt32(textBox3.Text));
                cmd.Parameters.AddWithValue("@Dongiagio", "5000đ/giờ");
                cmd.Parameters.AddWithValue("@Thanhtien", textBox13.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                LoadData();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn máy");
            }
        }

        private void ThanhToanM4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Red)
            {
                button4.BackColor = SystemColors.ButtonShadow;
                sqlConnection.Open();
                string STTmax = "Select Isnull(Max(STT), 0) From ThongKe";
                SqlCommand getSTTmaxcmd = new SqlCommand(STTmax, sqlConnection);
                int maxSTT = (int)getSTTmaxcmd.ExecuteScalar();
                string query = "Insert Into ThongKe(STT, [Số máy], [Giờ vào], [Giờ ra], [Số giờ sử dụng], [Đơn giá/giờ], [Thành tiền]) Values (@STT, @Somay, @Giovao, @Giora, @Sogiosudung, @Dongiagio, @Thanhtien)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@STT", maxSTT + 1);
                cmd.Parameters.AddWithValue("@Somay", "Máy 4");
                cmd.Parameters.AddWithValue("@Giovao", textBox4.Text);
                cmd.Parameters.AddWithValue("@Giora", textBox9.Text);
                cmd.Parameters.AddWithValue("@Sogiosudung", Convert.ToInt32(textBox9.Text) - Convert.ToInt32(textBox4.Text));
                cmd.Parameters.AddWithValue("@Dongiagio", "5000đ/giờ");
                cmd.Parameters.AddWithValue("@Thanhtien", textBox14.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                LoadData();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn máy");
            }
        }

        private void ThanhToanM5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Red)
            {
                button5.BackColor = SystemColors.ButtonShadow;
                sqlConnection.Open();
                string STTmax = "Select Isnull(Max(STT), 0) From ThongKe";
                SqlCommand getSTTmaxcmd = new SqlCommand(STTmax, sqlConnection);
                int maxSTT = (int)getSTTmaxcmd.ExecuteScalar();
                string query = "Insert Into ThongKe(STT, [Số máy], [Giờ vào], [Giờ ra], [Số giờ sử dụng], [Đơn giá/giờ], [Thành tiền]) Values (@STT, @Somay, @Giovao, @Giora, @Sogiosudung, @Dongiagio, @Thanhtien)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@STT", maxSTT + 1);
                cmd.Parameters.AddWithValue("@Somay", "Máy 5");
                cmd.Parameters.AddWithValue("@Giovao", textBox5.Text);
                cmd.Parameters.AddWithValue("@Giora", textBox10.Text);
                cmd.Parameters.AddWithValue("@Sogiosudung", Convert.ToInt32(textBox10.Text) - Convert.ToInt32(textBox5.Text));
                cmd.Parameters.AddWithValue("@Dongiagio", "5000đ/giờ");
                cmd.Parameters.AddWithValue("@Thanhtien", textBox15.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                LoadData();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn máy");
            }
        }
    }
}
