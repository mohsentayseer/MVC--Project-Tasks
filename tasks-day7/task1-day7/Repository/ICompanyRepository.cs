using task1_day7.Models;

namespace task1_day7.Repository
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetById(int id);
        void Add(Company comp);
        void Edit(Company comp);
        void Delete(int id, string choice);
    }
}
