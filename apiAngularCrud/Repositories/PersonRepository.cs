using apiAngularCrud.Data;
using apiAngularCrud.Models;
using apiAngularCrud.Repositories.IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace apiAngularCrud.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly APIContext _context;
        public PersonRepository(APIContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }


        public async Task<Person> FindByNameAsync(string name)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Name == name);

            if (person == null) return null;

            return person;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            var newPerson = await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            if (newPerson == null) return null;

            return person;
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var personExiste = await _context.Persons.FindAsync(person.Id);

            if (personExiste == null) return null;

            personExiste.Name = person.Name;
            personExiste.Surname = person.Surname;
            personExiste.Age = person.Age;
            personExiste.Profession = person.Profession;

            await _context.SaveChangesAsync();

            return personExiste;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null) return false;

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
