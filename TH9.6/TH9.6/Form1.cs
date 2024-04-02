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

namespace TH9._6
{
    public partial class Form1 : Form
    {
        SqlDataAdapter adapter;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        int tongTien = 0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            LoadData();
            LoadHQ();
        }

        private void LoadData()
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QLCHHoaQua;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select * From DonHang";
                adapter = new SqlDataAdapter(query, sql);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void LoadHQ()
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QLCHHoaQua;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select * From LoaiHQ";
                cmd = new SqlCommand(query, sql);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Loai";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QLCHHoaQua;Integrated Security=True"))
            {
                sql.Open();
                string query = "Select DGia From LoaiHQ Where Loai = @Loai";
                cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@Loai", comboBox1.Text);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["DGia"].ToString();
                }
            }
        }


        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox4.Text = (int.Parse(textBox3.Text) - int.Parse(textBox2.Text)).ToString();
        }

        /*//Them
        private void button1_Click(object sender, EventArgs e)
        {
            int thanhTien = int.Parse(textBox1.Text) * (int)numericUpDown1.Value;
            dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, comboBox1.Text, textBox1.Text, numericUpDown1.Value, thanhTien);
            tongTien = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                tongTien += int.Parse(row.Cells[4].Value.ToString());
            }
            textBox2.Text = tongTien.ToString();
        }

        //Xoa
        private void button2_Click(object sender, EventArgs e)
        {
            int thanhTien = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            tongTien -= thanhTien;
            textBox2.Text = tongTien.ToString();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
                numericUpDown1.Value = int.Parse(row.Cells[3].Value.ToString());
            }
        }

        //Luu
        private void button3_Click(object sender, EventArgs e)
        {
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                MessageBox.Show("Lưu thành công");
                dataGridView1.Rows.Clear();
                textBox2.Text = "";
        }*/


        //Them
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QLCHHoaQua;Integrated Security=True"))
            {
                sql.Open();
                string query = "Insert Into DonHang(STT, Ten, DonGia, SLuong, ThanhTien) Values(@STT, @Ten, @DonGia, @SLuong, @ThanhTien)";
                cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@STT", dataGridView1.Rows.Count + 1);
                cmd.Parameters.AddWithValue("@Ten", comboBox1.Text);
                cmd.Parameters.AddWithValue("@DonGia", textBox1.Text);
                cmd.Parameters.AddWithValue("@SLuong", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@ThanhTien", int.Parse(textBox1.Text) * (int)numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                LoadData();
                tongTien = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    tongTien += int.Parse(row.Cells[4].Value.ToString());
                }
                textBox2.Text = tongTien.ToString();
            }
        }

        //Xoa
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QLCHHoaQua;Integrated Security=True"))
            {
                sql.Open();
                string query = "Delete From DonHang Where STT = @STT";
                cmd = new SqlCommand(query, sql);
                cmd.Parameters.AddWithValue("@STT", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                LoadData();
                tongTien = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    tongTien -= int.Parse(row.Cells[4].Value.ToString());
                }
                textBox2.Text = tongTien.ToString();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["Ten"].Value.ToString();
                textBox1.Text = row.Cells["DonGia"].Value.ToString();
                numericUpDown1.Value = int.Parse(row.Cells["SLuong"].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QLCHHoaQua;Integrated Security=True"))
            {
                sql.Open();
                string query = "Delete From DonHang";
                cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }
    }
}
