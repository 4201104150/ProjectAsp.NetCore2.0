using System;
using System.Collections.Generic;

namespace ProjectCuoiKy.Models
{
    public partial class Dieukien
    {
        public string MaMh { get; set; }
        public string MaMhTruoc { get; set; }

        public virtual Monhoc MaMhNavigation { get; set; }
        public virtual Monhoc MaMhTruocNavigation { get; set; }
    }
}
