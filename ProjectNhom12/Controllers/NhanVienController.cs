using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectNhom12.Models;

namespace ProjectNhom12.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly QLSinhvien_NETContext _context;

        public NhanVienController(QLSinhvien_NETContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var qLSinhvien_NETContext = _context.NhanVien.Include(n => n.MaKhoaNavigation);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            id = HomeController.ID;
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaNv,Pass,TenNv,Ngayvaolam,MaKhoa,HinhNv,Gioitinh,Cmnd,Diachi")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", nhanVien.MaKhoa);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            id = HomeController.ID;
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", nhanVien.MaKhoa);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,MaNv,Pass,TenNv,Ngayvaolam,MaKhoa,HinhNv,Gioitinh,Cmnd,Diachi")] NhanVien nhanVien)
        {
            int id = HomeController.ID;
            if (id != nhanVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", nhanVien.MaKhoa);
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanVien.FindAsync(id);
            _context.NhanVien.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanVien.Any(e => e.Id == id);
        }
        public IActionResult dssv()
        {
            QLSinhvien_NETContext db = new QLSinhvien_NETContext();
            var dssv = db.Sinhvien
                .Where(p => p.MaKhoa == HomeController.makhoa)
                .ToList();
            return View(dssv);
        }
        public IActionResult Luong()
        {
            return View("Luong");
        }

        public async Task<IActionResult> QLSV()
        {
            var qLSinhvien_NETContext = _context.Sinhvien.Include(s => s.MaKhoaNavigation);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        public IActionResult CreateSV()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: Sinhvien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSV([Bind("Id,MaSv,Pass,TenSv,Nam,MaKhoa,HinhSv,Gioitinh,Cmnd,Diachi")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(QLSV));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", sinhvien.MaKhoa);
            return RedirectToAction("UploadFile");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("file not selected");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HinhSV", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create)) { await file.CopyToAsync(stream); }

            return View();
        }

        public async Task<IActionResult> EditSV(int? id)
        {
            id = HomeController.ID;
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", sinhvien.MaKhoa);
            return View(sinhvien);
        }

        // POST: Sinhvien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSV([Bind("Id,MaSv,Pass,TenSv,Nam,MaKhoa,HinhSv,Gioitinh,Cmnd,Diachi")] Sinhvien sinhvien)
        {
            int s = HomeController.ID;
            if (s != sinhvien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhvienExists(sinhvien.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(QLSV));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", sinhvien.MaKhoa);
            return View(sinhvien);
        }

        // GET: Sinhvien/Delete/5
        public async Task<IActionResult> DeleteSV(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .Include(s => s.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // POST: Sinhvien/Delete/5
        [HttpPost, ActionName("DeleteSV")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedSV(int id)
        {
            var sinhvien = await _context.Sinhvien.FindAsync(id);
            _context.Sinhvien.Remove(sinhvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(QLSV));
        }
        private bool SinhvienExists(int id)
        {
            return _context.Sinhvien.Any(e => e.Id == id);
        }

        //Môn học
        //--------------------------------------------------------

        // GET: Monhocs/Details/5
        public async Task<IActionResult> DetailsMH(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .Include(m => m.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // GET: Monhocs/Create
        public IActionResult CreateMH()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: Monhocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMH([Bind("MaMh,TenMh,Tinchi,MaKhoa")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(dsMon));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", monhoc.MaKhoa);
            return View(monhoc);
        }

        // GET: Monhocs/Edit/5
        public async Task<IActionResult> EditMH(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc.FindAsync(id);
            if (monhoc == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", monhoc.MaKhoa);
            return View(monhoc);
        }

        // POST: Monhocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMH(string id, [Bind("MaMh,TenMh,Tinchi,MaKhoa")] Monhoc monhoc)
        {
            if (id != monhoc.MaMh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonhocExists(monhoc.MaMh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(dsMon));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", monhoc.MaKhoa);
            return View(monhoc);
        }

        // GET: Monhocs/Delete/5
        public async Task<IActionResult> DeleteMH(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .Include(m => m.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // POST: Monhocs/Delete/5
        [HttpPost, ActionName("DeleteMH")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var monhoc = await _context.Monhoc.FindAsync(id);
            _context.Monhoc.Remove(monhoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(dsMon));
        }

        private bool MonhocExists(string id)
        {
            return _context.Monhoc.Any(e => e.MaMh == id);
        }
        public async Task<IActionResult> dsMon()
        {
            string s = HomeController.makhoa;
            var qLSinhvien_NETContext = _context.Monhoc.Where(p => p.MaKhoa == s);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        //-----------------------
        //Kết quả
        //-----------------------
        public async Task<IActionResult> QLKQ()
        {
            var qLSinhvien_NETContext = _context.Ketqua.Include(k => k.MaHpNavigation)
                .Include(k => k.MaSvcNavigation);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        // GET: Ketqua/Details/5
        public async Task<IActionResult> DetailsKQ(string id)
        {
            id = HomeController.ma;
            if (id == null)
            {
                return NotFound();
            }

            var ketqua = await _context.Ketqua
                .Include(k => k.MaHpNavigation)
                .Include(k => k.MaSvcNavigation)
                .FirstOrDefaultAsync(m => m.MaSvc == id);
            if (ketqua == null)
            {
                return NotFound();
            }

            return View(ketqua);
        }

        // GET: Ketqua/Create
        public IActionResult CreateKQ()
        {
            ViewData["MaHp"] = new SelectList(_context.Hocphan, "MaHp", "MaHp");
            ViewData["MaSvc"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv");
            return View();
        }

        // POST: Ketqua/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSvc,MaHp,Diem")] Ketqua ketqua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ketqua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHp"] = new SelectList(_context.Hocphan, "MaHp", "MaHp", ketqua.MaHp);
            ViewData["MaSvc"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv", ketqua.MaSvc);
            return View(ketqua);
        }

        // GET: Ketqua/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketqua = await _context.Ketqua.FindAsync(id);
            if (ketqua == null)
            {
                return NotFound();
            }
            ViewData["MaHp"] = new SelectList(_context.Hocphan, "MaHp", "MaHp", ketqua.MaHp);
            ViewData["MaSvc"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv", ketqua.MaSvc);
            return View(ketqua);
        }

        // POST: Ketqua/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSvc,MaHp,Diem")] Ketqua ketqua)
        {
            if (id != ketqua.MaSvc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ketqua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KetquaExists(ketqua.MaSvc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHp"] = new SelectList(_context.Hocphan, "MaHp", "MaHp", ketqua.MaHp);
            ViewData["MaSvc"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv", ketqua.MaSvc);
            return View(ketqua);
        }

        // GET: Ketqua/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketqua = await _context.Ketqua
                .Include(k => k.MaHpNavigation)
                .Include(k => k.MaSvcNavigation)
                .FirstOrDefaultAsync(m => m.MaSvc == id);
            if (ketqua == null)
            {
                return NotFound();
            }

            return View(ketqua);
        }

        // POST: Ketqua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ketqua = await _context.Ketqua.FindAsync(id);
            _context.Ketqua.Remove(ketqua);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KetquaExists(string id)
        {
            return _context.Ketqua.Any(e => e.MaSvc == id);
        }
    }
}
