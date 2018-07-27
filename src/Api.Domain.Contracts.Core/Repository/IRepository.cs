using Api.Domain.Contracts.Core.Entities;
using System;

namespace Api.Cqrs.Template.Core.Contract.Repository
{
    public interface IRepository<TEntity> :
        IPersistenceService<TEntity>,
        IQueryService<TEntity>, IDisposable where TEntity : IDomainEntity
    {
    }
}