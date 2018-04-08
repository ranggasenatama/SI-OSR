using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIOSR.Data;
using SIOSR.Models.App;

namespace SIOSR.Controllers
{
    public class PenggalanganDanaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PenggalanganDanaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PenggalanganDana
        public async Task<IActionResult> Index()
        {
            return View(await _context.PenggalanganDanas.ToListAsync());
        }

        // GET: PenggalanganDana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penggalanganDana = await _context.PenggalanganDanas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (penggalanganDana == null)
            {
                return NotFound();
            }

            return View(penggalanganDana);
        }

        // GET: PenggalanganDana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PenggalanganDana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Total,Status,Image")] PenggalanganDana penggalanganDana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penggalanganDana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penggalanganDana);
        }

        // GET: PenggalanganDana/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penggalanganDana = await _context.PenggalanganDanas.SingleOrDefaultAsync(m => m.Id == id);
            if (penggalanganDana == null)
            {
                return NotFound();
            }
            return View(penggalanganDana);
        }

        // POST: PenggalanganDana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Total,Status,Image")] PenggalanganDana penggalanganDana)
        {
            if (id != penggalanganDana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penggalanganDana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenggalanganDanaExists(penggalanganDana.Id))
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
            return View(penggalanganDana);
        }

        // GET: PenggalanganDana/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penggalanganDana = await _context.PenggalanganDanas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (penggalanganDana == null)
            {
                return NotFound();
            }

            return View(penggalanganDana);
        }

        // POST: PenggalanganDana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penggalanganDana = await _context.PenggalanganDanas.SingleOrDefaultAsync(m => m.Id == id);
            _context.PenggalanganDanas.Remove(penggalanganDana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenggalanganDanaExists(int id)
        {
            return _context.PenggalanganDanas.Any(e => e.Id == id);
        }
    }
}
