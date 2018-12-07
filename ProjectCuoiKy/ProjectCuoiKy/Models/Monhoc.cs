using System;
using System.Collections.Generic;

namespace ProjectCuoiKy.Models
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            DieukienMaMhNavigation = new HashSet<Dieukien>();
            DieukienMaMhTruocNavigation = new HashSet<Dieukien>();
            Hocphan = new HashSet<Hocphan>();
        }

        public string MaMh { get; set; }
        public string TenMh { get; set; }
        public int? Tinchi { get; set; }
        public string MaKhoa { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<Dieukien> DieukienMaMhNavigation { get; set; }
        public virtual ICollection<Dieukien> DieukienMaMhTruocNavigation { get; set; }
        public virtual ICollection<Hocphan> Hocphan { get; set; }
    }
}
