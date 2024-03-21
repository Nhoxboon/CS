using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH9._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtDGia_Leave(object sender, EventArgs e)
        {
            int a;
            if(int.TryParse(txtDGia.Text, out a))
            {
                if(a < 0)
                {
                    MessageBox.Show("Vui lòng nhập số dương");
                    txtDGia.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số");
                txtDGia.Focus();
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            rbDB.Checked = !rbXT.Checked;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtKH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dTPMua.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Để bàn")
                rbDB.Checked = true;
            else
                rbXT.Checked = true;
            txtTenMay.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDGia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            nbSL.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void Delete()
        {
            txtMa.Clear();
            txtKH.Clear();
            dTPMua.Value = DateTime.Now;
            txtTenMay.Clear();
            txtDGia.Clear();
            nbSL.Value = 0;
        }
        //Thêm
        private void btThem_Click(object sender, EventArgs e)
        {
            if(rbDB.Checked)
            {
                dataGridView1.Rows.Add(txtMa.Text, txtKH.Text, dTPMua.Text, "Để bàn", txtTenMay.Text, txtDGia.Text, nbSL.Value, Convert.ToInt32(txtDGia.Text) * Convert.ToInt32(nbSL.Value));
            }
            else
            {
                dataGridView1.Rows.Add(txtMa.Text, txtKH.Text, dTPMua.Text, "Xách tay", txtTenMay.Text, txtDGia.Text, nbSL.Value, Convert.ToInt32(txtDGia.Text) * Convert.ToInt32(nbSL.Value));
            }
            Delete();
        }

        //Sửa
        private void btSua_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Cells[0].Value = txtMa.Text;
            dataGridView1.CurrentRow.Cells[1].Value = txtKH.Text;
            dataGridView1.CurrentRow.Cells[2].Value = dTPMua.Text;
            if (rbDB.Checked)
                dataGridView1.CurrentRow.Cells[3].Value = "Để bàn";
            else
                dataGridView1.CurrentRow.Cells[3].Value = "Xách tay";
            dataGridView1.CurrentRow.Cells[4].Value = txtTenMay.Text;
            dataGridView1.CurrentRow.Cells[5].Value = txtDGia.Text;
            dataGridView1.CurrentRow.Cells[6].Value = nbSL.Value;
            dataGridView1.CurrentRow.Cells[7].Value = Convert.ToInt32(txtDGia.Text) * Convert.ToInt32(nbSL.Value);
        }

        //Xóa
        private void btXoa_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        //Đóng
        private void btDong_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }
    }
}
