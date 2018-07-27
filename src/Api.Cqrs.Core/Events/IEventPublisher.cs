using System.Threading.Tasks;

namespace Api.Cqrs.Core.Events
{
    public interface IEventPublisher
    {
        Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}