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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TH9._4
{
    public partial class Form1 : Form
    {
        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanCafe;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            LoadData();
            LoadDoUong();
        }

        void LoadData()
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select * From ThongTin";
                adapter = new SqlDataAdapter(query, sql);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        void LoadDoUong()
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select * From DoUong";
                cmd = new SqlCommand(query, sql);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "TenDouong";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select Gia From DoUong Where TenDouong = @TenDouong";
                cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@TenDouong", comboBox2.Text);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr["Gia"].ToString();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["Soban"].Value.ToString();
                comboBox2.Text = row.Cells["TenDouong"].Value.ToString();
                textBox1.Text = row.Cells["Ghichu"].Value.ToString();
                numericUpDown1.Value = Convert.ToDecimal(row.Cells["Soluong"].Value);
                textBox3.Text = row.Cells["Thanhtien"].Value.ToString();
            }
        }

        //Thêm 
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                sql.Open();
                string query = "Insert Into ThongTin(Soban, TenDouong, Ghichu, Soluong, Thanhtien) Values (@Soban, @TenDouong, @Ghichu, @Soluong, @Thanhtien)";
                cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@Soban", comboBox1.Text);
                cmd.Parameters.AddWithValue("TenDouong", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Ghichu", textBox1.Text);
                cmd.Parameters.AddWithValue("@Soluong", Convert.ToString(numericUpDown1.Value));
                textBox3.Text = ((int.Parse(textBox2.Text)) * numericUpDown1.Value).ToString();
                cmd.Parameters.AddWithValue("@Thanhtien", int.Parse(textBox3.Text));
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        //Sửa
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                sql.Open();
                string query = "Update ThongTin Set Soban = @Soban, TenDouong = @TenDouong, Ghichu = @Ghichu, Soluong = @Soluong, Thanhtien = @Thanhtien";
                cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@Soban", comboBox1.Text);
                cmd.Parameters.AddWithValue("TenDouong", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Ghichu", textBox1.Text);
                cmd.Parameters.AddWithValue("@Soluong", Convert.ToString(numericUpDown1.Value));
                textBox3.Text = ((int.Parse(textBox2.Text)) * numericUpDown1.Value).ToString();
                cmd.Parameters.AddWithValue("@Thanhtien", int.Parse(textBox3.Text));
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        //Xóa
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyQuanCafe;Integrated Security=True"))
            {
                sql.Open();
                string query = "Delete From ThongTin Where @Soban = Soban";
                cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@Soban", comboBox1.Text);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
