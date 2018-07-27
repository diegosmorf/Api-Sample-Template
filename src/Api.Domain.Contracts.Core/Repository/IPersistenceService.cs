using Api.Domain.Contracts.Core.Entities;
using System;
using System.Collections.Generic;

namespace Api.Cqrs.Template.Core.Contract.Repository
{
    public interface IPersistenceService<in TEntity> where TEntity : IDomainEntity
    {
        bool Insert(TEntity instance);

        void Insert(IEnumerable<TEntity> instances);

        void Delete(IEnumerable<Guid> ids);

        bool Delete(Guid id);

        bool Update(TEntity instance);

        void Update(IEnumerable<TEntity> instances);
    }
}