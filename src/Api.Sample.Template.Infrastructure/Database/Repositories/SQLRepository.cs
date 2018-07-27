using Api.Domain.Contracts.Core.Entities;
using Api.Cqrs.Template.Core.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Api.Sample.Template.Infrastructure.Database.Repositories
{
    public class SQLRepository<TEntity> : IRepository<TEntity> where TEntity : IDomainEntity
    {
        public IEnumerable<TEntity> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> instances)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TEntity> instances)
        {
            throw new NotImplementedException();
        }
    }
}
