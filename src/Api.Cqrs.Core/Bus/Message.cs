using System;

namespace Api.Cqrs.Core.Bus
{
    public abstract class Message : IMessage
    {
        public Guid MessageId { get; protected set; }
        public string SenderUserName { get; protected set; }
        public string MessageType { get; protected set; }       
        public DateTime MessageCreatedDate { get; protected set; }
        protected Message()
        {
            MessageId = Guid.NewGuid();
            MessageType = GetType().Name;
            MessageCreatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"MessageId:{MessageId} - MessageType:{MessageType} - TimeStamp:{MessageCreatedDate}";
        }
    }
}