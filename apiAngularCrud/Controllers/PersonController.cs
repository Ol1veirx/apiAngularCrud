using System.Reflection.PortableExecutable;
using apiAngularCrud.Models;
using apiAngularCrud.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace apiAngularCrud.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : Controller
    {
        private readonly IPersonServices _service;

        public PersonController(IPersonServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Person>>> GetAllAsync()
        {
            var persons = await _service.GetAllAsync();

            return Ok(persons);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Person>> FindByNameAsync(string name)
        {
            var person = await _service.FindByNameAsync(name);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Person person)
        {
            var newPerson = await _service.CreateAsync(person);

            if (newPerson == null) return BadRequest();

            return Ok(newPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, Person person)
        {
            if(id != person.Id) return BadRequest();

            var personExiste = await _service.UpdateAsync(person);

            if(personExiste == null) return BadRequest();

            return Ok(personExiste);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removePerson = await _service.DeleteAsync(id);

            if(!removePerson) return BadRequest();

            return NoContent();
        }
    }
}
