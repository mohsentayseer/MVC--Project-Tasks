using Microsoft.AspNetCore.Mvc;
using task_day2.Models;

namespace task_day2.Controllers
{
    public class DrugController : Controller
    {
        List<Drug> drugs = new List<Drug>()
        {
            new Drug (){Id=1, Name="Panadol", Price=70, ImagePath="panadol.jpeg", Description="Drug for headache"},
            new Drug (){Id=2, Name="Naproxen", Price=30, ImagePath="drug1.jpeg",Description="Drug as vitamines"},
            new Drug (){Id=3, Name="drug", Price=80, ImagePath="drug2.jpeg",Description="Drug for something"},
        };
        public ViewResult GetAll()
        {
            ViewData["drugs"] = drugs;
            return View();
        }
        public ViewResult DrugDetails(int id)
        {
            Drug d= drugs.FirstOrDefault(x => x.Id == id);
            ViewData["drug"] = d;
            return View();

        }
    }
}
