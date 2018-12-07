using System;
using System.Collections.Generic;

namespace ProjectNhom12.Models
{
    public partial class Hocphan
    {
        public Hocphan()
        {
            Ketqua = new HashSet<Ketqua>();
        }

        public string MaHp { get; set; }
        public string MaMh { get; set; }
        public int? Hocky { get; set; }
        public int? Nam { get; set; }
        public string Giangvien { get; set; }

        public virtual Monhoc MaMhNavigation { get; set; }
        public virtual ICollection<Ketqua> Ketqua { get; set; }
    }
}
