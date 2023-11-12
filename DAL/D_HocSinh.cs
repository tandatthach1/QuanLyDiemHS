using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class D_HocSinh
    {
        public static DataTable getData()
        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetAllHocSinh", Conn);
            command.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conn.Close();
            return dt;
        }

        public static void Research(tblHocSinh hs)

        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_Timkiem", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHS", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@TenHS", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@NgaySinh", SqlDbType.Date);
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Diem", SqlDbType.Float);
            command.Parameters.Add("@XepLoai", SqlDbType.NVarChar, 50);

            command.Parameters["@MaHS"].Value = hs.MaHS1;
            command.Parameters["@TenHS"].Value = hs.TenHS1;
            command.Parameters["@NgaySinh"].Value = hs.NgaySinh1;
            command.Parameters["@DiaChi"].Value = hs.DiaChi1;
            command.Parameters["@Diem"].Value = hs.Diem1;
            command.Parameters["@XepLoai"].Value = hs.XepLoai1;


            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static void InsertHS(tblHocSinh hs)

        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_InsertHocSinh", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHS", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@TenHS", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@NgaySinh", SqlDbType.Date);
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Diem", SqlDbType.Float);
            command.Parameters.Add("@XepLoai", SqlDbType.NVarChar, 50);




            command.Parameters["@MaHS"].Value = hs.MaHS1;
            command.Parameters["@TenHS"].Value = hs.TenHS1;
            command.Parameters["@NgaySinh"].Value = hs.NgaySinh1;
            command.Parameters["@DiaChi"].Value = hs.DiaChi1;
            command.Parameters["@Diem"].Value = hs.Diem1;
            command.Parameters["@XepLoai"].Value = hs.XepLoai1;


            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static void UpdateHS(tblHocSinh hs)

        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_UpdateHocSinh", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHS", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@TenHS", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@NgaySinh", SqlDbType.Date);
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Diem", SqlDbType.Float);
            command.Parameters.Add("@XepLoai", SqlDbType.NVarChar, 50);

            command.Parameters["@MaHS"].Value = hs.MaHS1;
            command.Parameters["@TenHS"].Value = hs.TenHS1;
            command.Parameters["@NgaySinh"].Value = hs.NgaySinh1;
            command.Parameters["@DiaChi"].Value = hs.DiaChi1;
            command.Parameters["@Diem"].Value = hs.Diem1;
            command.Parameters["@XepLoai"].Value = hs.XepLoai1;




            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static void DeleteHS(string mahs)

        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_DeleteHocSinh", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHS", SqlDbType.NVarChar, 50);
            command.Parameters["@MaHS"].Value = mahs;

            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }
    }
}
