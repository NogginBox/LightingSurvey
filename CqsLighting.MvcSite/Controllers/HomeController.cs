using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CqsLighting.MvcSite.Models;

namespace CqsLighting.MvcSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Question1()
        {
            return View();
        }

        public IActionResult Question2()
        {
            return View();
        }

        public IActionResult Question3()
        {
            return View();
        }

        public IActionResult Question4()
        {
            return View();
        }

        public IActionResult Question5()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
