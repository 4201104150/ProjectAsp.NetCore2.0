using System;
using System.Collections.Generic;

namespace ProjectCuoiKy.Models
{
    public partial class Ketqua
    {
        public string MaSv { get; set; }
        public string MaHp { get; set; }
        public int? Diem { get; set; }

        public virtual Hocphan MaHpNavigation { get; set; }
        public virtual Sinhvien MaSvNavigation { get; set; }
    }
}
