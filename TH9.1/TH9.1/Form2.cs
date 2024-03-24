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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TH9._1
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyTruyenTranh;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
            LoadData();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            double a;
            if(double.TryParse(textBox2.Text, out a))
            { }
            else
            {
                MessageBox.Show("Vui lòng nhập số");
                textBox2.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Doraemon")
            {
                textBox3.Text = "10000";
            }
            else if (comboBox1.Text == "Danmachi")
            {
                textBox3.Text = "20000";
            }
            else if (comboBox1.Text == "Frieren")
            {
                textBox3.Text = "30000";
            }
            else if (comboBox1.Text == "Oregairu")
            {
                textBox3.Text = "40000";
            }
            else if (comboBox1.Text == "Hắc quản gia")
            {
                textBox3.Text = "50000";
            }
            else
            {
                textBox3.Text = "0";
            }
        }

        private void LoadData()
        {
            dataGridView1.Columns.Clear();
            if(sqlConnection.State == ConnectionState.Open) 
            {
                sqlConnection.Close();
            }
            sqlConnection.Open();
            string query = "Select * from MuonTruyen";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        //Mượn truyện
        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string getMaxSTTQuery = "SELECT ISNULL(MAX(STT), 0) FROM MuonTruyen";
            SqlCommand getMaxSTTCmd = new SqlCommand(getMaxSTTQuery, sqlConnection);
            int maxSTT = (int)getMaxSTTCmd.ExecuteScalar();
            string query = "INSERT INTO MuonTruyen (STT, [Tên Khách], [Số Điện Thoại], [Tên Truyện], [Ngày Mượn], [Ngày Trả], [Thành Tiền], [Ghi Chú]) VALUES (@STT, @TenKhach, @SoDienThoai, @TenTruyen, @NgayMuon, @NgayTra, @ThanhTien, @GhiChu)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@STT", maxSTT + 1);
            cmd.Parameters.AddWithValue("@TenKhach", textBox1.Text);
            cmd.Parameters.AddWithValue("@SoDienThoai", textBox2.Text);
            cmd.Parameters.AddWithValue("@TenTruyen", comboBox1.Text);
            cmd.Parameters.AddWithValue("@NgayMuon", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@NgayTra", DBNull.Value);
            cmd.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            cmd.Parameters.AddWithValue("@GhiChu", "Chưa trả");
            cmd.ExecuteNonQuery();
            LoadData();
            sqlConnection.Close();
        }

        //Trả truyện
        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            DateTime ngaymuon = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime ngaytra = Convert.ToDateTime(dateTimePicker2.Text);
            TimeSpan time = ngaytra - ngaymuon;
            int songay = time.Days;

            string query = "UPDATE MuonTruyen SET [Ngày Trả] = @NgayTra, [Thành Tiền] = @ThanhTien, [Ghi Chú] = @GhiChu WHERE STT = @STT";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@STT", dataGridView1.CurrentRow.Cells["STT"].Value);
            cmd.Parameters.AddWithValue("@NgayTra", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@ThanhTien", songay * double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cmd.ExecuteNonQuery();

            LoadData();
            sqlConnection.Close();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Tên Khách"].Value?.ToString();
                textBox2.Text = row.Cells["Số Điện Thoại"].Value?.ToString();
                comboBox1.Text = row.Cells["Tên Truyện"].Value?.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Ngày Mượn"].Value);
                if (row.Cells["Ngày Trả"].Value == DBNull.Value && row.Cells["Ngày Trả"].Value == null)
                {
                    dateTimePicker2.Value = Convert.ToDateTime(row.Cells["Ngày Trả"].Value);
                }

            }
        }
    }
}
