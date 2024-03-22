using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TH08
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=QuanLySinhVienDB;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
            LoadData();
            LoadDataComboBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection.Open();
            string query = "SELECT * FROM SinhVien";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
            
        }
        private void LoadDataComboBox()
        {
            sqlConnection.Open();
            string query = "SELECT * FROM TinhThanh";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            comboBox2.DataSource = dataTable;
            comboBox2.DisplayMember = "NoiSinh";
            sqlConnection.Close();
        }

        private void dataGridViewSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells["MaSV"].Value.ToString();
                textBox3.Text = row.Cells["HoTen"].Value.ToString();
                dateTimePicker2.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                string noiSinh = row.Cells["NoiSinh"].Value.ToString();
                comboBox2.SelectedItem = noiSinh;
                radioButton4.Checked = Convert.ToBoolean(row.Cells["GioiTinh"].Value);
                
            }
        }


        //Thêm
        private void button8_Click(object sender, EventArgs e)
        {
            
                sqlConnection.Open();
                string query = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, NoiSinh, GioiTinh) VALUES (@MaSV, @HoTen, @NgaySinh, @NoiSinh, @GioiTinh)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@MaSV", textBox4.Text);
                cmd.Parameters.AddWithValue("@HoTen", textBox3.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@NoiSinh", comboBox2.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", radioButton4.Checked);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
                LoadData();
                sqlConnection.Close();
        }

        //Sửa
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    sqlConnection.Open();
                    string query = "UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, NoiSinh = @NoiSinh, GioiTinh = @GioiTinh WHERE MaSV = @MaSV";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@MaSV", textBox4.Text);
                    cmd.Parameters.AddWithValue("@HoTen", textBox3.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@NoiSinh", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", radioButton4.Checked);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.");
            }
        }

        //Xóa
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    sqlConnection.Open();
                    string maSV = dataGridView1.SelectedRows[0].Cells["MaSV"].Value.ToString();
                    string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@MaSV", maSV);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
            }
        }

        //Lọc
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                string query = "SELECT * FROM SinhVien WHERE MaSV = @MaSV OR NoiSinh = @NoiSinh";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@MaSV", textBox4.Text);
                cmd.Parameters.AddWithValue("@NoiSinh", comboBox2.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Dành cho cả 2 radio button
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton3.Checked = !radioButton4.Checked;
        }
    }
}
