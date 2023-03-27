using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102210050_NguyenTuanAnh
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
            maGV = 0;
            setCBBHocHam();
            setCBBHocPhan();
            setCBBHocVi();
            setCBBKhoa();
        }

        private int maGV,maHP;
        public void setForm(DataGridViewRow row)
        {
            tbTenGV.Text = row.Cells["TenGiangVien"].Value.ToString();
            cbbKhoa.Text = row.Cells["khoa"].Value.ToString();
            dtpNgaySinh.Value = (DateTime)row.Cells["ngaysinh"].Value;
            if (Convert.ToBoolean(row.Cells["gioitinh"].Value) == true)
            {
                rbNam.Checked = true;
            }
            else rbNu.Checked = true;
            cbbHocHam.Text = row.Cells["hocham"].Value.ToString();
            cbbHocPhan.Text = row.Cells["tenhocphan"].Value.ToString();
            cbbHocVi.Text = row.Cells["hocvi"].Value.ToString();
            maGV = Convert.ToInt32(row.Cells["magiangvien"].Value.ToString());
            maHP = Convert.ToInt32(row.Cells["mahocphan"].Value.ToString());
        }
        private void setCBBHocHam()
        {
            cbbHocHam.Items.Add("Giáo sư");
            cbbHocHam.Items.Add("Phó giáo sư");
            cbbHocHam.Items.Add("Không");
        }
        private void setCBBKhoa()
        {
            string query = "select DISTINCT khoa from GiangVien;";

            foreach (DataRow row in DBHelper.Instance.getRecords(query).Rows)
            {

                cbbKhoa.Items.Add(row["khoa"].ToString());
            }
        }
        private void setCBBHocVi()
        {
            cbbHocVi.Items.Add("Thạc sỹ");
            cbbHocVi.Items.Add("Tiến sỹ");
            cbbHocVi.Items.Add("Tiến sỹ khoa học");
        }
        private void setCBBHocPhan()
        {
            string query = "select * from HocPhan;";
            
            foreach (DataRow row in DBHelper.Instance.getRecords(query).Rows)
            {

                cbbHocPhan.Items.Add(new CBBHocPhan()
                {
                    maHocPhan = Convert.ToInt32(row["mahocphan"].ToString()),
                    tenHocPhan = row["tenhocphan"].ToString()

                });

            }
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            if (maGV == 0)
            {
                add();
            }
            else edit();
            Close();
        }
        private void edit()
        {
            string query = "update giangvien set TenGiangVien = N'"+tbTenGV.Text+"',NgaySinh = '"+dtpNgaySinh.Value.Year+"-"+ dtpNgaySinh.Value.Month+"-"+ dtpNgaySinh.Value.Day+"',Khoa = N'"+cbbKhoa.Text+"' ,HocHam = N'"+cbbHocHam.Text+"',HocVi = N'"+cbbHocVi.Text+"',GioiTinh = "+check(rbNam.Checked)+" where magiangvien = "+maGV+";";
            DBHelper.Instance.executeDB(query);
            query = "update PhanCong set MaGiangVien = "+maGV+", MaHocPhan= "+((CBBHocPhan)cbbHocPhan.SelectedItem).maHocPhan+" where MaGiangVien= "+maGV+" and MaHocPhan="+maHP+";";
            DBHelper.Instance.executeDB(query);
            MessageBox.Show("update thành công");
        }
        private void add()
        {
            string query = "INSERT INTO GiangVien (TenGiangVien, NgaySinh, Khoa, HocHam, HocVi, GioiTinh) VALUES (N'"+tbTenGV.Text+"', '"+dtpNgaySinh.Value.Date+"', N'"+cbbKhoa.Text+"', N'"+cbbHocHam.Text+"', N'"+cbbHocVi.Text+"', "+check(rbNam.Checked)+")";
            DBHelper.Instance.executeDB(query);
            string query2 = "SELECT MAX(magiangvien) FROM giangvien;";
            DataRow row = (DBHelper.Instance.getRecords(query2)).Rows[0];
            query = "INSERT INTO PhanCong (MaGiangVien, MaHocPhan) VALUES ("+row[0].ToString()+", " + ((CBBHocPhan)cbbHocPhan.SelectedItem).maHocPhan + ")";
            DBHelper.Instance.executeDB(query);
            MessageBox.Show("add thành công");
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int check(bool a)
        {
            if (a == true) return 1; else return 0;
        }
    }
}
