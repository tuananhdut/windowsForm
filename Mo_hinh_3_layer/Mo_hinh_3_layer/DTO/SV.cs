using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_hinh_3_layer.DTO
{
    internal class SV
    {
        public string MSSV { get; set; }
        public string Name { get; set; }
        public double DTB { get; set; }
        public bool Gender { get; set; }
        public int ID_Lop { get; set; }
        public bool anh { get; set; }
        public bool hoso { get; set; }
        public bool cccd { get; set; }
        /*public SV(string mssv, string name, double dtb, bool gender, int id_lop,bool anh, bool hoso, bool cccd)
        {
            this.MSSV = mssv;
            this.Name = name;
            this.DTB = dtb;
            this.Gender = gender;
            this.ID_Lop = id_lop;
            this.anh = anh;
            this.hoso = hoso;
            this.cccd = cccd;
        }*/
    }
}
