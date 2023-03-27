using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102210050_NguyenTuanAnh
{
    internal class DBHelper
    {
        public static DBHelper _Instance;
        private SqlConnection _cnn;
        public static DBHelper Instance
        {
            get
            {
                if(_Instance== null)
                {
                    string s = @"Data Source=DESKTOP-P21P68D\SQLEXPRESS;Initial Catalog=Quan_ly_dao_tao;Integrated Security=True";
                    _Instance = new DBHelper(s);
                }
                return _Instance;
            }
            private set { }
        }
        DBHelper(string s)
        {
            _cnn = new SqlConnection(s);
        }
        public DataTable getRecords(string s)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(s, _cnn);
            _cnn.Open();
            da.Fill(dt);
            _cnn.Close();
            return dt;
        }
        public void executeDB(string s)
        {
            SqlCommand cmd = new SqlCommand(s, _cnn);
            _cnn.Open();
            cmd.ExecuteNonQuery();
            _cnn.Close();
        }
    }
}
