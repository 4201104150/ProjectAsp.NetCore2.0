using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNhom12.Models
{
    public class Diem
    {
        public float diemGK { get; set; }
        public float diemCK { get; set; }

        public Diem()
        {
        }

        public Diem(float diemGK, float diemCK)
        {
            this.diemGK = diemGK;
            this.diemCK = diemCK;
        }

        public float tinhDiem()
        {
            float diem = 0;
            diem = diemGK * 0.03f + diemCK * 0.07f;
            return diem;
        }
    }
}
