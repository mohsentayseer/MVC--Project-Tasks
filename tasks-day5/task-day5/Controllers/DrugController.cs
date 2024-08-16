using Microsoft.AspNetCore.Mvc;
using task_day5.Models;

namespace task_day5.Controllers
{
    public class DrugController : Controller
    {
        public static List<Drug> drugs = new List<Drug>()
        {
            new Drug(){Id=1,Name="Paracetamol",CompanyName="Paracetamol Company", ManufactureDate=new DateTime(2023, 7, 30),ExpirationDate=new DateTime(2026, 7, 30),ImagePath="/images/1.jpeg"},
            new Drug(){Id=2,Name="Aspirin",CompanyName="Aspirin Company", ManufactureDate=new DateTime(2023, 7, 30),ExpirationDate=new DateTime(2026, 7, 30),ImagePath="/images/2.jpeg"},
            new Drug(){Id=3,Name="Comtrex",CompanyName="Comtrex Company",ManufactureDate=new DateTime(2023, 7, 27),ExpirationDate=new DateTime(2026, 7, 27),ImagePath="/images/3.jpeg"},
        };
        [HttpGet]
        public IActionResult Index()
        {
            return View(drugs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Drug drug)
        {
            int id = drugs.OrderBy(d => d.Id)?.LastOrDefault()?.Id + 1 ?? 1;
            drug.Id = id;
            drugs.Add(drug);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Drug? d = drugs.Find(d => d.Id == id);
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Drug d)
        {
            Drug? old = drugs.Find(dept => dept.Id == d.Id);
            old.Name = d.Name;
            old.CompanyName = d.CompanyName;
            old.ManufactureDate = d.ManufactureDate;
            old.ExpirationDate = d.ExpirationDate;
            old.ImagePath = d.ImagePath;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Drug dept = drugs.FirstOrDefault(d => d.Id == id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Delete(int id, string choice)
        {
            if (choice == "y")
            {
                Drug dept = drugs.FirstOrDefault(dpt => dpt.Id == id);
                drugs.Remove(dept);
            }
            return RedirectToAction("Index");
        }
    }
}
