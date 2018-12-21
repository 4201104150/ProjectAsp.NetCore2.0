using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNhom12.Models
{
    public class LoginViewModel
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [MaxLength(10)]
        public string Tendn { get; set; }
        [Display(Name = "Mật khẩu")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Matkhau { get; set; }
        public string DoiTuong { get; set; }
    }
}
