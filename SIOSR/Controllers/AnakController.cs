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
    public class AnakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Anak
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anak.ToListAsync());
        }

        // GET: Anak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anak = await _context.Anak
                .SingleOrDefaultAsync(m => m.Id == id);
            if (anak == null)
            {
                return NotFound();
            }

            return View(anak);
        }

        // GET: Anak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Birthday,Class,Parent,Contact,Status")] Anak anak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anak);
        }

        // GET: Anak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anak = await _context.Anak.SingleOrDefaultAsync(m => m.Id == id);
            if (anak == null)
            {
                return NotFound();
            }
            return View(anak);
        }

        // POST: Anak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Birthday,Class,Parent,Contact,Status")] Anak anak)
        {
            if (id != anak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnakExists(anak.Id))
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
            return View(anak);
        }

        // GET: Anak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anak = await _context.Anak
                .SingleOrDefaultAsync(m => m.Id == id);
            if (anak == null)
            {
                return NotFound();
            }

            return View(anak);
        }

        // POST: Anak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anak = await _context.Anak.SingleOrDefaultAsync(m => m.Id == id);
            _context.Anak.Remove(anak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnakExists(int id)
        {
            return _context.Anak.Any(e => e.Id == id);
        }

        private IActionResult SetStatus (int id, Status status) {
            var anak = _context.Anak.Single (a => a.Id == id);
            anak.Status = status;
            _context.Update (anak);
            _context.SaveChanges ();
            return Ok ();
        }

        public IActionResult Approve (int id) {
            return SetStatus (id, Status.Approved);
        }

        public IActionResult Reject (int id) {
            return SetStatus (id, Status.Rejected);
        }
    }
}
