using Microsoft.AspNetCore.Mvc;
using task_day5.Models;

namespace task_day5.Controllers
{
    public class CompanyController : Controller
    {
        public static List<Company> companies = new List<Company>()
        {
            new Company(){Id=1,Name="Company1",Location="Cairo"},
            new Company(){Id=2,Name="Company2",Location="Portsaid"},
            new Company(){Id=3,Name="Company3",Location="Cairo"},
        };
        public IActionResult Index()
        {
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company c)
        {
            int id = companies.OrderBy(d => d.Id)?.LastOrDefault()?.Id + 1 ?? 1;
            c.Id = id;
            companies.Add(c);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Company? d = companies.Find(d => d.Id == id);
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Company c)
        {
            Company? old = companies.Find(com => com.Id == c.Id);
            old.Name = c.Name;
            old.Location = c.Location;
            
            return RedirectToAction("Index");
        }
    }
}
