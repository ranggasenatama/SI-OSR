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
    public class MateriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Materi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materi.ToListAsync());
        }

        // GET: Materi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materi = await _context.Materi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (materi == null)
            {
                return NotFound();
            }

            return View(materi);
        }

        // GET: Materi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Image,Id")] Materi materi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materi);
        }

        // GET: Materi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materi = await _context.Materi.SingleOrDefaultAsync(m => m.Id == id);
            if (materi == null)
            {
                return NotFound();
            }
            return View(materi);
        }

        // POST: Materi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Image,Id")] Materi materi)
        {
            if (id != materi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriExists(materi.Id))
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
            return View(materi);
        }

        // GET: Materi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materi = await _context.Materi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (materi == null)
            {
                return NotFound();
            }

            return View(materi);
        }

        // POST: Materi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materi = await _context.Materi.SingleOrDefaultAsync(m => m.Id == id);
            _context.Materi.Remove(materi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriExists(int id)
        {
            return _context.Materi.Any(e => e.Id == id);
        }
    }
}
