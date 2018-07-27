using System;

namespace Api.Cqrs.Core.Bus
{
    public abstract class Message : IMessage
    {
        public string MessageType { get; protected set; }
       
        public DateTime Timestamp { get; protected set; }
        protected Message()
        {
            MessageType = GetType().Name;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"MessageType:{MessageType} TimeStamp:{Timestamp}";
        }
    }
}