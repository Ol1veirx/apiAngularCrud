using apiAngularCrud.Models;
using apiAngularCrud.Repositories.IRepositories;
using apiAngularCrud.Services.IServices;

namespace apiAngularCrud.Services
{
    public class PersonService : IPersonServices
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Person>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Person> FindByNameAsync(string name)
        {
            return await _repository.FindByNameAsync(name);
        }

        public async Task<Person> CreateAsync(Person person)
        {
            return await _repository.CreateAsync(person);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            return await _repository.UpdateAsync(person);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
