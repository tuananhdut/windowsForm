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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            setCBBKhoa();
            setDTGV();
            setCBBSort();
        }
        private void setDTGV()
        {
            string query = "select * from GiangVien,HocPhan,PhanCong  where PhanCong.MaGiangVien=GiangVien.MaGiangVien  and PhanCong.MaHocPhan=HocPhan.MaHocPhan;";
            dtgv1.DataSource = DBHelper.Instance.getRecords(query);
        }
        private void setCBBKhoa()
        {
            string query = "select DISTINCT Khoa from GiangVien;";
            cbbKhoa.Items.Add("ALL");
            foreach (DataRow i in DBHelper.Instance.getRecords(query).Rows)
            {
                cbbKhoa.Items.Add(i["khoa"].ToString());
            }
            cbbKhoa.Text="ALL";
        }

      


        // search theo ten giang vien,ma giang vien
        private void btSearch_Click(object sender, EventArgs e)
        {
            string query = "";
            if (cbbKhoa.Text == "ALL")
            {
                query= "select * from GiangVien,HocPhan,PhanCong where PhanCong.MaGiangVien=GiangVien.MaGiangVien  and PhanCong.MaHocPhan=HocPhan.MaHocPhan and (GiangVien.TenGiangVien like N'%" + tbSearch.Text + "%' or GiangVien.MaGiangVien like N'%" + tbSearch.Text + "%') ;";
            } else 
            query = "select * from GiangVien,HocPhan,PhanCong where PhanCong.MaGiangVien=GiangVien.MaGiangVien  and PhanCong.MaHocPhan=HocPhan.MaHocPhan and (GiangVien.TenGiangVien like N'%"+tbSearch.Text+"%' or GiangVien.MaGiangVien like N'%"+tbSearch.Text+ "%') and GiangVien.Khoa = N'"+cbbKhoa.Text+"';";
            dtgv1.DataSource = DBHelper._Instance.getRecords(query);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dtgv1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgv1.SelectedRows)
                {
                    string query = "delete from PhanCong where phancong.MaGiangVien = '" + row.Cells["magiangvien"].Value.ToString() + "' and phancong.mahocphan = "+ row.Cells["mahocphan"].Value.ToString() + ";";
                    DBHelper.Instance.executeDB(query);
                    /*query = "delete from GiangVien where GiangVien.MaGiangVien = '" + row.Cells[0].Value.ToString() + "' ;";
                    DBHelper.Instance.executeDB(query);*/

                    /*query = "select magiangvien from giangvien where giangvien.magiangvien not in (select phancong.magiangvien from phancong)";
                    if (DBHelper.Instance.getRecords(query)!=null) {
                        DataRow i = (DBHelper.Instance.getRecords(query)).Rows[0];
                        query = "delete from GiangVien where GiangVien.MaGiangVien = '" + i["magiangvien"].ToString() + "' ;";
                        DBHelper.Instance.executeDB(query);
                    }*/
                    
                    row.Selected = false;
                }

            }
            setDTGV();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dtgv1.Rows[dtgv1.CurrentCell.RowIndex];
            DetailForm f2 = new DetailForm();
            f2.setForm(row);
            f2.ShowDialog();
            setDTGV();
        }

        private void btADD_Click(object sender, EventArgs e)
        {
            DetailForm f2 = new DetailForm();
            f2.ShowDialog();
            setDTGV();
        }
        private void setCBBSort()
        {
            cbbSort.Items.Add("Tên");
            cbbSort.Items.Add("ngày sinh");
            cbbSort.Items.Add("khoa");
            cbbSort.Items.Add("Mã Giảng Viên");
        }
        private void btSort_Click(object sender, EventArgs e)
        {
            string query = "";
            if (cbbSort.SelectedIndex == 0)
            {
                query = "select * from GiangVien,PhanCong,HocPhan where GiangVien.MaGiangVien=PhanCong.MaGiangVien and PhanCong.MaHocPhan=HocPhan.MaHocPhan ORDER bY TenGiangVien;"; 
            } else if(cbbSort.SelectedIndex == 1)
            {
                query = "select * from GiangVien,PhanCong,HocPhan where GiangVien.MaGiangVien=PhanCong.MaGiangVien and PhanCong.MaHocPhan=HocPhan.MaHocPhan ORDER bY ngaysinh;";
            }
            else if (cbbSort.SelectedIndex == 2) query = "select * from GiangVien,PhanCong,HocPhan where GiangVien.MaGiangVien=PhanCong.MaGiangVien and PhanCong.MaHocPhan=HocPhan.MaHocPhan ORDER bY khoa;";
            else if (cbbSort.SelectedIndex == 3) query = "select * from GiangVien,PhanCong,HocPhan where GiangVien.MaGiangVien=PhanCong.MaGiangVien and PhanCong.MaHocPhan=HocPhan.MaHocPhan ORDER bY GiangVien.maGiangVien;";
            dtgv1.DataSource= DBHelper.Instance.getRecords(query);
            
        }
    }
}
