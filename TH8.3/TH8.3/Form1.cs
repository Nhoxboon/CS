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
            //LoadData();
            //LoadDataComboBox();
        }

        private void LoadData()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
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

        private int InsertData( string tenK, string tenH, string SL, string DGia, string TTien, int mDH)
        {
            
            sqlConnection.Open();
            string query = "INSERT INTO DONHANG (STT, TenKH, TenHang, SoLuong, DonGia, ThanhTien) VALUES (@STT, @TenKH, @TenHang, @SoLuong, @DonGia, @ThanhTien)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@STT", mDH);
            command.Parameters.AddWithValue("@TenKH", tenK);
            command.Parameters.AddWithValue("@TenHang", tenH);
            command.Parameters.AddWithValue("@SoLuong", SL);
            command.Parameters.AddWithValue("@DonGia", DGia);
            command.Parameters.AddWithValue("@ThanhTien", TTien);
            
            int row = command.ExecuteNonQuery();
            sqlConnection.Close();
            return row;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*txtKH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTHang.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            nbSLuong.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDGia.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTTien.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;
            txtDGia.Text = "";
            txtKH.Text = "";
            txtTTien.Text = "";
            nbSLuong.Text = "";
            txtTHang.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void txtTHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(txtTHang.SelectedIndex > 0)
            {
                txtDGia.Text = txtTHang.SelectedValue.ToString();
            }*/

            if(txtTHang.Text == "Bút")
            {
                txtDGia.Text = "5000";
            }    
            else if(txtTHang.Text == "Bom")
            {
                txtDGia.Text = "2000";
            }
            else if(txtTHang.Text == "Thước")
            {
                txtDGia.Text = "10000";
            }
            else if(txtTHang.Text == "Tẩy")
            {
                txtDGia.Text = "3000";
            }
        }

        //Thêm
        private void button3_Click(object sender, EventArgs e)
        {
             /*int check = InsertData();
            if(check > 0) 
            {
                MessageBox.Show("Thêm dữ liệu thành công");
                LoadData();
            }*/
            
            dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, txtTHang.Text, nbSLuong.Text, txtDGia.Text, Convert.ToInt32(txtDGia.Text) * Convert.ToInt32(nbSLuong.Text)) ;
        }

        //Xóa
        private void button4_Click(object sender, EventArgs e)
        {
           /* sqlConnection.Open();
            string query = "DELETE FROM DONHANG WHERE STT = @STT";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@STT", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            int row = command.ExecuteNonQuery();
            if(row > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadData();
            }
            sqlConnection.Close();*/
        }
        int flag = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            double Tong = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    Tong += double.Parse(row.Cells[4].Value.ToString());
                }
                InsertData(txtKH.Text , row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), flag);
            }
            txtTTien.Text = Tong.ToString();
            
            flag++;

        }

        private void đổiMàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = contextMenuStrip1.SourceControl as Control;
            if (control != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    control.BackColor = colorDialog.Color;
                }

            }
        }
    }
}
