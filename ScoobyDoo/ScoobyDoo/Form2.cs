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

namespace ScoobyDoo
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QuanLySVien;Integrated Security=True");

        SqlDataAdapter adapter;
        DataSet dataset;
        BindingSource bs;
        SqlCommand cmd;

        public Form2()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            //LoadData();
        }

        void LoadData()
        {
            sqlConnection.Open();
            string query = "Select * from Khoa";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            dataGridView1.DataSource = datatable;
            sqlConnection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string query = "Select * from Khoa";
            adapter = new SqlDataAdapter(query, sqlConnection);
            dataset = new DataSet();
            adapter.Fill(dataset);
            bs = new BindingSource();
            bs.DataSource = dataset.Tables[0].DefaultView;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataset.Tables[0].NewRow();

            newRow["MaKhoa"] = textBox1.Text;
            newRow["TenKhoa"] = textBox2.Text;

            dataset.Tables[0].Rows.Add(newRow);

            dataGridView1.DataSource = dataset.Tables[0];
            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ít nhất một dòng được chọn không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy chỉ mục của dòng được chọn đầu tiên
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Xóa dòng được chọn từ BindingSource
                bs.RemoveAt(selectedRowIndex);
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[dataGridView1.Rows.Count - 1].IsNewRow)
            {
                dataGridView1.EndEdit();

                sqlConnection.Open();

                // Tạo và thiết lập câu lệnh SQL
                string insertQuery = "INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES (@MaKhoa, @TenKhoa)";

                // Thực thi câu lệnh SQL cho mỗi hàng mới trong DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Lấy giá trị của cột MaKhoa và TenKhoa từ DataGridView
                        string maKhoa = Convert.ToString(row.Cells["MaKhoa"].Value);
                        string tenKhoa = Convert.ToString(row.Cells["TenKhoa"].Value);

                        // Kiểm tra xem MaKhoa đã tồn tại trong cơ sở dữ liệu chưa
                        string checkQuery = "SELECT COUNT(*) FROM Khoa WHERE MaKhoa = @MaKhoa";
                        SqlCommand checkCmd = new SqlCommand(checkQuery, sqlConnection);
                        checkCmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        // Nếu MaKhoa chưa tồn tại, thêm mới dữ liệu vào cơ sở dữ liệu
                        if (count == 0)
                        {
                            SqlCommand insertCmd = new SqlCommand(insertQuery, sqlConnection);
                            insertCmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                            insertCmd.Parameters.AddWithValue("@TenKhoa", tenKhoa);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                sqlConnection.Close();
            }

            // Kiểm tra xem có hàng được xóa không
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới

                if (row.Cells["MaKhoa"].Value == null && row.Cells["TenKhoa"].Value == null)
                {
                    string maKhoa = Convert.ToString(row.Cells["MaKhoa"].Value);

                    string deleteQuery = "DELETE FROM Khoa WHERE MaKhoa = @MaKhoa";

                    sqlConnection.Open();

                    // Thực thi câu lệnh SQL để xóa dữ liệu
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, sqlConnection);
                    deleteCmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    deleteCmd.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
        }

    }
}
