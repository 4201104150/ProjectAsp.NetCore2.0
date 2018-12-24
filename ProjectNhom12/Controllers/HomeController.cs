using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectNhom12.Models;

namespace ProjectNhom12.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLSinhvien_NETContext _context;
        public static int ID;
        public static string makhoa;
        public static string ma;
        public HomeController(QLSinhvien_NETContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("TestView");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TestView()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                string s = _context.Sinhvien.Where(p => p.MaSv == model.Tendn && p.Pass == model.Matkhau).Select(P => P.MaSv).ToString();
                //string n = _context.NhanVien.Where(p => p.MaNv == model.Tendn && p.Pass == model.Matkhau).Select(P => P.MaNv).ToString();
                
                
                //if (sv == null || nv == null)
                //{
                //    ModelState.AddModelError("Loi", "Không có người này.");
                //    return View();
                //}
                //else
                {
                    if (model.DoiTuong == "Sinh Viên")
                    {
                        Sinhvien sv = _context.Sinhvien.SingleOrDefault(p => p.MaSv == model.Tendn && p.Pass == model.Matkhau);
                        ID = sv.Id;
                        int IDD = sv.Id;
                        ViewBag.ID = IDD;
                        makhoa = sv.MaKhoa;
                        ma = sv.MaSv;
                        //ghi session
                        //HttpContext.Session.SetString("MaKH", kh.MaKh);
                        HttpContext.Session.Set("MaSv", sv);
                        //chuyển tới trang HangHoa (--> MyProfile)
                        return RedirectToAction("Details", "Sinhvien");
                    }
                    else
                    {
                        NhanVien nv = _context.NhanVien.SingleOrDefault(p => p.MaNv == model.Tendn && p.Pass == model.Matkhau);
                        ID = nv.Id;
                        int IDD = nv.Id;
                        ViewBag.ID = IDD;
                        makhoa = nv.MaKhoa;
                        //ghi session
                        //HttpContext.Session.SetString("MaKH", kh.MaKh);
                        HttpContext.Session.Set("MaNv", nv);
                        //chuyển tới trang HangHoa (--> MyProfile)
                        return RedirectToAction("Details", "NhanViens");
                    }
                }
            }
            return View();
        }
    }
}
