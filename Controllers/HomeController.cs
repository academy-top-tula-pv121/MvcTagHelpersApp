using Microsoft.AspNetCore.Mvc;
using MvcTagHelpersApp.Models;
using System.Diagnostics;

namespace MvcTagHelpersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Work()
        {
            return View();
        }

        public IActionResult Item(string title, int id)
        {
            return Content($"Id: {id}, Title: {title}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}