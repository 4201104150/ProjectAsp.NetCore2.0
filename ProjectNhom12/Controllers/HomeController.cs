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
                Sinhvien sv = _context.Sinhvien.SingleOrDefault(p => p.MaSv == model.Tendn && p.Pass == model.Matkhau);
                ID = int.Parse(sv.Id.ToString());
                int IDD = sv.Id;
                ViewBag.ID = IDD;
                if (sv == null)
                {
                    ModelState.AddModelError("Loi", "Không có người này.");
                    return View();
                }
                else
                {
                    if (model.DoiTuong == "Sinh Viên")
                    {
                        //ghi session
                        //HttpContext.Session.SetString("MaKH", kh.MaKh);
                        HttpContext.Session.Set("MaSv", sv);
                        //chuyển tới trang HangHoa (--> MyProfile)
                        return RedirectToAction("Edit", "Sinhvien");
                    }
                }
            }
            return View();
        }
    }
}
