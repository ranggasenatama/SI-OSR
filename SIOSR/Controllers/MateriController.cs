using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _hostingEnvironment;

        public MateriController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Create([Bind("Title,Description,Id")] Materi materi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materi);
                await _context.SaveChangesAsync();
                var fileName = string.Format ("{0}/images/media/media/materi/{1}.jpg", _hostingEnvironment.WebRootPath, materi.Id);
                materi.Image = fileName;
                Directory.CreateDirectory (Path.GetDirectoryName (fileName));

                foreach (var formFile in Request.Form.Files)
                    if (formFile.Length > 0)
                        using (var stream = new FileStream (fileName, FileMode.Create))
                            await formFile.CopyToAsync (stream);
                await _context.SaveChangesAsync ();
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
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Id")] Materi materi)
        {
            if (id != materi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = string.Format ("{0}/images/media/materi/{1}.jpg", _hostingEnvironment.WebRootPath, materi.Id);
                    Directory.CreateDirectory (Path.GetDirectoryName (fileName));

                    foreach (var formFile in Request.Form.Files)
                        if (formFile.Length > 0)
                            using (var stream = new FileStream (fileName, FileMode.Create))
                                await formFile.CopyToAsync (stream);
                    materi.Image = fileName;
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
