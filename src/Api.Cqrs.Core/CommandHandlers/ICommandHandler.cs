using Api.Cqrs.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace Api.Cqrs.Core.CommandHandlers
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {   
        Task Handle(TCommand message);
    }
}