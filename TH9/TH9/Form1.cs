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

namespace TH9
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLyDiemThi;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
            //LoadData();
            //LoadDataPLoai();
            //LoadDataMaSV();
        }
        
        void LoadData()
        {
            dataGridView1.Columns.Clear();
            sqlConnection.Open();
            string query = "SELECT * FROM SinhVien";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        void LoadDataMaSV()
        {
            sqlConnection.Open();
            string query = "SELECT MaSV, HoTen FROM MASV";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            txtMaSV.DataSource = dataTable;
            txtMaSV.DisplayMember = "MaSV";
            sqlConnection.Close();
        }


        void LoadDataPLoai()
        {
            sqlConnection.Open();
            string query = "SELECT * FROM PhanLoai";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            txtPLoai.DataSource = dataTable;
            txtPLoai.DisplayMember = "LoaiHL";
            sqlConnection.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            double a;
            if(double.TryParse(txtDToan.Text, out a))
            {
                if( a >= 0 && a <= 10)
                {
                    
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDToan.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDVan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDNN.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        //Thêm
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtMaSV.Text, txtHoTen.Text, txtDToan.Text, txtDVan.Text, txtDNN.Text, (Double.Parse(txtDToan.Text) + Double.Parse(txtDVan.Text) + Double.Parse(txtDNN.Text)) / 3);
        }

        //Sửa
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Cells[2].Value = txtDToan.Text;
            dataGridView1.CurrentRow.Cells[3].Value = txtDVan.Text;
            dataGridView1.CurrentRow.Cells[4].Value = txtDNN.Text;
            dataGridView1.CurrentRow.Cells[5].Value = (Double.Parse(txtDToan.Text) + Double.Parse(txtDVan.Text) + Double.Parse(txtDNN.Text)) / 3;

        }

        //Xóa
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }


        private void txtMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtMaSV.Text == "SV01")
            {
                txtHoTen.Text = "Nguyễn Văn An";
            }
            else if(txtMaSV.Text == "SV02")
            {
                txtHoTen.Text = "Trần Thị Bưởi";
            }
            else if(txtMaSV.Text == "SV03")
            {
                txtHoTen.Text = "Lê Thị Cúc";
            }
            else if(txtMaSV.Text == "SV04")
            {
                txtHoTen.Text = "Phạm Văn Đồng";
            }
            else if(txtMaSV.Text == "SV05")
            {
                txtHoTen.Text = "Nguyễn Thị Hồng";
            }
            else if(txtMaSV.Text == "SV06")
            {
                txtHoTen.Text = "Trần Văn Hùng";
            }
            else if(txtMaSV.Text == "SV07")
            {
                txtHoTen.Text = "Lê Thị Lan";
            }
            else if(txtMaSV.Text == "SV08")
            {
                txtHoTen.Text = "Phạm Văn Minh";
            }
            else if(txtMaSV.Text == "SV09")
            {
                txtHoTen.Text = "Nguyễn Thị Nga";
            }
            else if(txtMaSV.Text == "SV10")
            {
                txtHoTen.Text = "Trần Văn Quý";
            }
        }

        private void btTKe_Click(object sender, EventArgs e)
        {
            if(txtPLoai.Text == "Giỏi")
            {
                dataGridView2.Rows.Clear();
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString())) >= 8)
                    {
                        dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString());
                    }
                }
            }
            else if(txtPLoai.Text == "Khá")
            {
                dataGridView2.Rows.Clear();
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString())) >= 6.5 && (Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString())) < 8)
                    {
                        dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString());
                    }
                }
            }
            else if(txtPLoai.Text == "Trung bình")
            {
                dataGridView2.Rows.Clear();
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString())) < 6.5)
                    {
                        dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString());
                    }
                }
            }
        }
    }
}
