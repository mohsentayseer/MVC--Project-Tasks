using Microsoft.AspNetCore.Mvc;
using task1_day7.Models;
using task1_day7.Repository;

namespace task_day7.Controllers
{
    public class CompanyController : Controller
    {
        //ITIContext ITIContext = new ITIContext();
        ICompanyRepository CompanyRepo; //= new CompanyRepository();

        //Implement Dependency Injection
        public CompanyController(ICompanyRepository companyRepo)
        {
            CompanyRepo = companyRepo;
        }
        public IActionResult Index()
        {
            return View(CompanyRepo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company c)
        {
            CompanyRepo.Add(c);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Company comp = CompanyRepo.GetById(id);
            if (comp != null)
                return View(comp);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Company c)
        {
            Company? old = CompanyRepo.GetById(c.Id); ;
            if (old != null)
            {
                CompanyRepo.Edit(c);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Company comp = CompanyRepo.GetById(id);
            return View(comp);
        }
        [HttpPost]
        public IActionResult Delete(int id, string choice)
        {
            if (choice == "y")
            {
                CompanyRepo.Delete(id, choice);
            }
            return RedirectToAction("Index");
        }
    }
}
