using DDD.API.Commands;
using DDD.API.Queries;
using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;

namespace DDD.API.ApplicationServices
{
    public class DDDServices
    {
        private readonly IPersonRepository _repository;
        private readonly PersonQueries _personQueries;

        public DDDServices(IPersonRepository repository, PersonQueries personQueries)
        {
            this._repository = repository;
            this._personQueries = personQueries;
        }

        public async Task HandleCommand(CreatePersonCommand command)
        {
            var person = new Person(PersonId.Create(command.personId));
            person.SetName(PersonName.Create(command.name));

            await _repository.AddAsync(person);
        }

        public async Task<Person> GetPerson(Guid id) => await _personQueries.GetPersonByIdAsync(id);
    }
}
