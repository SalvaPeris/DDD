using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;

namespace DDD.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext _context;

        public PersonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Person> GetByIdAsync(PersonId id)
        {
            return await _context.Persons.FindAsync((Guid)id);
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }
    }
}
