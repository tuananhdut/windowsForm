using Mo_hinh_3_layer.BLL;
using Mo_hinh_3_layer.DAL;
using Mo_hinh_3_layer.DTO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mo_hinh_3_layer.VIEW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public void setform(string s)
        {
            QLSVBLL bll = new QLSVBLL();
            SV a= bll.getSV(s);
            if (a != null)
            {
                tbMSSV.Text = a.MSSV;
                tbName.Text = a.Name;
                tbIDClass.Text = a.ID_Lop.ToString();
                tbDTB.Text = a.DTB.ToString();
                radioButton1.Checked = a.Gender;
                cbAnh.Checked = a.anh;
                cbHoSo.Checked = a.hoso;
                cbCCCD.Checked = a.cccd;
            }

        }
        
        private void cbAnh_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btoke_Click(object sender, EventArgs e)
        {
            QLSVBLL bll = new QLSVBLL();
            SV sv = new SV();
            sv.MSSV = tbMSSV.Text;
            sv.Name = tbName.Text;
            sv.DTB = Convert.ToDouble(tbDTB.Text);
            sv.ID_Lop = Convert.ToInt32(tbIDClass.Text);
            sv.Gender = radioButton1.Checked;
            sv.anh = cbAnh.Checked;
            sv.cccd = cbCCCD.Checked;
            sv.hoso = cbHoSo.Checked;
            bll.AddAndEditSVBLL(sv);
            MessageBox.Show("ban da them thanh cong");
            this.Close();
        }
        public void setData(int index)
        {
            QLSVDAL dal = new QLSVDAL();
            

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
