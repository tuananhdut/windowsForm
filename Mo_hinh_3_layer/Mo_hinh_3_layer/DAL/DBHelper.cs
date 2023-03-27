using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_hinh_3_layer.DAL
{
    internal class DBHelper
    {
        private SqlConnection _cnn;
        private static DBHelper _Instance;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string s = @"Data Source=DESKTOP-P21P68D\SQLEXPRESS;Initial Catalog=QLSV_thre_layer;Integrated Security=True";
                    _Instance = new DBHelper(s);
                   
                }
                return _Instance;
            }
            private set { }
        }
        private DBHelper(string s) 
        {
            _cnn = new SqlConnection(s);
        }
        public void ExecuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _cnn);
            _cnn.Open();
            cmd.ExecuteNonQuery();
            _cnn.Close();
        }
        public DataTable getRecords(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, _cnn);
            _cnn.Open();
            da.Fill(dt);
            _cnn.Close();
            return dt;

        }
    }
}
