using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIOSR.Models;

namespace SIOSR.Controllers {

    public class HomeController : Controller {

        [AllowAnonymous]
        public IActionResult Index () {
            return View ();
        }

        [AllowAnonymous]
        public IActionResult About () {
            ViewData["Message"] = typeof (Controller).Assembly.GetName ().Version;
            return View ();
        }

        [AllowAnonymous]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
