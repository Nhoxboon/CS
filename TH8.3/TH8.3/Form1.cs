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

namespace TH8._3
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-7EEJR3H;Initial Catalog=QuanLyBH;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
            LoadData();
            LoadDataComboBox();
        }

        private void LoadData()
        {
            sqlConnection.Open();
            string query = "SELECT * FROM DONHANG";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void LoadDataComboBox()
        {
            sqlConnection.Open();
            string query = "SELECT * FROM MatHang";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            txtTHang.DataSource = dataTable;
            txtTHang.DisplayMember = "TenHang";
            txtTHang.ValueMember = "DonGia";
            sqlConnection.Close();
        }

        private int InsertData()
        {
            sqlConnection.Open();
            string query = "INSERT INTO DONHANG (STT, MaDon, TenHang, SoLuong, DonGia, ThanhTien) VALUES (6, 6, '"+txtTHang.Text+"', 2, 255, 500)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            
            
            int row = command.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTHang.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            nbSLuong.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDGia.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTTien.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void txtTHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtDGia.Text = txtTHang.SelectedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             int check = InsertData();
            if(check > 0) 
            {
                MessageBox.Show("Thêm dữ liệu thành công");
                LoadData();
            }
            
        }
    }
}
