using Api.Cqrs.Core.Bus;

namespace Api.Cqrs.Core.Commands
{
    public abstract class Command : Message, ICommand
    {
    }
}