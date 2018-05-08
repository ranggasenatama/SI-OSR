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
    public class PenggalanganDanaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PenggalanganDanaController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: PenggalanganDana
        public async Task<IActionResult> Index()
        {
            return View(await _context.PenggalanganDana.ToListAsync());
        }

        // GET: PenggalanganDana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penggalanganDana = await _context.PenggalanganDana
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
        public async Task<IActionResult> Create([Bind("Title,Description,Status,Id")] PenggalanganDana penggalanganDana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penggalanganDana);
                await _context.SaveChangesAsync();
                var fileName = string.Format ("{0}/images/media/penggalangandana/{1}.jpg", _hostingEnvironment.WebRootPath, penggalanganDana.Id);
                penggalanganDana.Image = fileName;
                Directory.CreateDirectory (Path.GetDirectoryName (fileName));

                foreach (var formFile in Request.Form.Files)
                    if (formFile.Length > 0)
                        using (var stream = new FileStream (fileName, FileMode.Create))
                            await formFile.CopyToAsync (stream);
                await _context.SaveChangesAsync ();
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

            var penggalanganDana = await _context.PenggalanganDana.SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Status,Id")] PenggalanganDana penggalanganDana)
        {
            if (id != penggalanganDana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = string.Format ("{0}/images/media/penggalangandana/{1}.jpg", _hostingEnvironment.WebRootPath, penggalanganDana.Id);
                    Directory.CreateDirectory (Path.GetDirectoryName (fileName));

                    foreach (var formFile in Request.Form.Files)
                        if (formFile.Length > 0)
                            using (var stream = new FileStream (fileName, FileMode.Create))
                                await formFile.CopyToAsync (stream);
                    penggalanganDana.Image = fileName;
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

            var penggalanganDana = await _context.PenggalanganDana
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
            var penggalanganDana = await _context.PenggalanganDana.SingleOrDefaultAsync(m => m.Id == id);
            _context.PenggalanganDana.Remove(penggalanganDana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenggalanganDanaExists(int id)
        {
            return _context.PenggalanganDana.Any(e => e.Id == id);
        }

        private IActionResult SetStatus (int id, Status status) {
            var penggalanganDana = _context.PenggalanganDana.Single (a => a.Id == id);
            penggalanganDana.Status = status;
            _context.Update (penggalanganDana);
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
