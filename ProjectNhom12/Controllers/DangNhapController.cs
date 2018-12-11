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
    public class DangNhapController : Controller
    {
        private readonly QLSinhvien_NET1Context _context;

        public DangNhapController(QLSinhvien_NET1Context context)
        {
            _context = context;
        }

        // GET: DangNhap
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dangnhap.ToListAsync());
        }

        // GET: DangNhap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap
                .FirstOrDefaultAsync(m => m.Username == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // GET: DangNhap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DangNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Matkhau,Loai")] Dangnhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangnhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dangnhap);
        }

        // GET: DangNhap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap.FindAsync(id);
            if (dangnhap == null)
            {
                return NotFound();
            }
            return View(dangnhap);
        }

        // POST: DangNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Matkhau,Loai")] Dangnhap dangnhap)
        {
            if (id != dangnhap.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangnhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangnhapExists(dangnhap.Username))
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
            return View(dangnhap);
        }

        // GET: DangNhap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap
                .FirstOrDefaultAsync(m => m.Username == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // POST: DangNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dangnhap = await _context.Dangnhap.FindAsync(id);
            _context.Dangnhap.Remove(dangnhap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangnhapExists(string id)
        {
            return _context.Dangnhap.Any(e => e.Username == id);
        }
    }
}
