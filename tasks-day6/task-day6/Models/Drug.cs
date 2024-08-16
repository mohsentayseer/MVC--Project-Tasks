namespace task_day6.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ImagePath { get; set; }
        public int CompanyId { get; set; }
        //navigational prop
        public virtual Company? Company { get; set; }
    }
}
