using System;
using System.Collections.Generic;

namespace ProjectNhom12.Models
{
    public partial class Ketqua
    {
        public string MaSvc { get; set; }
        public string MaHp { get; set; }
        public int? Diem { get; set; }

        public virtual Hocphan MaHpNavigation { get; set; }
        public virtual Sinhvien MaSvcNavigation { get; set; }
    }
}
