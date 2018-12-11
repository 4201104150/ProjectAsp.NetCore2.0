using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectNhom12.Models;

namespace ProjectNhom12.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly QLSinhvien_NET1Context _context;

        public SinhVienController(QLSinhvien_NET1Context context)
        {
            _context = context;
        }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
            var qLSinhvien_NET1Context = _context.Sinhvien.Include(s => s.MaKhoaNavigation).Include(s => s.MaSvNavigation);
            return View(await qLSinhvien_NET1Context.ToListAsync());
        }

        // GET: SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .Include(s => s.MaKhoaNavigation)
                .Include(s => s.MaSvNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa");
            ViewData["MaSv"] = new SelectList(_context.Dangnhap, "Username", "Username");
            return View();
        }

        // POST: SinhVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSv,TenSv,Nam,MaKhoa,HinhSv,Gioitinh,Cmnd,Diachi")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", sinhvien.MaKhoa);
            ViewData["MaSv"] = new SelectList(_context.Dangnhap, "Username", "Username", sinhvien.MaSv);
            return View(sinhvien);
        }

        // GET: SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", sinhvien.MaKhoa);
            ViewData["MaSv"] = new SelectList(_context.Dangnhap, "Username", "Username", sinhvien.MaSv);
            return View(sinhvien);
        }

        // POST: SinhVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSv,TenSv,Nam,MaKhoa,HinhSv,Gioitinh,Cmnd,Diachi")] Sinhvien sinhvien)
        {
            if (id != sinhvien.MaSv)
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
                    if (!SinhvienExists(sinhvien.MaSv))
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", sinhvien.MaKhoa);
            ViewData["MaSv"] = new SelectList(_context.Dangnhap, "Username", "Username", sinhvien.MaSv);
            return View(sinhvien);
        }

        // GET: SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .Include(s => s.MaKhoaNavigation)
                .Include(s => s.MaSvNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhvien = await _context.Sinhvien.FindAsync(id);
            _context.Sinhvien.Remove(sinhvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhvienExists(string id)
        {
            return _context.Sinhvien.Any(e => e.MaSv == id);
        }
    }
}
