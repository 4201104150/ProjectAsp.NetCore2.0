using System;
using System.Collections.Generic;

namespace ProjectNhom12.Models
{
    public partial class Dangnhap
    {
        public string Username { get; set; }
        public string Matkhau { get; set; }
        public int Loai { get; set; }

        public virtual Sinhvien Username1 { get; set; }
        public virtual NhanVien UsernameNavigation { get; set; }
    }
}
