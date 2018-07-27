using System;

namespace Api.Cqrs.Core.Bus
{
    public interface IMessage 
    {
        Guid MessageId { get; }
        string MessageType { get; }
        DateTime Timestamp { get; }
    }
}