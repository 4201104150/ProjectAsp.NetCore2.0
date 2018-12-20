using System;
using System.Collections.Generic;

namespace ProjectNhom12.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            Monhoc = new HashSet<Monhoc>();
            NhanVien = new HashSet<NhanVien>();
            Sinhvien = new HashSet<Sinhvien>();
        }

        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public int? Nam { get; set; }
        public string ThongTinKhoa { get; set; }

        public virtual ICollection<Monhoc> Monhoc { get; set; }
        public virtual ICollection<NhanVien> NhanVien { get; set; }
        public virtual ICollection<Sinhvien> Sinhvien { get; set; }
    }
}
