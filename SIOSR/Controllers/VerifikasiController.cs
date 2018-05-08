using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIOSR.Data;
using SIOSR.Models.App;

namespace SIOSR.Controllers {

    public class VerifikasiController : Controller {

        private readonly ApplicationDbContext _context;

        public VerifikasiController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index () => View ();

        public IActionResult Pendapatan () {
            PendapatanViewModel model = new PendapatanViewModel ();
            model.Umkms = _context.Umkm.Include (u => u.Pembelians).Where (u => u.Status == Status.Approved).ToList ();
            model.PenggalanganDanas = _context.PenggalanganDana.Where (p => p.Status == Status.Approved).Include (p => p.Donasis).ToList ();
            return View (model);
        }
    }
}
