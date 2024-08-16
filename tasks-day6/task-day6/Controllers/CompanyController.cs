using Microsoft.AspNetCore.Mvc;
using task_day6.Context;
using task_day6.Models;

namespace task_day6.Controllers
{
    public class CompanyController : Controller
    {
        ITIContext ITIContext = new ITIContext();
        public IActionResult Index()
        {
            return View(ITIContext.Companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company c)
        {
            ITIContext.Companies.Add(c);
            ITIContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                RedirectToAction("Index");
            Company? comp = ITIContext.Companies.Find(id);
            if (comp != null)
                return View(comp);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Company c)
        {
            Company? old = ITIContext.Companies.Find(c.Id);
            if (old != null)
            {
                old.Name = c.Name;
                ITIContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Company comp = ITIContext.Companies.Find(id);
            return View(comp);
        }
        [HttpPost]
        public IActionResult Delete(int id, string choice)
        {
            if (choice == "y")
            {
                Company comp = ITIContext.Companies.Find(id);
                ITIContext.Companies.Remove(comp);
                ITIContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
