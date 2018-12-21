using System;
using System.Collections.Generic;

namespace ProjectNhom12.Models
{
    public partial class Sinhvien
    {
        public Sinhvien()
        {
            Ketqua = new HashSet<Ketqua>();
        }

        public int Id { get; set; }
        public string MaSv { get; set; }
        public string Pass { get; set; }
        public string TenSv { get; set; }
        public int? Nam { get; set; }
        public string MaKhoa { get; set; }
        public string HinhSv { get; set; }
        public string Gioitinh { get; set; }
        public string Cmnd { get; set; }
        public string Diachi { get; set; }

        public Sinhvien(int id, string maSv, string pass, string tenSv, int? nam, string maKhoa, string hinhSv, string gioitinh, string cmnd, string diachi, Khoa maKhoaNavigation, ICollection<Ketqua> ketqua)
        {
            Id = id;
            MaSv = maSv;
            Pass = pass;
            TenSv = tenSv;
            Nam = nam;
            MaKhoa = maKhoa;
            HinhSv = hinhSv;
            Gioitinh = gioitinh;
            Cmnd = cmnd;
            Diachi = diachi;
            MaKhoaNavigation = maKhoaNavigation;
            Ketqua = ketqua;
        }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<Ketqua> Ketqua { get; set; }
    }
}
