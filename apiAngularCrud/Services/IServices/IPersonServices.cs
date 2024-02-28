using apiAngularCrud.Models;

namespace apiAngularCrud.Services.IServices
{
    public interface IPersonServices
    {
        Task<ICollection<Person>> GetAllAsync();
        Task<Person> FindByNameAsync(string name);
        Task<Person> CreateAsync(Person person);
        Task<Person> UpdateAsync(Person person);
        Task<bool> DeleteAsync(int id);
    }
}
