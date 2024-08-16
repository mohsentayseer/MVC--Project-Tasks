using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task_day6.Context;
using task_day6.Models;

namespace task_day6.Controllers
{
    public class DrugController : Controller
    {
        ITIContext ITIContext = new ITIContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View(ITIContext.Drugs.Include(s => s.Company));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.comps = new SelectList(ITIContext.Companies, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Drug drug)
        {
            ITIContext.Drugs.Add(drug);
            ITIContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Drug? d = ITIContext.Drugs.FirstOrDefault(dd => dd.Id == id);

                if (d != null)
                {
                    ViewBag.Companies = new SelectList(ITIContext.Companies, "Id", "Name");
                    return View(d);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Drug d)
        {
            if (d != null)
            {
                Drug? old = ITIContext.Drugs.FirstOrDefault(dd => dd.Id == d.Id);
                if (old != null)
                {
                    old.Name = d.Name;
                    old.ManufactureDate = d.ManufactureDate;
                    old.ExpirationDate = d.ExpirationDate;
                    old.ImagePath = d.ImagePath;
                    old.CompanyId = d.CompanyId;
                    ITIContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Drug dept = ITIContext.Drugs.Find(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Delete(int id, string choice)
        {
            if (choice == "y")
            {
                Drug dept = ITIContext.Drugs.Find(id);
                ITIContext.Drugs.Remove(dept);
                ITIContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
