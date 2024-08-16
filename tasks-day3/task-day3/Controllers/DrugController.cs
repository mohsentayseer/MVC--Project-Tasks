using Microsoft.AspNetCore.Mvc;
using task_day3.Models;

namespace task_day3.Controllers
{
    public class DrugController : Controller
    {

        static List<Drug> drugs = new List<Drug>()
        {
            new Drug(){Id=1,Name="Paracetamol",CompanyName="Paracetamol Company", ManufactureDate=new DateTime(2023, 7, 30),ExpirationDate=new DateTime(2026, 7, 30),ImagePath="/images/1.jpeg"},
            new Drug(){Id=2,Name="Aspirin",CompanyName="Aspirin Company", ManufactureDate=new DateTime(2023, 7, 30),ExpirationDate=new DateTime(2026, 7, 30),ImagePath="/images/2.jpeg"},
            new Drug(){Id=3,Name="Comtrex",CompanyName="Comtrex Company",ManufactureDate=new DateTime(2023, 7, 27),ExpirationDate=new DateTime(2026, 7, 27),ImagePath="/images/3.jpeg"},
        };

        public IActionResult Index()
        {
            ViewBag.drugs = drugs;
            return View();
        }
        public IActionResult GetDetails(int id)
        {
            Drug? drug = drugs.Find(d => d.Id == id);
            ViewBag.Drug = drug;
            return View();
        }
        public IActionResult AddDrug()
        {
            return View();
        }
        public IActionResult InsertDrug(string _name, string _companyName, DateTime _manufactureDate, DateTime _expirationDate, string _image)
        {
            int id = drugs.OrderBy(d => d.Id)?.LastOrDefault()?.Id + 1 ?? 1;
            drugs.Add(new Drug()
            {
                Id = id,
                Name = _name,
                CompanyName = _companyName,
                ManufactureDate = _manufactureDate,
                ExpirationDate = _expirationDate,
                ImagePath = _image
            });
            return RedirectToAction("Index");
        }
        public IActionResult EditDrug(int id)
        {
            Drug? drug = drugs.Find(d => d.Id == id);
            ViewBag.Drug = drug;
            return View();
        }
        public IActionResult UpdateDrug(int id, string name, string companyName, DateTime manufactureDate, DateTime expirationDate, string image)
        {
            Drug? drug = drugs.Find(d => d.Id == id);
            if (drug != null)
            {
                drug.Name = name;
                drug.CompanyName = companyName;
                drug.ManufactureDate = manufactureDate;
                drug.ExpirationDate = expirationDate;
                drug.ImagePath = image;
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDrug(int id)
        {
            Drug? drug = drugs.Find(d => d.Id == id);
            if (drug != null)
            {
                drugs.Remove(drug);
            }
            return RedirectToAction("Index");
        }
    }
}
