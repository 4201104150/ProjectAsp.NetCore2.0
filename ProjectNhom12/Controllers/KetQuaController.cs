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
    public class KetQuaController : Controller
    {
        private readonly QLSinhvien_NET1Context _context;

        public KetQuaController(QLSinhvien_NET1Context context)
        {
            _context = context;
        }

        // GET: KetQua
        public async Task<IActionResult> Index()
        {
            var qLSinhvien_NET1Context = _context.Ketqua.Include(k => k.MaHpNavigation).Include(k => k.MaSvNavigation);
            return View(await qLSinhvien_NET1Context.ToListAsync());
        }

        // GET: KetQua/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketqua = await _context.Ketqua
                .Include(k => k.MaHpNavigation)
                .Include(k => k.MaSvNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (ketqua == null)
            {
                return NotFound();
            }

            return View(ketqua);
        }

        // GET: KetQua/Create
        public IActionResult Create()
        {
            ViewData["MaHp"] = new SelectList(_context.Hocphan, "MaHp", "MaHp");
            ViewData["MaSv"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv");
            return View();
        }

        // POST: KetQua/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSv,MaHp,Diem")] Ketqua ketqua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ketqua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHp"] = new SelectList(_context.Hocphan, "MaHp", "MaHp", ketqua.MaHp);
            ViewData["MaSv"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv", ketqua.MaSv);
            return View(ketqua);
        }

        // GET: KetQua/Edit/5
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
            ViewData["MaSv"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv", ketqua.MaSv);
            return View(ketqua);
        }

        // POST: KetQua/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSv,MaHp,Diem")] Ketqua ketqua)
        {
            if (id != ketqua.MaSv)
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
                    if (!KetquaExists(ketqua.MaSv))
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
            ViewData["MaSv"] = new SelectList(_context.Sinhvien, "MaSv", "MaSv", ketqua.MaSv);
            return View(ketqua);
        }

        // GET: KetQua/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketqua = await _context.Ketqua
                .Include(k => k.MaHpNavigation)
                .Include(k => k.MaSvNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (ketqua == null)
            {
                return NotFound();
            }

            return View(ketqua);
        }

        // POST: KetQua/Delete/5
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
            return _context.Ketqua.Any(e => e.MaSv == id);
        }
    }
}
