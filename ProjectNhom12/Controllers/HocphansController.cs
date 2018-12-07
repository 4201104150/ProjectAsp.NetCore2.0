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
    public class HocphansController : Controller
    {
        private readonly QLSinhvien_NETContext _context;

        public HocphansController(QLSinhvien_NETContext context)
        {
            _context = context;
        }

        // GET: Hocphans
        public async Task<IActionResult> Index()
        {
            var qLSinhvien_NETContext = _context.Hocphan.Include(h => h.MaMhNavigation);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        // GET: Hocphans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocphan = await _context.Hocphan
                .Include(h => h.MaMhNavigation)
                .FirstOrDefaultAsync(m => m.MaHp == id);
            if (hocphan == null)
            {
                return NotFound();
            }

            return View(hocphan);
        }

        // GET: Hocphans/Create
        public IActionResult Create()
        {
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh");
            return View();
        }

        // POST: Hocphans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHp,MaMh,Hocky,Nam,Giangvien")] Hocphan hocphan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocphan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", hocphan.MaMh);
            return View(hocphan);
        }

        // GET: Hocphans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocphan = await _context.Hocphan.FindAsync(id);
            if (hocphan == null)
            {
                return NotFound();
            }
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", hocphan.MaMh);
            return View(hocphan);
        }

        // POST: Hocphans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHp,MaMh,Hocky,Nam,Giangvien")] Hocphan hocphan)
        {
            if (id != hocphan.MaHp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocphan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocphanExists(hocphan.MaHp))
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
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", hocphan.MaMh);
            return View(hocphan);
        }

        // GET: Hocphans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocphan = await _context.Hocphan
                .Include(h => h.MaMhNavigation)
                .FirstOrDefaultAsync(m => m.MaHp == id);
            if (hocphan == null)
            {
                return NotFound();
            }

            return View(hocphan);
        }

        // POST: Hocphans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hocphan = await _context.Hocphan.FindAsync(id);
            _context.Hocphan.Remove(hocphan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocphanExists(string id)
        {
            return _context.Hocphan.Any(e => e.MaHp == id);
        }
    }
}
