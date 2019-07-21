using LightingSurvey.MvcSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LightingSurvey.MvcSite.Controllers
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

        public IActionResult Summary()
        {
            return View();
        }

        public IActionResult Done()
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
