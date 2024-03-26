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
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-7EEJR3H;Initial Catalog=QLSVien;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            LoadData();
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

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
    }
}
