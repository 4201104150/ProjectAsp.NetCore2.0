﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectNhom12.Models;

namespace ProjectNhom12.Controllers
{
    public class DieukiensController : Controller
    {
        private readonly QLSinhvien_NETContext _context;

        public DieukiensController(QLSinhvien_NETContext context)
        {
            _context = context;
        }

        // GET: Dieukiens
        public async Task<IActionResult> Index()
        {
            var qLSinhvien_NETContext = _context.Dieukien.Include(d => d.MaMhNavigation).Include(d => d.MaMhTruocNavigation);
            return View(await qLSinhvien_NETContext.ToListAsync());
        }

        // GET: Dieukiens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieukien = await _context.Dieukien
                .Include(d => d.MaMhNavigation)
                .Include(d => d.MaMhTruocNavigation)
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (dieukien == null)
            {
                return NotFound();
            }

            return View(dieukien);
        }

        // GET: Dieukiens/Create
        public IActionResult Create()
        {
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh");
            ViewData["MaMhTruoc"] = new SelectList(_context.Monhoc, "MaMh", "MaMh");
            return View();
        }

        // POST: Dieukiens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMh,MaMhTruoc")] Dieukien dieukien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dieukien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", dieukien.MaMh);
            ViewData["MaMhTruoc"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", dieukien.MaMhTruoc);
            return View(dieukien);
        }

        // GET: Dieukiens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieukien = await _context.Dieukien.FindAsync(id);
            if (dieukien == null)
            {
                return NotFound();
            }
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", dieukien.MaMh);
            ViewData["MaMhTruoc"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", dieukien.MaMhTruoc);
            return View(dieukien);
        }

        // POST: Dieukiens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaMh,MaMhTruoc")] Dieukien dieukien)
        {
            if (id != dieukien.MaMh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dieukien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DieukienExists(dieukien.MaMh))
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
            ViewData["MaMh"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", dieukien.MaMh);
            ViewData["MaMhTruoc"] = new SelectList(_context.Monhoc, "MaMh", "MaMh", dieukien.MaMhTruoc);
            return View(dieukien);
        }

        // GET: Dieukiens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieukien = await _context.Dieukien
                .Include(d => d.MaMhNavigation)
                .Include(d => d.MaMhTruocNavigation)
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (dieukien == null)
            {
                return NotFound();
            }

            return View(dieukien);
        }

        // POST: Dieukiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dieukien = await _context.Dieukien.FindAsync(id);
            _context.Dieukien.Remove(dieukien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DieukienExists(string id)
        {
            return _context.Dieukien.Any(e => e.MaMh == id);
        }
    }
}