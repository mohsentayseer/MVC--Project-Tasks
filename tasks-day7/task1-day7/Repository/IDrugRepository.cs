using task1_day7.Models;

namespace task1_day7.Repository
{
    public interface IDrugRepository
    {
        IEnumerable<Drug> GetAllWithCompName();
        Drug GetById(int id);
        void Add(Drug drug);
        void Edit(Drug drug);
        void Delete(int id, string choice);
    }
}
