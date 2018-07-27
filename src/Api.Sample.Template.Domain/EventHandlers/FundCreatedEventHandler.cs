using Api.Cqrs.Core.Events;
using Api.Sample.Template.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Sample.Template.Domain.EventHandlers
{
    public class FundCreatedEventHandler : IEventHandler<FundCreatedEvent>
    {
        public Task Handle(FundCreatedEvent @event)
        {
            // TODO: Implement real event

            return Task.CompletedTask;
        }
    }
}
