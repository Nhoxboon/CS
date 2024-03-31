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
using System.Data.Common;

namespace TH9._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            LoadData();
            LoadQueQuan();
        }

        private void LoadData()
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=QLBacSi;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select * From ThongTin";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sql);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void LoadQueQuan()
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=QLBacSi;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select * From QQuan";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Ten";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["HoTen"].Value.ToString();
                if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                }
                comboBox1.Text = row.Cells["QueQuan"].Value.ToString();
                listBox1.ClearSelected();
                string[] chucdanh = row.Cells["ChucDanh"].Value.ToString().Split('.');
                foreach (string item in chucdanh)
                {
                    listBox1.SelectedItems.Add(item);
                }
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            }
        }


        //Thêm
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=QLBacSi;Integrated Security=True"))
            {
                sql.Open();
                string query = "Insert Into ThongTin(HoTen, GioiTinh, QueQuan, ChucDanh, NgaySinh) Values (@HoTen, @GioiTinh, @QueQuan, @ChucDanh, @NgaySinh)";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                if(radioButton1.Checked)
                {
                    cmd.Parameters.AddWithValue("@GioiTinh", "Nam");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GioiTinh", "Nữ");
                }

                cmd.Parameters.AddWithValue("@QueQuan", comboBox1.Text);
                if(listBox1.SelectedItems.Count > 1)
                {
                    cmd.Parameters.AddWithValue("@ChucDanh", string.Join(".", listBox1.SelectedItems.Cast<string>().ToArray()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ChucDanh", listBox1.SelectedItem.ToString());
                }
                cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker1.Value.Date);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }


        //Sửa
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=QLBacSi;Integrated Security=True"))
            {
                sql.Open();
                string query = "Update ThongTin Set HoTen = @HoTen, GioiTinh = @GioiTinh, QueQuan = @QueQuan, ChucDanh = @ChucDanh, NgaySinh = @NgaySinh Where HoTen = @HoTen And QueQuan = @QueQuan And ChucDanh = @ChucDanh";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                if(radioButton1.Checked)
                {
                    cmd.Parameters.AddWithValue("@GioiTinh", "Nam");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GioiTinh", "Nữ");
                }
                cmd.Parameters.AddWithValue("@QueQuan", comboBox1.Text);

                if(listBox1.SelectedItems.Count > 1)
                {
                    cmd.Parameters.AddWithValue("@ChucDanh", string.Join(".", listBox1.SelectedItems.Cast<string>().ToArray()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ChucDanh", listBox1.SelectedItem.ToString());
                }
                cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker1.Value.Date);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        //Xóa
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=QLBacSi;Integrated Security=True"))
            {
                sql.Open();
                string query = "Delete From ThongTin where HoTen = @HoTen and QueQuan = @QueQuan and ChucDanh = @ChucDanh";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                cmd.Parameters.AddWithValue("@QueQuan", comboBox1.Text);
                if (listBox1.SelectedItems.Count > 1)
                {
                    cmd.Parameters.AddWithValue("@ChucDanh", string.Join(".", listBox1.SelectedItems.Cast<string>().ToArray()));
                }
                else
                {
                    if (listBox1.SelectedItem != null)
                    {
                        cmd.Parameters.AddWithValue("@ChucDanh", listBox1.SelectedItem.ToString());
                    }
                    else
                    {
                        // Handle the case where no item is selected
                    }
                }
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        //Lọc
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=QLBacSi;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select * From ThongTin Where ChucDanh = @ChucDanh";
                SqlCommand cmd = new SqlCommand(query, sql);
                if(listBox1.SelectedItems.Count > 1)
                {
                    cmd.Parameters.AddWithValue("@ChucDanh", string.Join(".", listBox1.SelectedItems.Cast<string>().ToArray()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ChucDanh", listBox1.SelectedItem.ToString());
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;            
            }
        }
    }
}
