namespace task1_day7.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //navigational prop
        public virtual List<Drug>? Drugs { get; set; } =new List<Drug>();
    }
}
