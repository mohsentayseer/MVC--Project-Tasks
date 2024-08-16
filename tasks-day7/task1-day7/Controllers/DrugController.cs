using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using task1_day7.Models;
using task1_day7.Repository;

namespace task_day6.Controllers
{
    public class DrugController : Controller
    {
        //ITIContext ITIContext = new ITIContext();
        IDrugRepository DrugRepo;//= new DrugRepository();
        ICompanyRepository CompRepo;//= new CompanyRepository();

        //Implement Dependency Injection
        public DrugController(IDrugRepository drugRepo, ICompanyRepository compRepo)
        {
            DrugRepo = drugRepo;
            CompRepo = compRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(DrugRepo.GetAllWithCompName());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.comps = new SelectList(CompRepo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Drug drug)
        {
            DrugRepo.Add(drug);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Drug d = DrugRepo.GetById(id);

            if (d != null)
            {
                ViewBag.Companies = new SelectList(CompRepo.GetAll(), "Id", "Name");
                return View(d);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Drug d)
        {
            Drug? old = DrugRepo.GetById(d.Id);
            if (old != null)
            {
                DrugRepo.Edit(d);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Drug dept = DrugRepo.GetById(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Delete(int id, string choice)
        {
            DrugRepo.Delete(id, choice);
            return RedirectToAction("Index");
        }
    }
}
