using apiAngularCrud.Models;

namespace apiAngularCrud.Repositories.IRepositories
{
    public interface IPersonRepository
    {
        Task<ICollection<Person>> GetAllAsync();
        Task<Person> FindByNameAsync(string name);
        Task<Person> CreateAsync(Person person);
        Task<Person> UpdateAsync(Person person);
        Task<bool> DeleteAsync(int id);
    }
}
