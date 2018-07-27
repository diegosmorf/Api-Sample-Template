using Api.Domain.Contracts.Core.Entities;
using System.Threading.Tasks;

namespace Api.Cqrs.Core.Commands
{
    public interface ICommandDispatcher
    {
        Task<TEntity> DispatchCommand<TCommand, TEntity>(TCommand command) 
            where TCommand : ICommand
            where TEntity: IDomainEntity;
    }
}