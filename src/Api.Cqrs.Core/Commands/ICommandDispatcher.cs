using System.Threading.Tasks;

namespace Api.Cqrs.Core.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand;
    }
}