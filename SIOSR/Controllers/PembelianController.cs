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
    public class PembelianController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PembelianController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pembelian
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pembelian.ToListAsync());
        }

        // GET: Pembelian/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembelian = await _context.Pembelian
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pembelian == null)
            {
                return NotFound();
            }

            return View(pembelian);
        }

        // GET: Pembelian/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pembelian/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Name,Phone,Email,Address,Amount,AccountNumber,Shipping")] Pembelian pembelian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembelian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pembelian);
        }

        // GET: Pembelian/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembelian = await _context.Pembelian.SingleOrDefaultAsync(m => m.Id == id);
            if (pembelian == null)
            {
                return NotFound();
            }
            return View(pembelian);
        }

        // POST: Pembelian/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Name,Phone,Email,Address,Amount,AccountNumber,Shipping")] Pembelian pembelian)
        {
            if (id != pembelian.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembelian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembelianExists(pembelian.Id))
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
            return View(pembelian);
        }

        // GET: Pembelian/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembelian = await _context.Pembelian
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pembelian == null)
            {
                return NotFound();
            }

            return View(pembelian);
        }

        // POST: Pembelian/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembelian = await _context.Pembelian.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pembelian.Remove(pembelian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembelianExists(int id)
        {
            return _context.Pembelian.Any(e => e.Id == id);
        }
    }
}
