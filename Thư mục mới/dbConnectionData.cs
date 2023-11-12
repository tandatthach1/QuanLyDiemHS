using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dbConnectionData
    {
        public static SqlConnection HamKetNoi()
        {
            SqlConnection Conn = new SqlConnection(@"Data Source=Doug912\SQLEXPRESS;Initial Catalog=DemoHocSinh;User ID=sa; Integrated Security=True");
            return Conn;
        }
    }
}
