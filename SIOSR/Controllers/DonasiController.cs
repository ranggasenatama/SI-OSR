using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIOSR.Data;
using SIOSR.Models.App;

namespace SIOSR.Controllers
{
    public class DonasiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonasiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donasi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donasi.ToListAsync());
        }

        // GET: Donasi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donasi = await _context.Donasi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (donasi == null)
            {
                return NotFound();
            }

            return View(donasi);
        }

        // GET: Donasi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donasi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Name,Phone,Address,AccountNumber,Total,Bank")] Donasi donasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donasi);
        }

        // GET: Donasi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donasi = await _context.Donasi.SingleOrDefaultAsync(m => m.Id == id);
            if (donasi == null)
            {
                return NotFound();
            }
            return View(donasi);
        }

        // POST: Donasi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Name,Phone,Address,AccountNumber,Total,Bank")] Donasi donasi)
        {
            if (id != donasi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonasiExists(donasi.Id))
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
            return View(donasi);
        }

        // GET: Donasi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donasi = await _context.Donasi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (donasi == null)
            {
                return NotFound();
            }

            return View(donasi);
        }

        // POST: Donasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donasi = await _context.Donasi.SingleOrDefaultAsync(m => m.Id == id);
            _context.Donasi.Remove(donasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonasiExists(int id)
        {
            return _context.Donasi.Any(e => e.Id == id);
        }
    }
}
