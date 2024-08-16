using Microsoft.AspNetCore.Mvc;

namespace task_day2.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }

    }
}
