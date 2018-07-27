using MediatR;
using System;

namespace Api.Cqrs.Core.Bus
{
    public interface IMessage : IRequest
    {
        string MessageType { get; }
        DateTime Timestamp { get; }
    }
}