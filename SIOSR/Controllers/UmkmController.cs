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
    public class UmkmController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UmkmController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Create([Bind("Title,Type,Price,Description,Status,Id")] Umkm umkm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(umkm);
                await _context.SaveChangesAsync();
                var fileName = string.Format ("{0}/images/media/umkm/{1}.jpg", _hostingEnvironment.WebRootPath, umkm.Id);
                umkm.Image = fileName;
                Directory.CreateDirectory (Path.GetDirectoryName (fileName));

                foreach (var formFile in Request.Form.Files)
                    if (formFile.Length > 0)
                        using (var stream = new FileStream (fileName, FileMode.Create))
                            await formFile.CopyToAsync (stream);
                await _context.SaveChangesAsync ();
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
        public async Task<IActionResult> Edit(int id, [Bind("Title,Type,Price,Description,Status,Id")] Umkm umkm)
        {
            if (id != umkm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = string.Format ("{0}/images/media/umkm/{1}.jpg", _hostingEnvironment.WebRootPath, umkm.Id);
                    Directory.CreateDirectory (Path.GetDirectoryName (fileName));

                    foreach (var formFile in Request.Form.Files)
                        if (formFile.Length > 0)
                            using (var stream = new FileStream (fileName, FileMode.Create))
                                await formFile.CopyToAsync (stream);
                    umkm.Image = fileName;
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

        private IActionResult SetStatus (int id, Status status) {
            var umkm = _context.Umkm.Single (a => a.Id == id);
            umkm.Status = status;
            _context.Update (umkm);
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
