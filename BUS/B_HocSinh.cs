using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class B_HocSinh
    {
        public static DataTable GetAllHocSinh()
        {
            return D_HocSinh.getData();
        }
        public static void TimKiem(tblHocSinh hs)
        {
            D_HocSinh.Research(hs);
        }

        public static void InsertHocSinh(tblHocSinh hs)
        {
            D_HocSinh.InsertHS(hs);
        }
        public static void UpdateHocSinh(tblHocSinh hs)
        {
            D_HocSinh.UpdateHS(hs);
        }
        public static void DeleteHocSinh(string mahs)
        {
            D_HocSinh.DeleteHS(mahs);
        }
    }
}
