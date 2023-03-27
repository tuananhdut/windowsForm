using Mo_hinh_3_layer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;
using System.Collections;

namespace Mo_hinh_3_layer.DAL
{
    internal class QLSVDAL
    {
        public SV GetSVByDataRow(DataRow row)
        {
            return new SV
            {
                MSSV = row["MaSV"].ToString(),
                Name = row["TenSV"].ToString(),
                DTB = Convert.ToDouble(row["DiemTB"].ToString()),
                Gender = Convert.ToBoolean(row["GioiTinh"].ToString()),
                ID_Lop = Convert.ToInt32(row["MaLop"].ToString()),
                anh = Convert.ToBoolean(row["anh"].ToString()),
                hoso =    Convert.ToBoolean(row["hoso"].ToString()),
                cccd= Convert.ToBoolean(row["cccd"].ToString())
            };
        }
        public List<SV> GetALLSV()
        {
            List<SV> result = new List<SV>();
            foreach(DataRow i in DBHelper.Instance.getRecords("select * from SinhVien").Rows)
            {
                result.Add(GetSVByDataRow(i));
            }
            return result;
        }

        public LSH GetLSHByDataRow(DataRow row)
        {
            return new LSH
            {
                ID_Lop = Convert.ToInt32(row["MaLop"].ToString()),
                Name_Lop = row["TenLop"].ToString()
            };
        }
        public List<LSH> GetALLLSH()
        {
            List<LSH> result = new List<LSH>();
            foreach (DataRow i in DBHelper.Instance.getRecords("select * from lop").Rows)
            {
                result.Add(GetLSHByDataRow(i));
            }
            return result;
        }
        public int check(bool s)
        {
            if (s == true) return 1;
            else return 0;
        }
        public void AddSVDAL(SV s)
        {
            string query = "INSERT INTO SinhVien(MaSV, TenSV, GioiTinh, DiemTB, MaLop,anh,hoso,cccd) VALUES ("+s.MSSV+", '"+s.Name+"', "+check(s.Gender) + ", "+s.DTB+", "+s.ID_Lop+", "+check(s.anh) +", "+check(s.hoso) +", "+check(s.cccd) +");";
            DBHelper.Instance.ExecuteDB(query);
        }
        public List<SV> Search(string s)
        {
            string query = "select * from sinhvien where tenSV Like '%" + s + "%';";
            List<SV> result = new List<SV>();
            foreach (DataRow i in DBHelper.Instance.getRecords(query).Rows)
            {
                result.Add(GetSVByDataRow(i));
            }
            return result;
        }

        public void DelSVDAL(string s)
        {
            string query = "Delete from sinhvien where maSV = '"+s+"';";
            DBHelper.Instance.ExecuteDB(query);
        }
        public void EditSVDAL(SV s)
        {
            string query = "update SinhVien set TenSV = '" + s.Name + "',GioiTinh = '" + check(s.Gender) + "',DiemTB = " + s.DTB + ",malop = " + s.ID_Lop +
                        ",anh = " + check(s.anh) + ",hoso = " +check(s.hoso) +
                        ",cccd = " + check(s.cccd) + " where MaSV = " + s.MSSV+"; ";
            DBHelper.Instance.ExecuteDB(query);
        }
        public DataTable SortDTBDAL()
        {

            string query = "select * from SinhVien order by DiemTB asc";
            return DBHelper.Instance.getRecords(query);
        }
        public DataTable SortMSSVDAL()
        {
            string query = "select * from SinhVien order by MaSV asc";
            return DBHelper.Instance.getRecords(query);
        }
    }
}
