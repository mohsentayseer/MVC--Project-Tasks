namespace task_day4.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ImagePath { get; set; }
    }
}
