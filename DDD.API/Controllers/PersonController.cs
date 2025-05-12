using DDD.API.ApplicationServices;
using DDD.API.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DDDServices _services;

        public PersonController(DDDServices services)
        {
            this._services = services;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(CreatePersonCommand createPersonCommand)
        {
            await _services.HandleCommand(createPersonCommand);
            return Ok(createPersonCommand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            var person = await _services.GetPerson(id);
            if (person == null)
                return NotFound();
            
            return Ok(person);
        }
    }
}
