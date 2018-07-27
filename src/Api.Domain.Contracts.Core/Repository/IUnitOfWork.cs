using System;

namespace Api.Cqrs.Template.Core.Contract.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}