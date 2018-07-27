using Api.Sample.Template.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Sample.Template.Domain.EventHandlers
{
    public class FundCreatedEventHandler : 
        INotificationHandler<FundCreatedEvent>
    {
        public Task Handle(FundCreatedEvent message, CancellationToken cancellationToken)
        {
            // TODO: Implement real event

            return Task.CompletedTask;
        }
    }
}
