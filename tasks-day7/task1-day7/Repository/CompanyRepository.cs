using task1_day7.Context;
using task1_day7.Models;

namespace task1_day7.Repository
{
    public class CompanyRepository: ICompanyRepository
    {
        ITIContext context;// = new ITIContext();
        //Implement Dependency Injection with constructor
        public CompanyRepository(ITIContext context)
        {
            this.context = context;
        }
        public IEnumerable<Company> GetAll()
        {
            return context.Companies;
        }
        public Company GetById(int id)
        {
            Company? comp = context.Companies.FirstOrDefault(dd => dd.Id == id);
            return comp;
        }
        public void Add(Company comp)
        {
            context.Companies.Add(comp);
            context.SaveChanges();
        }
        public void Edit(Company comp)
        {
            Company? old = context.Companies.FirstOrDefault(dd => dd.Id == comp.Id);
            old.Name = comp.Name;
            context.SaveChanges();
        }
        public void Delete(int id, string choice)
        {
            if (choice == "y")
            {
                Company? comp = context.Companies.Find(id);
                context.Companies.Remove(comp);
                context.SaveChanges();
            }
        }
    }
}
