﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIOSR.Models;

namespace SIOSR.Controllers {

    public class HomeController : Controller {

        public IActionResult Index () {
            return View ();
        }

//        public IActionResult PenggalanganDana () {
//            return View ();
//        }

        public IActionResult About () {
            ViewData["Message"] = typeof (Controller).Assembly.GetName ().Version;
            return View ();
        }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}