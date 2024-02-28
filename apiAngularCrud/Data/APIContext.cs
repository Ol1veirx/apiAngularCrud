using apiAngularCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace apiAngularCrud.Data
{
    public class APIContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
    }
}
