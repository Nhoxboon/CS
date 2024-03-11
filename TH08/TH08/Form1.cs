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
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-GLH3U47;Initial Catalog=Test1;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void LoadData()
        {
            try
            {
                sqlConnection.Open();
                string query = "SELECT * FROM SinhVien";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void dataGridViewSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị dữ liệu tại dòng đang chọn lên các Controls tương ứng
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells["MaSV"].Value.ToString();
                textBox3.Text = row.Cells["HoTen"].Value.ToString();
                dateTimePicker2.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                string noiSinh = row.Cells["NoiSinh"].Value.ToString();
                comboBox2.SelectedItem = noiSinh;
                radioButton3.Checked = Convert.ToBoolean(row.Cells["GioiTinh"].Value);
                radioButton4.Checked = !Convert.ToBoolean(row.Cells["GioiTinh"].Value);
            }
        }


        }
    }
