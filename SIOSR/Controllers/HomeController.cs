using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIOSR.Data;
using SIOSR.Models;
using SIOSR.Models.App;

namespace SIOSR.Controllers {

    public class HomeController : Controller {

        private readonly ApplicationDbContext _context;

        public HomeController (ApplicationDbContext context) {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index ()
            => View ();

        [AllowAnonymous]
        public IActionResult Event ()
            => View (_context.Lomba.Where (l => l.Status == Status.Approved).OrderByDescending (l => l.CreatedAt).ToList ());

        [AllowAnonymous]
        [HttpGet ("Home/Event/{eventId}")]
        public IActionResult EventDetails (int eventId)
            => View (_context.Lomba.Single (l => l.Id == eventId && l.Status == Status.Approved));

        [AllowAnonymous]
        public IActionResult Contact () {
            ViewData["Message"] = "ASP .NET Core " + typeof (Controller).Assembly.GetName ().Version;
            return View ();
        }

        [AllowAnonymous]
        public IActionResult About () {
            ViewData["Message"] = typeof (Controller).Assembly.GetName ().Version;
            return View ();
        }

        [AllowAnonymous]
        public IActionResult Donasi ()
            => View (_context.PenggalanganDana.Where (p => p.Status == Status.Approved).ToList ());

        [AllowAnonymous]
        [HttpGet ("Home/Donasi/{donasiId}")]
        public IActionResult DonasiDetails (int donasiId)
            => View (_context.PenggalanganDana.Include(p => p.Donasis).Single (p => p.Id == donasiId && p.Status == Status.Approved));

        [AllowAnonymous]
        public IActionResult Produk ()
            => View (_context.Umkm.Where (u => u.Status == Status.Approved).OrderByDescending (u => u.CreatedAt).ToList ());

        [AllowAnonymous]
        [HttpGet ("Home/Produk/{produkId}")]
        public IActionResult ProdukDetails (int produkId)
            => View (_context.Umkm.Include (u => u.Pembelians).Single (u => u.Id == produkId && u.Status == Status.Approved));

        [AllowAnonymous]
        [HttpGet ("Home/Produk/{produkId}/Purchase")]
        public IActionResult ProdukPurchase (int produkId)
            => View (_context.Umkm.Single (u => u.Id == produkId && u.Status == Status.Approved));

        [AllowAnonymous]
        [HttpGet ("Home/Donasi/{penggalanganId}/Donate")]
        public IActionResult Donate (int penggalanganId)
            => View (_context.PenggalanganDana.Single (p => p.Id == penggalanganId && p.Status == Status.Approved));

        [AllowAnonymous]
        public IActionResult Absensi ()
            => View (_context.Absensi.OrderBy (a => a.CreatedAt).ToList ());

        [AllowAnonymous]
        public IActionResult Materi ()
            => View (_context.Materi.OrderBy (m => m.CreatedAt).ToList ());

        [AllowAnonymous]
        [HttpGet ("Home/Materi/{materiId}")]
        public IActionResult MateriDetails (int materiId)
            => View (_context.Materi.Single (u => u.Id == materiId));

        [AllowAnonymous]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
