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
    public class SinhvienController : Controller
    {
        private readonly QLSinhvien_NETContext _context;

        public SinhvienController(QLSinhvien_NETContext context)
        {
            _context = context;
        }

        // GET: Sinhvien
        public async Task<IActionResult> Index()
        {
            var qLSinhvien_NETContext = _context.Sinhvien.Include(s => s.MaKhoaNavigation);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        // GET: Sinhvien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            id = HomeController.ID;
            
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

        // GET: Sinhvien/Create
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: Sinhvien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaSv,Pass,TenSv,Nam,MaKhoa,HinhSv,Gioitinh,Cmnd,Diachi")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", sinhvien.MaKhoa);
            return RedirectToAction("UploadFile");
        }

        // GET: Sinhvien/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit([Bind("Id,MaSv,Pass,TenSv,Nam,MaKhoa,HinhSv,Gioitinh,Cmnd,Diachi")] Sinhvien sinhvien)
        {
            int s = HomeController.ID;
            if ( s!= sinhvien.Id)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "TenKhoa", sinhvien.MaKhoa);
            return View(sinhvien);
        }

        // GET: Sinhvien/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinhvien = await _context.Sinhvien.FindAsync(id);
            _context.Sinhvien.Remove(sinhvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhvienExists(int id)
        {
            return _context.Sinhvien.Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("file not selected");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HinhSV", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create)) { await file.CopyToAsync(stream); }

            return View();
        }
        public IActionResult lala()
        {
            return View("lala");
        }
    }
}
