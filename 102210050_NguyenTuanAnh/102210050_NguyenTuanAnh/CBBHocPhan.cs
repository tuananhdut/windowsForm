using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102210050_NguyenTuanAnh
{
    internal class CBBHocPhan
    {
        public int maHocPhan { get; set; }
        public string tenHocPhan { get; set; }
        public override string ToString()
        {
            return tenHocPhan;
        }
    }
}
