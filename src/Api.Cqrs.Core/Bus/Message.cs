using System;

namespace Api.Cqrs.Core.Bus
{
    public abstract class Message : IMessage
    {
        public Guid MessageId { get; protected set; }
        public string MessageType { get; protected set; }       
        public DateTime Timestamp { get; protected set; }
        protected Message()
        {
            MessageId = Guid.NewGuid();
            MessageType = GetType().Name;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"MessageId:{MessageId} - MessageType:{MessageType} - TimeStamp:{Timestamp}";
        }
    }
}