using Microsoft.AspNetCore.Mvc;
using task_day2.Models;

namespace task_day2.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>()
        {
            new Student (){Id=1, Name="mohsen", Age=18, Address="USA", ImagePath="~/Images/pizza.jpeg"},
            new Student (){Id=2, Name="ali", Age=20, Address="UK", ImagePath="burger.jpeg"},

        };
        public ViewResult Hello()
        {
            return View();
        }
        public ViewResult GetAll()
        {
            //to send data to view
            int x = 5;
            ViewData["myVar"] = x;
            ViewData ["students"] = students;
            return View();
        }
        public ViewResult ViewDetails(int id)//any sent data from url will be in the parameters
        {
           Student s = students.FirstOrDefault(x => x.Id == id);
            ViewData["student"] = s;
            return View();
        }
    }
}
