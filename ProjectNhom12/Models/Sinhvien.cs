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

        public string MaSv { get; set; }
        public string TenSv { get; set; }
        public int? Nam { get; set; }
        public string MaKhoa { get; set; }
        public string HinhSv { get; set; }
        public string Gioitinh { get; set; }
        public string Cmnd { get; set; }
        public string Diachi { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual Dangnhap Dangnhap { get; set; }
        public virtual ICollection<Ketqua> Ketqua { get; set; }
    }
}
