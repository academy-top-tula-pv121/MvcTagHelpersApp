using Microsoft.AspNetCore.Mvc;
using MvcTagHelpersApp.Models;
using StepClasses;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcTagHelpersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<Country> countries;
        List<Company> companies;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            countries = new List<Country>()
            {
                new Country("Russia", "Moscow"),
                new("USA", "Washington"),
            };

            companies = new List<Company>()
            {
                new("Yandex", countries[0]),
                new("Ozon", countries[0]),
                new("Google", countries[1]),
                new("Amazone", countries[1]),
                new("Mail Group", countries[0]),
            };
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

        [HttpGet]
        public IActionResult Empl()
        {
            ViewBag.Companies = new SelectList(companies, "Title", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Empl(Employe employe)
        {
            Company? company = companies.FirstOrDefault(c => c == employe?.Company);
            return Content($"Create new Emplye: name {employe.Name}, company {employe.Company?.Title}");
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