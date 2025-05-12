namespace DDD.API.Commands
{
    public record CreatePersonCommand(Guid personId, string name);
}
