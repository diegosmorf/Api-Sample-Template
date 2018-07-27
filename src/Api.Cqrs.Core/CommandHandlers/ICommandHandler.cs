using Api.Cqrs.Core.Commands;
using Api.Domain.Contracts.Core.Entities;
using System.Threading.Tasks;

namespace Api.Cqrs.Core.CommandHandlers
{
    public interface ICommandHandler<in TCommand, TDomainEntity> 
        where TCommand : ICommand  
        where TDomainEntity: IDomainEntity
    {   
        Task<TDomainEntity> Handle(TCommand command);
    }
}