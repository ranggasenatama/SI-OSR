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
    public class AbsensiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsensiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Absensi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Absensi.ToListAsync());
        }

        // GET: Absensi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absensi = await _context.Absensi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (absensi == null)
            {
                return NotFound();
            }

            return View(absensi);
        }

        // GET: Absensi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Absensi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kehadiran,Date")] Absensi absensi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absensi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(absensi);
        }

        // GET: Absensi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absensi = await _context.Absensi.SingleOrDefaultAsync(m => m.Id == id);
            if (absensi == null)
            {
                return NotFound();
            }
            return View(absensi);
        }

        // POST: Absensi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kehadiran,Date")] Absensi absensi)
        {
            if (id != absensi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absensi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsensiExists(absensi.Id))
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
            return View(absensi);
        }

        // GET: Absensi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absensi = await _context.Absensi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (absensi == null)
            {
                return NotFound();
            }

            return View(absensi);
        }

        // POST: Absensi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var absensi = await _context.Absensi.SingleOrDefaultAsync(m => m.Id == id);
            _context.Absensi.Remove(absensi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsensiExists(int id)
        {
            return _context.Absensi.Any(e => e.Id == id);
        }
    }
}
