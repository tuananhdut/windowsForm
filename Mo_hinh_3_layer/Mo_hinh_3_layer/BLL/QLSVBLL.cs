using Mo_hinh_3_layer.DAL;
using Mo_hinh_3_layer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mo_hinh_3_layer.BLL
{
    internal class QLSVBLL
    {
        public List<CBBItem> GetCBB()
        {
            List<CBBItem> result = new List<CBBItem>();
            result.Add(new CBBItem
            {
                Value = 0,
                Text="ALL"
            });
            QLSVDAL dal = new QLSVDAL();
            foreach (LSH i in dal.GetALLLSH())
            {
                result.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.Name_Lop
                });
            }
            return result;
        }
        public List<SV> GetSVByIDLop(int ID_Lop)
        {
            List<SV> svs = new List<SV>();
            QLSVDAL dal = new QLSVDAL();
            if (ID_Lop == 0)
            {
                svs = dal.GetALLSV();
            } else
            {
                foreach(SV i in dal.GetALLSV())
                {
                    if (ID_Lop == i.ID_Lop)
                    {
                        svs.Add(i);
                    }
                }
            }
            return svs;
        }
        public List<SV> GetSVSearch(string s,int ID_Lop)
        {
            List<SV> svs = new List<SV>();
            QLSVDAL dal = new QLSVDAL();
            if (ID_Lop == 0)
            {
                svs = dal.Search(s);
            }
            else
            {
                foreach (SV i in dal.Search(s))
                {
                    if (ID_Lop == i.ID_Lop)
                    {
                        svs.Add(i);
                    }
                }
            }
            return svs;
        }
       public List<SV> ListSV (List<string> m)
        {
            List<SV> r = new List<SV>();
            foreach (string i in m)
            {
                QLSVDAL dal = new QLSVDAL();
                foreach (SV j in dal.GetALLSV())
                {
                    if (i == j.MSSV)
                    {
                        r.Add(j);
                        break;
                    }
                }
            }
            return r;
        }
        public SV getSV(string s)
        {
            QLSVDAL dal = new QLSVDAL();
            SV sv = new SV();
            foreach (SV i in dal.GetALLSV())
            {
                if (i.MSSV == s)
                {
                    return i;
                }
            }
            return null;
        }
        public void DelSVBLL(string m)
        {
            QLSVDAL dal = new QLSVDAL();
            dal.DelSVDAL(m);
        }
        public void AddAndEditSVBLL(SV x)
        {
            QLSVDAL dal = new QLSVDAL();
            bool kt = true;
            foreach (SV i in dal.GetALLSV())
            {
                if (i.MSSV == x.MSSV)
                {
                    
                    dal.EditSVDAL(x);
                    kt = false;
                    break;
                }
            }
            if (kt==true) dal.AddSVDAL(x);
        }
        public DataTable sort(int index)
        {
            QLSVDAL dal = new QLSVDAL();
            if (index == 0)
            {
                return dal.SortMSSVDAL();
            }
            else return dal.SortDTBDAL();
            
        }
    }
}
