using System;

namespace Api.Cqrs.Core.Bus
{
    public interface IMessage 
    {
        Guid MessageId { get; }
        string SenderUserName { get; }
        string MessageType { get; }
        DateTime MessageCreatedDate { get; }
    }
}