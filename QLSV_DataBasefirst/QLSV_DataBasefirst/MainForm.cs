using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_DataBasefirst
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            setCBBLopSH();
            SetDTGV();
            setCBBSort();
            dtgv.DataSource = SetDTGV();
            //setCBBSort();
        }
        private void setCBBLopSH()
        {
            cbbLopSh.Items.Add(new CBBLopSH()
            {
                value = 0, text="ALL"
            });
            cbbLopSh.SelectedItem = cbbLopSh.Items[0];
            using (QLSV_DB db = new QLSV_DB())
            {
                foreach (Lop i in db.Lops)
                {
                    cbbLopSh.Items.Add(new CBBLopSH()
                    {
                        text = i.TenLop, value=i.MaLop
                    });
                }
            }
            
        }

        private List<SinhVien> SetDTGV()
        {
            List<SinhVien> x = new List<SinhVien>();
            int id_lop = ((CBBLopSH)cbbLopSh.SelectedItem).value;
            using (QLSV_DB db = new QLSV_DB())
            {
                if (id_lop == 0)
                {
                    x = db.SinhViens.Where(p => p.TenSV.Contains(tbSearch.Text)).ToList();
                }
                else
                {
                    x = db.SinhViens.Where(p => p.TenSV.Contains(tbSearch.Text) && p.MaLop == id_lop).ToList();
                }
            }
            return x;
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            int id_lop = ((CBBLopSH)cbbLopSh.SelectedItem).value;
            using(QLSV_DB db = new QLSV_DB())
            {
                if (id_lop == 0)
                {
                    dtgv.DataSource=db.SinhViens.Where(p=>p.TenSV.Contains(tbSearch.Text)).ToList();
                }
                else
                {
                    dtgv.DataSource = db.SinhViens.Where(p => p.TenSV.Contains(tbSearch.Text)  && p.MaLop==id_lop).ToList();
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dtgv.SelectedRows)
            {
            string mssv = i.Cells[0].Value.ToString();
                using (QLSV_DB db = new QLSV_DB())
                {
                    var s = db.SinhViens.Where(p => p.MaSV == mssv).FirstOrDefault();
                    db.SinhViens.Remove(s);
                    db.SaveChanges();
                }
            }
            dtgv.DataSource = SetDTGV();
        }

        private void btADD_Click(object sender, EventArgs e)
        {
            DetailForm f2 = new DetailForm();
            f2.ShowDialog();
            dtgv.DataSource = SetDTGV();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            DetailForm f2 = new DetailForm();
            DataGridViewRow i = dtgv.Rows[dtgv.CurrentRow.Index];
            string s = i.Cells[0].Value.ToString();
            f2.setForm(s);
            f2.ShowDialog();
            dtgv.DataSource = SetDTGV();
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            List<SinhVien> li = SetDTGV();
            if (cbbSort.SelectedIndex == 0)
            {
                dtgv.DataSource = li.OrderBy(p => p.DiemTB).ToList();
            }
            else if (cbbSort.SelectedIndex == 1)
            {
                dtgv.DataSource = li.OrderBy(p => p.TenSV).ToList();
            }
            else
            {
                dtgv.DataSource = li.OrderBy(p => p.MaSV).ToList();
            }
           
        }
        private void setCBBSort()
        {
            cbbSort.Items.Add("Điểm TB");
            cbbSort.Items.Add("Tên SV");
            cbbSort.Items.Add("Mã SV");
        }
    }
}
