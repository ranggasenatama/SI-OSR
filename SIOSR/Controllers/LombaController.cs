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
    public class LombaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LombaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lomba
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lomba.ToListAsync());
        }

        // GET: Lomba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lomba = await _context.Lomba
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lomba == null)
            {
                return NotFound();
            }

            return View(lomba);
        }

        // GET: Lomba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lomba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image")] Lomba lomba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lomba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lomba);
        }

        // GET: Lomba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lomba = await _context.Lomba.SingleOrDefaultAsync(m => m.Id == id);
            if (lomba == null)
            {
                return NotFound();
            }
            return View(lomba);
        }

        // POST: Lomba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Image")] Lomba lomba)
        {
            if (id != lomba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lomba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LombaExists(lomba.Id))
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
            return View(lomba);
        }

        // GET: Lomba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lomba = await _context.Lomba
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lomba == null)
            {
                return NotFound();
            }

            return View(lomba);
        }

        // POST: Lomba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lomba = await _context.Lomba.SingleOrDefaultAsync(m => m.Id == id);
            _context.Lomba.Remove(lomba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LombaExists(int id)
        {
            return _context.Lomba.Any(e => e.Id == id);
        }
    }
}
