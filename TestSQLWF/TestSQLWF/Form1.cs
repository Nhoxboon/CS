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

namespace TestSQLWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7EEJR3H;Initial Catalog=Test1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from HOPDONG", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show(dr["SOHD"].ToString() + dr["MAK"].ToString() + dr["NGAYBATDAU"].ToString());
                
                
            }
        }
    }
}
