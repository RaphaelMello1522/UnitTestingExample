using UnitTestingExample.Data;
using UnitTestingExample.Models;
using UnitTestingExample.Repository.IRepository;

namespace UnitTestingExample.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationDbContext context;

        public PersonRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task AddPersonAsync(Person person)
        {
            context.Add(person);
            await context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(Guid id)
        {
            context.Persons.Find(id);
            context.Remove(id);
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task FindByAgeAsync(int age)
        {
            context.Persons.ToList().Where(x => x.Age.Equals(age));
            await context.DisposeAsync();
        }

        public async Task FindByNameAsync(string name)
        {
            await context.Persons.FindAsync(name);
        }

        public Task UpdatePersonAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
