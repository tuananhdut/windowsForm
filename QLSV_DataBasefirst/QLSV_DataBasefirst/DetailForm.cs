using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_DataBasefirst
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }

        public void setForm(string s)
        {
            using (QLSV_DB db = new QLSV_DB())
            {
                var x = db.SinhViens.Where(p => p.MaSV == s).FirstOrDefault();
                tbMSSV.Text = x.MaSV;
                tbDiemTB.Text = x.DiemTB.ToString();
                tbMaLop.Text = x.MaLop.ToString();
                tbName.Text = x.TenSV;
                if (x.GioiTinh == true)
                {
                    rbNam.Checked = true;
                }
                else rbNu.Checked = true;
                cbAnh.Checked =Convert.ToBoolean( x.anh);
                cbCCCD.Checked = Convert.ToBoolean(x.cccd);
                cbHoSo.Checked = Convert.ToBoolean(x.hoso);
            }
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            using(QLSV_DB db = new QLSV_DB())
            {
                SinhVien x = new SinhVien();
                x.MaSV = tbMSSV.Text;
                x.TenSV = tbName.Text;
                x.DiemTB = Convert.ToDouble(tbDiemTB.Text);
                x.MaLop = Convert.ToInt32(tbMaLop.Text);
                x.GioiTinh = rbNam.Checked;
                x.anh = cbAnh.Checked;
                x.hoso = cbHoSo.Checked;
                x.cccd = cbCCCD.Checked;
                db.SinhViens.AddOrUpdate(x);
                db.SaveChanges();
            }
            MessageBox.Show("ADD,Update thành công");
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
