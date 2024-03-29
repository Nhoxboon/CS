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

namespace ScoobyDoo
{
    public partial class Form3 : Form
    {
        SqlDataAdapter adapter;
        DataTable dataTable;
        DataSet dataset;
        BindingSource bs;
        SqlCommand cmd;


        public Form3()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            LoadData();
            LoadMaSo();
            LoadTenSV();
        }

        void LoadData()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLySVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select Mon.TenMH, KetQua.Diem From Mon Inner Join KetQua On Mon.MaMH = KetQua.MaMH";
                adapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        void LoadMaSo()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLySVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select MaSo from SinhVien";
                cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["MaSo"].ToString());
                }
            }
        }

        void LoadTenSV()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLySVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select HoTen from SinhVien";
                cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["HoTen"].ToString());
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLySVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select HoTen From SinhVien Where MaSo = @MaSo";
                SqlCommand cmd1 = new SqlCommand(query, connection);
                cmd1.Parameters.AddWithValue("@MaSo", comboBox1.Text);
                SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Text = dr["HoTen"].ToString();
                }
                dr.Close();

                string query1 = "SELECT SinhVien.MaKhoa, Khoa.TenKhoa FROM SinhVien INNER JOIN Khoa ON SinhVien.MaKhoa = Khoa.MaKhoa WHERE MaSo = @MaSo";
                SqlCommand cmd2 = new SqlCommand(query1, connection);
                cmd2.Parameters.AddWithValue("@MaSo", comboBox1.Text);
                SqlDataReader dr1 = cmd2.ExecuteReader();
                while (dr1.Read())
                {
                    textBox1.Text = dr1["TenKhoa"].ToString();
                }
                dr1.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLySVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select MaSo From SinhVien Where HoTen = @HoTen";
                SqlCommand cmd1 = new SqlCommand(query, connection);
                cmd1.Parameters.AddWithValue("@HoTen", comboBox2.Text);
                SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Text = dr["MaSo"].ToString();
                }
                dr.Close();

                string query1 = "SELECT SinhVien.MaKhoa, Khoa.TenKhoa FROM SinhVien INNER JOIN Khoa ON SinhVien.MaKhoa = Khoa.MaKhoa WHERE HoTen = @HoTen";
                SqlCommand cmd2 = new SqlCommand(query1, connection);
                cmd2.Parameters.AddWithValue("@HoTen", comboBox2.Text);
                SqlDataReader dr1 = cmd2.ExecuteReader();
                while (dr1.Read())
                {
                    textBox1.Text = dr1["TenKhoa"].ToString();
                }
                dr1.Close();
            }
        }


        //Lọc datagridview theo combobox và textbox
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLySVien;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select Mon.TenMH, KetQua.Diem From Mon Inner Join KetQua On Mon.MaMH = KetQua.MaMH Where MaSo = @MaSo";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaSo", comboBox1.Text);
                adapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }    
        }
    }
}
