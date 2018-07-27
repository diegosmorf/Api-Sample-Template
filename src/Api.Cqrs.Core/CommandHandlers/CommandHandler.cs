using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.Events;
using Api.Domain.Contracts.Core.Entities;
using System.Linq;

namespace Api.Cqrs.Core.CommandHandlers
{
    public abstract class CommandHandler<TEntity>
            where TEntity : IDomainEntity
    {
        private readonly IMessageBus bus;
        public CommandHandler(IMessageBus bus)
        {
            this.bus = bus;
        }

        public TEntity PublishEvent(TEntity entity)
        {
            entity.AppliedEvents
                    .Select(@event => 
                        bus.PublishEvent((IEvent)@event));

            return entity;
        }
    }
}
