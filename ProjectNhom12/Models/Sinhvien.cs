using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectNhom12.Models
{
    public partial class Sinhvien
    {
        public Sinhvien()
        {
            Ketqua = new HashSet<Ketqua>();
        }
        
        public int Id { get; set; }
        [Display(Name="Mã sinh viên")]
        public string MaSv { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Pass { get; set; }
        [Display(Name = "Tên sinh viên")]
        public string TenSv { get; set; }
        [Display(Name = "Năm")]
        public int? Nam { get; set; }
        [Display(Name = "Mã khoa")]
        public string MaKhoa { get; set; }
        [Display(Name = "Hình sinh viên")]
        public string HinhSv { get; set; }
        [Display(Name = "Giới tính")]
        public string Gioitinh { get; set; }
        [Display(Name = "CMND")]
        public string Cmnd { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        

        public Sinhvien(int id, string maSv, string pass, string tenSv, int? nam, string maKhoa, string hinhSv, string gioitinh, string cmnd, string diachi, Khoa maKhoaNavigation, ICollection<Ketqua> ketqua)
        {
            Id = id;
            MaSv = maSv;
            Pass = pass;
            TenSv = tenSv;
            Nam = nam;
            MaKhoa = maKhoa;
            HinhSv = hinhSv;
            Gioitinh = gioitinh;
            Cmnd = cmnd;
            Diachi = diachi;
            MaKhoaNavigation = maKhoaNavigation;
            Ketqua = ketqua;
        }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<Ketqua> Ketqua { get; set; }
    }
}
