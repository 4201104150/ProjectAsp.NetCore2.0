using System;
using System.Collections.Generic;
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa");
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", nhanVien.MaKhoa);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", nhanVien.MaKhoa);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaNv,Pass,TenNv,Ngayvaolam,MaKhoa,HinhNv,Gioitinh,Cmnd,Diachi")] NhanVien nhanVien)
        {
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoa, "MaKhoa", "MaKhoa", nhanVien.MaKhoa);
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
        
    }
}
