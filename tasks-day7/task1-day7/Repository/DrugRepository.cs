using Microsoft.EntityFrameworkCore;
using task1_day7.Context;
using task1_day7.Models;

namespace task1_day7.Repository
{
    public class DrugRepository:IDrugRepository
    {
        ITIContext context;// = new ITIContext();
        //Implement Dependency Injection with constructor
        public DrugRepository(ITIContext context)
        {
            this.context = context;
        }

        public IEnumerable<Drug> GetAllWithCompName()
        {
            IEnumerable<Drug> drugs = context.Drugs.Include(s => s.Company).ToList();
            return drugs;
        }
        public Drug GetById(int id)
        {
            Drug? drug = context.Drugs.FirstOrDefault(dd => dd.Id == id);
            return drug;
        }
        public void Add(Drug drug)
        {
            context.Drugs.Add(drug);
            context.SaveChanges();
        }
        public void Edit(Drug drug)
        {
            Drug? old = context.Drugs.FirstOrDefault(dd => dd.Id == drug.Id);
            old.Name = drug.Name;
            old.ManufactureDate = drug.ManufactureDate;
            old.ExpirationDate = drug.ExpirationDate;
            old.ImagePath = drug.ImagePath;
            old.CompanyId = drug.CompanyId;
            context.SaveChanges();
        }
        public void Delete(int id, string choice)
        {
            if (choice == "y")
            {
                Drug? dept = context.Drugs.Find(id);
                context.Drugs.Remove(dept);
                context.SaveChanges();
            }
        }
    }
}
