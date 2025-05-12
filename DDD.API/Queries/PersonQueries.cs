using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;

namespace DDD.API.Queries
{
    public class PersonQueries
    {
        private readonly IPersonRepository _repository;

        public PersonQueries(IPersonRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Person> GetPersonByIdAsync(Guid personId)
        {
            return await _repository.GetByIdAsync(PersonId.Create(personId));
        }
    }
}
