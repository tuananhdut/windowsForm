using Mo_hinh_3_layer.BLL;
using Mo_hinh_3_layer.DAL;
using Mo_hinh_3_layer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mo_hinh_3_layer.VIEW
{
    public partial class Fmain : Form
    {
        public Fmain()
        {
            InitializeComponent();
            SetCBBLSH();
            QLSVBLL bll = new QLSVBLL();
            dataGridView1.DataSource = bll.GetSVByIDLop(0);
        }

        private void SetCBBLSH()
        {
            QLSVBLL bll = new QLSVBLL();
            comboBox1.Items.AddRange(bll.GetCBB().ToArray());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_lop = ((CBBItem)comboBox1.SelectedItem).Value;
            QLSVBLL bll = new QLSVBLL();
            dataGridView1.DataSource = bll.GetSVByIDLop(id_lop);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            int id_lop = ((CBBItem)comboBox1.SelectedItem).Value;
            string s = tbSearch.Text;
            QLSVBLL bll = new QLSVBLL();
            dataGridView1.DataSource = bll.GetSVSearch(s, id_lop);
        }

        private void btADD_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
            QLSVBLL bll = new QLSVBLL();
            dataGridView1.DataSource = bll.GetSVByIDLop(0);
        }

        private void btDEL_Click(object sender, EventArgs e)
        {
           if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string m = i.Cells[0].Value.ToString();
                    QLSVBLL bll = new QLSVBLL();
                    bll.DelSVBLL(m);
                    dataGridView1.DataSource = bll.GetSVByIDLop(0);
                }
                
            }
            
        }

        private void btEDIT_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            
            DataGridViewRow row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
            string m = row.Cells[0].Value.ToString();

            f1.setform(m);
            f1.ShowDialog();


            QLSVBLL bll = new QLSVBLL();
            dataGridView1.DataSource = bll.GetSVByIDLop(0);
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            int index = cbbSort.SelectedIndex;
            QLSVBLL bll = new QLSVBLL();
           
            dataGridView1.DataSource = bll.sort(index);
        }
    }
}
