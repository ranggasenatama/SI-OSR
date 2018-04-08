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
    public class UmkmController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UmkmController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Umkm
        public async Task<IActionResult> Index()
        {
            return View(await _context.Umkm.ToListAsync());
        }

        // GET: Umkm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umkm = await _context.Umkm
                .SingleOrDefaultAsync(m => m.Id == id);
            if (umkm == null)
            {
                return NotFound();
            }

            return View(umkm);
        }

        // GET: Umkm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Umkm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Type,Price,Description,Image")] Umkm umkm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(umkm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(umkm);
        }

        // GET: Umkm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umkm = await _context.Umkm.SingleOrDefaultAsync(m => m.Id == id);
            if (umkm == null)
            {
                return NotFound();
            }
            return View(umkm);
        }

        // POST: Umkm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type,Price,Description,Image")] Umkm umkm)
        {
            if (id != umkm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(umkm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UmkmExists(umkm.Id))
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
            return View(umkm);
        }

        // GET: Umkm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umkm = await _context.Umkm
                .SingleOrDefaultAsync(m => m.Id == id);
            if (umkm == null)
            {
                return NotFound();
            }

            return View(umkm);
        }

        // POST: Umkm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var umkm = await _context.Umkm.SingleOrDefaultAsync(m => m.Id == id);
            _context.Umkm.Remove(umkm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UmkmExists(int id)
        {
            return _context.Umkm.Any(e => e.Id == id);
        }
    }
}
