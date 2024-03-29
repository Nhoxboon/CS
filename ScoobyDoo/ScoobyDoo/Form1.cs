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
using System.ComponentModel.Design.Serialization;

namespace ScoobyDoo
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-GLH3U47;Initial Catalog=QLSVien;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }
    }
}
