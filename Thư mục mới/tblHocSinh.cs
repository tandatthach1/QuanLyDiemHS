using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class tblHocSinh
    {
        private String MaHS;
        private String TenHS;
        private DateTime NgaySinh;
        private String DiaChi;
        private float Diem;
        private string XepLoai;
        public tblHocSinh(string maHS, string tenHS, DateTime ngaySinh, string diaChi, float diem, string xepLoai)
        {
            MaHS = maHS;
            TenHS = tenHS;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Diem = diem;
            XepLoai = xepLoai;
        }

        public string MaHS1 { get => MaHS; set => MaHS = value; }
        public string TenHS1 { get => TenHS; set => TenHS = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public float Diem1 { get => Diem; set => Diem = value; }
        public string XepLoai1 { get => XepLoai; set => XepLoai = value; }

    }
}
