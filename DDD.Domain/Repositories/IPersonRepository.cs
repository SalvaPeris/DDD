using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;

namespace DDD.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(PersonId id);
        Task AddAsync(Person person);
    }
}
