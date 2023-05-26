using UnitTestingExample.Models;

namespace UnitTestingExample.Repository.IRepository
{
    public interface IPersonRepository : IDisposable
    {
        Task FindByNameAsync(string name);
        Task FindByAgeAsync(int age);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Guid id);
        Task DeletePersonAsync(Guid id);
    }
}
