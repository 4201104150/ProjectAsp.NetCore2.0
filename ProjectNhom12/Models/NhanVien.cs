using System;
using System.Collections.Generic;

namespace ProjectNhom12.Models
{
    public partial class NhanVien
    {
        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public DateTime? Ngayvaolam { get; set; }
        public string MaKhoa { get; set; }
        public string HinhNv { get; set; }
        public string Gioitinh { get; set; }
        public string Cmnd { get; set; }
        public string Diachi { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual Dangnhap MaNvNavigation { get; set; }
    }
}
