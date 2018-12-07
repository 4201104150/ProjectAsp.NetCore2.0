using System;
using System.Collections.Generic;

namespace ProjectNhom12.Models
{
    public partial class Dieukien
    {
        public string MaMh { get; set; }
        public string MaMhTruoc { get; set; }

        public virtual Monhoc MaMhNavigation { get; set; }
        public virtual Monhoc MaMhTruocNavigation { get; set; }
    }
}
