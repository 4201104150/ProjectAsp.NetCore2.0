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
    public class KetquaController : Controller
    {
        private readonly QLSinhvien_NETContext _context;

        public KetquaController(QLSinhvien_NETContext context)
        {
            _context = context;
        }

        // GET: Ketqua
        public async Task<IActionResult> Index()
        {
            var qLSinhvien_NETContext = _context.Ketqua.Include(k => k.MaHpNavigation)
                .Include(k => k.MaSvcNavigation);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        // GET: Ketqua/Details/5
        public async Task<IActionResult> Details(string id)
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
        public IActionResult Create()
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
